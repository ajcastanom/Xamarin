using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Runtime;
using Android.Net;

namespace Choose.image.android
{
    [Activity(Label = "Choose.image.android", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button buttonChooseImage;
        ImageView imageViewShowImage;

        public static readonly int PickImageId = 1000;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            buttonChooseImage = FindViewById<Button>(Resource.Id.buttonChooseImage);
            imageViewShowImage = FindViewById<ImageView>(Resource.Id.imageViewShowImage);

            buttonChooseImage.Click += ButtonChooseImage_Click;
        }

        private void ButtonChooseImage_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent();
            intent.SetType("image/*");

            intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(intent, "Select Picture"), PickImageId);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null))
            {
                Uri uri = data.Data;
                Toast.MakeText(this, "La url de la imagen seleccionada: " + uri, ToastLength.Short).Show();
                imageViewShowImage.SetImageURI(uri);
            }
        }
    }
}

