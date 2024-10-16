namespace ST10294145_prog_2.Models
{
    namespace ST10294145_prog_2.Models
    {
        public static class InMemoryData
        {
            public static List<Claim> Claims { get; set; } = new List<Claim>();
            public static List<User> Users { get; set; } = new List<User>
        {
            new User { Username = "lecturer", Password = "password", Role = "Lecturer" },
            new User { Username = "coordinator", Password = "password", Role = "Coordinator" },
            new User { Username = "manager", Password = "password", Role = "Manager" }
        };
        }
    }
}
