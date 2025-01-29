using System;
using System.Collections.Generic;

namespace Labb2SchoolDB.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public string? ClassName { get; set; }

    public int? MentorId { get; set; }

    public virtual ICollection<ClassSubjectTeacher> ClassSubjectTeachers { get; set; } = new List<ClassSubjectTeacher>();

    public virtual Staff? Mentor { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
