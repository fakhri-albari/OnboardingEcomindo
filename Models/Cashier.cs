using System;

namespace OnboardingEcomindo.Models
{
    public enum Gender
    {
        Male, Female
    }
    public class Cashier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
