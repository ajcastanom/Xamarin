using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PruebaMobileFirst.MobileFirst.Conector;
using PruebaMobileFirst.MobileFirst.Resultado;
using PruebaMobileFirst.MobileFirst.Seguridad;
using PruebaMobileFirst.Utilidades;
using Worklight;

namespace PruebaMobileFirst.MobileFirst.Reporitorio
{
	public class MobileFirstRepository<T> 
	{

		IWorklightClient client;

		public IWorklightClient Client
		{
			get
			{
				return client;
			}

			set
			{
				client = value;
			}
		}

		public string Endpoint { get; set; }

		public string Scopes { get; set; }

		public SecurityChallengeHandler challenge { get; set; }

		public void AddChallenge(string securityCheck, JObject challengeAnswer)
		{
			this.challenge = new SecurityChallengeHandler(securityCheck, challengeAnswer);
			this.client.RegisterChallengeHandler(challenge);
		}

		public async Task<MobileFirstResult> GetDataPOST(T entity)
		{
			MobileFirstConnector connector = new MobileFirstConnector(this.client);

			MobileFirstResult result = await connector.GetServices(this.Endpoint, MethodService.POST, JsonFormatter.SerializeJObject<T>(entity), this.Scopes);

			return result;
		}

		public async Task<MobileFirstResult> GetDataForm(Dictionary<string, string> entity)
		{
			MobileFirstConnector connector = new MobileFirstConnector(this.client);

			MobileFirstResult result = await connector.GetServicesForm(this.Endpoint, MethodService.POST, entity, this.Scopes);

			return result;
		}

		public async Task<MobileFirstResult> SetDataPOST(T entity)
		{
			MobileFirstConnector connector = new MobileFirstConnector(this.client);

			MobileFirstResult result = await connector.GetServices(this.Endpoint, MethodService.POST, JsonFormatter.SerializeJObject<T>(entity), this.Scopes);

			return result;
		}

		public async Task<MobileFirstResult> SubmitLoginChallenge(string securityChallenge, JObject challengeAnswer)
		{
			MobileFirstConnector connector = new MobileFirstConnector(this.client);

			MobileFirstResult result = await connector.SubmitLoginChallenge(securityChallenge, challengeAnswer);

			return result;

		}

		public async Task<MobileFirstResult> SubmitLogoutChallenge(string securityChallenge)
		{
			MobileFirstConnector connector = new MobileFirstConnector(this.client);

			MobileFirstResult result = await connector.SubmitLogoutChallenge(securityChallenge);

			return result;

		}

		public async Task<MobileFirstResult> GetAccessToken(string securityChallenge)
		{
			MobileFirstConnector connector = new MobileFirstConnector(this.client);

			var result = await connector.GetAccessToken(securityChallenge);

			return result;

		}
	}
}
