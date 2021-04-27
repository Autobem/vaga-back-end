using BuildingBlocks.Domain.Generics.CPF;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BuildingBlocks.Domain.Extensions
{
    public static class CustomDataExtensions
    {
        public static IList<JsonConverter> AddCustoms(this IList<JsonConverter> JsonConverters)
        {

            JsonConverters.Add(new CPFConverter());
            return JsonConverters;
        }
    }
}
