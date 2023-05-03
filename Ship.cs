using System.Xml.Serialization;

namespace PTI_API {
    public interface IShipOptions {
        public string Name { get; set; }
        public string Class { get; set; }
        public ShipType Type { get; set; }
        public ShipDimensions Dimensions { get; set; }
    }

    public interface IShipDimensions {
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class ShipDimensions : IShipDimensions {
        [XmlElement(ElementName = "Dimensions")]
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        
        public ShipDimensions() {}
        public ShipDimensions(int length, int width, int height) {
            Length = length;
            Width = width;
            Height = height;
        }

        public override string ToString() {
            return $"{this.Length}, {this.Width}, {this.Height}";
        }
    }
    
    public class ShipOptions : IShipOptions {
        public string Name { get; set; }
        public string Class { get; set; }
        public ShipType Type { get; set; }
        public ShipDimensions Dimensions { get; set; }
        public ShipOptions(string name, string shipClass, ShipType type, ShipDimensions dimensions) {
            Name = name;
            Class = shipClass;
            Type = type;
            Dimensions = dimensions;

        }
    }

    public enum ShipType {
        Corvette,
        Frigate,
        Destroyer,
        Cruiser,
        Battlecruiser,
        Battleship,
        Carrier
    }

    public class Ship {
        [XmlElement(ElementName = "Ship")]
        
        [XmlText()]
        public string Name { get; set; }
        public string Class { get; set; }
        public ShipType Type { get; set; }
        public ShipDimensions Dimensions { get; set; }

        public Ship() {}
        public Ship(IShipOptions options) {
            Name = options.Name != "" ? options.Name : "";
            Class = options.Class != "" ? options.Class : "";
            Type = options.Type;
            Dimensions = options.Dimensions;
        }

        public override string ToString() {
            return $"Name: {this.Name}\nType: {Util.TypeDict[this.Type]}\nClass: {this.Class}\nDimensions(L, W, H): {this.Dimensions.ToString()}";
        }
        
        public static ShipType InferType(ShipDimensions dimensions) {

            return ShipType.Corvette;
        }
    }   
}