namespace OtusHomework
{
    public class Program
    {
        static void Main()
        {
            var tempSalary = 0;

            var storage = new BinaryTreeStorage<Employee>();

            while (true)
            {
                Console.WriteLine("Введите имя сотрудника:");
                string? tempName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(tempName))
                {
                    Console.WriteLine("Ввод сотрудников завершен.");
                    break;
                }

                while (true)
                {
                    Console.WriteLine("Введите заплату сотрудника (целое неотрицательное число):");

                    if (int.TryParse(Console.ReadLine(), out tempSalary) && tempSalary > 0)
                    {
                        storage.Add(new Employee(tempName, tempSalary));
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
    }
}