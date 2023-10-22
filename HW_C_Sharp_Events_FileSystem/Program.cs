using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_C_Sharp_Events_FileSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataManager dataManager = new DataManager();

            Card creditCard = new Card(7323666891122787, "John Doe", "10/26", "2342", 500, 700);

            List<Card> creditCards = new List<Card>();
            creditCards.Add(creditCard);

            Owner cardOwner = new Owner(creditCard);

            Console.WriteLine(creditCard);
            Console.WriteLine("--------------------------------");

            creditCard.Deposit(250);
            creditCard.Withdraw(1200);
            creditCard.ChangePIN("1999");
            Console.WriteLine("--------------------------------");

            Console.WriteLine(creditCard);
            Console.WriteLine("--------------------------------");

            dataManager.SaveCreditCards(creditCards);

            List<Card> loadedCreditCards = dataManager.LoadCreditCards();

            foreach (Card loadedCard in loadedCreditCards)
            {
                Console.WriteLine("Loaded from creditcards.json file:");
                Console.WriteLine(loadedCard);
            }

            Console.ReadLine();
        }
    }
}
