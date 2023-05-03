using System.IO;
using System.Reflection;
using System.Text;

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
}