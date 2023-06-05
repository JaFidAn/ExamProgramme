using ExamProgramme.ViewModels.PupilViewModel;
using FluentValidation;

namespace ExamProgramme.Validation.PupilValidator
{
	public class UpdatePupilValidator : AbstractValidator<UpdatePupilViewModel>
	{
		public UpdatePupilValidator()
		{
			RuleFor(p => p.Name)
				.NotNull()
				.WithMessage("Please enter a Name")
				.NotEmpty().WithMessage("Pupil name can not be empty")
				.MinimumLength(3).WithMessage("Name minimum length can not be less than 3 character")
				.MaximumLength(30).WithMessage("Name maximum length can not be more than 30 character");
			RuleFor(p => p.Surname)
				.NotNull()
				.WithMessage("Please enter a Surname")
				.NotEmpty().WithMessage("Pupil surname can not be empty")
				.MinimumLength(3).WithMessage("Surname minimum length can not be less than 3 character")
				.MaximumLength(30).WithMessage("Surname maximum length can not be more than 30 character");
			RuleFor(p => p.Class)
				.NotNull()
				.WithMessage("Please enter a value")
				.InclusiveBetween(1, 11)
				.WithMessage("Value must be between 1 and 11");
		}
	}
}
