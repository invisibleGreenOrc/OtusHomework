using System.Text;

namespace OtusHomework
{
    public static class Program
    {
        private static BinaryTreeStorage<Employee> _storage = new();

        static void Main()
        {
            while (true)
            {
                GetUserInputAndCreateEmployees();

                PrintAscSortedEmplyees();

                FindAndPrintEmpoyee(); 
            }
        }

        private static void GetUserInputAndCreateEmployees()
        {
            _storage = new BinaryTreeStorage<Employee>();

            while (true)
            {
                Console.WriteLine("Введите имя сотрудника:");
                string? tempName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(tempName))
                {
                    Console.WriteLine("Ввод сотрудников завершен.\n");
                    break;
                }

                while (true)
                {
                    Console.WriteLine("Введите заплату сотрудника (целое неотрицательное число):");

                    if (int.TryParse(Console.ReadLine(), out int tempSalary) && tempSalary >= 0)
                    {
                        _storage.Add(new Employee(tempName, tempSalary));
                        Console.WriteLine("Сотрудник добавлен");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Не удалось распознать зарплату, введите целое неотрицательное число:");
                    }
                }
            }
        }

        private static void PrintAscSortedEmplyees()
        {
            var sb = new StringBuilder();
            var employees = _storage.GetAscSortedList();

            sb.AppendLine("Список сотрудников \"Имя - Зарплата\" по возрастанию зарплат:");

            foreach (Employee employee in employees)
            {
                sb.AppendLine(employee.ToString());
            }

            Console.WriteLine(sb.ToString());
        }

        private static void FindAndPrintEmpoyee()
        {
            while (true)
            {
                while (true)
                {
                    Console.WriteLine("Введите размер зарплаты для поиска сотрудников (целое число):");

                    if (int.TryParse(Console.ReadLine(), out int salary))
                    {
                        var person = _storage.Find(new Employee("Для поиска", salary));

                        if (person is null)
                        {
                            Console.WriteLine("Такой сотрудник не найден.");
                        }
                        else
                        {
                            Console.WriteLine($"Сотрудник найден:\n{person}");
                        }

                        break;
                    }
                    else
                    {
                        Console.WriteLine("Не удалось распознать зарплату, введите целое число:");
                    }
                }

                string input;

                while (true)
                {
                    Console.WriteLine("Введите 0 для перехода к началу программы, 1 - для поиска сотрудника:");
                    input = Console.ReadLine();

                    if (input == "0" || input == "1")
                    {
                        break;
                    }

                    Console.WriteLine("Введена неверная команда.");
                }

                if (input == "0")
                {
                    break;
                }
            }
        }
    }
}