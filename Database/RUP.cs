namespace Practice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RUP")]
    public partial class RUP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RUP()
        {
            Grades = new HashSet<Grades>();
        }

        public int DisciplineID { get; set; }

        public int Semestr { get; set; }

        [Required]
        [StringLength(50)]
        public string TypeOfAttestation { get; set; }

        public int TeacherID { get; set; }

        public int id { get; set; }

        public virtual Disciplines Disciplines { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grades> Grades { get; set; }

        public virtual Teachers Teachers { get; set; }
    }
}
