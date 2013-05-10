using System;

namespace MVCSkeleton.Presentation.DTOs
{
    public class CustomerDTO
    {
        public  Guid Id { get; set; }

        public  string Name { get; set; }

        public  string Surname { get; set; }

        public  string AddressId { get; set; }
    }
}