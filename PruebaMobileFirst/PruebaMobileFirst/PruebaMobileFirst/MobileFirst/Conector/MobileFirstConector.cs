using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PruebaMobileFirst.MobileFirst.Resultado;
using Worklight;

namespace PruebaMobileFirst.MobileFirst.Conector
{
	public class MobileFirstConnector
	{

		IWorklightClient client;

		public MobileFirstConnector(IWorklightClient client)
		{
			this.client = client;
		}

		public async Task<MobileFirstResult> GetServices(string endpoint, MethodService method, JObject parameters, string scopes)
		{
			MobileFirstResult result = new MobileFirstResult();

			try
			{
				StringBuilder build = new StringBuilder().Append(endpoint);

				WorklightResourceRequest request;

				if (String.IsNullOrEmpty(scopes))
				{
					request = this.client.ResourceRequest(new Uri(build.ToString(), UriKind.Relative), method.ToString());
				}
				else
				{
					request = this.client.ResourceRequest(new Uri(build.ToString(), UriKind.Relative), method.ToString(), scopes);
				}

				WorklightResponse respuesta;

				if (parameters != null)
				{
					string param = JsonConvert.SerializeObject(parameters);
					respuesta = await request.Send(parameters);
				}
				else
				{
					respuesta = await request.Send();
				}
				result.Success = respuesta.Success;
				result.Message = respuesta.Message;
				result.CodeStatus = respuesta.HTTPStatus;
				result.Response = JsonConvert.SerializeObject(respuesta.ResponseJSON);
			}
			catch (Exception ex)
			{
				result.CodeStatus = ex.HResult;
				result.Success = false;
				result.Message = ex.Message;
				result.Response = "";
			}

			return result;
		}

		public async Task<MobileFirstResult> SubmitLoginChallenge(string securityCheck, JObject challengeAnswer)
		{
			MobileFirstResult result = new MobileFirstResult();

			var resultChallenge = await this.client.AuthorizationManager.Login(securityCheck, challengeAnswer);
			//var resultChallenge = await this.client.AuthorizationManager.IsAuthorizationRequired();

			result.Success = resultChallenge.Success;
			result.Message = resultChallenge.Message;
			result.CodeStatus = resultChallenge.HTTPStatus;
			result.Response = JsonConvert.SerializeObject(resultChallenge.ResponseJSON);


			return result;
		}

		public async Task<MobileFirstResult> SubmitLogoutChallenge(string securityCheck)
		{
			MobileFirstResult result = new MobileFirstResult();

			var token = await this.client.AuthorizationManager.ObtainAccessToken(securityCheck);

			var resultChallenge = await this.client.AuthorizationManager.Logout(securityCheck);

			//WorklightAccessToken authenticated = await this.client.AuthorizationManager.ObtainAccessToken(securityCheck);
			//this.client.AuthorizationManager.ClearAccessToken(authenticated);

			result.Success = resultChallenge.Success;
			result.Message = resultChallenge.Message;
			result.CodeStatus = resultChallenge.HTTPStatus;
			result.Response = JsonConvert.SerializeObject(resultChallenge.ResponseJSON);

			return result;
		}

		public async Task<MobileFirstResult> GetAccessToken(string securityCheck)
		{
			MobileFirstResult result = new MobileFirstResult();
			WorklightAccessToken autenticated = await this.client.AuthorizationManager.ObtainAccessToken(securityCheck);

			result.Success = autenticated.Value != null;

			return result;

		}

		public async Task<MobileFirstResult> GetServicesForm(string endpoint, MethodService method, Dictionary<string, string> parameters, string scopes)
		{
			MobileFirstResult result = new MobileFirstResult();

			try
			{
				StringBuilder build = new StringBuilder().Append(endpoint);

				WorklightResourceRequest request;

				if (String.IsNullOrEmpty(scopes))
				{
					request = this.client.ResourceRequest(new Uri(build.ToString(), UriKind.Relative), method.ToString());
				}
				else
				{
					request = this.client.ResourceRequest(new Uri(build.ToString(), UriKind.Relative), method.ToString(), scopes);
				}

				WorklightResponse respuesta;

				if (parameters != null)
				{
					foreach (KeyValuePair<string, string> entry in parameters)
					{
						request.SetQueryParameter(entry.Key, entry.Value);
					}
					respuesta = await request.Send();
				}
				else
				{
					respuesta = await request.Send();
				}
				result.Success = respuesta.Success;
				result.Message = respuesta.Message;
				result.CodeStatus = respuesta.HTTPStatus;
				result.Response = JsonConvert.SerializeObject(respuesta.ResponseJSON);
			}
			catch (Exception ex)
			{
				result.CodeStatus = ex.HResult;
				result.Success = false;
				result.Message = ex.Message;
				result.Response = "";
			}

			return result;
		}
	}

	public enum MethodService
	{
		POST,

		GET
	}
}
