namespace Practice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DvoechinikiVRazrezeGrupIDisciplin")]
    public partial class DvoechinikiVRazrezeGrupIDisciplin
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string GroupName { get; set; }

        [StringLength(40)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string FIO { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime Date { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte ValueGrade { get; set; }
    }
}
