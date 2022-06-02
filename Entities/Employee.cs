namespace ZoobookExam.Entities
{
    public class Employee
    {
        public int employeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
