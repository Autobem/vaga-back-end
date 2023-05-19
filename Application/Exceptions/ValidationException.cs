namespace VehicleRegistry.Application.Exceptions;

/// <summary>
/// Exceção lançada quando há um dado inválido.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class ValidationException : Exception
{
    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="message">A mensagem da exceção.</param>
    public ValidationException(string message) : base(message)
    {}
}