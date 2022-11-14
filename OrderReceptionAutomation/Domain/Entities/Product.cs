namespace OrderReceptionAutomation.Domain.Entities
{
    /// <summary>
    /// Товар.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Количество на складе.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Цена единицы.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// В каких Заказах присустсвует.
        /// </summary>
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
