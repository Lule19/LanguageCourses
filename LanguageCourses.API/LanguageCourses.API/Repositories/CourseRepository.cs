﻿using LanguageCourses.API.Data;
using LanguageCourses.API.DTOs;
using LanguageCourses.API.Enums;
using LanguageCourses.API.Models;
using LanguageCourses.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanguageCourses.API.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly LanguageCoursesDbContext _languageCoursesDbContext;

    public CourseRepository(LanguageCoursesDbContext languageCoursesDbContext)
    {
        _languageCoursesDbContext = languageCoursesDbContext;
    }

    public async Task<IEnumerable<CourseFirstDto>> GetFirstCoursesAsync()
    {
        var courses = await _languageCoursesDbContext.Courses
                .Where(c => c.Available)
                .OrderBy(c => Guid.NewGuid())
                .Take(4)
                .Join(_languageCoursesDbContext.Users,
                course => course.ProfessorId,
                user => user.Id,
                (course, user) => new
                {
                    Course = course,
                    Professor = user
                })
                .Select(result => new CourseFirstDto
                {
                    Id = result.Course.Id,
                    Name = result.Course.Name,
                    Language = result.Course.Language,
                    Level = result.Course.Level,
                    FirstName = result.Professor.FirstName,
                    LastName = result.Professor.LastName,
                    Picture = result.Course.Picture
                }).ToListAsync();

        return courses;
    }

    public async Task<CourseDto> GetCourseByIdAsync(Guid id)
    {
        var courseDto = await _languageCoursesDbContext.Courses
                .Where(course => course.Id == id)
                .Join(
                    _languageCoursesDbContext.Users,
                    course => course.ProfessorId,
                    user => user.Id,
                    (course, professor) => new CourseDto
                    {
                        Id = course.Id,
                        ProfessorFirstName = professor.FirstName,
                        ProfessorLastName = professor.LastName,
                        ProfessorPhone = professor.Phone,
                        ProfessorEmail = professor.Email,
                        ProfessorPicture = professor.Picture,
                        Name = course.Name,
                        Description = course.Description,
                        Language = course.Language,
                        Level = course.Level,
                        Type = course.Type,
                        Price = course.Price,
                        Duration = course.Duration,
                        Picture = course.Picture
                    })
                .FirstOrDefaultAsync();

        return courseDto;
    }

    public async Task DeleteCourseAsync(Guid userId, Guid courseId)
    {
        var course = await _languageCoursesDbContext.Courses.FirstOrDefaultAsync(x => x.Id == courseId);

        if (course == null)
        {
            throw new Exception("The course with this id does not exist, so it can't be deleted!");
        }

        var user = await _languageCoursesDbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

        if (user.Role != Role.ADMIN)
        {
            if (course.ProfessorId != userId)
            {
                throw new Exception("You don't have a permission to delete this course!");
            }
        }

        _languageCoursesDbContext.Courses.Remove(course);
        await _languageCoursesDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<CourseDto2>> GetAvailableCoursesAsync(
        int pageNumber, 
        int pageSize, 
        string? language = null, 
        string? level = null, 
        decimal? priceFrom = null, 
        decimal? priceTo = null)
    {
        var courses = _languageCoursesDbContext.Courses
                .Where(c => c.Available)
                .AsQueryable();

        if (string.IsNullOrWhiteSpace(language) == false)
        {
            courses = courses.Where(x => x.Language.Contains(language));
        }

        if (string.IsNullOrWhiteSpace(level) == false)
        {
            courses = courses.Where(x => x.Level.Contains(level));
        }

        if (priceFrom > 0)
        {
            courses = courses.Where(x => x.Price >= priceFrom);
        }

        if (priceTo > 0)
        {
            courses = courses.Where(x => x.Price <= priceTo);
        }

        var skipResults = (pageNumber - 1) * pageSize;

        var result = await courses.Skip(skipResults).Take(pageSize).ToListAsync();

        var finalResult = result
                .Join(_languageCoursesDbContext.Users,
                course => course.ProfessorId,
                user => user.Id,
                (course, user) => new
                {
                    Course = course,
                    Professor = user
                })
                .Select(result => new CourseDto2
                {
                    Id = result.Course.Id,
                    Name = result.Course.Name,
                    Language = result.Course.Language,
                    Level = result.Course.Level,
                    Price = result.Course.Price,
                    Type = result.Course.Type,
                    FirstName = result.Professor.FirstName,
                    LastName = result.Professor.LastName,
                    Picture = result.Course.Picture
                });

        return finalResult;
    }

    public async Task EnrollToCourseAsync(Guid userId, Guid courseId)
    {
        CourseUser enrolment = new();
        
        enrolment.CourseId = courseId;
        enrolment.UserId = userId;
        enrolment.EnrollmentDate = DateTime.Now;

        await _languageCoursesDbContext.Enrollments.AddAsync(enrolment);
        await _languageCoursesDbContext.SaveChangesAsync();
    }

    public async Task AddCourseAsync(Course course)
    {
        await _languageCoursesDbContext.Courses.AddAsync(course);
        await _languageCoursesDbContext.SaveChangesAsync();
    }
}