using KingsOwnInstitute.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KingsOwnInstitute.Models
{
    public class Organizer: IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 4)]
        [Required(ErrorMessage = "Organizer's Name is required.")]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        public virtual ICollection<SeminarOrganizer> SeminarOrganizers { get; set; }
    }
}
