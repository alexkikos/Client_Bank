using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bankomat_sp.Client_sp;
using Bankomat_sp.Account_sp;


namespace Bankomat_sp
{
    public class Bank
    {
        List<Account> accounts;
        public void AdNewClien()
        {
            Console.Clear();
            Console.WriteLine("=============ADD CLIENT=============");
            Console.WriteLine("Enter client login: ");
            string l = Console.ReadLine();
            if (accounts.Find(a => a.Login == l) == null)
            {
                Account a = new Account(l);
                long scores = 0;
                do
                {

                    Console.WriteLine("Enter number of score: ");
                    long.TryParse(Console.ReadLine(), out scores);
                    if (accounts.Find(s => s.Score == scores) != null) Console.WriteLine("This score exist, enter another");
                    else break;
                } while (true);
                a.Score = scores;
                a.PhillInfo();
                accounts.Add(a);
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("This login exist");
                return;
            }
        }
        public void Login_Clien()
        {
            int tr_count = 0;
        againt:
            if (tr_count > 3)
            {
                Console.WriteLine("To many tryes");
                System.Environment.Exit(0);

            }
            Console.WriteLine("========================ENTER FOR CLIENT====================");
            Console.WriteLine("enter login (x - return): ");
            string log = Console.ReadLine();
            if (log == "x") return;
            string pas = "";
            Console.WriteLine("enter password: ");
            ConsoleKeyInfo b1;
            do
            {
                b1 = Console.ReadKey(true);
                if (b1.Key != ConsoleKey.Enter && b1.Key != ConsoleKey.Backspace)
                {
                    pas += b1.KeyChar;
                    Console.Write("*");
                }
                else
                if (b1.Key == ConsoleKey.Backspace && pas.Length > 0)
                {
                    pas = pas.Remove(pas.Length - 1);
                    Console.Write("\b \b");
                }

            } while (b1.Key != ConsoleKey.Enter);

            Console.WriteLine("ok");
            Account b;
            b = accounts.Find(a => a.Login == log);
            if (b != null)
            {
                if (b.Password == pas)
                {
                    b.Menu();
                }
                else
                {
                    tr_count++;
                    Console.WriteLine("Wrong input, left tryes: " + (3 - tr_count));
                    goto againt;
                }

            }
        }
        public void ShowAllClients()
        {
            int count = 1;
            Console.WriteLine("===========AL CLIENTS=============");
            foreach (var item in accounts)
            {
                Console.WriteLine(count+". "+item.Login.ToString());
                count++;
            }
            Console.WriteLine("======================================");
        }
        /// <summary>
        /// edit all client params
        /// menu section
        /// </summary>
        public void EditClient()
        {
            Console.Clear();
            ShowAllClients();
            Console.WriteLine("Enter client login: ");//можно было сделать по индексу, но тут решил сделать по логину, у всех остальных редактирование и тд идет по индексу
            string log = Console.ReadLine();
            Account b;
            b = accounts.Find(a => a.Login == log);
            if (b != null)
            {
                string s;
                int choice;        
                do
                {
                    Console.Clear();
                    b.InfoAccount();
                    Console.WriteLine("================================");
                    Console.WriteLine("1. Edit user name");
                    Console.WriteLine("2. Edit user surname");
                    Console.WriteLine("3. Edit user patronomic");
                    Console.WriteLine("4. Edit user date of birth");
                    Console.WriteLine("5. Edit user login");
                    Console.WriteLine("6. Edit user password");
                    Console.WriteLine("7. Exit menu");
                    int.TryParse(Console.ReadLine(), out choice);
                    switch (choice)
                    {

                        case 1:
                            Console.WriteLine("enter new name: ");
                            do
                            {
                                s = Console.ReadLine();
                                s = s.Trim();

                            } while (string.IsNullOrWhiteSpace(s) || string.IsNullOrEmpty(s));
                            b.Client.User_name = s;
                            Console.WriteLine("done");
                            Console.WriteLine("push key for continue");
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.WriteLine("enter new surname: ");
                            do
                            {
                                s = Console.ReadLine();
                                s = s.Trim();

                            } while (string.IsNullOrWhiteSpace(s) || string.IsNullOrEmpty(s));
                            b.Client.User_surname = s;
                            Console.WriteLine("done");
                            Console.WriteLine("push key for continue");
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.WriteLine("enter new patronomic: ");
                            do
                            {
                                s = Console.ReadLine();
                                s = s.Trim();

                            } while (string.IsNullOrWhiteSpace(s) || string.IsNullOrEmpty(s));
                            b.Client.Patronomic = s;
                            Console.WriteLine("done");
                            Console.WriteLine("push key for continue");
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.WriteLine("user day bidrth: ");
                            int.TryParse(Console.ReadLine(), out int day);
                            Console.WriteLine("user month bidrth: ");
                            int.TryParse(Console.ReadLine(), out int month);
                            Console.WriteLine("user month year: ");
                            int.TryParse(Console.ReadLine(), out int year);
                            try
                            {

                                b.Client.Date_birth = new DateTime(year: year, month: month, day: day);
                            }
                            catch (ArgumentOutOfRangeException a)
                            {
                                a.Message.ToString();
                                return;
                            }
                            Console.WriteLine("done");
                            Console.WriteLine("push key for continue");
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.WriteLine("enter new login: ");
                            do
                            {
                                s = Console.ReadLine();
                                s = s.Trim();

                            } while (string.IsNullOrWhiteSpace(s) || string.IsNullOrEmpty(s));
                            b.Login = s;
                            Console.WriteLine("done");
                            Console.WriteLine("push key for continue");
                            Console.ReadKey();
                            break;
                        case 6:
                            Console.WriteLine("enter new pass: ");
                            do
                            {
                                s = Console.ReadLine();
                                s = s.Trim();

                            } while (string.IsNullOrWhiteSpace(s) || string.IsNullOrEmpty(s));
                            b.Password = s;
                            Console.WriteLine("done");
                            Console.WriteLine("push key for continue");
                            Console.ReadKey();
                            break;
                        default:
                            break;
                    }
                } while (choice != 7);
                return;
            }
            else Console.WriteLine("Cant find Login");
        }                                 
        public void Login_Personal()
        {
            int a = 0;
            Console.Clear();
            while (true)
            {
                Console.WriteLine("1. Add client");
                Console.WriteLine("2. Edit client");
                Console.WriteLine("3. Remove client");
                Console.WriteLine("4. Show All clients logins");
                Console.WriteLine("5. Exit");
                int.TryParse(Console.ReadLine(), out a);
                switch (a)
                {
                    case 1: AdNewClien(); break;
                    case 2: EditClient(); break;
                    case 3: RemoveClient(); break;
                    case 4: ShowAllClients(); break;
                    case 5: Console.Clear(); return; break;
                    default:
                        break;
                }
            }
        }

        public void RemoveClient()
        {
            Console.Clear();
            ShowAllClients();
            Console.WriteLine("Enter index of client: ");
            int.TryParse(Console.ReadLine(), out int index);
            index -= 1;
            if (index >=0 && index < accounts.Count)
            {
                try
                {
                    accounts.RemoveAt(index);
                }
                catch (ArgumentOutOfRangeException a)
                {
                    a.Message.ToString();
                    return;
                }
                Console.WriteLine("done, push some key");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            else Console.WriteLine("wrong input");
        }

        /// <summary>
        /// создаем банк с тестовой учеткой
        /// </summary>
        public Bank()
        {
            accounts = new List<Account>();
            DateTime date = new DateTime(1990, 12, 12);
            Account a = new Account("test", "123", 1255.65f, "alexandr", "yurievich", "nechiporenko", 1230, date);
            accounts.Add(a);
        }
    }
}
