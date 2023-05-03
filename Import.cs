using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace PTI_API;

public class Import {
    public static Ship ImportShip(FileFormat format, string filePath) {
        Ship s = null;
        switch (format) {
            case FileFormat.Xml:
                XmlSerializer serializer = new XmlSerializer(typeof(Ship));
                using (Stream reader = new FileStream(filePath, FileMode.Open)) {
                    s = (Ship)serializer.Deserialize(reader);
                }

                break;
        }

        return s;
    }
}