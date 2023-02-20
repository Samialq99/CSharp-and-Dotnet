using System;


public class cardHolder
{
    int pin;
    String cardNum;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.pin = pin;
        this.cardNum = cardNum;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }
    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }


    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    
    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdrawl");
            Console.WriteLine("3. show balance");
            Console.WriteLine("4. exit");

        }

        void deposit(cardHolder currentUser) // the paramter is a class of type cardholder
        {
            Console.WriteLine("How much $ would you like to deposit ? ");
            double deposit = Double.Parse(Console.ReadLine()); // we parse it from String to Double
            currentUser.setBalance(deposit+currentUser.getBalance());
            Console.WriteLine("Thank you for your deposit your new balance is " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $ would you like to Withdraw ? ");
            double withdraw = Double.Parse(Console.ReadLine()); // we parse it from String to Double
            if (currentUser.getBalance() < withdraw)
            {
                Console.WriteLine("you do not have enough funds");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdraw);
                Console.WriteLine("Thank you for your deposit your new balance is " + currentUser.getBalance());
            }
        }

        // how you access a method is printOptions(); dont forget ()

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("current balance: " + currentUser.getBalance());
        }

        // create a user database using List

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("45", 1234, "John", "Griffith", 200.31));
        cardHolders.Add(new cardHolder("46", 5678, "ashley", "Jones", 100.13));
        cardHolders.Add(new cardHolder("47", 9101112, "Frida", "Dickenz", 50.22));
        cardHolders.Add(new cardHolder("48", 13141516, "dawn", "Smith", 20000.10));
        // NOTICE ORDER OF CONSTRUCTOR PARAMETERS MATTERS TO PASS IT PROPERLY

        //promt user
        Console.WriteLine("Welcome to My ATM");
        Console.WriteLine("Please insert your Debit card");
        String debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //check against DB
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                // firstordefault searches lists, and returns entire object
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card Not recognized");
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Card Not recognized");
                
            }
           
         //end of whileloop  
        }

        Console.WriteLine("Please enter your pin:  ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                //dont need to check against DB we have currentuser from line above
                //currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                // firstordefault searches lists, and returns entire object
                if (currentUser.getPin() == userPin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Pin Not recognized");
                }
            }
            catch (Exception)
            {

                Console.WriteLine("PIN Not recognized");

            }

            //end of whileloop  
        }

        Console.WriteLine("welcome "+ currentUser.getFirstName() +" :) ");
        int option =0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            {
                if(option == 1) { deposit(currentUser); }
                else if (option == 2) { withdraw(currentUser); }
                else if (option == 3) { balance(currentUser); }
                else if (option == 4) { break; }
                else { option = 0; } // this line is to set it back without looping again.

            }
        } while (option != 4);
        Console.WriteLine("Thank you for stopping by");



    }



}
