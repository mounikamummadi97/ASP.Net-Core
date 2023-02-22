// See https://aka.ms/new-console-template for more information
using Unit_testing_Sample;

BankAccount objBankAccount = new BankAccount("Mr. Bryan Walton", 11.99);

objBankAccount.Credit(5.77);
objBankAccount.Debit(11.22);
Console.WriteLine("Current balance is ${0}", objBankAccount.Balance);