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
    public static void ExportShip(FileFormat format, Ship ship) {
        string dir = $@"/PTI/Ships/{Util.TypeDict[ship.Type]}/{ship.Class}/";
        if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
        string indent = "    ";
        switch (format) {
            case FileFormat.Xml:
                StreamWriter stream = new StreamWriter($@"{dir}{ship.Name}.xml");
                XmlWriter writer = XmlWriter.Create(stream, new XmlWriterSettings { Indent = true, IndentChars = "    " });
                // string xml = $"<Ship>\n{indent}<Name>{ship.Name}</Name>\n{indent}<Type>{Util.TypeDict[ship.Type]}</Type>\n{indent}<Class>{ship.Class}</Class>\n{indent}<Dimensions>\n{indent}{indent}<Length>{ship.Dimensions.Length}</Length>\n{indent}{indent}<Width>{ship.Dimensions.Width}</Width>\n{indent}{indent}<Height>{ship.Dimensions.Height}</Height>\n{indent}</Dimensions>\n</Ship>";
                XmlSerializer serializer = new XmlSerializer(typeof(Ship));

                serializer.Serialize(writer, ship);

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