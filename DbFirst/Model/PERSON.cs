namespace DbFirst.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COOLIEDNIKKEMATEDB.PERSON")]
    public partial class PERSON
    {
        [StringLength(50)]
        public string ID { get; set; }

        [StringLength(100)]
        public string FULLNAME { get; set; }

        public DateTime? DOB { get; set; }

        [Column(TypeName = "float")]
        public decimal? SALARY { get; set; }

        [StringLength(100)]
        public string DEPARTMENT { get; set; }

        [StringLength(100)]
        public string NOTE { get; set; }
    }
}
