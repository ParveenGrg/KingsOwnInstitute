using KingsOwnInstitute.Data.Services;
using KingsOwnInstitute.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingsOwnInstitute.Controllers
{
    public class SeminarTypeController : Controller
    {
        private readonly ISeminarTypeService _service;
        public SeminarTypeController(ISeminarTypeService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allSemType = await _service.GetAllAsync();
            return View(allSemType);
        }

        //Get: Organizer Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeName")] SeminarType semType)
        {
            if (!ModelState.IsValid)
            {
                return View(semType);
            }
            await _service.AddAsync(semType);
            TempData["Success"] = "Seminar Type added successfully";
            return RedirectToAction(nameof(Index));
        }

        //Get: Attendee Edit
        public async Task<IActionResult> Edit(int id)
        {
            var semTypeDetails = await _service.GetByIdAsync(id);
            if (semTypeDetails == null) return View("NotFound");
            return View(semTypeDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, TypeName")] SeminarType semType)
        {
            if (!ModelState.IsValid) return View(semType);
            if (id == semType.Id)
            {
                await _service.UpdateAsync(id, semType);
                TempData["Success"] = "Seminar Type updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(semType);
        }

        //Get: Organizer Delete
        public async Task<IActionResult> Delete(int id)
        {
            var semTypeDetails = await _service.GetByIdAsync(id);
            if (semTypeDetails == null) return View("NotFound");
            return View(semTypeDetails);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var semTypeDetails = await _service.GetByIdAsync(id);
            if (semTypeDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            TempData["Success"] = "Seminar Type deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
