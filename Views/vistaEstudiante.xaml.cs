using Newtonsoft.Json;
using System.Collections.ObjectModel;
using wsimbanaS6.Models;

namespace wsimbanaS6.Views;

public partial class vistaEstudiante : ContentPage
{
    private const string URL = "http://172.27.96.1/wsestudiante/restEstudiantes.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Estudiante> _Estudiantes;

    public vistaEstudiante()
    {
        InitializeComponent();
        mostrar(); // carga inicial
    }


    public async void mostrar()
    {
        var content = await cliente.GetStringAsync(URL); // GET
        List<Estudiante> lista = JsonConvert.DeserializeObject<List<Estudiante>>(content);
        _Estudiantes = new ObservableCollection<Estudiante>(lista);
        lvEstudiante.ItemsSource = _Estudiantes;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        mostrar(); // refresca cada vez que regresa a esta vista
    }

    private async void btnRegistroNuevo_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new vistaNuevoEstudiante());
    }

    private async void lvEstudiante_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is Estudiante estudianteSeleccionado)
        {
            ((ListView)sender).SelectedItem = null; // limpia selección
            await Navigation.PushAsync(new vistaActElim(estudianteSeleccionado));
        }
    }

}

