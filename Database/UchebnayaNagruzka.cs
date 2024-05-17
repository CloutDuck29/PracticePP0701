namespace Practice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UchebnayaNagruzka")]
    public partial class UchebnayaNagruzka
    {
        [Key]
        [Column("ФИО преподавателя")]
        [StringLength(50)]
        public string ФИО_преподавателя { get; set; }

        [Column("Имя дисцплины")]
        [StringLength(40)]
        public string Имя_дисцплины { get; set; }

        [Column("Имя специальности")]
        [StringLength(42)]
        public string Имя_специальности { get; set; }
    }
}
