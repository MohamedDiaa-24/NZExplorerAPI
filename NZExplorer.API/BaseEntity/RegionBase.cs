using NZExplorer.API.Validations;
using System.ComponentModel.DataAnnotations;

namespace NZExplorer.API.BaseEntity
{
    public class RegionBase
    {
        [Required]
        [MinLength(3)]
        [MaxLength(5)]
        public string Code { get; set; }
        [Required(ErrorMessage = "cannot be null or empty or white space.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "cannot be null or empty or white space.")]
        [GreaterThanZero(ErrorMessage = "cannot be less than or equal to zero.")]
        public double Area { get; set; }

        [Required(ErrorMessage = "cannot be null or empty or white space.")]
        public double Lat { get; set; }


        [Required(ErrorMessage = "cannot be null or empty or white space.")]
        [GreaterThanZero(ErrorMessage = "cannot be less than or equal to zero.")]
        public double Long { get; set; }


        [Required(ErrorMessage = "cannot be null or empty or white space.")]
        [GreaterThanZero(ErrorMessage = "cannot be less than or equal to zero.")]
        public long Population { get; set; }

        public string? ImageURL { get; set; }
    }
}
