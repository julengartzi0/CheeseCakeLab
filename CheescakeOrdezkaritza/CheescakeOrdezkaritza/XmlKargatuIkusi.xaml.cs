using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage; // Para FilePicker
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;       // Para XDocument
using System.Linq;

namespace CheescakeOrdezkaritza
{
    public partial class XmlKargatuPage : ContentPage
    {
        public XmlKargatuPage()
        {
            InitializeComponent();
        }

        private async void OnSelectXmlClicked(object sender, EventArgs e)
        {
            try
            {
                loadingIndicator.IsRunning = true;
                lblEstado.Text = "Kargatzen...";

                // Definimos los tipos de archivos permitidos para cada plataforma
                var fileType = new FilePickerFileType(
                    new Dictionary<DevicePlatform, IEnumerable<string>>
                    {
                        { DevicePlatform.Android, new[] { "application/xml" } },
                        { DevicePlatform.iOS, new[] { "public.xml" } },
                        { DevicePlatform.WinUI, new[] { ".xml" } },
                        { DevicePlatform.MacCatalyst, new[] { "public.xml" } }
                    }
                );

                // Abre el selector de archivos con la restricción de solo XML
                var result = await FilePicker.Default.PickAsync(new PickOptions
                {
                    PickerTitle = "XML fitxategi bat aukeratu",
                    FileTypes = fileType
                });

                if (result != null)
                {
                    // Limpiamos el contenedor por si ya tenía contenido de otra vez
                    stackContainer.Children.Clear();

                    // Leemos el contenido del archivo
                    var xmlContent = File.ReadAllText(result.FullPath);

                    // Actualizamos el estado
                    lblEstado.Text = $"Fitxategia kargatua: {result.FileName}";

                    // Parseamos como XDocument
                    XDocument doc = XDocument.Parse(xmlContent);

                    // Tomamos la raíz (por ejemplo <Partner>, <Stock>, etc.)
                    var root = doc.Root;
                    if (root != null)
                    {
                        // Agregamos un label para indicar el nombre del elemento raíz
                        stackContainer.Children.Add(new Label
                        {
                            Text = $"Root: {root.Name.LocalName}",
                            FontAttributes = FontAttributes.Bold,
                            FontSize = 18
                        });

                        // Para cada elemento hijo de la raíz, creamos un label con "Nombre: Valor"
                        foreach (var element in root.Elements())
                        {
                            stackContainer.Children.Add(new Label
                            {
                                Text = $"{element.Name.LocalName}: {element.Value}"
                            });
                        }
                    }
                    else
                    {
                        // Caso donde el XML está vacío o la raíz no se puede leer
                        stackContainer.Children.Add(new Label
                        {
                            Text = "XML hutsa edo ezin izan da root-a irakurri."
                        });
                    }
                }
                else
                {
                    lblEstado.Text = "Ez da fitxategirik aukeratu";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Errorea", $"Errorea XML prozesatzean: {ex.Message}", "Ados");
                lblEstado.Text = "Errorea kargatzean";
            }
            finally
            {
                loadingIndicator.IsRunning = false;
            }
        }
    }
}
