using System;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Resource
{
    public class ResourceManager
    {
        private int playerWabaloos;
        private int playerRubbers;
        private int playerMoney;

        // Load Save JSON File
        public static ResourceManager LoadFile(string jsonFile)
        {
            string json = File.ReadAllText(jsonFile);
            ResourceManager r = new ResourceManager();
            JObject doc = JObject.Parse(json);
            try
            {
                r.SetPlayerWabaloos((int)doc["playerWabaloos"]);
            }
            catch (Exception e)
            {
                r.SetPlayerWabaloos(0);
            }
            try
            {
                r.SetPlayerRubbers((int)doc["playerRubbers"]);
            }
            catch (Exception e)
            {
                r.SetPlayerRubbers(0);
            }
            try
            {
                r.SetPlayerMoney((int)doc["playeMoney"]);
            }
            catch (Exception e)
            {
                r.SetPlayerMoney(0);
            }
            return r;
        }

        public void SaveFile(string jsonFile)
        {
            Debug.Log($"Saving file to path: {jsonFile}");
            StringBuilder sb = new StringBuilder();
            sb.Append("{\n");
            sb.Append(@"  ""playerWabaloos"": ");
            sb.Append(this.playerWabaloos);
            sb.Append(",\n");
            sb.Append(@"  ""playerRubbers"": ");
            sb.Append(this.playerRubbers);
            sb.Append(",\n");
            sb.Append(@"  ""playerMoney"": ");
            sb.Append(this.playerMoney);
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


        // Money
        public int GetPlayerMoney()
        {
            return playerMoney;
        }

        public int SetPlayerMoney(int newMoney)
        {
            int old = playerMoney;
            playerMoney = newMoney;
            return old;
        }
    }

}