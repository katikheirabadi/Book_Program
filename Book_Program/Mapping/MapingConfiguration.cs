using AutoMapper;
using Book_Program.DTO.PublicationDtos;
using Book_Program.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Program.Mapping
{
    public class MapingConfiguration:Profile
    {
        public MapingConfiguration()
        {
            CreateMap<InsertPubllicationinputDTO, Publication>().ForMember(x => x.Name , y=> y.MapFrom(p=>p.Name));
            //estefade kon...
        }
    }
}
