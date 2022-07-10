using AutoMapper;
using ProyectoGYM.DOMAIN.Core.DTOs;
using ProyectoGYM.DOMAIN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGYM.DOMAIN.Infrastructure.Mapping
{
    public class AutomapperProfile: Profile 
    {
        public AutomapperProfile()
        {
            CreateMap<TbProductos, ProductosDTO>();
            CreateMap<ProductosDTO, TbProductos>();
            CreateMap<TbProductos, ProductosPostDTO>();
            CreateMap<ProductosPostDTO, TbProductos>();




        }

    }
}
