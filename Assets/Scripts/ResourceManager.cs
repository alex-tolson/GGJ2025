using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Resource
{
    public class ResourceManager
    {
        private int playerWabaloos;
        private int playerRubbers;

        // Load Save JSON File
        public static ResourceManager LoadFile(string jsonFile)
        {
            string json = File.ReadAllText(jsonFile);
            ResourceManager r = new ResourceManager();
            JObject doc = JObject.Parse(json);
            r.SetPlayerWabaloos((int) doc["playerWabaloos"]);
            r.SetPlayerRubbers((int) doc["playerRubbers"]);
            return r;
        }

        public void SaveFile(string jsonFile)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{\n");
            sb.Append(@"  ""playerWabaloos"": ");
            sb.Append(this.playerWabaloos);
            sb.Append(",\n");
            sb.Append(@"  ""playerRubbers"": ");
            sb.Append(this.playerRubbers);
            sb.Append("\n");
            sb.Append("}\n");

            File.WriteAllText(jsonFile, sb.ToString());
        }


        // Wabaloos
        public int GetPlayerWabaloos()
        {
            return playerWabaloos;
        }

        public int SetPlayerWabaloos(int newWabaloos)
        {
            int old = playerWabaloos;
            playerWabaloos = newWabaloos;
            return old;
        }


        // Rubbers
        public int GetPlayerRubbers()
        {
            return playerRubbers;
        }

        public int SetPlayerRubbers(int newRubbers)
        {
            int old = playerRubbers;
            playerRubbers = newRubbers;
            return old;
        }
    }

}