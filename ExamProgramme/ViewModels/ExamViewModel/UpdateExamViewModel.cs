using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamProgramme.ViewModels.ExamViewModel
{
	public class UpdateExamViewModel
	{
		public int Id { get; set; }
		public int SelectedLesson { get; set; }
		public List<SelectListItem> LessonsSelectList { get; set; }

		public int SelectedPupil { get; set; }
		public List<SelectListItem> PupilsSelectList { get; set; }

		public DateTime Date { get; set; }
		public int Grade { get; set; }
	}
}
