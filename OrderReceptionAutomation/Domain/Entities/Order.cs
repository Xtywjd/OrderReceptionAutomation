namespace OrderReceptionAutomation.Domain.Entities
{
    /// <summary>
    /// Заказ.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Общая сумма.
        /// </summary>
        public double TotelPrice { get; set; }

        /// <summary>
        /// Дата создания в системе.
        /// </summary>
        public DateTime CreatedDate { get; set; }

		/// <summary>
		/// Кода статуса состояния. 
		/// Использует значения из OrderStatusCodeEnum.
		/// </summary>
		public int StatusCode { get; set; }

		/// <summary>
		/// Код источника.
		/// Использует значения из OrderInformationSourceEnum.
		/// </summary>
		public int OrderInformationSource { get; set; }

        /// <summary>
        /// Список Товаров.
        /// </summary>
        public List<Product> Products { get; set; } = new List<Product>();

        /// <summary>
        /// Заказчик.
        /// </summary>
        public Customer Customer { get; set; }
    }
}
