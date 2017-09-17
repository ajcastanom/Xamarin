using System;
using System.Threading.Tasks;

namespace PruebaMobileFirst.Servicios
{
    public interface IContactosService
    {
        Task<bool> Login(string usr, string psw, string tipo);
    }
}
