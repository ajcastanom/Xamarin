using System;
using Plugin.CurrentActivity;
using AccenturePeoplePCL.Contratos;
using Worklight;
using Worklight.Xamarin.Android;

namespace AccenturePeople.android.Implementations
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
