using System;
using System.Threading.Tasks;

namespace AccenturePeoplePCL.Servicios
{
    public interface IContactosService
    {
        Task<bool> Login(string usr, string psw, string tipo);
    }
}
