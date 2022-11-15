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
            string json = File.ReadAllText(@"ProfesoresData.json");

            List<Profesor> Profesores = JsonConvert.DeserializeObject<List<Profesor>>(json);

            return Profesores;
        }

        public void InsertarAspAdmin(string AspAdmin, Profesor profesorEnSesion, Curso cursoEnSesion)
        {
            List<Profesor> profesores = GetProfesorModels();

            foreach (Profesor profesor in profesores)
            {
                if (profesor.Nombre == profesorEnSesion.Nombre)
                {
                    foreach (Curso curso in profesor.Cursos)
                    {
                        if (curso.Nombre_Curso == cursoEnSesion.Nombre_Curso)
                        {
                            curso.Asp_Administrativo = AspAdmin;
                            break;
                        }
                    }
                    break;
                }
            }

            GuardarData(profesores, "Aspecto Administrativo guardado con exito");            
        }

        public void InsertarAyudante(Ayudante ayudante, Profesor profesorEnSesion, Curso cursoEnSesion)
        {
            List<Profesor> profesores = GetProfesorModels();

            foreach (Profesor profesor in profesores)
            {
                if (profesor.Nombre == profesorEnSesion.Nombre)
                {
                    foreach (Curso curso in profesor.Cursos)
                    {
                        if (curso.Nombre_Curso == cursoEnSesion.Nombre_Curso)
                        {
                            curso.Ayudantes.Add(ayudante);
                            break;
                        }
                    }
                    break;
                }
            }

            GuardarData(profesores, "Ayudante guardado con exito");
        }

        public void InsertarProposito(string Proposito, Profesor profesorEnSesion, Curso cursoEnSesion)
        {
            List<Profesor> profesores = GetProfesorModels();

            foreach (Profesor profesor in profesores)
            {
                if (profesor.Nombre == profesorEnSesion.Nombre)
                {
                    foreach (Curso curso in profesor.Cursos)
                    {
                        if (curso.Nombre_Curso == cursoEnSesion.Nombre_Curso)
                        {
                            curso.Proposito = Proposito;
                            break;
                        }
                    }
                    break;
                }
            }

            GuardarData(profesores, "Proposito guardado con exito");            
        }

        public void GuardarData(List<Profesor> profesores, string mensajeNotificacion)
        {
            var NewJsonData = JsonConvert.SerializeObject(profesores, Formatting.Indented);

            File.WriteAllText(@"ProfesoresData.json", NewJsonData);

            MessageBox.Show(mensajeNotificacion, "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void InsertarRA(ResultadoAprendizaje resultadoAprendizaje, Profesor profesorEnSesion, Curso cursoEnSesion)
        {
            List<Profesor> profesores = GetProfesorModels();

            foreach (Profesor profesor in profesores)
            {
                if (profesor.Nombre == profesorEnSesion.Nombre)
                {
                    foreach (Curso curso in profesor.Cursos)
                    {
                        if (curso.Nombre_Curso == cursoEnSesion.Nombre_Curso)
                        {
                            curso.RAs.Add(resultadoAprendizaje);
                            break;
                        }
                    }
                    break;
                }
            }

            GuardarData(profesores, "Resultado de Aprendizaje guardado con exito");
        }

        public void InsertarRecurso(Recurso recurso, Profesor profesorEnSesion, Curso cursoEnSesion)
        {
            List<Profesor> profesores = GetProfesorModels();

            foreach (Profesor profesor in profesores)
            {
                if (profesor.Nombre == profesorEnSesion.Nombre)
                {
                    foreach (Curso curso in profesor.Cursos)
                    {
                        if (curso.Nombre_Curso == cursoEnSesion.Nombre_Curso)
                        {
                            curso.Recursos.Add(recurso);
                            break;
                        }
                    }
                    break;
                }
            }

            GuardarData(profesores, "Recurso guardado con exito");
        }

        public Profesor BuscarProfesorAPI(string RUT)
        {
            string json = File.ReadAllText(@"la_oferta.json");

            List<DatoAPI> DatosAPI = JsonConvert.DeserializeObject<List<DatoAPI>>(json);

            Profesor profesor = new Profesor("-1","","","","");

            profesor.Cursos = new List<Curso>();

            foreach(DatoAPI datoAPI in DatosAPI)
            {
                if(datoAPI.RUT_PROFESOR == RUT)
                {
                    profesor.RUT = datoAPI.RUT_PROFESOR;
                    profesor.Nombre = datoAPI.NOMBRES + " " + datoAPI.AP_PATERNO; 

                    profesor.Cursos.Add(new Curso(datoAPI.TITULO, "carrerapend", "coordinador_pend", datoAPI.NRC, CrearPlanificacionDefault()));
                }
            }

            if (profesor.RUT != "-1")
            {
                List<Profesor> profesores = GetProfesorModels();

                profesores.Add(profesor);

                GuardarData(profesores, "Profesor añadido Con exito");
            }

            return profesor;
        }
    }    
}
