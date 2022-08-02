using System;

namespace VendasWeb.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(String message) : base(message)
        {
        }
    }
}
