using ClientXML.Models;
using System;
using System.Threading.Tasks;

namespace ClientXML.Repositories.ClientRepository
{
    public interface IClientRepository: IRepository<Client, Guid>
    {
        Task<Client> GetByCardCodeAsync(long id);
    }
}
