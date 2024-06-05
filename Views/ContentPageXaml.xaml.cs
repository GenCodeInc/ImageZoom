
namespace ImageZoom.Views;

public partial class ContentPageXaml
{
	public ContentPageXaml()
	{
        BindingContext = new ViewModels.TransformImageViewModel();
        InitializeComponent();
	}
}
