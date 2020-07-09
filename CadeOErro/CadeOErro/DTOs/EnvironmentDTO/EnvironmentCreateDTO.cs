using System.ComponentModel.DataAnnotations;

namespace CadeOErro.Server.DTOs.EnvironmentDTO
{
    public class EnvironmentCreateDTO
    {
        [Required]
        public string shortName { get; set; }
        [Required]
        public string description { get; set; }
    }
}
