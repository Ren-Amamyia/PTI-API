namespace PTI_API;

using System.Collections.Generic;

public class Util {
    public static Dictionary<ShipType, string> TypeDict = new Dictionary<ShipType, string>();
    public static Dictionary<string, ShipType> NameToTypeDict = new Dictionary<string, ShipType>();

    public static void InitializeDictionary() {
        // Map ShipType enum values to a string name
        TypeDict.Add(ShipType.Corvette, "Corvette");
        TypeDict.Add(ShipType.Frigate, "Frigate");
        TypeDict.Add(ShipType.Destroyer, "Destroyer");
        TypeDict.Add(ShipType.Cruiser, "Cruiser");
        TypeDict.Add(ShipType.Battlecruiser, "Battlecruiser");
        TypeDict.Add(ShipType.Battleship, "Battleship");
        TypeDict.Add(ShipType.Carrier, "Carrier");
        
        // Map String names to ShipType enum values
        NameToTypeDict.Add("Corvette", ShipType.Corvette);
        NameToTypeDict.Add("Frigate", ShipType.Frigate);
        NameToTypeDict.Add("Destroyer", ShipType.Destroyer);
        NameToTypeDict.Add("Cruiser", ShipType.Cruiser);
        NameToTypeDict.Add("Battlecruiser", ShipType.Battlecruiser);
        NameToTypeDict.Add("Battleship", ShipType.Battleship);
        NameToTypeDict.Add("Carrier", ShipType.Carrier);
    }
}