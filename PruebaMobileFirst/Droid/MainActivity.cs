using Android.App;
using Android.Widget;
using Android.OS;
using PruebaMobileFirst.Servicios;
using PruebaMobileFirst.Contratos;
using System.Threading.Tasks;
using System;
using PruebaMobileFirst.Droid.Implementaciones;
using Plugin.CurrentActivity;

namespace PruebaMobileFirst.Droid
{
    [Activity(Label = "PruebaMobileFirst", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
		IContactosService contactosService;
		IMobileFirstHelper mobileFirstHelper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
			mobileFirstHelper = new MobileFirstHelper();
            contactosService = new ContactosService(mobileFirstHelper);
            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += delegate { 
                Login();
            };
        }

		public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
		{
			CrossCurrentActivity.Current.Activity = activity;
		}

		public void OnActivityResumed(Activity activity)
		{
			CrossCurrentActivity.Current.Activity = activity;
		}

		public void OnActivityStarted(Activity activity)
		{
			CrossCurrentActivity.Current.Activity = activity;
		}

		void Login()
		{

			Task.Run(async () =>
			{
				try
				{
					

                    TextView usuario = FindViewById<TextView>(Resource.Id.txtUsuario);
                    TextView clave = FindViewById<TextView>(Resource.Id.txtClave);

					bool conectado = await contactosService.Login(usuario.Text, clave.Text, string.Empty);
					RunOnUiThread(() =>
                    {

                    });
				}
				catch (Exception ex)
				{

				}
				finally
				{

				}
			});
		}
    }
}

