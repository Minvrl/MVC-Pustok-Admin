using System.ComponentModel.DataAnnotations;

namespace MVC_Pustok.Attributes.ValidationAttributes
{
    public class MaxfileSize : ValidationAttribute
    {
        private int _byteSize;
        public MaxfileSize(int byteSize)
        {
            _byteSize = byteSize;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            IFormFile? file = value as IFormFile;

            if ((file != null))
            {
                if (file.Length > _byteSize)
                {
                    double mb = _byteSize / 1024d / 1024d;
                    return new ValidationResult($"File must be less or equal than {mb.ToString("0.##")}mb");
                }
            }

            return ValidationResult.Success;
        }
    }
}
