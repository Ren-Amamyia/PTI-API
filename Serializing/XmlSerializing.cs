using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace PTI_API.Serializing; 

public class XmlSerializing {
    
    public object Deserialize(string filePath, Encoding? encoding) {
        string[] lines =  File.ReadAllLines(filePath, encoding ?? Encoding.UTF8);
        Ship s = new Ship();
        PropertyInfo[] props = s.GetType().GetProperties();
        PropertyInfo[] dimProps = props[3].GetType().GetProperties();
        s.Dimensions = new ShipDimensions();
        char[] separators = new char[] { '<', '>' };
        foreach (string line in lines) {
            string[] attrib = line.Split(separators);
            Console.WriteLine(attrib[2]);
            switch (attrib[1]) {
                case "Name":
                    s.Name = attrib[2];
                    break;
                case "Type":
                    s.Type = Util.NameToTypeDict[attrib[2]];
                    break;
                case "Class":
                    s.Class = attrib[2];
                    break;
                case "Length":
                    s.Dimensions.Length = Int32.Parse(attrib[2]);
                    break;
                case "Width":
                    s.Dimensions.Width = Int32.Parse(attrib[2]);
                    break;
                case "Height":
                    s.Dimensions.Height = Int32.Parse(attrib[2]);
                    break;
                default:
                    continue;
                
            }
        }

        return s;
    }

    public async Task<Ship> Deserialize(Stream stream) {
        Ship s = new Ship();
        s.Dimensions = new ShipDimensions();
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.Async = true;

        using (XmlReader reader = XmlReader.Create(stream, settings)) {
            while (await reader.ReadAsync()) {
                switch (reader.NodeType) {
                    case XmlNodeType.Element:
                        string value = await reader.GetValueAsync();
                        if (reader.Name == "Name") s.Name = value;
                        else if (reader.Name == "Type") s.Type = Util.NameToTypeDict[value];
                        else if (reader.Name == "Class") s.Class = value;
                        else if (reader.Name == "Length") s.Dimensions.Length = Int32.Parse(value);
                        else if (reader.Name == "Width") s.Dimensions.Width = Int32.Parse(value);
                        else if (reader.Name == "Height") s.Dimensions.Height = Int32.Parse(value);
                        break;
                }
            }
        }

        return s;
    }
}