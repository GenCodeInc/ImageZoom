using Microsoft.Maui.Controls;
using ImageZoom.ViewModels;

namespace ImageZoom.Views
{
    public partial class ImageXaml 
    {
        public ImageXaml()
        {
            InitializeComponent();
            BindingContext = new TransformImageViewModelImageTest();
        }

    }
}
