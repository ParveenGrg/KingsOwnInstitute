using KingsOwnInstitute.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KingsOwnInstitute.Models
{
    public class Seminar : IEntityBase
    {
        [Key]
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
        public virtual ICollection<RegistrationInfo> RegistrationInfo { get; set; }
        public virtual ICollection<SeminarOrganizer> SeminarOrganizers { get; set; }
    }
    public enum Status
    {
        Upcoming,
        Ongoing,
        Completed
    }
}