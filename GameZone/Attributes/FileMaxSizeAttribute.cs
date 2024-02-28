using GameZone.Settings;

namespace GameZone.Attributes
{
    public class FileMaxSizeAttribute:ValidationAttribute
    {
            private readonly int _maxFileSize;

            public FileMaxSizeAttribute(int maxFileSize)
            {
                _maxFileSize = maxFileSize;
            }
            protected override ValidationResult? IsValid
                (object? value, ValidationContext validationContext)
            {
                var file = value as IFormFile;
                if (file is not null)
                {
                    if (file.Length>_maxFileSize)
                    {
                        return new ValidationResult($"Maximum allowed file size is{_maxFileSize/1024/1024} MB!");
                    }
                }
                return ValidationResult.Success;
            }
        
    }
}
