using Newtonsoft.Json;
using System.Text;
using wsimbanaS6.Models;

namespace wsimbanaS6.Views;

public partial class vistaActElim : ContentPage
{
    private const string URL = "http://172.27.96.1/wsestudiante/restEstudiantes.php";
    private readonly HttpClient cliente = new HttpClient();
    private Estudiante estudiante;

    // Constructor por defecto (necesario para XAML)
    public vistaActElim()
    {
        InitializeComponent();
    }

  
    public vistaActElim(Estudiante est) : this()
    {
        estudiante = est;

   
        txtCodigo.Text = estudiante.codigo.ToString();
        txtNombre.Text = estudiante.nombre;
        txtApellido.Text = estudiante.apellido;
        txtEdad.Text = estudiante.edad.ToString();
    }


    private async void OnActualizarClicked(object sender, EventArgs e)
    {
        var actualizado = new
        {
            codigo = estudiante.codigo,
            nombre = txtNombre.Text,
            apellido = txtApellido.Text,
            edad = txtEdad.Text
        };

        var json = JsonConvert.SerializeObject(actualizado);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await cliente.PutAsync(URL + "?codigo=" + estudiante.codigo, content);

        if (response.IsSuccessStatusCode)
        {
            await DisplayAlert("Éxito", "Estudiante actualizado", "OK");
            await Navigation.PopAsync(); 
        }
        else
        {
            await DisplayAlert("Error", "No se pudo actualizar", "OK");
        }
    }


    private async void OnEliminarClicked(object sender, EventArgs e)
    {
        var response = await cliente.DeleteAsync(URL + "?codigo=" + estudiante.codigo);

        if (response.IsSuccessStatusCode)
        {
            await DisplayAlert("Éxito", "Estudiante eliminado", "OK");
            await Navigation.PopAsync(); 
        }
        else
        {
            await DisplayAlert("Error", "No se pudo eliminar", "OK");
        }
    }
}
