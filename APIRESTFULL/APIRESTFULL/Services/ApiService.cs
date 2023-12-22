using APIRESTFULL.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIRESTFULL.Services
{
    public class ApiService
    {
        private const string UrlApi = "https://thesimpsonsquoteapi.glitch.me/quotes"; 

        public async Task<List<Personaje>> ObtenerPersonajes()
        {
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync(UrlApi);

                    if (respuesta.IsSuccessStatusCode)
                    {
                        string contenido = await respuesta.Content.ReadAsStringAsync();
                        var personajes = JsonConvert.DeserializeObject<List<Personaje>>(contenido);

                        foreach (var personaje in personajes)
                        {
                            personaje.CharacterImage = ObtenerUrlImagen(personaje.Character);

                        }
                        return personajes;
                    }
                    else
                    {
                        // Manejar el error según sea necesario
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones
                return null;
            }
        }

        private string ObtenerUrlImagen(string character)
        {
            return $"https://cdn.glitch.com/3c3ffadc-3406-4440-bb95-d40ec8fcde72%2F{character.Replace(" ", "")}.png";
        }
    }
}
    
