using KingsOwnInstitute.Data.Base;
using KingsOwnInstitute.Data.ViewModels;
using KingsOwnInstitute.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingsOwnInstitute.Data.Services
{
    public interface IRegistrationInfoService : IEntityBaseRepository<RegistrationInfo>
    {
        Task<RegistrationInfo> GetRegistrationByIdAysnc(int id);
        Task<RegistrationDropDownValue> GetRegistrationDropdownsValues();
        Task AddNewRegistrationAsync(NewRegistrationViewModel data);
        Task UpdateRegistrationAsync(NewRegistrationViewModel data);
    }
}
