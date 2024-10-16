namespace ST10294145_prog_2.Models
{
    public class Claim
    {
        public int Id { get; set; }
        public string LecturerName { get; set; }
        public double HoursWorked { get; set; }
        public double HourlyRate { get; set; }
        public string Status { get; set; } = "Pending";
        public string SupportingDocument { get; set; }
    }
}
