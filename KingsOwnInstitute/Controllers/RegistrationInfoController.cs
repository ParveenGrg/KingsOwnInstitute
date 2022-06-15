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
    public class RegistrationInfoController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IRegistrationInfoService _service;
        public RegistrationInfoController(AppDBContext context, IRegistrationInfoService service)
        {
            _context = context;
            _service = service;
        }
        public IActionResult Index()
        {
            var allRegisterInfo = _context.RegistrationInfo
                .Include(a => a.Attendee)
                .Include(s => s.Seminar);
            return View(allRegisterInfo);
        }

        //Get: Registration
        public async Task<IActionResult> Create()
        {
            var registerDropdownsData = await _service.GetRegistrationDropdownsValues();
            ViewBag.Attendees = new SelectList(registerDropdownsData.Attendees, "Id", "Name");
            ViewBag.Seminars = new SelectList(registerDropdownsData.Seminars, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewRegistrationViewModel register)
        {
            if (!ModelState.IsValid)
            {
                var registerDropdownsData = await _service.GetRegistrationDropdownsValues();
                ViewBag.Attendees = new SelectList(registerDropdownsData.Attendees, "Id", "Name");
                ViewBag.Seminars = new SelectList(registerDropdownsData.Seminars, "Id", "Name");
                return View(register);
            }
            await _service.AddNewRegistrationAsync(register);
            TempData["Success"] = "Registered Attendee successfully";
            return RedirectToAction(nameof(Index));
        }

        //Get: Registration Edit
        public async Task<IActionResult> Edit(int id)
        {
            var registrationDetails = await _service.GetRegistrationByIdAysnc(id);
            if (registrationDetails == null) return View("NotFound");

            var response = new NewRegistrationViewModel()
            {
                Id = registrationDetails.Id,
                AttendeeId = registrationDetails.AttendeeId,
                SeminarId = registrationDetails.SeminarId,
                RegistrationDate = registrationDetails.RegistrationDate
            };
            var registerDropdownsData = await _service.GetRegistrationDropdownsValues();
            ViewBag.Attendees = new SelectList(registerDropdownsData.Attendees, "Id", "Name");
            ViewBag.Seminars = new SelectList(registerDropdownsData.Seminars, "Id", "Name");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewRegistrationViewModel register)
        {
            if (id != register.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {
                var registerDropdownsData = await _service.GetRegistrationDropdownsValues();
                ViewBag.Attendees = new SelectList(registerDropdownsData.Attendees, "Id", "Name");
                ViewBag.Seminars = new SelectList(registerDropdownsData.Seminars, "Id", "Name");
                return View(register);
            }
            await _service.UpdateRegistrationAsync(register);
            TempData["Success"] = "Registration updated successfully";
            return RedirectToAction(nameof(Index));
        }

        //Get: Registration Delete
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
            TempData["Success"] = "Registration deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
