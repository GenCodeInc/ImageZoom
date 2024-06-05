
//using ImageView.Views;
using ImageZoom.ViewModels;
using ImageZoom.Views;

namespace ImageZoom
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void OnTestImageXamlClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ImageXaml());

        }
        private void OnTestContentPageXamlClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ContentPageXaml());

        }


    }
}
