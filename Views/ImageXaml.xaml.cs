using Microsoft.Maui.Controls;
using ImageZoom.ViewModels;

namespace ImageZoom.Views
{
    public partial class ImageXaml : ContentPage
    {
        public ImageXaml()
        {
            InitializeComponent();
            BindingContext = new TransformImageViewModel();
        }

        private void OnImageSizeChanged(object sender, EventArgs e)
        {
            if (BindingContext is TransformImageViewModel viewModel && sender is MR.Gestures.Image image)
            {
                viewModel.ImageWidth = image.Width;
                viewModel.ImageHeight = image.Height;

                Console.WriteLine($"OnImageSizeChanged: ImageWidth={viewModel.ImageWidth}, ImageHeight={viewModel.ImageHeight}");
            }
        }
    }
}
