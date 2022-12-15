using CaitiCore.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaitiCore.Commands
{
    public class DescargarPDFCommand : CommandBase
    {

        public DescargarPDFCommand() // Solo se instancia 
        {

        }

        public override void Execute(object parameter)
        {
            Curso curso = (Curso)parameter; // Se pasa el curso por CommandParameter en la listview de MenuView
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Guardar como PDF";
            sfd.Filter = "(*.pdf)|*.pdf";
            sfd.InitialDirectory = @"C:\Documents";
            if (sfd.ShowDialog() == true)
            {
                iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.Legal.Rotate());
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                var pe = new PageEventHelper();
                writer.PageEvent = pe;
                pe.Title = "Planificación Didáctica";
                pe.HeaderFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16); 
                doc.Open();
                doc = generarPDF(curso, doc);
                doc.Close();               
            }

        }
        private Document generarPDF(Curso curso, Document doc)
        {
            doc.SetMargins(10f, 10f, 50f, 10f);
            //Se declara una tabla vacía y sin bordes que simula un salto de línea.
            PdfPTable espacio = new PdfPTable(1);
            espacio.AddCell(new PdfPCell(new Phrase(" ")) { Border = 0 });
            /*Imagen del logo UCN y el título del documento.
            PdfPTable tbl = new PdfPTable(new float[] { 10f, 90f }) { HorizontalAlignment = Element.ALIGN_CENTER };
            string fileName = "UCN.png";
            string path = Path.Combine(Environment.CurrentDirectory, @"Images\", fileName);
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(path);
            logo.ScalePercent(6f);
            tbl.AddCell(new PdfPCell(logo) { Border = 0 });
            //tbl.AddCell(new PdfPCell(new Phrase("LOGO")) { Border=0});
            //tbl.AddCell(new PdfPCell(new Phrase("Planificación Didáctica")) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0 });
            doc.Add(tbl);
            doc.Add(espacio);*/


            var whiteFont = FontFactory.GetFont(FontFactory.HELVETICA, 12, new BaseColor(255,255,255));
            var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            //Item I
            PdfPTable itemi = new PdfPTable(1);
            doc.Add(espacio);
            itemi.AddCell(new PdfPCell(new Phrase("I. Identificación del curso",whiteFont)) {BackgroundColor = new BaseColor(93, 118, 242) });
            doc.Add(itemi);
            itemi = new PdfPTable(new float[] { 20f, 80f });
            itemi.AddCell(new PdfPCell(new Phrase("Carrera/Programa", boldFont) ));
            itemi.AddCell(new PdfPCell(new Phrase(curso.Carrera)));
            itemi.AddCell(new PdfPCell(new Phrase("Unidad responsable", boldFont)));
            itemi.AddCell(new PdfPCell(new Phrase(curso.Unidad_Responsable)));
            itemi.AddCell(new PdfPCell(new Phrase("Nombre del curso", boldFont)));
            itemi.AddCell(new PdfPCell(new Phrase(curso.Nombre_Curso)));
            doc.Add(itemi);
            itemi = new PdfPTable(new float[] { 20f, 30f, 20f, 30f });
            itemi.AddCell(new PdfPCell(new Phrase("Código/NRC", boldFont)));
            itemi.AddCell(new PdfPCell(new Phrase(curso.Codigo_NRC)));
            itemi.AddCell(new PdfPCell(new Phrase("Semestre en la malla", boldFont)));
            itemi.AddCell(new PdfPCell(new Phrase(curso.Semestre_Malla.ToString())));
            itemi.AddCell(new PdfPCell(new Phrase("Semestre/Año", boldFont)));
            itemi.AddCell(new PdfPCell(new Phrase(curso.Semestre_Ano.ToString())));
            itemi.AddCell(new PdfPCell(new Phrase("Créditos SCT", boldFont)));
            itemi.AddCell(new PdfPCell(new Phrase(curso.Creditos_SCT.ToString())));
            doc.Add(itemi);
            itemi = new PdfPTable(new float[] { 20f, 20f, 20f, 20f, 20f });
            itemi.AddCell(new PdfPCell(new Phrase("Tipo de Asignatura ", boldFont)));
            itemi.AddCell(new PdfPCell(new Phrase(curso.Tipo)));
            itemi.AddCell(new PdfPCell(new Phrase("X")));
            itemi.AddCell(new PdfPCell(new Phrase("Electiva")));
            itemi.AddCell(new PdfPCell(new Phrase("")));
            doc.Add(itemi);
            doc.Add(espacio);


            //Item II
            PdfPTable itemii = new PdfPTable(1);
            itemii.AddCell(new PdfPCell(new Phrase("II. Organización Semestral del Curso", whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });
            doc.Add(itemii);
            itemii = new PdfPTable(new float[] { 40f, 10f, 10f, 10f, 10f, 10f, 10f });
            itemii.AddCell(new PdfPCell(new Phrase("Horas Dedicación Semanal (Cronológicas)", boldFont)));
            itemii.AddCell(new PdfPCell(new Phrase("Docencia Directa")) { HorizontalAlignment = Element.ALIGN_CENTER });
            itemii.AddCell(new PdfPCell(new Phrase("3")) { HorizontalAlignment = Element.ALIGN_CENTER });//curso.Organizacion.Docencia_Directa
            itemii.AddCell(new PdfPCell(new Phrase("Trabajo autónomo")) { HorizontalAlignment = Element.ALIGN_CENTER });
            itemii.AddCell(new PdfPCell(new Phrase("4.5")) { HorizontalAlignment = Element.ALIGN_CENTER });//curso.Organizacion.Trabajo_Autonomo
            itemii.AddCell(new PdfPCell(new Phrase("Total")) { HorizontalAlignment = Element.ALIGN_CENTER });
            itemii.AddCell(new PdfPCell(new Phrase("7.5")) { HorizontalAlignment = Element.ALIGN_CENTER });//Ejemplo
            doc.Add(itemii);
            itemii = new PdfPTable(new float[] { 40f, 8.57f, 8.57f, 8.57f, 8.57f, 8.57f, 8.57f, 8.57f });
            itemii.AddCell(new PdfPCell(new Phrase("Detalle Horas Directas", boldFont)) { Rowspan = 2 });
            itemii.AddCell(new PdfPCell(new Phrase("Cátedra")) { HorizontalAlignment = Element.ALIGN_CENTER });
            itemii.AddCell(new PdfPCell(new Phrase("Ayudantía")) { HorizontalAlignment = Element.ALIGN_CENTER });
            itemii.AddCell(new PdfPCell(new Phrase("Laboratorio")) { HorizontalAlignment = Element.ALIGN_CENTER });
            itemii.AddCell(new PdfPCell(new Phrase("Taller")) { HorizontalAlignment = Element.ALIGN_CENTER });
            itemii.AddCell(new PdfPCell(new Phrase("Terreno")) { HorizontalAlignment = Element.ALIGN_CENTER });
            itemii.AddCell(new PdfPCell(new Phrase("Exp.Clínica")) { HorizontalAlignment = Element.ALIGN_CENTER });
            itemii.AddCell(new PdfPCell(new Phrase("Supervisión")) { HorizontalAlignment = Element.ALIGN_CENTER });
            itemii.AddCell(new PdfPCell(new Phrase("3")) { HorizontalAlignment = Element.ALIGN_CENTER });//curso.Organizacion.Catedra
            itemii.AddCell(new PdfPCell(new Phrase("0")) { HorizontalAlignment = Element.ALIGN_CENTER });//curso.Organizacion.Ayudantia
            itemii.AddCell(new PdfPCell(new Phrase("0")) { HorizontalAlignment = Element.ALIGN_CENTER });//curso.Organizacion.Laboratorio
            itemii.AddCell(new PdfPCell(new Phrase("0")) { HorizontalAlignment = Element.ALIGN_CENTER });//curso.Organizacion.Taller
            itemii.AddCell(new PdfPCell(new Phrase("0")) { HorizontalAlignment = Element.ALIGN_CENTER });//curso.Organizacion.Terreno
            itemii.AddCell(new PdfPCell(new Phrase("0")) { HorizontalAlignment = Element.ALIGN_CENTER });//curso.Organizacion.Exp_clinica
            itemii.AddCell(new PdfPCell(new Phrase("0")) { HorizontalAlignment = Element.ALIGN_CENTER });//curso.Organizacion.Supervision
            doc.Add(itemii);
            doc.Add(espacio);


            //Item III
            PdfPTable itemiii = new PdfPTable(1);
            itemiii.AddCell(new PdfPCell(new Phrase("III. Identificación Docentes", whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });
            doc.Add(itemiii);
            itemiii = new PdfPTable(new float[] { 10f, 90f });
            itemiii.AddCell(new PdfPCell(new Phrase("Coordinador(a):")));
            itemiii.AddCell(new PdfPCell(new Phrase(curso.Coordinador)));//Ejemplo
            itemiii.AddCell(new PdfPCell(new Phrase("Docente(s):")));
            itemiii.AddCell(new PdfPCell(new Phrase("Bodoque")));//Ejemplo
            doc.Add(itemiii);
            itemiii = new PdfPTable(new float[] { 10f, 20f, 10f, 20f, 10f, 30f });
            itemiii.AddCell(new PdfPCell(new Phrase("Email:")));
            itemiii.AddCell(new PdfPCell(new Phrase("Bodoque@ucn.cl")));//Ejemplo
            itemiii.AddCell(new PdfPCell(new Phrase("Teléfono:")));
            itemiii.AddCell(new PdfPCell(new Phrase("93384")));//Ejemplo
            itemiii.AddCell(new PdfPCell(new Phrase("Horario de atención:")));
            itemiii.AddCell(new PdfPCell(new Phrase("Lunes bloque B")));//Ejemplo
            doc.Add(itemiii);
            doc.Add(espacio);

            //Item IV
            PdfPTable itemiv = new PdfPTable(1);
            itemiv.AddCell(new PdfPCell(new Phrase("IV. Identificación Ayudantes", whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });
            doc.Add(itemiv);
            
            foreach (Ayudante ayudante in curso.Ayudantes)
            {
                itemiv = new PdfPTable(new float[] { 10f, 90f });
                itemiv.AddCell(new PdfPCell(new Phrase("Ayudante(s): ")));
                //doc.Add(itemiv);
                itemiv.AddCell(new PdfPCell(new Phrase(ayudante.Nombre)));//Ejemplo
                doc.Add(itemiv);
                itemiv = new PdfPTable(new float[] { 10f, 20f, 10f, 20f, 10f, 30f });
                itemiv.AddCell(new PdfPCell(new Phrase("Email:")));
                itemiv.AddCell(new PdfPCell(new Phrase(ayudante.Correo)));//Ejemplo
                itemiv.AddCell(new PdfPCell(new Phrase("Teléfono:")));
                itemiv.AddCell(new PdfPCell(new Phrase(ayudante.Telefono)));//Ejemplo
                itemiv.AddCell(new PdfPCell(new Phrase("Horario de atención")));
                itemiv.AddCell(new PdfPCell(new Phrase(ayudante.Horario_Atencion)));//Ejemplo
                doc.Add(itemiv);
            }
            
            doc.Add(espacio);

            //Item V
            PdfPTable itemv = new PdfPTable(1);
            itemv.AddCell(new PdfPCell(new Phrase("V. Propósito del curso", whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });
            itemv.AddCell(new PdfPCell(new Phrase(curso.Proposito)));//Ejemplo
            doc.Add(itemv);
            doc.Add(espacio);


            PdfPTable itemvi = new PdfPTable(1);
            itemvi.AddCell(new PdfPCell(new Phrase("VI. Resultados de Aprendizajes del Curso",whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });
            string ra = "";
            foreach(ResultadoAprendizaje ras in curso.RAs)
            {
                ra = ra + "-" + ras.Contenido + "\n";
            }
            itemvi.AddCell(new PdfPCell(new Phrase(ra)));
            doc.Add(itemvi);
            doc.Add(espacio);

            /* semana a smeana el main el fuerte*/
            PdfPTable itemvii = new PdfPTable(1);
            itemvii.AddCell(new PdfPCell(new Phrase("VII. Detalle Planificación Didáctica", whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });
            doc.Add(itemvii);
            Random rnd = new Random();// comedia pura
            foreach (Semana semana in curso.Planificacion_Curso.Semanas)
            {
                foreach (Clase clase in semana.Clases)
                {
                    

                    itemvii = new PdfPTable(new float[] { 20f, 80f });
                    itemvii.AddCell(new PdfPCell(new Phrase("Resultados de Aprendizaje", boldFont)));
                    itemvii.AddCell(new PdfPCell(new Phrase(curso.RAs[rnd.Next(curso.RAs.Count())].Contenido)));
                    itemvii.AddCell(new PdfPCell(new Phrase("Unidades Temáticas", boldFont)));
                    itemvii.AddCell(new PdfPCell(new Phrase("")));
                    itemvii.AddCell(new PdfPCell(new Phrase("Semana/Sesión/Fecha", boldFont)));
                    var cultureInfo = new CultureInfo("en-US");
                    
                    if(clase.Fecha_Planificada != null && clase.Fecha_Realizada != null)
                    {
                        var dateTime = DateTime.Parse(clase.Fecha_Planificada, cultureInfo,
                                                    DateTimeStyles.NoCurrentDateDefault);
                        var dateTime2 = DateTime.Parse(clase.Fecha_Planificada, cultureInfo,
                                                    DateTimeStyles.NoCurrentDateDefault);
                        itemvii.AddCell(new PdfPCell(new Phrase("Semana " + clase.Id_Semana + " Clase " + clase.Id_Clase + " Fecha Planificada: " + dateTime.ToString("yyyy-MM-dd") + " Fecha Realizada: " + dateTime2.ToString("yyyy-MM-dd"))));
                    }
                    else
                    {
                       
                        itemvii.AddCell(new PdfPCell(new Phrase("Semana " + clase.Id_Semana + " Clase " + clase.Id_Clase + " Fecha Planificada: " + clase.Fecha_Planificada + " Fecha Realizada: " + clase.Fecha_Realizada)));
                    }
                    
                    itemvii.AddCell(new PdfPCell(new Phrase("Corresponde a", boldFont)));
                    itemvii.AddCell(new PdfPCell(new Phrase()));
                    doc.Add(itemvii);
                    foreach (Actividad actividad in clase.Actividades)
                    {
                        itemvii = new PdfPTable(new float[] { 8f, 8f, 14f, 10f, 15f, 10f, 15f, 10f, 10f });
                        itemvii.AddCell(new PdfPCell(new Phrase("Presencial", whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });
                        itemvii.AddCell(new PdfPCell(new Phrase("Autónoma", whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });
                        itemvii.AddCell(new PdfPCell(new Phrase("Descripción de la actividad ", whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });
                        itemvii.AddCell(new PdfPCell(new Phrase("Metodología", whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });
                        itemvii.AddCell(new PdfPCell(new Phrase("Producto (evidencia) ", whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });
                        itemvii.AddCell(new PdfPCell(new Phrase("Evaluación", whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });
                        itemvii.AddCell(new PdfPCell(new Phrase("Recursos de Aprendizaje ", whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });
                        itemvii.AddCell(new PdfPCell(new Phrase("H.Directas", whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });
                        itemvii.AddCell(new PdfPCell(new Phrase("H.Indirectas", whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });
                        itemvii.AddCell(new PdfPCell(new Phrase("x")));
                        itemvii.AddCell(new PdfPCell(new Phrase(" ")));
                        itemvii.AddCell(new PdfPCell(new Phrase(actividad.Descripcion_Actividad)));
                        itemvii.AddCell(new PdfPCell(new Phrase(" ")));
                        itemvii.AddCell(new PdfPCell(new Phrase(" ")));
                        itemvii.AddCell(new PdfPCell(new Phrase(" ")));
                        itemvii.AddCell(new PdfPCell(new Phrase(" ")));
                        itemvii.AddCell(new PdfPCell(new Phrase(" ")));
                        itemvii.AddCell(new PdfPCell(new Phrase(" ")));
                        doc.Add(itemvii);
                        
                    }
                    doc.Add(espacio);
                    doc.Add(espacio);

                }
            }
            doc.Add(espacio);

            PdfPTable itemviii = new PdfPTable(1);
            itemviii.AddCell(new PdfPCell(new Phrase("VIII. Consolidado del Proceso de Evaluacion", whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });
            itemviii.AddCell(new PdfPCell(new Phrase("Resultados de Apredizaje", whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });
            doc.Add(itemviii);
            
            itemviii = new PdfPTable(new float[] { 60f, 20f, 20f });
            itemviii.AddCell(new PdfPCell(new Phrase("Instrumento de evaluacion", whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });
            itemviii.AddCell(new PdfPCell(new Phrase("Ponderacion(%)", whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });
            itemviii.AddCell(new PdfPCell(new Phrase("Fecha", whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });
            doc.Add(itemviii);
            foreach (ResultadoAprendizaje ras in curso.RAs)
            {
                itemviii = new PdfPTable(1);
                itemviii.AddCell(new PdfPCell(new Phrase(ras.Contenido, boldFont)));
                doc.Add(itemviii);
                itemviii = new PdfPTable(new float[] { 60f, 20f, 20f });
                itemviii.AddCell(new PdfPCell(new Phrase("(SUMATIVA y FORMATIVA) Prueba Cátedra 1 ")));
                itemviii.AddCell(new PdfPCell(new Phrase("21 %")));
                itemviii.AddCell(new PdfPCell(new Phrase("2020-07-12")));
                doc.Add(itemviii);
            }
            
            doc.Add(espacio);
            doc.Add(espacio);

            PdfPTable itemix = new PdfPTable(1);
            itemix.AddCell(new PdfPCell(new Phrase("IX. Aspectos Administrativos", whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });
            itemix.AddCell(new PdfPCell(new Phrase(curso.Asp_Administrativo)));
            doc.Add(itemix);
            doc.Add(espacio);


            PdfPTable itemx = new PdfPTable(1);
            itemx.AddCell(new PdfPCell(new Phrase("X. Recursos de Aprendizaje", whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });

            foreach (Recurso recurso in curso.Recursos)
            {
                itemx.AddCell(new PdfPCell(new Phrase(recurso.Contenido)));
            }
            doc.Add(itemx);
            doc.Add(espacio);


            PdfPTable itemxi = new PdfPTable(1);
            itemxi.AddCell(new PdfPCell(new Phrase("XI. Resumen Carga Academica Estudiante",whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });
            doc.Add(itemxi);
            itemxi = new PdfPTable(new float[] { 30f, 20f, 30f, 20f });
            itemxi.AddCell(new PdfPCell(new Phrase("Actividades Presenciales", whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });
            itemxi.AddCell(new PdfPCell(new Phrase("Horas Estimadas", whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });
            itemxi.AddCell(new PdfPCell(new Phrase("Actividades No Presenciales", whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });
            itemxi.AddCell(new PdfPCell(new Phrase("Horas Estimadas", whiteFont)) { BackgroundColor = new BaseColor(93, 118, 242) });
            itemxi.AddCell(new PdfPCell(new Phrase("Catedra")));
            itemxi.AddCell(new PdfPCell(new Phrase("1")));
            itemxi.AddCell(new PdfPCell(new Phrase("Trabajo Individual")));
            itemxi.AddCell(new PdfPCell(new Phrase("1")));
            itemxi.AddCell(new PdfPCell(new Phrase("Ayudantia")));
            itemxi.AddCell(new PdfPCell(new Phrase("2")));
            itemxi.AddCell(new PdfPCell(new Phrase("Trabajo Grupal")));
            itemxi.AddCell(new PdfPCell(new Phrase("2")));
            itemxi.AddCell(new PdfPCell(new Phrase("Laboratorio")));
            itemxi.AddCell(new PdfPCell(new Phrase("3")));
            itemxi.AddCell(new PdfPCell(new Phrase("Estudio Personal")));
            itemxi.AddCell(new PdfPCell(new Phrase("3")));
            itemxi.AddCell(new PdfPCell(new Phrase("Taller")));
            itemxi.AddCell(new PdfPCell(new Phrase("3")));
            itemxi.AddCell(new PdfPCell(new Phrase("Estudio Grupal")));
            itemxi.AddCell(new PdfPCell(new Phrase("3")));
            itemxi.AddCell(new PdfPCell(new Phrase("Terreno")));
            itemxi.AddCell(new PdfPCell(new Phrase("3")));
            itemxi.AddCell(new PdfPCell(new Phrase("Busqueda de Informacion")));
            itemxi.AddCell(new PdfPCell(new Phrase("3")));
            itemxi.AddCell(new PdfPCell(new Phrase("Exp.Clinica")));
            itemxi.AddCell(new PdfPCell(new Phrase("3")));
            itemxi.AddCell(new PdfPCell(new Phrase("Trabajo Virtual")));
            itemxi.AddCell(new PdfPCell(new Phrase("3")));
            itemxi.AddCell(new PdfPCell(new Phrase("Evaluaciones")));
            itemxi.AddCell(new PdfPCell(new Phrase("3")));
            itemxi.AddCell(new PdfPCell(new Phrase("")));
            itemxi.AddCell(new PdfPCell(new Phrase("")));
            itemxi.AddCell(new PdfPCell(new Phrase("Total", boldFont)));
            itemxi.AddCell(new PdfPCell(new Phrase("47.67", boldFont)));
            itemxi.AddCell(new PdfPCell(new Phrase("Total", boldFont)));
            itemxi.AddCell(new PdfPCell(new Phrase("50.67", boldFont)));
            doc.Add(itemxi);
            doc.Add(espacio);
           
            return doc;
        }
    }
}