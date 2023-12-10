﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace LanguageCourses.API.Models;

public class Enrollment
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid CourseId { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public bool IsCompleted { get; set; } = false;

    public User User { get; set; } = null!;

    public Course Course { get; set; } = null!;
}