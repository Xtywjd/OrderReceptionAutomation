namespace OrderReceptionAutomation.Domain.DTOs
{
	/// <summary>
	/// Объект для передачи данных о Заказе между модулями системы.
	/// </summary>
	public class OrderDTO
	{
		/// <summary>
		/// Полное имя заказчика.
		/// </summary>
		public string FullName { get; set; } = string.Empty;

		/// <summary>
		/// Номер телефона заказчика.
		/// </summary>
		public string PhoneNumber { get; set; } = string.Empty;

		/// <summary>
		/// Электронная почта заказчика.
		/// </summary>
		public string Email { get; set; } = string.Empty;

		/// <summary>
		/// Список Товаров в Заказе.
		/// </summary>
		public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
	}
}
