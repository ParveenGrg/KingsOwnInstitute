using KingsOwnInstitute.Data.Base;
using KingsOwnInstitute.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingsOwnInstitute.Data.Services
{
    public class SeminarTypeService : EntityBaseRepository<SeminarType>, ISeminarTypeService
    {
        public SeminarTypeService(AppDBContext context): base(context)
        {

        }
    }
}
