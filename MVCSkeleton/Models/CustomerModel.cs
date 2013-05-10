using System;
using System.ComponentModel.DataAnnotations;

namespace MVCSkeleton.Presentation.Models
{
    public class CustomerModel
    {
        [ScaffoldColumn(false)]
        public  Guid Id { get; set; }

        public  string Name { get; set; }

        public  string Surname { get; set; }

        public  string AddressId { get; set; }
    }
}