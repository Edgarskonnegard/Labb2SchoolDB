using System;
using System.Collections.Generic;

namespace Labb2SchoolDB.Models;

public partial class ClassSubjectTeacher
{
    public int ClassId { get; set; }

    public int SubjectId { get; set; }

    public int? TeacherId { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;

    public virtual Staff? Teacher { get; set; }
}
