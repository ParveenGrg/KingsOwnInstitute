using KingsOwnInstitute.Data;
using KingsOwnInstitute.Data.Services;
using KingsOwnInstitute.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingsOwnInstitute.Controllers
{
    public class SeminarOrganizersController : Controller
    {
        private readonly AppDBContext _context;
        private readonly ISeminarOrganizersService _service;
        public SeminarOrganizersController(AppDBContext context, ISeminarOrganizersService service)
        {
            _context = context;
            _service = service;
        }
        public IActionResult Index()
        {
            var allSemOrg = _context.SeminarOrganizers
                .Include(o => o.Organizer)
                .Include(s => s.Seminar);
            return View(allSemOrg);
        }

        //Get: Seminar Organizers Create
        public async Task<IActionResult> Create()
        {
            var semOrgDropdownsData = await _service.GetSemOrgDropdownsValues();
            ViewBag.Organizers = new SelectList(semOrgDropdownsData.Organizers, "Id", "Name");
            ViewBag.Seminars = new SelectList(semOrgDropdownsData.Seminars, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewSemOrgViewModel semOrg)
        {
            if (!ModelState.IsValid)
            {
                var semOrgDropdownsData = await _service.GetSemOrgDropdownsValues();
                ViewBag.Organizers = new SelectList(semOrgDropdownsData.Organizers, "Id", "Name");
                ViewBag.Seminars = new SelectList(semOrgDropdownsData.Seminars, "Id", "Name");
                return View(semOrg);
            }
            await _service.AddNewSemOrgAsync(semOrg);
            TempData["Success"] = "Seminar Organizers added successfully";
            return RedirectToAction(nameof(Index));
        }

        //Get: Movies Edit
        public async Task<IActionResult> Edit(int id)
        {
            var semOrgDetails = await _service.GetSemOrgByIdAysnc(id);
            if (semOrgDetails == null) return View("NotFound");

            var response = new NewSemOrgViewModel()
            {
                Id = semOrgDetails.Id,
                OrganizerId = semOrgDetails.OrganizerId,
                SeminarId = semOrgDetails.SeminarId
            };
            var semOrgDropdownsData = await _service.GetSemOrgDropdownsValues();
            ViewBag.Seminars = new SelectList(semOrgDropdownsData.Seminars, "Id", "Name");
            ViewBag.Organizers = new SelectList(semOrgDropdownsData.Organizers, "Id", "Name");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewSemOrgViewModel semOrg)
        {
            if (id != semOrg.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetSemOrgDropdownsValues();
                ViewBag.Organizers = new SelectList(movieDropdownsData.Organizers, "Id", "Name");
                ViewBag.Seminars = new SelectList(movieDropdownsData.Seminars, "Id", "Name");
                return View(semOrg);
            }
            await _service.UpdateSemOrgAsync(semOrg);
            TempData["Success"] = "Seminar Organizers updated successfully";
            return RedirectToAction(nameof(Index));
        }

        //Get: Movie Delete
        public async Task<IActionResult> Delete(int id)
        {
            var semOrgDetails = await _service.GetByIdAsync(id);
            if (semOrgDetails == null) return View("NotFound");
            return View(semOrgDetails);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var semOrgDetails = await _service.GetByIdAsync(id);
            if (semOrgDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            TempData["Success"] = "Seminar Organizers deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}