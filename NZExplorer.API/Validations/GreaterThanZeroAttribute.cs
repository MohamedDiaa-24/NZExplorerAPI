using System.ComponentModel.DataAnnotations;

namespace NZExplorer.API.Validations
{
    public class GreaterThanZeroAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return false;

            if (double.TryParse(value.ToString(), out double number))
            {
                return number > 0;
            }

            return false;
        }
    }
}
