// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using ATM;
using ATM.Models;

Console.WriteLine("----------Welcome To Our ATM Machine-----------");
Console.WriteLine("");

//Here at the program we enter our ATM details
//We check for account number
//check for pin
//we present our available options 
Console.WriteLine("Welcome! please enter your account number");

List<Client> clients = new List<Client>();
clients.Add(new Client("Joshua", "Adeleke ", "0236894108", 1234, 1000));
clients.Add(new Client("James", "Brown ", "023455920", 1224, 2000));
clients.Add(new Client("Abel", "Cain ", "023667890", 2234, 3000));
clients.Add(new Client("Jacob", "Omoniyi ", "0234569810", 3234, 4000));
clients.Add(new Client("Prosper", "Sadiku ", "0234569810", 5234, 5000));

Client client;
string accountnumber;
while (true)
{
  accountnumber = Console.ReadLine();
  if(string.IsNullOrWhiteSpace(accountnumber))
  {
    Console.WriteLine("");
  }
  client = clients.FirstOrDefault(client => client.Accountnumber == accountnumber);
  if (client != null)
  {
    break;
  }
  else
  {
    Console.WriteLine("Incorrect account number, please try again");
  }
}
Console.WriteLine("Please enter your pin");
int pin = 0;
while (true)
{
  if (int.TryParse(Console.ReadLine(), out pin))
  {
    if (client.Pin == pin)
    {
      break;
    }
  }
  Console.WriteLine("Incorrect pin! Please try again:");
}
Console.WriteLine("-------------");

Atm atm = new Atm(client);
atm.Greet();
int option = 0;

while (true)
{
  PrintAtmOptions();
  option = int.Parse(Console.ReadLine());
  if (option == 1)
  {
    Console.WriteLine();
    Console.WriteLine("How much would you like to deposit? ");
    double deposit = double.Parse(Console.ReadLine());
    atm.Deposit(deposit);
    Console.WriteLine("Thank you! your money has been deposited to your account");
    Console.WriteLine("Your new balance is : " + client.Balance);
  }
  else if (option == 2)
  {
    Console.WriteLine("");
    Console.WriteLine("How much would you like to withdraw? ");
    double withdrawl = double.Parse(Console.ReadLine());
    if (client.Balance < withdrawl || client.Balance - withdrawl < 0)
    {
      Console.WriteLine("Insufficient funds .....please try again");
      break;

    }
    else
    {
      atm.Withdraw(withdrawl);
      Console.WriteLine($"Thank you! you've successfully withdrawed {withdrawl} from your account");
      Console.WriteLine("Your new balance is " + client.Balance);
    }
  }
  else if (option == 3)
  {
    Console.WriteLine("");
    atm.Printbalance();
  }
  else if (option == 4)
  {
    Console.WriteLine("Thank you for using this ATM...Hope you have a nice day");
    break;
  }
  else
  {
    option = 0;
  }


}
void PrintAtmOptions()
{
  Console.WriteLine("1. Deposit");
  Console.WriteLine("2. Withdraw");
  Console.WriteLine("3. Check balance");
  Console.WriteLine("4. Exit");
}









