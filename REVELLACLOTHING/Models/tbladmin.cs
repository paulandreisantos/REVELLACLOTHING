//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace REVELLACLOTHING.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class tbladmin
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Required")]
        public string username { get; set; }

        [Required(ErrorMessage = "Required")]
        public string password { get; set; }

        [Required(ErrorMessage = "Required")]
        public string contact { get; set; }

        [Required(ErrorMessage = "Required")]
        public string firstname { get; set; }

        [Required(ErrorMessage = "Required")]
        public string lastname { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(6,ErrorMessage="Minimum lenght is 6")]
        public string address { get; set; }
    }
}
