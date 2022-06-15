using KingsOwnInstitute.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KingsOwnInstitute.Models
{
    public class SeminarType : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 4)]
        [Required(ErrorMessage = "Seminar Type is required.")]
        [Display(Name = "Seminar Type")]
        public string TypeName { get; set; }
    }
}
