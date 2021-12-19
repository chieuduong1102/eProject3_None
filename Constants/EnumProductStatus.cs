using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eProject3_Verhicle_Management.Constants
{
    public enum EnumProductStatus
    {

        [Display(Name = "Un Available")]
        Unavailable = 0,

        [Display(Name = "Available")]
        Available = 1,

        [Display(Name = "Comming soon")]
        Commingsoon = 2,
    }
}