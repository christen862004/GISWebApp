using System.ComponentModel.DataAnnotations;

namespace GISWebApp.Models
{
    public class GreaterThanAttribute:ValidationAttribute
    {
        public int ComparazonValue { get; set; }
        public override bool IsValid(object? value)
        {
            int val = int.Parse(value.ToString());
            if (val > ComparazonValue)
            {
                return true;
            }
            return false;
        }
    }
}
