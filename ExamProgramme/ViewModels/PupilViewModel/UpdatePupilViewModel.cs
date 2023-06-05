using ExamProgramme.Models;

namespace ExamProgramme.ViewModels.PupilViewModel
{
	public class UpdatePupilViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public int Class { get; set; }
	}
}
