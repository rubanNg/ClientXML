using ClientXML.Dto;
using ClientXML.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;

namespace ClientXML.Services.ClientService
{
    public interface IClientService
    {
        List<Client> Parse(string xmlClients);
        void Merge(Client target, Client source, Func<Client, string[]> getIgnoredProperties);
        Client MapCreateDtoToModel(ClientCreateDto clientDto);
        Client MapUpdateDtoToModel(ClientUpdateDto clientDto);
    }
}
