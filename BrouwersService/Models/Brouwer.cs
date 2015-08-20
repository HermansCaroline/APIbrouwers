using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BrouwersService.Models
{
    [DataContract(Name = "brouwer", Namespace = "")]
    public class Brouwer
    {
        [DataMember(Name = "id", Order = 1)]
        public int ID { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 1)]
        [DataMember(Name = "naam", Order = 2)]
        public string Naam { get; set; }

        [Range(1000, 9999)]
        [DataMember(Name = "postcode", Order = 3)]
        public int Postcode { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 1)]
        [DataMember(Name = "gemeente", Order = 4)]
        public string Gemeente { get; set; }
    }
}