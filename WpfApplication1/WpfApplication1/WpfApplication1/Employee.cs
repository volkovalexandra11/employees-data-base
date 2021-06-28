namespace WpfApplication1
{
    public class Employee
    {
        public Employee(string surname, string name, string secondName)
        {
            Surname = surname;
            Name = name;
            SecondName = secondName;
        }

        public Employee(string fullName)
        {
            var parts = fullName.Split();
            Surname = parts[0];
            Name = parts[1];
            SecondName = parts[2];
        }

        public string Name { get; }
        public string Surname { get; }
        public string SecondName { get; }
        public int Id { get; set; }
    }
}