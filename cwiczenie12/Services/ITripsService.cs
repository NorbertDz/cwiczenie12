using cwiczenie12.Models.DTO;

namespace cwiczenie12.Services;

public interface ITripsService
{
    Task<object> GetTrips(int page = 1, int pageSize = 10);
    Task<bool> AssignClientToTrip(int idTrip, AssignClientDto dto);
}