﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.bueno.crm.domain.sql;

namespace web.bueno.crm.aplication.UsesCases.UseCaseContacto.ListarContactoPorGestor
{
    public class ListarContactoPorGestorResponse
    {
        public List<ContactoResponse>? contactos {  get; set; }
    }

    public class ContactoResponse
    {
        public long Id { get; set; }

        public int? IdGestor { get; set; }

        public int? IdGestorAsignado { get; set; }

        public string Nombres { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public int? IdTipoDocumento { get; set; }

        public string NumeroDocumento { get; set; }

        public DateTime? FechaCreacion { get; set; }
    }

}