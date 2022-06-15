using KingsOwnInstitute.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingsOwnInstitute.Data.ViewModels
{
    public class SeminarDropDownValue
    {
        public SeminarDropDownValue()
        {
            SeminarTypes = new List<SeminarType>();
        }
        public List<SeminarType> SeminarTypes { get; set; }
    }
}
