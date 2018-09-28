namespace TeacherStudent.ModelClasses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        public int StudentId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Class { get; set; }

        public string Section { get; set; }

        public string Address { get; set; }

        public int? TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
