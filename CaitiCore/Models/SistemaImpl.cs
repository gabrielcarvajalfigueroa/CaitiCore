using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaitiCore.Models
{
    public class SistemaImpl : Sistema
    {
        public Profesor _profesorEnSesion { get ; set ; }
        public Curso _cursoEnSesion { get; set; }

        public void ActualizarPlanificacion(List<Semana> semanas)
        {
            List<Profesor> profesores = GetProfesorModels();

            foreach(Profesor profesor in profesores)
            {
                if(profesor.Nombre == _profesorEnSesion.Nombre)
                {
                   foreach(Curso curso in profesor.Cursos)
                    {
                        if(curso.Nombre_Curso == _cursoEnSesion.Nombre_Curso)
                        {
                            curso.Planificacion_Curso.Semanas = semanas;
                            break;
                        }
                    }
                    break;
                }
            }
            var NewJsonData = JsonConvert.SerializeObject(profesores, Formatting.Indented);

            File.WriteAllText(@"ProfesoresData.json", NewJsonData);

            MessageBox.Show("Planificacion guardada con exito", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);

        }

        public Planificacion CrearPlanificacionDefault()
        {
            // Esta funcion crea las 16 semanas por defecto y añade una clase vacia a cada semana
            Planificacion planificacion = new Planificacion();

            Clase clase = new Clase();

            clase.Id_Clase = "1";
          
            for(int i = 1; i <= 16; i++)
            {
                Semana semana = new Semana();

                semana.Id_Semana = i.ToString();

                semana.Clases.Add(clase);

                planificacion.Semanas.Add(semana);
            }
            
            
            return planificacion;
        }

        public List<Profesor> GetProfesorModels()
        {
            string json = System.IO.File.ReadAllText(@"ProfesoresData.json");

            List<Profesor> Profesores = JsonConvert.DeserializeObject<List<Profesor>>(json);

            return Profesores;
        }
        
        
    }
}
