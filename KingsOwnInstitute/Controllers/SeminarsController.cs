using KingsOwnInstitute.Data;
using KingsOwnInstitute.Models;
using KingsOwnInstitute.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingsOwnInstitute.Data.ViewModels;

namespace KingsOwnInstitute.Controllers
{
    public class SeminarsController : Controller
    {
        private readonly AppDBContext _context;
        private readonly ISeminarsService _service;
        public SeminarsController(AppDBContext context, ISeminarsService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allSeminars = await _service.GetAllAsync(n => n.SeminarType);
            return View(allSeminars) ;
        }

        //Get: Seminars Create
        public async Task<IActionResult> Create()
        {
            var semTypeDropdownsData = await _service.GetSeminarDropdownsValues();
            ViewBag.SeminarTypes = new SelectList(semTypeDropdownsData.SeminarTypes, "Id", "TypeName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewSeminarViewModel seminar)
        {
            if (!ModelState.IsValid)
            {
                var semTypeDropdownsData = await _service.GetSeminarDropdownsValues();
                ViewBag.SeminarTypes = new SelectList(semTypeDropdownsData.SeminarTypes, "Id", "TypeName");
                return View(seminar);
            }
            await _service.AddNewSeminarAsync(seminar);
            TempData["Success"] = "Seminar added successfully";
            return RedirectToAction(nameof(Index));
        }

        //Get: Seminar Edit
        public async Task<IActionResult> Edit(int id)
        {
            var seminarDetails = await _service.GetSeminarByIdAysnc(id);
            if (seminarDetails == null) return View("NotFound");

            var response = new NewSeminarViewModel()
            {
                Id = seminarDetails.Id,
                SeminarTypeId = seminarDetails.SeminarTypeId,
                SeminarDate = seminarDetails.SeminarDate,
                Status = (Data.ViewModels.Status)seminarDetails.Status
            };
            var seminarDropdownsData = await _service.GetSeminarDropdownsValues();
            ViewBag.SeminarTypes = new SelectList(seminarDropdownsData.SeminarTypes, "Id", "TypeName");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewSeminarViewModel seminar)
        {
            if (id != seminar.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {
                var seminarDropdownsData = await _service.GetSeminarDropdownsValues();
                ViewBag.SeminarTypes = new SelectList(seminarDropdownsData.SeminarTypes, "Id", "TypeName");
                return View(seminar);
            }
            await _service.UpdateSeminarAsync(seminar);
            TempData["Success"] = "Seminar updated successfully";
            return RedirectToAction(nameof(Index));
        }

        //Get: Seminar Delete
        public async Task<IActionResult> Delete(int id)
        {
            var movieDetails = await _service.GetByIdAsync(id);
            if (movieDetails == null) return View("NotFound");
            return View(movieDetails);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieDetails = await _service.GetByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            TempData["Success"] = "Seminar deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
