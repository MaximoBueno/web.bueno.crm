﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.bueno.crm.aplication.Common
{
    public class ApplicationException : Exception
    {
        public ApplicationException() { }

        public ApplicationException(string message) : base(message) { }

        public ApplicationException(string message, Exception innerException) : base(message, innerException) { }

    }
}
