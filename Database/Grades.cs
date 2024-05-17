namespace Practice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Grades
    {
        public int StudentID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public byte ValueGrade { get; set; }

        public int id { get; set; }

        public int? RupID { get; set; }

        public virtual RUP RUP { get; set; }

        public virtual Students Students { get; set; }
    }
}
