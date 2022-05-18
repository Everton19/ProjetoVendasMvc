using System;

namespace ProjetoAspVendas.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        {
            
        }
    }
}