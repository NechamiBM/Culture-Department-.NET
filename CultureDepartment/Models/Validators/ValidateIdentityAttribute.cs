using Microsoft.IdentityModel.Tokens;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class ValidateIdentityAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        string identityStr = (string)value;
        if (string.IsNullOrEmpty(identityStr))
            return new ValidationResult(ErrorMessage);
        if (!Regex.IsMatch(identityStr, @"^\d{6,9}$"))
            return new ValidationResult("Identity must contain between 6 to 9 digits only.");
        identityStr = identityStr.PadLeft(9, '0');
        int checksum = int.Parse(identityStr.Substring(identityStr.Length - 1));
        int identity = int.Parse(identityStr.Substring(0, identityStr.Length - 1));
        int digit, sum = 0;
        for (int i = 0; i < 8; i++)
        {
            digit = identity % 10;
            identity /= 10;
            if (i % 2 == 0) 
            {
                digit *= 2;
                if (digit > 9)
                    digit = digit / 10 + digit % 10;
            }
            sum += digit;
        }

        int calculatedChecksum = (10 - sum % 10) % 10;
        return calculatedChecksum == checksum ? ValidationResult.Success: new ValidationResult(ErrorMessage);
    }
}