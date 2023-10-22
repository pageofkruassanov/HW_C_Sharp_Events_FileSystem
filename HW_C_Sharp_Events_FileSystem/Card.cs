using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace HW_C_Sharp_Events_FileSystem
{
    internal class Card
    {
        public decimal Id { get; set; }
        public string FullName { get; set; }
        public string Date { get; set; }
        public string Pin {  get; set; }
        public decimal Limit { get; set; }
        public decimal Balance { get; set; }

        public Card(decimal id, string fullName, string date, string pin, decimal limit, decimal balance)
        {
            Id = id;
            FullName = fullName;
            Date = date;
            Pin = pin;
            Limit = limit;
            Balance = balance;
        }

        public event Action<decimal> Deposited;

        public event Action<decimal> Withdrawn;

        public event Action<decimal> CreditStarted;

        public event Action<string> PINChanged;

        public void Deposit(decimal amount)
        {
            Balance += amount;
            Deposited?.Invoke(amount);
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Withdrawn?.Invoke(amount);
            }
            else
            {
                decimal creditWithdraw = amount - Balance;
                decimal balanceWithdraw = amount - creditWithdraw;

                Balance -= balanceWithdraw;

                Withdrawn?.Invoke(balanceWithdraw);

                StartCredit(creditWithdraw);
            }
        }
        private void StartCredit(decimal amount)
        {
            if (Balance == 0)
            {
                Limit -= amount;
                CreditStarted?.Invoke(amount);
            }
        }
        public void ChangePIN(string newPIN)
        {
            Pin = newPIN;
            PINChanged?.Invoke(newPIN);
        }



        public override string ToString()
        {
            return
                $"Card number: {Id}\n" +
                $"Card holder name: {FullName}\n" +
                $"Expiration: {Date}\n" +
                $"Pin code: {Pin}\n" +
                $"Credit funds: {Limit}\n" +
                $"Balance: {Balance}";
        }
    }
}
