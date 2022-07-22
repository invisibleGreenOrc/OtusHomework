namespace OtusHomework
{
    public class Employee : IComparable<Employee>
    {
        private string _name;
        private int _salary;

        public Employee(string name, int salary)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            _name = name;
            _salary = salary;
        }

        public int CompareTo(Employee? other)
        {
            throw new NotImplementedException();
        }
    }
}
