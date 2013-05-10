using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSkeleton.Presentation.Models
{
    public class StoreModel
    {
        public Guid Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}