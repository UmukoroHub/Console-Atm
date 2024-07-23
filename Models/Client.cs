using System.ComponentModel.DataAnnotations;

namespace ATM.Models;

public class Client
{
  public string Firstname { get; set; }
  public string Lastname { get; set;}
  [Required(ErrorMessage = "Account number is required")]
  public string Accountnumber { get; set; }
  public int Pin { get; set; }
  public double Balance { get; set; }
  public Client(string firstname, string lastname,string accountnumber,int pin, double balance)
  {
    this.Firstname = firstname;
    this.Lastname = lastname;
    this.Accountnumber = accountnumber;
    this.Pin = pin;
    this.Balance = balance;
  }
}