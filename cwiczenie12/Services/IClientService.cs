namespace cwiczenie12.Services;

public interface IClientService
{
    Task<bool> DeleteClient(int idClient);
}