using wsimbanaS6.Models;
using wsimbanaS6.PageModels;

namespace wsimbanaS6.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}