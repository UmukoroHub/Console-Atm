
using ATM.Models;

namespace ATM;

public class Atm
{
    readonly Client client; 

  public Atm(Client client)
  {
    this.client = client;
  }

  public void Printbalance()
  {
    Console.WriteLine("This is your current balance "+ client.Balance);
  }
  public void Deposit(double deposit)
  {
    this.client.Balance += deposit;
  }
  internal void Withdraw(double withdrawl)
  {
    this.client.Balance -= withdrawl;
  }
  public void Greet()
  {
    Console.WriteLine("Hello good-day "+ client.Firstname +" "+ client.Lastname + " what would you like to do!");
  }
     

}