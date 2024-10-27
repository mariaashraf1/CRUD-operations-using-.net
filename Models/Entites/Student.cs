namespace studentPortal.web.Models.Entites
{
    public class Student
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string email { get; set; }
        public string Phone { get; set; }
        public bool subcribed { get; set; }
    }
}
