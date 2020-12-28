namespace Hotel_Rooms_Management.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceString")]
    public partial class ServiceString
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ServiceString_Id { get; set; }

        public int Price { get; set; }

        public int Service_FK { get; set; }

        public int Order_FK { get; set; }

        public virtual Order Order { get; set; }

        public virtual Service Service { get; set; }
    }
}
