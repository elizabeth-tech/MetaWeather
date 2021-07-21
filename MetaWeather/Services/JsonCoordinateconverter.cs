using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MetaWeather.Services
{
    // Класс для преобразования строки широты и долготы в значения double
    public class JsonCoordinateconverter : JsonConverter<(double Latitude, double Longitude)>
    {
        // Десериализация
        public override (double Latitude, double Longitude) Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Если прочитанная строка длиной не более 3-х символов, либо
            // если после разбиения строки по запятой результат не длины 2, либо
            // если не удалось прочитать первый или второй компонент
            // то возвращаем NaN
            // Если все хорошо, то возвращаем кортеж ширины и долготы
            return reader.GetString() is not { Length: >= 3 } str
                || str.Split(',') is not { Length: 2 } components
                || !double.TryParse(components[0], NumberStyles.Any, CultureInfo.InvariantCulture, out var lat)
                || !double.TryParse(components[0], NumberStyles.Any, CultureInfo.InvariantCulture, out var lon)
                ? (double.NaN, double.NaN)
                : (lat, lon);
        }

        // Сериализация
        public override void Write(Utf8JsonWriter writer, (double Latitude, double Longitude) value, JsonSerializerOptions options) => writer
            .WriteStringValue($"{value.Latitude.ToString(CultureInfo.InvariantCulture)}, {value.Longitude.ToString(CultureInfo.InvariantCulture)}");
    }
}
