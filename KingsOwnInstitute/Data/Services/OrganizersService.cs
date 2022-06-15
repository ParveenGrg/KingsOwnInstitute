using KingsOwnInstitute.Data.Base;
using KingsOwnInstitute.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingsOwnInstitute.Data.Services
{
    public class OrganizersService : EntityBaseRepository<Organizer>, IOrganizersService
    {
        public OrganizersService(AppDBContext context) : base(context)
        {

        }
    }
}
