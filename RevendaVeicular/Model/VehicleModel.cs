using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RevendaVeicular.Model
{
    [Table("vehicle")]
    public class VehicleModel
    {

        [Key]
        public int Id { get; set; }
        public string? Model { get; set; }   
        public string? Color { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        public VehicleModel(int id, string? model, string? color, int year, decimal price)
        {
            Id = id;
            Model = model;
            Color = color;
            Year = year;
            Price = price;
        }
    }
    
}
