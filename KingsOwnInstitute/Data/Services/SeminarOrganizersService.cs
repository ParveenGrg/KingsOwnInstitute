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
    public class SeminarOrganizersService : EntityBaseRepository<SeminarOrganizer>, ISeminarOrganizersService
    {
        private readonly AppDBContext _context;
        public SeminarOrganizersService(AppDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewSemOrgAsync(NewSemOrgViewModel data)
        {
            var newSemOrg = new SeminarOrganizer()
            {
                OrganizerId = data.OrganizerId,
                SeminarId = data.SeminarId
            };
            await _context.SeminarOrganizers.AddAsync(newSemOrg);
            await _context.SaveChangesAsync();
        }

        public async Task<SeminarOrganizer> GetSemOrgByIdAysnc(int id)
        {
            var semOrgDetails = await _context.SeminarOrganizers
                .Include(o => o.Organizer)
                .Include(s => s.Seminar)
                .FirstOrDefaultAsync(n => n.Id == id);
            return semOrgDetails;
        }

        public async Task<SemOrgDropDownValue> GetSemOrgDropdownsValues()
        {
            var response = new SemOrgDropDownValue()
            {
                Organizers = await _context.Organizers.OrderBy(o => o.Name).ToListAsync(),
                Seminars = await _context.Seminars.OrderBy(s => s.Name).ToListAsync()
            };
            return response;
        }

        public async Task UpdateSemOrgAsync(NewSemOrgViewModel data)
        {
            var dbSemOrg = await _context.SeminarOrganizers.FirstOrDefaultAsync(n => n.Id == data.Id);
            if (dbSemOrg != null)
            {
                dbSemOrg.OrganizerId = data.OrganizerId;
                dbSemOrg.SeminarId = data.SeminarId;
            }
            await _context.SaveChangesAsync();
        }
    }
}
