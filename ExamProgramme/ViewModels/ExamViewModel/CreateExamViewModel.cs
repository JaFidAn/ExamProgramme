using ExamProgramme.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamProgramme.ViewModels.ExamViewModel
{
	public class CreateExamViewModel
	{
		public int SelectedLesson { get; set; }
		public List<SelectListItem> LessonsSelectList { get; set; }

		public int SelectedPupil { get; set; }
		public List<SelectListItem> PupilsSelectList { get; set; }

		public DateTime Date { get; set; } = DateTime.Now;
		public int Grade { get; set; } = 5;
	}
}
