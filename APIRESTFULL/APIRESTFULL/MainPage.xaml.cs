using APIRESTFULL.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace APIRESTFULL
{
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel viewModel = new MainViewModel();
        public MainPage()
        {
            InitializeComponent();

        }

        private async void OnObtenerDatosClicked(object sender, EventArgs e)
        {
            await viewModel.CargarPersonajes();
            PersonajesListView.ItemsSource = viewModel.Personajes;
        }
    }
}