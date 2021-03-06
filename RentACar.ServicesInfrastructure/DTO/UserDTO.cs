﻿using System.Web;

namespace RentACar.ServicesInfrastructure.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public UserPhotoDTO Photo { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
