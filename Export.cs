using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;
using PTI_API.Extensions;
using PTI_API.Serializing;

namespace PTI_API;

public enum FileFormat {
    Xml,
    Json
}

public class Export {
    public static void ExportShip(FileFormat format, Ship ship, string? filePath) {
        string dir = filePath ?? $@"/PTI/Ships/{Util.TypeDict[ship.Type]}/{ship.Class}/";
        if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
        switch (format) {
            case FileFormat.Xml:
                StringWriter stream = new StringWriter();
                XmlTextWriter writer = new XmlTextWriter(stream);
                writer.Formatting = Formatting.Indented;

                XmlSerializer serializer = new XmlSerializer(typeof(Ship));
                serializer.Serialize(writer, ship);

                string xml = stream.ToString();

                File.WriteAllText($@"{dir}{ship.Name}.xml", xml);

                break;
            case FileFormat.Json:
                string path = $@"{dir}{ship.Name}.json";
                string json = JsonSerializer.Serialize(ship, new JsonSerializerOptions { WriteIndented = true, PropertyNamingPolicy = new FirstCharJsonNamingPolicy() });

                json = json.Replace("\"Type\": 0", $"\"Type\": \"{Util.TypeDict[ship.Type]}\"");
                json = json.Replace("\"Type\": 1", $"\"Type\": \"{Util.TypeDict[ship.Type]}\"");
                json = json.Replace("\"Type\": 2", $"\"Type\": \"{Util.TypeDict[ship.Type]}\"");
                json = json.Replace("\"Type\": 3", $"\"Type\": \"{Util.TypeDict[ship.Type]}\"");
                json = json.Replace("\"Type\": 4", $"\"Type\": \"{Util.TypeDict[ship.Type]}\"");
                json = json.Replace("\"Type\": 5", $"\"Type\": \"{Util.TypeDict[ship.Type]}\"");
                json = json.Replace("\"Type\": 6", $"\"Type\": \"{Util.TypeDict[ship.Type]}\"");
                
                File.WriteAllText(path, json, Encoding.UTF8);
                break;
        }
    }
}