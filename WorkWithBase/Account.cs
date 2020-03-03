using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bankomat_sp.Client_sp;

namespace Bankomat_sp
{
    namespace Account_sp
    {
        class Account
        {

            Client client;
            long score;
            float money;
            string login;
            string password;


            public void Menu()
            {

                int c = 0;
                Console.Clear();
                while (c != 3)
                {
                    Console.WriteLine("==========USER INFO===============");
                    Console.WriteLine("User name: " + Client.User_name);
                    Console.WriteLine("User patronomic: " + Client.Patronomic);
                    Console.WriteLine("User surname: " + Client.User_surname);
                    Console.WriteLine("Date of birth: " + Client.Date_birth.ToShortDateString());
                    Console.WriteLine("=================================");
                    Console.WriteLine("Number of score : " + score);
                    Console.WriteLine("Total money : " + money);
                    Console.WriteLine("=================================");
                    Console.WriteLine("1. add money");
                    Console.WriteLine("2. withdrow money");
                    Console.WriteLine("3. exit");
                    int.TryParse(Console.ReadLine(), out c);
                    switch (c)
                    {
                        case 1:
                            Console.WriteLine("add money, enter amount: ");
                            if (!float.TryParse(Console.ReadLine(), out float result))
                            {
                                Console.WriteLine("Wrong input amount, try with ,");
                            }
                            else
                            {
                                money += result;
                                Console.WriteLine("done");

                            }
                            break;
                        case 2:
                            Console.WriteLine("winthdraw money, enter money: ");
                            if (!float.TryParse(Console.ReadLine(), out result))
                            {
                                Console.WriteLine("Wrong input amount, try with ,");
                            }
                            else
                            {
                                if (result <= money && result >= 0)
                                {
                                    money -= result;
                                    Console.WriteLine("done");
                                }
                                else
                                    Console.WriteLine("To much amount");
                            }
                            break;
                        case 3: Console.Clear(); return;
                        default:
                            break;
                    }
                }
                return;
            }
            public void PhillInfo()
            {
                Console.WriteLine("==================NEW ACCOUNT===========================");
                Console.WriteLine("User Password: ");
                Password = Console.ReadLine();
                Console.WriteLine("User First depo money: ");
                float.TryParse(Console.ReadLine(), out money);
                Client = new Client();
                Client.PhillInfo();
            }
            public void InfoAccount()
            {
                client.ShowInfo();
                Console.WriteLine("number of score: "+score);
                Console.WriteLine("Total money: " + money);
                Console.WriteLine($"Login : {login}");
                
            }
            #region Constructors
            public Account()
            {
                this.Login = "111";
                this.Password = "111";
                this.money = 0.0f;
            }
            public Account(string user_login)
            {
                this.Login = user_login;
                this.Password = "111";
                this.money = 0.0f;
            }
            /// <summary>
            /// конструктор иницилизирует аккаунт
            /// </summary>
            /// <param name="login"></param>
            /// <param name="password"></param>
            /// <param name="money"></param>
            /// <param name="user_name"></param>
            /// <param name="surname"></param>
            /// <param name="patronomic"></param>
            /// <param name="birth"></param>
            public Account(string login, string password, float money, string user_name, string surname, string patronomic, long number_score, DateTime birth)
            {
                this.Login = login;
                this.Password = password;
                this.money = money;
                this.score = number_score;
                Client = new Client(user_name, surname, patronomic, birth);
            }
            #endregion
            #region Properties
            public string Password
            {
                get => password; set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        password = value;
                    }
                    else Console.WriteLine("Check pass");
                }
            }
            public string Login
            {
                get => login;
                set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        login = value;
                    }
                    else Console.WriteLine("Check pass");
                }
            }

            public long Score { get => score; set => score = value; }
            public float Money { get => money; set => money = value; }
            internal Client Client { get => client; set => client = value; } //работаем в одной сборке

            #endregion
        }
    }
}