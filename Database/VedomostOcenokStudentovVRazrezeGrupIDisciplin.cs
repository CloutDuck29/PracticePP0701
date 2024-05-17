namespace Practice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VedomostOcenokStudentovVRazrezeGrupIDisciplin")]
    public partial class VedomostOcenokStudentovVRazrezeGrupIDisciplin
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string GroupName { get; set; }

        [StringLength(40)]
        public string DisciplineName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string StudentName { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime GradeDate { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte GradeValue { get; set; }
    }
}
