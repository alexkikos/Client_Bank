using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bankomat_sp;


//Это запускающий прооэкт(авторизация), вся работа с клиентами идет в длл файле
//тест учетка для клиента test 123
//персонал без пароля
namespace Client_Bank
{
    class Program
    {
        static void Main(string[] args)
        {

            int choice;
            Bank bank = new Bank();
            do
            {
                Console.WriteLine("1. Client auth");
                Console.WriteLine("2. Personal Auth");
                Console.WriteLine("3. Exit");
                Console.Write("Choice: ");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {

                    case 1: bank.Login_Clien(); break;
                    case 2: bank.Login_Personal(); break;
                    case 3: break;
                    default:
                        break;
                }


            } while (choice != 3);

        }
    }
}
