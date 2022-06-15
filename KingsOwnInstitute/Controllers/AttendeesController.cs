using KingsOwnInstitute.Data;
using KingsOwnInstitute.Data.Services;
using KingsOwnInstitute.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingsOwnInstitute.Controllers
{
    public class AttendeesController : Controller
    {
        private readonly IAttendeesService _service;
        public AttendeesController(IAttendeesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allAttendees = await _service.GetAllAsync();
            return View(allAttendees);
        }

        //Get: Attendee Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, DOB, Address")] Attendee attendee)
        {
            if (!ModelState.IsValid)
            {
                return View(attendee);
            }
            await _service.AddAsync(attendee);
            TempData["Success"] = "Attendee added successfully";
            return RedirectToAction(nameof(Index));
        }

        //Get: Attendee Edit
        public async Task<IActionResult> Edit(int id)
        {
            var attendeeDetails = await _service.GetByIdAsync(id);
            if (attendeeDetails == null) return View("NotFound");
            return View(attendeeDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, DOB, Address")] Attendee attendee)
        {
            if (!ModelState.IsValid) return View(attendee);
            if (id == attendee.Id)
            {
                await _service.UpdateAsync(id, attendee);
                TempData["Success"] = "Attendee updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(attendee);
        }

        //Get: Attendee Delete
        public async Task<IActionResult> Delete(int id)
        {
            var attendeeDetails = await _service.GetByIdAsync(id);
            if (attendeeDetails == null) return View("NotFound");
            return View(attendeeDetails);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attendeeDetails = await _service.GetByIdAsync(id);
            if (attendeeDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            TempData["Success"] = "Attendee deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
