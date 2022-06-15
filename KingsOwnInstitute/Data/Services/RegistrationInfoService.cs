using KingsOwnInstitute.Data.Base;
using KingsOwnInstitute.Data.ViewModels;
using KingsOwnInstitute.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingsOwnInstitute.Data.Services
{
    public class RegistrationInfoService : EntityBaseRepository<RegistrationInfo>, IRegistrationInfoService
    {
        private readonly AppDBContext _context;
        public RegistrationInfoService(AppDBContext context): base(context)
        {
            _context = context;
        }

        public async Task AddNewRegistrationAsync(NewRegistrationViewModel data)
        {
            var register = new RegistrationInfo()
            {
                AttendeeId = data.AttendeeId,
                SeminarId = data.SeminarId,
                RegistrationDate = data.RegistrationDate
            };
            await _context.RegistrationInfo.AddAsync(register);
            await _context.SaveChangesAsync();
        }

        public async Task<RegistrationInfo> GetRegistrationByIdAysnc(int id)
        {
            var registrationDetails = await _context.RegistrationInfo
                .Include(a => a.Attendee)
                .Include(s => s.Seminar)
                .FirstOrDefaultAsync(n => n.Id == id);
            return registrationDetails;
        }

        public async Task<RegistrationDropDownValue> GetRegistrationDropdownsValues()
        {
            var response = new RegistrationDropDownValue()
            {
                Attendees = await _context.Attendees.OrderBy(n => n.Name).ToListAsync(),
                Seminars = await _context.Seminars.OrderBy(n => n.Name).ToListAsync()
            };
            return response;
        }

        public async Task UpdateRegistrationAsync(NewRegistrationViewModel data)
        {
            var dbRegister = await _context.RegistrationInfo.FirstOrDefaultAsync(n => n.Id == data.Id);
            if (dbRegister != null)
            {
                dbRegister.AttendeeId = data.AttendeeId;
                dbRegister.SeminarId = data.SeminarId;
                dbRegister.RegistrationDate = data.RegistrationDate;
            }
            await _context.SaveChangesAsync();
        }
    }
}
