using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TossPayments.Core.JsonConverters
{
    internal class yyyyMMddHHmmSSConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => DateTime.ParseExact(reader.GetString()!, "yyyyMMddHHmmSS", CultureInfo.InvariantCulture);

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString("yyyyMMddHHmmSS"));
    }
}