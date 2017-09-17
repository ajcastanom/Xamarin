using System;
using Plugin.CurrentActivity;
using PruebaMobileFirst.Contratos;
using Worklight;
using Worklight.Xamarin.Android;

namespace PruebaMobileFirst.Droid.Implementaciones
{
	public class MobileFirstHelper : IMobileFirstHelper
	{
		public IWorklightClient MobileFirstClient
		{
			get
			{
				return WorklightClient.CreateInstance(CrossCurrentActivity.Current.Activity);
			}
		}
	}
}
