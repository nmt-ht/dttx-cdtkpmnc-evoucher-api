﻿namespace eVoucherApi.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? EmailAddress { get; set; }
        public string? Phone { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool IsActive { get; set; }
    }
}
