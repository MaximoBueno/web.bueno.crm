using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using web.bueno.crm.domain.sql;
using AutoMapper;

namespace web.bueno.crm.aplication.UsesCases.UseCaseContacto.ListarContactoPorGestor
{
    public class ListarContactoPorGestorMapper : Profile
    {
        public ListarContactoPorGestorMapper() {

           

            CreateMap<ContactoResponse, Contacto>()
                .ForMember(d => d.ContactoAtenciones, opt => opt.Ignore())
                .ForMember(d => d.ContactoCorreos, opt => opt.Ignore())
                .ForMember(d => d.ContactoDirecciones, opt => opt.Ignore())
                .ForMember(d => d.ContactoResumenes, opt => opt.Ignore())
                .ForMember(d => d.ContactoTelefonos, opt => opt.Ignore());

            CreateMap<Contacto, ContactoResponse>();

        }

    }

}
