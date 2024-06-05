
using ImageZoom.Views;

namespace ImageZoom
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void OnCounterClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ImageXaml());

        }
    }
}
