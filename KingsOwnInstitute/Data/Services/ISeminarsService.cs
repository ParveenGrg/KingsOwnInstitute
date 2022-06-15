using KingsOwnInstitute.Data.Base;
using KingsOwnInstitute.Models;
using KingsOwnInstitute.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingsOwnInstitute.Data.Services
{
    public interface ISeminarsService : IEntityBaseRepository<Seminar>
    {
        Task<Seminar> GetSeminarByIdAysnc(int id);
        Task<SeminarDropDownValue> GetSeminarDropdownsValues();
        Task AddNewSeminarAsync(NewSeminarViewModel data);
        Task UpdateSeminarAsync(NewSeminarViewModel data);
    }
}
