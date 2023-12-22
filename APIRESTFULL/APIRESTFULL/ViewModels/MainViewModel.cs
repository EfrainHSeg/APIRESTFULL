using APIRESTFULL.Modelo;
using APIRESTFULL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace APIRESTFULL.ViewModels
{
    public class MainViewModel
    {
        private readonly ApiService apiService = new ApiService();

        public ObservableCollection<Personaje> Personajes { get; set; } = new ObservableCollection<Personaje>();

        public async Task CargarPersonajes()
        {
            var personajes = await apiService.ObtenerPersonajes();

            if (personajes != null)
            {
                foreach (var personaje in personajes)
                {
                    Personajes.Add(personaje);
                }
            }
            else
            {
                Console.WriteLine("Error al obtener personajes desde la API");
            }
        }
    }
}
    

