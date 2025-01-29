using System;
using System.Collections.Generic;

namespace Labb2SchoolDB.Models;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string? SubjectName { get; set; }

    public virtual ICollection<ClassSubjectTeacher> ClassSubjectTeachers { get; set; } = new List<ClassSubjectTeacher>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; } = new List<SubjectTeacher>();
}
