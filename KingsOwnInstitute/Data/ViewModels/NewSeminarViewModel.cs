using KingsOwnInstitute.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KingsOwnInstitute.Data.ViewModels
{
    public class NewSeminarViewModel
    {
        public int Id { get; set; }

        [ForeignKey("SeminarType")]
        [Display(Name = "Seminar Type")]
        public int SeminarTypeId { get; set; }

        [StringLength(100, MinimumLength = 4)]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        public Status Status { get; set; }

        [Display(Name = "Seminar Date")]
        [Required(ErrorMessage = "Seminar Date is required.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SeminarDate { get; set; }
        public SeminarType SeminarType { get; set; }
    }
}
