using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TossPayments.Core.JsonConverters
{
    internal class yyyyMMddConverter : JsonConverter<DateOnly>
    {
        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => DateOnly.ParseExact(reader.GetString()!, "yyyyMMdd", CultureInfo.InvariantCulture);

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString("yyyyMMdd"));
    }
}