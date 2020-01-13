using Newtonsoft.Json.Linq;

namespace ARKSO
{
    class Objects
    {
        public static JObject server = new JObject(
            new JProperty("name", $"{Utils.GetUserName()}'s dedicated server"),
            new JProperty("map", "TheIsland"),
            new JProperty("players", "70"),
            new JProperty("vac", "secure"),
            new JProperty("battleye", "UseBattlEye"),
            new JProperty("password", ""),
            new JProperty("admin_password", ""),
            new JProperty("port", "7777"),
            new JProperty("query_port", "7778"),
            new JProperty("arguments", ""),
            new JProperty("options", ""));

        public static JObject maps = new JObject(
           new JProperty("The Island", "TheIsland"),
           new JProperty("The Center", "TheCenter"),
           new JProperty("Scorched Earth", "ScorchedEarth_P"),
           new JProperty("Ragnarok", "Ragnarok"),
           new JProperty("Aberration", "Aberration_P"),
           new JProperty("Extinction", "Extinction"),
           new JProperty("Valguero", "Valguero_P"));

        public static JObject vac = new JObject(
           new JProperty("Enable", "secure"),
           new JProperty("Disable", "insecure"));

        public static JObject battleye = new JObject(
           new JProperty("Enable", "UseBattlEye"),
           new JProperty("Disable", "NoBattlEye"));
    }
}
