using Microsoft.EntityFrameworkCore;
namespace OrderReceptionAutomation.Domain.Entities
{
	/// <summary>
	/// Заказчик.
	/// </summary>
	[Index("PhoneNumber", "Email", IsUnique = true)]
	public class Customer
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Полное имя.
		/// </summary>
		public string FullName { get; set; } = string.Empty;

		/// <summary>
		/// Номер телефона.
		/// </summary>
		public string PhoneNumber { get; set; } = string.Empty;

		/// <summary>
		/// Электронная почта.
		/// </summary>
		public string Email { get; set; } = string.Empty;

		/// <summary>
		/// Дата создания в системею
		/// </summary>
		public DateTime CreatedDate { get; set; }

		/// <summary>
		/// Список Заказов.
		/// </summary>
		public List<Order> Orders { get; set; } = new List<Order>();
	}
}
