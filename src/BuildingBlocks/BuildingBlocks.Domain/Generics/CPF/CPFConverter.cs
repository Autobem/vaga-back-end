using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BuildingBlocks.Domain.Generics.CPF
{
    public class CPFConverter : JsonConverter<CPF>
    {
        public override CPF Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            CPF.TryParse(reader.GetString(), out var cpf);
            return cpf;
        }

        public override void Write(Utf8JsonWriter writer, CPF value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Value);
        }
    }
}
