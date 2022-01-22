using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDeReservas.Entities.Exceptions
{
    class DomainException : ApplicationException //indico que essa classe será uma subclasse de application exception
    {
        public DomainException (string message) : base(message) //o construtor recebe a mensagem, com base na superclasse
        {

        }
    }
}
