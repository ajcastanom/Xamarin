using System;
using System.Threading.Tasks;
using PruebaMobileFirst.Contratos;
using PruebaMobileFirst.iOS.Implementaciones;
using PruebaMobileFirst.Servicios;
using UIKit;

namespace PruebaMobileFirst.iOS
{
    public partial class ViewController : UIViewController
    {
        int count = 1;
        IContactosService contactosService;
        IMobileFirstHelper mobileFirstHelper;
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            mobileFirstHelper = new MobileFirstHelper();
            contactosService = new ContactosService(mobileFirstHelper);
            // Perform any additional setup after loading the view, typically from a nib.
            this.Button.TouchUpInside += delegate
            {
                Login();
            };
        }

		void Login()
		{

			Task.Run(async () =>
			{
				try
				{
					contactosService = new ContactosService(mobileFirstHelper);

                    bool conectado = await contactosService.Login(this.txtUsuario.Text, this.txtClave.Text, string.Empty);
					InvokeOnMainThread(() =>
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

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
    }
}
