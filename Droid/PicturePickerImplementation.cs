using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Android.Content;
using Contatos.Droid;
using Contatos.Pages;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(PicturePickerImplementation))]
namespace Contatos.Droid
{
    public class PicturePickerImplementation : IPicturePicker
    {
        public PicturePickerImplementation()
        {
        }

        public Task<Stream> GetImageStreamAsync()
        {
            // Define the Intent for getting images
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);

            // Get the MainActivity instance
            MainActivity activity = Forms.Context as MainActivity;

            // Start the picture-picker activity (resumes in MainActivity.cs)
            activity.StartActivityForResult(
                Intent.CreateChooser(intent, "Select Picture"),
                MainActivity.PickImageId);

            // Save the TaskCompletionSource object as a MainActivity property
            activity.PickImageTaskCompletionSource = new TaskCompletionSource<Stream>();

            // Return Task object
            return activity.PickImageTaskCompletionSource.Task;
        }
    }
}
