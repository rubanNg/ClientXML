using ClientXML.Models;
using ClientXML.Repositories.ClientRepository;
using System.Collections.Generic;
using System.Xml;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using ClientXML.Dto;
using AutoMapper;
using Newtonsoft.Json.Linq;

namespace ClientXML.Services.ClientService
{
    public class ClientService : IClientService
    {
        private readonly MapperConfiguration mapperConfiguration;
        private readonly Mapper mapper = null;

        public ClientService()
        {
            mapperConfiguration = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<ClientCreateDto, Client>();
                cfg.CreateMap<ClientUpdateDto, Client>();
            });
            mapper = new Mapper(mapperConfiguration);
        }

        public List<Client> Parse(string xmlClients)
        {
            var clients = new List<Client>();

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlClients);

            var nodes = xmlDocument.FirstChild.SelectNodes("Client");

            foreach (XmlNode node in nodes)
            {

                clients.Add(new Client
                {
                    CardCode = Convert.ToInt64(node.Attributes["CARDCODE"].Value),
                    StartDate = node.Attributes["STARTDATE"].Value,
                    FinishDate = node.Attributes["FINISHDATE"].Value,
                    LastName = node.Attributes["LASTNAME"].Value,
                    FirstName = node.Attributes["FIRSTNAME"].Value,
                    SurName = node.Attributes["SURNAME"].Value,
                    Gender = node.Attributes["GENDER"].Value,
                    BirthDay = node.Attributes["BIRTHDAY"].Value,
                    PhoneHome = node.Attributes["PHONEHOME"].Value,
                    PhoneMobil = node.Attributes["PHONEMOBIL"].Value,
                    Email = node.Attributes["EMAIL"].Value,
                    City = node.Attributes["CITY"].Value,
                    Street = node.Attributes["STREET"].Value,
                    House = node.Attributes["HOUSE"].Value,
                    Apartment = node.Attributes["APARTMENT"].Value,
                });
            }

            return clients;
        }

        public void Merge(Client target, Client source, Func<Client, string[]> getIgnoredProperties)
        {
            Type type = typeof(Client);

            var ignoredProperties = getIgnoredProperties.Invoke(target);

            var properties = type.GetProperties().Where(prop => prop.CanRead && prop.CanWrite);

            foreach (var property in properties)
            {
                if (ignoredProperties.Contains(property.Name)) continue;

                var value = property.GetValue(source, null);

                if (value != null) property.SetValue(target, value, null);
            }
        }

        public Client MapCreateDtoToModel(ClientCreateDto clientDto)
        {
            return mapper.Map<ClientCreateDto, Client>(clientDto);
        }

        public Client MapUpdateDtoToModel(ClientUpdateDto clientDto)
        {
            return mapper.Map<ClientUpdateDto, Client>(clientDto);
        }
    }
}
