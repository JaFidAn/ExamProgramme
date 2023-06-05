using ExamProgramme.Models;
using ExamProgramme.Models.Repositories.PupilRepository;
using ExamProgramme.ViewModels.PupilViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ExamProgramme.Controllers
{
    public class PupilsController : Controller
	{
		private readonly IPupilRepository _pupilRepository;

		public PupilsController(IPupilRepository pupilRepository)
		{
			_pupilRepository = pupilRepository;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var pupilList = _pupilRepository.GetAll();
			return View(pupilList);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreatePupilViewModel createPupilViewModel)
		{
			if (ModelState.IsValid)
			{
				var pupil = new Pupil()
				{
					Name = createPupilViewModel.Name,
					Surname = createPupilViewModel.Surname,
					Class = createPupilViewModel.Class
				};
				await _pupilRepository.AddAsync(pupil);
				await _pupilRepository.SaveAsync();
				return RedirectToAction("Index");
			}
			return View();
			
		}

		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
			var pupil = await _pupilRepository.GetByIdAsync(id);
			if(pupil != null)
			{
				var viewModel = new UpdatePupilViewModel
				{
					Id = pupil.Id,
					Name = pupil.Name,
					Surname = pupil.Surname,
					Class = pupil.Class
				};
				return View(viewModel);
			}
			return RedirectToAction("Index");	
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdatePupilViewModel updatePupilViewModel)
		{
			if (ModelState.IsValid)
			{
				var pupil = await _pupilRepository.GetByIdAsync(updatePupilViewModel.Id);
				if (pupil != null)
				{
					pupil.Name = updatePupilViewModel.Name;
					pupil.Surname = updatePupilViewModel.Surname;
					pupil.Class = updatePupilViewModel.Class;

					await _pupilRepository.SaveAsync();
					return RedirectToAction("Index");
				}
				return RedirectToAction("Index");
			}
			return View(updatePupilViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			await _pupilRepository.RemoveAsync(id);
			await _pupilRepository.SaveAsync();
			return RedirectToAction("Index");
		}
	}
}
