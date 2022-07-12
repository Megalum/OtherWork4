using System;

namespace OtherWork4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] name = new string[1000];
            string[] position = new string[1000];
            string[] salary = new string[1000];
            int length = 0;
            int number;
            string search = String.Empty;
            string task = String.Empty;

            do
            {
                Console.Clear();
                Console.WriteLine("Доступные команды:" +
                                "\n1 - AddRecord - Добавить досье" +
                                "\n2 - PrintAllRecord - Вывесли все досье" +
                                "\n3 - DellRecord - Удалить досье по номеру" +
                                "\n4 - SearchBySurnames - Поиск по фамилии" +
                                "\n5 - SearchBySalary - Поиск по зарплате" +
                                "\n6 - SearchByPosition - Поиск по должности" +
                                "\n7 - RelpayRecord - Изменить досье" +
                                "\n8 - Exit - Выход");
                task = InputString("Введите команду: ");
                Console.Clear();
                switch (task)
                {                    
                    case "1":
                    case "AddRecord":
                        name[length] = InputString("Введите ФИО работника: ");
                        position[length] = InputString("Введите должность работника: ");
                        salary[length] = InputString("Введите зарплату работника: ");
                        length++;
                        break;

                    case "2":
                    case "PrintAllRecord":
                        PrintAll();
                        break;

                    case "3":
                    case "DellRecord":
                        PrintAll();
                        search = InputString("Введите номер досье которое желаете удалить: ");
                        for (int i = Convert.ToInt32(search) - 1; i < length; i++)
                        {
                            name[i] = name[i + 1];
                            position[i] = position[i + 1];
                            salary[i] = salary[i + 1];
                        }
                        length--;
                        break;

                    case "4":
                    case "SearchBySurnames":
                        search = InputString("Введите фамилию для поискa: ");
                        Search(name, search);
                        break;

                    case "5":
                    case "SearchBySalary":
                        string minMax = InputString("Осуществляем поиск: в большую(>), в мeньшую(<)");
                        search = InputString("Введите зарплату для поиска: ");

                        number = 1;
                        PrintTableCap();
                        for (int i = 0; i < length; i++)
                            if (minMax == ">")
                            {
                                if (Convert.ToInt32(salary[i]) >= Convert.ToInt32(search))
                                    Print(number++, i);
                            }
                            else if (minMax == "<")
                                if (Convert.ToInt32(salary[i]) <= Convert.ToInt32(search))
                                    Print(number++, i);

                        break;

                    case "6":
                    case "SearchByPosition":
                        search = InputString("Введите должность для поиска: ");
                        Search(position, search);
                        break;

                    case "7":
                    case "RelpayRecord":
                        PrintAll();
                        search = InputString("Укащите какую колонку желаете изменить: ");
                        int index = int.Parse(InputString("Укажите номер досье которое желаете изменить: ")) - 1;
                        if (search.ToLower() == "фио")
                            name[index] = InputString("Введите новое ФИО работника");
                        if (search.ToLower() == "должность")
                            position[index] = InputString("Введите новую должность работника: ");
                        if (search.ToLower() == "зарплата")
                            salary[index] = InputString("Введите новую зарплату работника: ");
                        break;

                    case "8":
                        task = "Exit";
                        break;
                }

                Console.Write("Press key to continue...");
                Console.ReadKey();
            } while (task != "Exit");

            void Print(int number, int index)
            {
                void Table(string ounput, int length)
                {
                    Console.Write("\u2551");
                    for (int i = 0; i < length; i++)
                    {
                        if (i < ounput.Length)
                            Console.Write(ounput[i]);
                        else
                            Console.Write(" ");
                    }
                }
                string fio = $"{number}. {name[index]}";
                string post = position[index];
                string pay = salary[index];
                int fieldFirst = 49, fieldSecond = 34, fieldThird = 14;
                Table(fio, fieldFirst);
                Table(post, fieldSecond);
                Table(pay, fieldThird);
                Console.WriteLine("\u2551");
                PrintTableContinue();
            }

            void PrintAll()
            {
                PrintTableCap();
                for (int i = 0; i < length; i++)
                {
                    Print(i + 1, i);
                }
            }

            void PrintTableCap()
            {
                Console.Write("\u2554");
                for (int i = 1; i < 100; i++)
                {
                    if (i == 50 || i == 85)
                        Console.Write("\u2566");
                    else
                        Console.Write("\u2550");
                }
                Console.WriteLine("\u2557");
                Console.WriteLine("\u2551ФИО                                              \u2551Должность                         \u2551Зарплата      \u2551");
                PrintTableContinue();
            }

            void PrintTableContinue()
            {
                Console.Write("\u2560");
                for (int i = 1; i < 100; i++)
                {
                    if (i == 50 || i == 85)
                        Console.Write("\u256C");
                    else
                        Console.Write("\u2550");
                }
                Console.WriteLine("\u2563");
            }


            void Search(string[] output, string search)
            {
                number = 1;
                PrintTableCap();
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < output[i].Length; j++)
                    {
                        if (output[i][j] == ' ')
                            break;

                        if (search.ToLower()[0] == output[i].ToLower()[j])
                        {
                            for (int k = 1; k < search.Length; k++)
                            {
                                if (j + k >= output[i].Length && search.ToLower()[k] != output[i].ToLower()[j + k])
                                    break;
                                if (k == search.Length - 1)
                                    Print(number++, i);
                            }
                            if (0 == search.Length - 1)
                                Print(number++, i);
                        }

                    }
                }
            }

            string InputString(string output)
            {
                Console.Write(output);
                return Console.ReadLine();
            }
        }
    }
}
