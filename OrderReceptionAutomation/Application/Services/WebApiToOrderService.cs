using Microsoft.EntityFrameworkCore;
using OrderReceptionAutomation.Application.Services.Enums;
using OrderReceptionAutomation.Domain.DTOs;
using OrderReceptionAutomation.Domain.Entities;
using OrderReceptionAutomation.Infrastructure.Data;

namespace OrderReceptionAutomation.Application.Services
{
	/// <summary>
	/// Преобразование данных, полученных из WebAPI, в объект "Заказ".
	/// </summary>
	public class WebApiToOrderService : ISourceToOrderService
	{
		/// <summary>
		/// Контекст базы данных.
		/// </summary>
		private readonly DatabaseContext _dbContext;

		/// <summary>
		/// Конструктор сервиса.
		/// </summary>
		/// <param name="dbContext"></param>
		public WebApiToOrderService(DatabaseContext dbContext)
		{
			_dbContext = dbContext;
		}

		/// <summary>
		/// Создать новый Заказ.
		/// </summary>
		/// <param name="orderData"></param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public async Task<Order> CreateOrder(OrderDTO orderData)
		{
			CheckNull(orderData);

			var customer = new Customer();

			if (!await _dbContext.Customers.AnyAsync(
				c => c.Email == orderData.Email
				|| c.PhoneNumber == orderData.PhoneNumber))
			{
				customer = await CreateCustomer(orderData);
			}

			CheckNull(orderData.Products);

			var checkedProducts = new List<Product>();

			foreach (var productData in orderData.Products)
			{
				if (!await _dbContext.Products.AnyAsync(p => p.Id == productData.Id))
				{
					throw new Exception("Товар с данным идентификатором отсутствует в каталоге.");
				}

				var product = await _dbContext.Products.FindAsync(productData.Id);

				if (product?.Count < productData.Count)
				{
					throw new Exception("Товар с данным идентификатором имеет недостаточное количество на складе" +
						"для оформления Заказа.");
				}

				product.Count = productData.Count;
				checkedProducts.Add(product);
			}

			var order = new Order
			{
				Id = Guid.NewGuid(),
				TotelPrice = GetOrderTotalPrice(checkedProducts),
				CreatedDate = DateTime.Now,
				StatusCode = (int)OrderStatusCodeEnum.Created,
				OrderInformationSource = (int)OrderInformationSourceEnum.WebAPI,
				Customer = customer,
				Products = checkedProducts
			};

			_dbContext.Orders.Add(order);
			await _dbContext.SaveChangesAsync();

			return order;
		}

		/// <summary>
		/// Создать нового Заказчика.
		/// </summary>
		/// <param name="orderData"></param>
		/// <returns></returns>
		private async Task<Customer> CreateCustomer(OrderDTO orderData)
		{
			var customer = new Customer
			{
				Id = new Guid(),
				FullName = orderData.FullName,
				PhoneNumber = orderData.PhoneNumber,
				Email = orderData.Email,
				Orders = new List<Order>(),
				CreatedDate = DateTime.Now
			};

			_dbContext.Customers.Add(customer);
			await _dbContext.SaveChangesAsync();

			return customer;
		}

		/// <summary>
		/// Получить итоговую сумму Заказа.
		/// </summary>
		/// <param name="products"></param>
		/// <returns></returns>
		private static double GetOrderTotalPrice(List<Product> products)
		{
			var totalPrice = 0.0;

			foreach (var product in products)
			{
				totalPrice += product.Count * product.Price;
			}

			return totalPrice;
		}

		/// <summary>
		/// Проверка, пустая ли ссылка на объект.
		/// </summary>
		/// <param name="obj"></param>
		/// <exception cref="ArgumentNullException"></exception>
		private static void CheckNull(object obj)
		{
			if (obj is null)
			{
				throw new ArgumentNullException(nameof(obj), "Ссылка на объект пуста");
			}
		}
	}
}
