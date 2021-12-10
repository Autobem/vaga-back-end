using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Aggregates.Usuarios.CrossCutting
{
    public interface IMD5Cryptography
    {
        string Encrypt(string value);
    }
}
