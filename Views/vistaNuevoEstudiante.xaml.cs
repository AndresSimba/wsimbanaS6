using Newtonsoft.Json;
using System.Text;

namespace wsimbanaS6.Views;

public partial class vistaNuevoEstudiante : ContentPage
{
    private const string URL = "http://172.27.96.1/wsestudiante/restEstudiantes.php";
    private readonly HttpClient cliente = new HttpClient();

    public vistaNuevoEstudiante()
    {
        InitializeComponent();
    }

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        var nuevo = new
        {
            nombre = txtNombre.Text,
            apellido = txtApellido.Text,
            edad = txtEdad.Text
        };

        var json = JsonConvert.SerializeObject(nuevo);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await cliente.PostAsync(URL, content);

        if (response.IsSuccessStatusCode)
        {
            await DisplayAlert("Éxito", "Estudiante registrado", "OK");
            await Navigation.PopAsync(); // Regresa a VistaEstudiante
        }
        else
        {
            await DisplayAlert("Error", "No se pudo registrar", "OK");
        }
    }

}
