namespace ImageZoom.Views;

public partial class ImageXaml 
{
	public ImageXaml()
	{
        BindingContext = new ViewModels.TransformImageViewModel();
        InitializeComponent();
    }
}