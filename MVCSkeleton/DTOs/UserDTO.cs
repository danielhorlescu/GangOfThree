﻿using System;

namespace MVCSkeleton.Presentation.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }
    }
}