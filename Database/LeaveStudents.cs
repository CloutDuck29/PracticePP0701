namespace Practice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LeaveStudents
    {
        public int ID { get; set; }

        public int? StudentID { get; set; }

        [StringLength(255)]
        public string FIO { get; set; }

        public int? GroupID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfExpulsion { get; set; }
    }
}
