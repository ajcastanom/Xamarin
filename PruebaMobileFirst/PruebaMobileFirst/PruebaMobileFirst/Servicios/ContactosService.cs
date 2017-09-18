using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaMobileFirst.Contratos;
using PruebaMobileFirst.MobileFirst.Reporitorio;
using PruebaMobileFirst.MobileFirst.Resultado;

namespace PruebaMobileFirst.Servicios
{
    public class ContactosService : IContactosService
    {

        IMobileFirstHelper mobileFirstHelper;

        public ContactosService(IMobileFirstHelper mobileFirstHelper)
        {
            this.mobileFirstHelper = mobileFirstHelper;
        }

        public async Task<bool> Login(string usr, string psw, string tipo)
        {
            MobileFirstRepository<String> repository = new MobileFirstRepository<string>();
            Dictionary<string, string> parametros = new Dictionary<string, string>();

            parametros.Add("UserName", usr);
            parametros.Add("Password", psw);


			repository.Client = this.mobileFirstHelper.MobileFirstClient;
			repository.Endpoint = "/adapters/contactsAdapter/contactos/token";
			repository.Scopes = "";

			MobileFirstResult response = await repository.GetDataForm(parametros);

            return response.Success;

        }
    }
}
