﻿using System;
using System.Collections.Generic;

namespace Labb2SchoolDB.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public string? Grade1 { get; set; }

    public DateOnly? Date { get; set; }

    public int? StudentId { get; set; }

    public int? SubjectId { get; set; }

    public int? TeacherId { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Subject? Subject { get; set; }

    public virtual Staff? Teacher { get; set; }
}
