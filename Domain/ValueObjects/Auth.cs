using Microsoft.IdentityModel.Tokens;

using System.Text;

namespace VehicleRegistry.Domain.ValueObjects;

/// <summary>
/// Objeto de valor para autenticação.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class Auth
{
    /// <summary>
    /// A chave de segurança.
    /// </summary>
    private string key;

    /// <summary>
    /// O emissor do token.
    /// </summary>
    private string issuer;

    /// <summary>
    /// A audiência (destinatário) do token.
    /// </summary>
    private string audience;

    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="key">A chave de segurança.</param>
    /// <param name="issuer">O emissor do token.</param>
    /// <param name="audience">A audiência do token.</param>
    public Auth(string key, string issuer, string audience)
    {
        this.key = key;
        this.issuer = issuer;
        this.audience = audience;
    }

    /// <summary>
    /// A chave de segurança processada.
    /// </summary>
    public SymmetricSecurityKey Key {
        get {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.key));
        }
    }

    /// <summary>
    /// O emissor do token processado.
    /// </summary>
    public string Issuer {
        get {
            return this.issuer;
        }
    }

    /// <summary>
    /// A audiência do token processada.
    /// </summary>
    public string Audience {
        get {
            return this.audience;
        }
    }
}