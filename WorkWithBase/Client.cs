using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_sp
{
    namespace Client_sp
    {
        class Client
        {
            string user_name;
            string user_surname;
            string patronomic;
            DateTime date_birth;


            public void PhillInfo()
            {
                Console.WriteLine("================NEW CLIENT=========================");
                try
                {
                    do
                    {
                        Console.WriteLine("Name of user: ");
                        user_name = Console.ReadLine();
                        user_name = user_name.Trim();
                    } while (string.IsNullOrEmpty(user_name) || string.IsNullOrWhiteSpace(user_name));

                    do
                    {
                        Console.WriteLine("User patronomic: ");
                        patronomic = Console.ReadLine();
                        patronomic = patronomic.Trim();
                    } while (string.IsNullOrEmpty(patronomic) || string.IsNullOrWhiteSpace(patronomic));


                    do
                    {
                        Console.WriteLine("user surname: ");
                        user_surname = Console.ReadLine();
                        user_surname = user_surname.Trim();
                    } while (string.IsNullOrEmpty(user_surname) || string.IsNullOrWhiteSpace(user_surname));
                }
                catch (OutOfMemoryException a)//ловлю станд екзепшины чтения строки
                {
                    Console.WriteLine(a.Message);
                    return;
                }
                catch (ArgumentOutOfRangeException a)
                {
                    Console.WriteLine(a.Message);
                    return;
                }
                catch (System.IO.IOException a)
                {
                    Console.WriteLine(a.Message);
                    return;
                }
                Console.WriteLine("user day bidrth: ");
                int.TryParse(Console.ReadLine(), out int day);
                Console.WriteLine("user month bidrth: ");
                int.TryParse(Console.ReadLine(), out int month);
                Console.WriteLine("user month year: ");
                int.TryParse(Console.ReadLine(), out int year);
                try
                {

                    date_birth = new DateTime(year:year, month:month, day:day);
                }
                catch (ArgumentOutOfRangeException a)
                {
                    a.Message.ToString();
                    return;
                }
            }
            public void ShowInfo()
            {
                Console.WriteLine("===========Client Info=============");
                Console.WriteLine("Name: " + user_name);
                Console.WriteLine("Patronomic: " + patronomic);
                Console.WriteLine("Surname: " + user_surname);
                Console.WriteLine("Date bidrth: " + Date_birth);
            }
            #region Properties
            public string User_name
            {
                get => user_name;
                set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        user_name = value;
                    }
                    else Console.WriteLine("Check name");
                }
            }
            public string User_surname
            {
                get => user_surname;
                set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        user_surname = value;
                    }
                    else Console.WriteLine("Check name");
                }
            }

            public DateTime Date_birth { get => date_birth; set => date_birth = value; }
            public string Patronomic { get => patronomic; set => patronomic = value; }


            #endregion
            #region Constructors
            public Client(string user_name, string patronomic, string user_surname, DateTime date_birth)
            {
                this.user_name = user_name;
                this.user_surname = user_surname;
                this.Date_birth = date_birth;
                this.patronomic = patronomic;
            }
            /// <summary>
            /// констукторк без параметров, создает имя,отчество, фамилию, дату рождения в виде 01.01.2001
            /// </summary>
            public Client()
            {
                this.user_name = "";
                this.user_surname = "";
                this.patronomic = "";
                this.Date_birth = new DateTime(0);
            }
            #endregion

        }
    }
}
