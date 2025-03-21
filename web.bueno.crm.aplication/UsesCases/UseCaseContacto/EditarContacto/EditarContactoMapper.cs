﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using web.bueno.crm.domain.sql;

namespace web.bueno.crm.aplication.UsesCases.UseCaseContacto.EditarContacto
{
    public class EditarContactoMapper : Profile
    {
        public EditarContactoMapper() {
            CreateMap<EditarContactoRequest, Contacto>()
                       .ForMember(d => d.ContactoAtenciones, opt => opt.Ignore())
                       .ForMember(d => d.ContactoCorreos, opt => opt.Ignore())
                       .ForMember(d => d.ContactoDirecciones, opt => opt.Ignore())
                       .ForMember(d => d.ContactoResumenes, opt => opt.Ignore())
                       .ForMember(d => d.ContactoTelefonos, opt => opt.Ignore());

            CreateMap<Contacto, EditarContactoResponse>();
        }
    }
}
