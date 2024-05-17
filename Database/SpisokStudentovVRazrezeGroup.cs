namespace Practice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SpisokStudentovVRazrezeGroup")]
    public partial class SpisokStudentovVRazrezeGroup
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string StudentName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string GroupName { get; set; }

        [StringLength(42)]
        public string SpecialityName { get; set; }
    }
}
