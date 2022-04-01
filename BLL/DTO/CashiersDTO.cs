using System;
using OnboardingEcomindo.DAL.Models;

namespace OnboardingEcomindo.BLL.DTO
{
    public class CashiersDTO
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
