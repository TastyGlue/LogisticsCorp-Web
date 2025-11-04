namespace LogisticsCorp.API.Interfaces
{
    public interface IUserShipmentService
    {
        Task<CustomResult> GetAll(Guid id);
    }
}
