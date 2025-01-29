using System;
using System.Collections.Generic;

namespace Labb2SchoolDB.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Ssn { get; set; }

    public string? Position { get; set; }

    public virtual ICollection<ClassSubjectTeacher> ClassSubjectTeachers { get; set; } = new List<ClassSubjectTeacher>();

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; } = new List<SubjectTeacher>();
}
