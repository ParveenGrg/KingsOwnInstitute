using KingsOwnInstitute.Data.Services;
using KingsOwnInstitute.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingsOwnInstitute.Controllers
{
    public class OrganizersController : Controller
    {
        private readonly IOrganizersService _service;
        public OrganizersController(IOrganizersService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allOrganizers = await _service.GetAllAsync();
            return View(allOrganizers);
        }

        //Get: Organizer Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, DOB, Address")] Organizer organizer)
        {
            if (!ModelState.IsValid)
            {
                return View(organizer);
            }
            await _service.AddAsync(organizer);
            TempData["Success"] = "Organizer added successfully";
            return RedirectToAction(nameof(Index));
        }

        //Get: Attendee Edit
        public async Task<IActionResult> Edit(int id)
        {
            var organizerDetails = await _service.GetByIdAsync(id);
            if (organizerDetails == null) return View("NotFound");
            return View(organizerDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, DOB, Address")] Organizer organizer)
        {
            if (!ModelState.IsValid) return View(organizer);
            if (id == organizer.Id)
            {
                await _service.UpdateAsync(id, organizer);
                TempData["Success"] = "Organizer updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(organizer);
        }

        //Get: Organizer Delete
        public async Task<IActionResult> Delete(int id)
        {
            var organizerDetails = await _service.GetByIdAsync(id);
            if (organizerDetails == null) return View("NotFound");
            return View(organizerDetails);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizerDetails = await _service.GetByIdAsync(id);
            if (organizerDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            TempData["Success"] = "Organizer deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
