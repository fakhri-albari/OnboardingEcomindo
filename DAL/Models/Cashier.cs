using System;
using System.ComponentModel.DataAnnotations;

namespace OnboardingEcomindo.DAL.Models
{
    public enum Gender
    {
        Male, Female
    }
    public class Cashier
    {
        [Key]
        public int CashierId { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
