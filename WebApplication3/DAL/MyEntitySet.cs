namespace WebApplication3.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MyEntitySet")]
    public partial class MyEntitySet
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
