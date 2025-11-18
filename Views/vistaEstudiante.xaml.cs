using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using wsimbanaS6.Models;

public partial class vistaEstudiante : ContentPage
{
    private const string Url = "http://10.1.1.141/wesestudiante/rest/estudiantes.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Estudiante> _estudiante;
    public async void Mostrar()
    {
        try
        {
            var content = await cliente.GetStringAsync(Url);
            List<Estudiante> mostrarEst = JsonConvert.DeserializeObject<List<Estudiante>>(content);
            _estudiante = new ObservableCollection<Estudiante>(mostrarEst);
            listaEstudiantes.ItemsSource = _estudiante;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"No se pudo cargar los datos: {ex.Message}", "OK");
        }
    }
    public vistaEstudiante()
    {
        InitializeComponent();
    }
    https://github.com/ElvinSanchez/esanchezS6
   
}
