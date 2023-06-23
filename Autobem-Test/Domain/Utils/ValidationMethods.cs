using System.Numerics;

namespace Domain.Utils;

public static class ValidationMethods
{
    public static bool BeOnlyNumeric(string numericString)
    {
        return numericString != null ? BigInteger.TryParse(numericString, out _) : true;
    }
}