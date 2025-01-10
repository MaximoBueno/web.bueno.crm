using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using web.bueno.crm.domain.sql;

namespace web.bueno.crm.aplication.UsesCases.UseCaseContacto.CrearContacto
{
    public class CrearContactoMapper :Profile
    {
       public CrearContactoMapper() {

            CreateMap<CrearContactoRequest, Contacto>()
                    .ForMember(d => d.ContactoAtenciones, opt => opt.Ignore())
                    .ForMember(d => d.ContactoCorreos, opt => opt.Ignore())
                    .ForMember(d => d.ContactoDirecciones, opt => opt.Ignore())
                    .ForMember(d => d.ContactoResumenes, opt => opt.Ignore())
                    .ForMember(d => d.ContactoTelefonos, opt => opt.Ignore());

            CreateMap<Contacto, CrearContactoResponse>();


            CreateMap<CrearContactoTelefonoRequest, ContactoTelefono>()
                    .ForMember(d => d.Contactos, opt => opt.Ignore());

            CreateMap<ContactoTelefono, CrearContactoTelefonoResponse>();


            CreateMap<CrearContactoCorreoRequest, ContactoCorreo>()
                    .ForMember(d => d.Contactos, opt => opt.Ignore());

            CreateMap<ContactoCorreo, CrearContactoCorreoResponse>();

        }

    }

}
