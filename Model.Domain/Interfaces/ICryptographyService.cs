using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Model.Domain.Interfaces
{
    public interface ICryptographyService
    {
        string EncryptPassword(string password);
        bool VerifyPassword(string informedPassword, string savedPassword);
    }
}
