namespace OtusHomework
{
    public class Employee : IComparable<Employee>
    {
        public string Name { get; set; }
        public int Salary { get; private set; }


        public Employee(string name, int salary)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            Salary = salary;
        }

        public int CompareTo(Employee? other)
        {
            if (other is null || Salary > other.Salary)
            {
                return 1;
            }
            else if (Salary < other.Salary)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
