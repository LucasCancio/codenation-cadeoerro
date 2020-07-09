using System.ComponentModel.DataAnnotations;

namespace CadeOErro.Server.DTOs.LogLevel
{
    public class LogLevelCreateDTO
    {
        [Required]
        public string description { get; set; }
    }
}
