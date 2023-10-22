using Newtonsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace HW_C_Sharp_Events_FileSystem
{
    internal class DataManager
    {
        private const string DataFilePath = "creditcards.json";

        public void SaveCreditCards(List<Card> creditCards)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(creditCards, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(DataFilePath, json);
        }

        public List<Card> LoadCreditCards()
        {
            List<Card> creditCards = new List<Card>();

            if (File.Exists(DataFilePath))
            {
                string json = File.ReadAllText(DataFilePath);
                creditCards = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Card>>(json);
            }

            return creditCards;
        }
    }
}
