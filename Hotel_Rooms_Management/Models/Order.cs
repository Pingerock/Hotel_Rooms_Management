namespace Hotel_Rooms_Management.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            ServiceString = new HashSet<ServiceString>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Order_Id { get; set; }

        public int Room_Id { get; set; }

        public int Customer_Id { get; set; }

        public int Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_start { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_finish { get; set; }

        public int Days { get; set; }

        [Required]
        [StringLength(100)]
        public string Services { get; set; }

        public int? Discount_Id { get; set; }

        public bool Active { get; set; }

        public bool Waiting { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Discount Discount { get; set; }

        public virtual Room Room { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceString> ServiceString { get; set; }
    }
}
