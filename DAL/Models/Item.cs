using System.ComponentModel.DataAnnotations;

namespace OnboardingEcomindo.DAL.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
    }
}
