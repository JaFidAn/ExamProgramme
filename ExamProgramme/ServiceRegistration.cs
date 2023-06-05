using ExamProgramme.Models;
using ExamProgramme.Models.Repositories.ExamRepository;
using ExamProgramme.Models.Repositories.LessonRepository;
using ExamProgramme.Models.Repositories.PupilRepository;
using ExamProgramme.Validation.PupilValidator;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExamProgramme
{
    public static class ServiceRegistration
    {
        public static void AddNewServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(Configuration.ConnectionString));

            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<IPupilRepository, PupilRepository>();
            services.AddScoped<IExamRepository, ExamRepository>();


            services.AddFluentValidation(x =>
			 {
				 x.DisableDataAnnotationsValidation = true;
				 x.RegisterValidatorsFromAssemblyContaining<CreatePupilValidator>();
			 });
		}
    }
}
