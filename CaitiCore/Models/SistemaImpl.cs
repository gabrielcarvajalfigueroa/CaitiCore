using CaitiCore.Model;
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
        public ProfesorModel _profesorEnSesion { get ; set ; }
        public Curso _cursoEnSesion { get; set; }

        public void ActualizarPlanificacion(List<Semana> semanas)
        {
            List<ProfesorModel> profesores = GetProfesorModels();

            foreach(ProfesorModel profesor in profesores)
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

        public List<ProfesorModel> GetProfesorModels()
        {
            string json = System.IO.File.ReadAllText(@"ProfesoresData.json");

            List<ProfesorModel> Profesores = JsonConvert.DeserializeObject<List<ProfesorModel>>(json);

            return Profesores;
        }

        public void InsertCurso(ProfesorModel profeEnSesion,Curso curso)
        {
            List<ProfesorModel> Profesores = GetProfesorModels();

            for(int i = 0; i < Profesores.Count; i++)
            {
                if(Profesores[i].Nombre == profeEnSesion.Nombre)
                {
                    Profesores[i].Cursos.Add(curso); // Para el update del json
                    
                    _profesorEnSesion.Cursos.Add(curso); // Para mantener el sistema actualizado
                    break;
                }
            }

            var NewJsonData = JsonConvert.SerializeObject(Profesores, Formatting.Indented);

            File.WriteAllText(@"ProfesoresData.json", NewJsonData);

            MessageBox.Show("Curso registrado con exito", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);




        }

        public void InsertProfesorModel(ProfesorModel profesor)
        {

            List<ProfesorModel> Profesores = GetProfesorModels();

            Profesores.Add(profesor);

            var NewJsonData = JsonConvert.SerializeObject(Profesores, Formatting.Indented);

            File.WriteAllText(@"ProfesoresData.json", NewJsonData);
            
            MessageBox.Show("Profesor registrado con exito", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
