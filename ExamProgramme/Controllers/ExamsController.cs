using ExamProgramme.Models;
using ExamProgramme.Models.Repositories.ExamRepository;
using ExamProgramme.Models.Repositories.LessonRepository;
using ExamProgramme.Models.Repositories.PupilRepository;
using ExamProgramme.ViewModels.ExamViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamProgramme.Controllers
{
	public class ExamsController : Controller
	{
		private readonly IExamRepository _examRepository;
		private readonly IPupilRepository _pupilRepository;
		private readonly ILessonRepository _lessonRepository;

		public ExamsController(IExamRepository examRepository, IPupilRepository pupilRepository, ILessonRepository lessonRepository)
		{
			_examRepository = examRepository;
			_pupilRepository = pupilRepository;
			_lessonRepository = lessonRepository;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var exams = _examRepository.GetAll()
				.Include(l => l.Lesson)
				.Include(p => p.Pupil)
				.Select(e => new Exam
				{
					Id = e.Id,
					Pupil = e.Pupil,
					Lesson = e.Lesson,
					Date = e.Date,
					Grade = e.Grade,
				});
			return View(exams);
		}

		[HttpGet]
		public IActionResult Create()
		{
			var lessonsData = _lessonRepository.GetAll();
			var model = new CreateExamViewModel();
			model.LessonsSelectList = new List<SelectListItem>();
			foreach (var lesson in lessonsData)
			{
				model.LessonsSelectList.Add(new SelectListItem { Text = lesson.LessonName, Value = Convert.ToString(lesson.Id) });
			}

			var pupilsData = _pupilRepository.GetAll();
			model.PupilsSelectList = new List<SelectListItem>();
			foreach (var pupil in pupilsData)
			{
				model.PupilsSelectList.Add(new SelectListItem { Text = (pupil.Name + " " + pupil.Surname), Value = Convert.ToString(pupil.Id) });
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateExamViewModel createExamViewModel)
		{
			var exam = new Exam()
			{
				LessonId = createExamViewModel.SelectedLesson,
				PupilId = createExamViewModel.SelectedPupil,
				Date = createExamViewModel.Date,
				Grade = createExamViewModel.Grade
			};
			await _examRepository.AddAsync(exam);
			await _examRepository.SaveAsync();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
			var exam = await _examRepository.GetByIdAsync(id);
			if (exam != null)
			{
				var viewModel = new UpdateExamViewModel
				{
					Id = exam.Id,
					SelectedLesson = exam.LessonId,
					SelectedPupil = exam.PupilId,
					Date = exam.Date,
					Grade = exam.Grade
				};
				var lessonsData = _lessonRepository.GetAll();
				viewModel.LessonsSelectList = new List<SelectListItem>();
				foreach (var lesson in lessonsData)
				{
					viewModel.LessonsSelectList.Add(new SelectListItem { Text = lesson.LessonName, Value = Convert.ToString(lesson.Id) });
				}
				var pupilsData = _pupilRepository.GetAll();
				viewModel.PupilsSelectList = new List<SelectListItem>();
				foreach (var pupil in pupilsData)
				{
					viewModel.PupilsSelectList.Add(new SelectListItem { Text = (pupil.Name + " " + pupil.Surname), Value = Convert.ToString(pupil.Id) });
				}

				return View(viewModel);
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateExamViewModel updateExamViewModel)
		{
			var exam = await _examRepository.GetByIdAsync(updateExamViewModel.Id);
			if (exam != null)
			{
				exam.LessonId = updateExamViewModel.SelectedLesson;
				exam.PupilId = updateExamViewModel.SelectedPupil;
				exam.Date = updateExamViewModel.Date;
				exam.Grade = updateExamViewModel.Grade;

				await _examRepository.SaveAsync();
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			await _examRepository.RemoveAsync(id);
			await _examRepository.SaveAsync();
			return RedirectToAction("Index");
		}
	}
}
