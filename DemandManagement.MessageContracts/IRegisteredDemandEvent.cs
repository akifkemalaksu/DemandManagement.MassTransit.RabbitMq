namespace DemandManagement.MessageContracts
{
    public interface IRegisteredDemandEvent
    {
        public Guid DemandId { get; set; }
    }
}