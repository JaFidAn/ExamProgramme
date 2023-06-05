using ExamProgramme.ViewModels.LessonViewModel;
using FluentValidation;

namespace ExamProgramme.Validation.LessonValidator
{
	public class UpdateLessonValidator : AbstractValidator<UpdateLessonViewModel>
	{
		public UpdateLessonValidator()
		{
			RuleFor(p => p.LessonName)
				.NotNull()
				.WithMessage("Please enter a Lesson Name")
				.NotEmpty().WithMessage("Lesson Name can not be empty")
				.MinimumLength(3).WithMessage("Lesson Name minimum length can not be less than 3 character")
				.MaximumLength(30).WithMessage("Lesson Name maximum length can not be more than 30 character");

			RuleFor(p => p.Class)
				.NotNull()
				.WithMessage("Please enter a value")
				.InclusiveBetween(1, 11)
				.WithMessage("Value must be between 1 and 11");

			RuleFor(p => p.TeacherName)
				.NotNull()
				.WithMessage("Please enter a Teacher Name")
				.NotEmpty().WithMessage("Teacher Name can not be empty")
				.MinimumLength(3).WithMessage("Teacher Name minimum length can not be less than 3 character")
				.MaximumLength(20).WithMessage("Teacher Name maximum length can not be more than 20 character");

			RuleFor(p => p.TeacherSurname)
				.NotNull()
				.WithMessage("Please enter a Teacher Surname")
				.NotEmpty().WithMessage("Teacher Surname can not be empty")
				.MinimumLength(3).WithMessage("Teacher Surname minimum length can not be less than 3 character")
				.MaximumLength(20).WithMessage("Teacher Surname maximum length can not be more than 20 character");
		}
	}
}
