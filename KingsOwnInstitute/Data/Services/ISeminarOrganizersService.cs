using KingsOwnInstitute.Data.Base;
using KingsOwnInstitute.Data.ViewModels;
using KingsOwnInstitute.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingsOwnInstitute.Data.Services
{
    public interface ISeminarOrganizersService : IEntityBaseRepository<SeminarOrganizer>
    {
        Task<SeminarOrganizer> GetSemOrgByIdAysnc(int id);
        Task<SemOrgDropDownValue> GetSemOrgDropdownsValues();
        Task AddNewSemOrgAsync(NewSemOrgViewModel data);
        Task UpdateSemOrgAsync(NewSemOrgViewModel data);
    }
}
