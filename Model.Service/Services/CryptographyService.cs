using Model.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Model.Service.Services
{
    public class CryptographyService : ICryptographyService
    {
        SHA512 _algorithm { get; set; }

        public CryptographyService()
        {
            _algorithm = SHA512.Create();
        }

        public string EncryptPassword(string password)
        {
            var encodedValue = Encoding.UTF8.GetBytes(password);
            var encryptedPassword = _algorithm.ComputeHash(encodedValue);

            var sb = new StringBuilder();
            foreach (var caracter in encryptedPassword)
            {
                sb.Append(caracter.ToString("X2"));
            }

            return sb.ToString();
        }

        public bool VerifyPassword(string informedPassword, string savedPassword)
        {
            if (string.IsNullOrEmpty(savedPassword))
                throw new NullReferenceException("Insert a password.");

            var encryptedPassword = _algorithm.ComputeHash(Encoding.UTF8.GetBytes(informedPassword));

            var sb = new StringBuilder();
            foreach (var caractere in encryptedPassword)
            {
                sb.Append(caractere.ToString("X2"));
            }

            return sb.ToString() == savedPassword;
        }
    }
}
