using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomerOrdersAPI.Model
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        [ForeignKey("Customer")]
        public Guid CustomerID { get; set; }

        [Required]
        [StringLength(100)]
        public string ItemName { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal ItemPrice { get; set; }

        public Customer Customer { get; set; }
    }
}
