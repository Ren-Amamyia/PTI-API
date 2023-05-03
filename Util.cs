namespace PTI_API;

using System.Collections.Generic;

public class Util {
    public static Dictionary<ShipType, string> TypeDict = new Dictionary<ShipType, string>();

    public static void InitializeDictionary() {
        TypeDict.Add(ShipType.Corvette, "Corvette");
        TypeDict.Add(ShipType.Frigate, "Frigate");
        TypeDict.Add(ShipType.Destroyer, "Destroyer");
        TypeDict.Add(ShipType.Cruiser, "Cruiser");
        TypeDict.Add(ShipType.Battlecruiser, "Battlecruiser");
        TypeDict.Add(ShipType.Battleship, "Battleship");
        TypeDict.Add(ShipType.Carrier, "Carrier");
    }
}