using System.Text.Json;

namespace PTI_API; 

public class FirstCharJsonNamingPolicy : JsonNamingPolicy {
    public override string ConvertName(string name) =>
        name[0].ToString().ToUpper() + name.Substring(1);
}