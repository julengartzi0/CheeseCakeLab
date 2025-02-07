using Microsoft.Maui.Controls;
using Syncfusion.Maui.Calendar;

namespace CheescakeOrdezkaritza
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            // Cargar Google Maps con iframe
            MapView.Source = new HtmlWebViewSource
            {
                Html = @"
                    <html>
                    <body style='margin:0;padding:0;'>
                        <iframe 
                            width='100%' 
                            height='100%' 
                            frameborder='0' 
                            style='border:0' 
                            referrerpolicy='no-referrer-when-downgrade'
                            src='https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d727.7206861591912!2d-2.068839830358238!3d43.148991476635985!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xd504b6900588037%3A0xbaa343d5f58fb872!2sTolosaldea%20Lanbide%20Heziketako%20Ikastetxe%20Integratua!5e0!3m2!1ses!2ses!4v1737717857774!5m2!1ses!2ses'
                            allowfullscreen>
                        </iframe>
                    </body>
                    </html>"
            };
        }

        // Abre la aplicación de correo con mailto
        private async void OnContactClicked(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("mailto:contacto@tuempresa.com");
        }

    

    private async void OnCargarXmlClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new XmlKargatuPage());
        }

    }
}
