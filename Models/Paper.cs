//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Do_An.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Paper
    {
        public int PaperID { get; set; }
        public Nullable<int> ConferenceID { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public int PrimaryAreaID { get; set; }
        public Nullable<int> SecondaryAreaID { get; set; }
        public string Keywords { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    
        public virtual Conference Conference { get; set; }
        public virtual ResearchArea ResearchArea { get; set; }
        public virtual ResearchArea ResearchArea1 { get; set; }
    }
}
