namespace OrderReceptionAutomation.Domain.DTOs
{
	/// <summary>
	/// Объект для передачи данных о Товаре между модулями системы.
	/// </summary>
	public class ProductDTO
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Количество единиц Товара в Заказе.
		/// </summary>
		public int Count { get; set; }
	}
}
