using Microsoft.AspNetCore.Mvc;
using OrderReceptionAutomation.Application.Services;
using OrderReceptionAutomation.Domain.DTOs;
using OrderReceptionAutomation.Domain.Entities;

namespace OrderReceptionAutomation.Application.Controllers
{
	/// <summary>
	/// Обрабатывает входные данные, полученные из WebAPI, в объект "Заказ".
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class WebApiOrderController : ControllerBase
	{
		/// <summary>
		/// Сервис создания нового заказа.
		/// </summary>
		private ISourceToOrderService _sourceToOrderService;

		public WebApiOrderController(ISourceToOrderService sourceToOrderService)
		{
			_sourceToOrderService = sourceToOrderService;
		}

		/// <summary>
		/// Создать Заказ.
		/// </summary>
		/// <param name="orderData"></param>
		/// <returns></returns>
		// POST api/<WebApiOrderController>
		[HttpPost]
		public async Task<string> CreateOrder([FromBody] OrderDTO orderData)
		{
			return await _sourceToOrderService.CreateOrder(orderData) is Order
				? "Заказ успешно оформлен" 
				: "Возникла ошибка в процессе оформления заказа";
		}
	}
}
