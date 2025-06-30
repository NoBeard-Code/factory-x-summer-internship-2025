namespace AMI.EduWork._2025.Domain.Models.ContractModel
{
    public class ContractCreateModel
    {
        public int WorkingHour { get; set; }
        public DateOnly Created {  get; set; }
        public bool IsActive { get; set; }
        public int HourlyRate { get; set; }
        public string UserId{ get; set; }
    }
}
