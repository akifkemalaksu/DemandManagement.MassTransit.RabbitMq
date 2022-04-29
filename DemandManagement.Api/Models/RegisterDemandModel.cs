using DemandManagement.MessageContracts;

namespace DemandManagement.Api.Models
{
    public class RegisterDemandModel : IRegisterDemandCommand
    {
        public string Subject { get; set; }
        public string Description { get; set; }
    }
}