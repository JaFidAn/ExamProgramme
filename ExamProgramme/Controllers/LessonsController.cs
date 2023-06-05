using ExamProgramme.Models;
using ExamProgramme.Models.Repositories.LessonRepository;
using ExamProgramme.ViewModels.LessonViewModel;
using ExamProgramme.ViewModels.PupilViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ExamProgramme.Controllers
{
	public class LessonsController : Controller
	{
		private readonly ILessonRepository _lessonRepository;

		public LessonsController(ILessonRepository lessonRepository)
		{
			_lessonRepository = lessonRepository;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var lessons = _lessonRepository.GetAll();
			return View(lessons);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateLessonViewModel createLessonViewModel)
		{
			if (ModelState.IsValid)
			{
				var lesson = new Lesson()
				{
					LessonName = createLessonViewModel.LessonName,
					Class = createLessonViewModel.Class,
					TeacherName = createLessonViewModel.TeacherName,
					TeacherSurname = createLessonViewModel.TeacherSurname
				};
				await _lessonRepository.AddAsync(lesson);
				await _lessonRepository.SaveAsync();
				return RedirectToAction("Index");
			}
			return View();

		}

		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
			var lesson = await _lessonRepository.GetByIdAsync(id);
			if (lesson != null)
			{
				var viewModel = new UpdateLessonViewModel
				{
					Id = lesson.Id,
					LessonName = lesson.LessonName,
					Class = lesson.Class,
					TeacherName = lesson.TeacherName,
					TeacherSurname = lesson.TeacherSurname
				};
				return View(viewModel);
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateLessonViewModel updateLessonViewModel)
		{
			if (ModelState.IsValid)
			{
				var lesson = await _lessonRepository.GetByIdAsync(updateLessonViewModel.Id);
				if (lesson != null)
				{
					lesson.LessonName = updateLessonViewModel.LessonName;
					lesson.Class = updateLessonViewModel.Class;
					lesson.TeacherName = updateLessonViewModel.TeacherName;
					lesson.TeacherSurname = updateLessonViewModel.TeacherSurname;

					await _lessonRepository.SaveAsync();
					return RedirectToAction("Index");
				}
				return RedirectToAction("Index");
			}
			return View(updateLessonViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			await _lessonRepository.RemoveAsync(id);
			await _lessonRepository.SaveAsync();
			return RedirectToAction("Index");
		}
	}
}
