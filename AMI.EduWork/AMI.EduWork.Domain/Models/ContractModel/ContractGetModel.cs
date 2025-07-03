using AMI.EduWork.Domain.Models.User;

namespace AMI.EduWork.Domain.Models.ContractModel
{
    public class ContractGetModel
    {
        public string Id { get; set; }
        public DateOnly Created { get; set; }
        public int WorkingHour { get; set; }
        public bool IsActive { get; set; }
        public int HourlyRate { get; set; }
        public GetUserModel _GetUserModel { get; set; }
    }
}
