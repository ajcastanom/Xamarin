using System;
using MobileFirst.Xamarin.iOS;
using PruebaMobileFirst.Contratos;
using Worklight;

namespace PruebaMobileFirst.iOS.Implementaciones
{
	public class MobileFirstHelper : IMobileFirstHelper
	{
		public IWorklightClient MobileFirstClient
		{
			get
			{
				return WorklightClient.CreateInstance();
			}
		}
	}
}
