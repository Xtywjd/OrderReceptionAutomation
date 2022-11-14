using OrderReceptionAutomation.Domain.DTOs;
using OrderReceptionAutomation.Domain.Entities;

namespace OrderReceptionAutomation.Application.Services
{
	/// <summary>
	/// Преобразование полученных данных в объект "Заказ".
	/// </summary>
	public interface ISourceToOrderService
	{
		/// <summary>
		/// Создать новый Заказ.
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		Task<Order> CreateOrder(OrderDTO order);
	}
}
