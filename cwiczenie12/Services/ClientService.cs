using cwiczenie12.Data;
using Microsoft.EntityFrameworkCore;

namespace cwiczenie12.Services;

public class ClientService : IClientService
{
    private readonly Cw12Context _context;

    public ClientService(Cw12Context context)
    {
        _context = context;
    }

    public async Task<bool> DeleteClient(int idClient)
    {
        var client = await _context.Clients
            .Include(c => c.ClientTrips)
            .FirstOrDefaultAsync(c => c.IdClient == idClient);

        if (client == null)
            return false;

        if (client.ClientTrips.Any())
            return false;

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
        return true;
    }
}