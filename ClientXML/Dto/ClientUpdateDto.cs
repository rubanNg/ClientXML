using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace ClientXML.Dto
{
    public class ClientUpdateDto: BaseClientDto
    {
        public Guid Id { get; set; }
    }
}
