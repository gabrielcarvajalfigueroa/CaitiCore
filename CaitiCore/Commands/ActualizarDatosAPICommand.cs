using CaitiCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaitiCore.Commands
{
    public class ActualizarDatosAPICommand : CommandBase
    {        

        static HttpClient client = new HttpClient();

        public override void Execute(object parameter)
        {           

            // Consigue los datos desde la api
            Task<string> datosAPI = conseguirdata();            

        }

        public async Task<string> conseguirdata()
        {
            string project = await GetAPIAsync("https://losvilos.ucn.cl/eross/la_oferta.json");


            return project;
        }

        public async Task<string> GetAPIAsync(string path)

        {

            string dataJson = null;

            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)

            {
                dataJson = await response.Content.ReadAsStringAsync();
                
                List<DatoAPI> DatosAPIS = JsonConvert.DeserializeObject<List<DatoAPI>>(dataJson);                

                var NewJsonData = JsonConvert.SerializeObject(DatosAPIS, Formatting.Indented);                

                File.WriteAllText(@"la_oferta.json", NewJsonData);
               
                // Mensaje de exito
                MessageBox.Show("Base de datos Actualizada", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }

            return dataJson;

        }

    }
}
