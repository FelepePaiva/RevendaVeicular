using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RevendaVeicular.Model
{
    [Table("employer")]
    public class EmployerModel
    {
        public EmployerModel()
        {
        }

        public EmployerModel(int id, string name, string password, string role)
        {
            Id = id;
            Name = name;
            Password = password;
            Role = role;
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }    
    }
}
