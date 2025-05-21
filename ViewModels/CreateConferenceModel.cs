using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Do_An.ViewModels
{
    public class CreateConferenceModel
    {
        [Required(ErrorMessage = "Conference title must be specified")]
        [DataType(DataType.Text)]
        //[Display(Name = "Conference title:")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Acronym must be specified")]
        [DataType(DataType.Text)]
        //[Display(Name = "Acronym")]
        public string Acronym { get; set; }
        [Required(ErrorMessage = "First day must be specified")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Display(Name = "First day:")]
        public System.DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Last day must be specified")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Last day:")]
        public System.DateTime EndDate { get; set; }
        [Required(ErrorMessage = "If you did not select the primary area, you should write some area notes")]
        [Display(Name = "Primary area:")]
        public int? PrimaryAreaID { get; set; }
        [Display(Name = "Secondary area:")]
        public int? SecondaryAreaID { get; set; }
        [Required(ErrorMessage = "Location must be specified")]
        [Display(Name = "Location:")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Organizer must be specified")]
        [Display(Name = "Organizer:")]
        public string Organizer { get; set; }
    }
}