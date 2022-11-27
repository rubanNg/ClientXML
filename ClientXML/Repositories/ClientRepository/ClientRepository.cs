using ClientXML.Context;
using ClientXML.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;

namespace ClientXML.Repositories.ClientRepository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationContext applicationContext;
        private bool disposed = false;

        public ClientRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        async public Task<Client> GetByCardCodeAsync(long cardCode) 
        {
            var client = applicationContext.Clients.FirstOrDefaultAsync(s => s.CardCode == cardCode);
            return await client;
        }

        async public Task<List<Client>> GetAllAsync()
        {
            var clients = applicationContext.Clients.ToListAsync();
            return await clients;
        }

        async public Task<Client> GetAsync(Guid id)
        {
            var client = applicationContext.Clients.FirstOrDefaultAsync(s => s.Id == id);
            return await client;
        }

        async public Task CreateAsync(Client client)
        {
            applicationContext.Clients.Add(client);
            await applicationContext.SaveChangesAsync();
        }

        async public Task CreateRangeAsync(IEnumerable<Client> clients)
        {
            applicationContext.Clients.AddRange(clients);
            await applicationContext.SaveChangesAsync();
        }

        async public Task DeleteAsync(Guid id)
        {
            await Task.FromResult(true);
        }

        async public Task DeleteRangeAsync(IEnumerable<Guid> ids)
        {
            await Task.FromResult(true);
        }

        async public Task UpdateAsync(Client client)
        {
            ModifyState(new List<Client> { client }, EntityState.Modified);
            await applicationContext.SaveChangesAsync();
        }

        async public Task UpdateRangeAsync(IEnumerable<Client> clients)
        {

            ModifyState(clients, EntityState.Modified);
            await applicationContext.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing) applicationContext.Dispose();
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void ModifyState(IEnumerable<Client> clients, EntityState state) 
        {
            foreach (var client in clients)
            {
                var entry = applicationContext.Entry(client);
                entry.State = state;
            }
        }

    }
}
