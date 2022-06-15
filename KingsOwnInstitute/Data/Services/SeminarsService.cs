using KingsOwnInstitute.Data.Base;
using KingsOwnInstitute.Models;
using KingsOwnInstitute.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KingsOwnInstitute.Data.Services
{
    public class SeminarsService : EntityBaseRepository<Seminar>, ISeminarsService
    {
        private readonly AppDBContext _context;
        public SeminarsService(AppDBContext context): base(context)
        {
            _context = context;
        }

        public async Task AddNewSeminarAsync(NewSeminarViewModel data)
        {
            var newSeminar = new Seminar()
            {
                Name = data.Name,
                SeminarTypeId = data.SeminarTypeId,
                SeminarDate = data.SeminarDate,
                Status = (Models.Status)data.Status
            };
            await _context.Seminars.AddAsync(newSeminar);
            await _context.SaveChangesAsync();
        }

        public async Task<Seminar> GetSeminarByIdAysnc(int id)
        {
            var seminarDetails = await _context.Seminars
                .Include(s => s.SeminarType)
                .FirstOrDefaultAsync(n => n.Id == id);
            return seminarDetails;
        }

        public async Task<SeminarDropDownValue> GetSeminarDropdownsValues()
        {
            var response = new SeminarDropDownValue()
            {
                SeminarTypes = await _context.SeminarTypes.OrderBy(n => n.TypeName).ToListAsync()
            };
            return response;
        }

        public async Task UpdateSeminarAsync(NewSeminarViewModel data)
        {
            var dbSeminar = await _context.Seminars.FirstOrDefaultAsync(n => n.Id == data.Id);
            if(dbSeminar != null)
            {
                dbSeminar.SeminarTypeId = data.SeminarTypeId;
                dbSeminar.Name = data.Name;
                dbSeminar.SeminarDate = data.SeminarDate;
                dbSeminar.Status = (Models.Status)data.Status;
            }
            await _context.SaveChangesAsync();
        }
    }
}
