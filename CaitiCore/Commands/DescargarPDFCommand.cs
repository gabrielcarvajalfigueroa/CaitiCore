
using CaitiCore.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
                pe.Title = "Planificacion Didactica";
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


            //Item I
            PdfPTable itemi = new PdfPTable(1);
            doc.Add(espacio);
            itemi.AddCell(new PdfPCell(new Phrase("I. Identificación del curso")) { BackgroundColor = new BaseColor(0, 166, 255) });
            doc.Add(itemi);
            itemi = new PdfPTable(new float[] { 20f, 80f });
            itemi.AddCell(new PdfPCell(new Phrase("Carrera/Programa")));
            itemi.AddCell(new PdfPCell(new Phrase(curso.Carrera)));
            itemi.AddCell(new PdfPCell(new Phrase("Unidad responsable")));
            itemi.AddCell(new PdfPCell(new Phrase(curso.Unidad_Responsable)));
            itemi.AddCell(new PdfPCell(new Phrase("Nombre del curso")));
            itemi.AddCell(new PdfPCell(new Phrase(curso.Nombre_Curso)));
            doc.Add(itemi);
            itemi = new PdfPTable(new float[] { 20f, 30f, 20f, 30f });
            itemi.AddCell(new PdfPCell(new Phrase("Código/NRC")));
            itemi.AddCell(new PdfPCell(new Phrase(curso.Codigo_NRC)));
            itemi.AddCell(new PdfPCell(new Phrase("Semestre en la malla")));
            itemi.AddCell(new PdfPCell(new Phrase(curso.Semestre_Malla)));
            itemi.AddCell(new PdfPCell(new Phrase("Semestre/Año")));
            itemi.AddCell(new PdfPCell(new Phrase(curso.Semestre_Ano)));
            itemi.AddCell(new PdfPCell(new Phrase("Créditos SCT")));
            itemi.AddCell(new PdfPCell(new Phrase(curso.Creditos_SCT)));
            doc.Add(itemi);
            itemi = new PdfPTable(new float[] { 20f, 20f, 20f, 20f, 20f });
            itemi.AddCell(new PdfPCell(new Phrase("Tipo de Asignatura ")));
            itemi.AddCell(new PdfPCell(new Phrase(curso.Tipo)));
            itemi.AddCell(new PdfPCell(new Phrase("X")));
            itemi.AddCell(new PdfPCell(new Phrase("Electiva")));
            itemi.AddCell(new PdfPCell(new Phrase("X")));
            doc.Add(itemi);
            doc.Add(espacio);


            //Item II
            PdfPTable itemii = new PdfPTable(1);
            itemii.AddCell(new PdfPCell(new Phrase("II. Organización Semestral del Curso")) { BackgroundColor = new BaseColor(0, 166, 255) });
            doc.Add(itemii);
            itemii = new PdfPTable(new float[] { 40f, 10f, 10f, 10f, 10f, 10f, 10f });
            itemii.AddCell(new PdfPCell(new Phrase("Horas Dedicación Semanal (Cronológicas)")));
            itemii.AddCell(new PdfPCell(new Phrase("Docencia Directa")) { HorizontalAlignment = Element.ALIGN_CENTER });
            itemii.AddCell(new PdfPCell(new Phrase("ejemplo")) { HorizontalAlignment = Element.ALIGN_CENTER });//Ejemplo
            itemii.AddCell(new PdfPCell(new Phrase("Trabajo autónomo")) { HorizontalAlignment = Element.ALIGN_CENTER });
            itemii.AddCell(new PdfPCell(new Phrase("4.5")) { HorizontalAlignment = Element.ALIGN_CENTER });//Ejemplo
            itemii.AddCell(new PdfPCell(new Phrase("Total")) { HorizontalAlignment = Element.ALIGN_CENTER });
            itemii.AddCell(new PdfPCell(new Phrase("7.5")) { HorizontalAlignment = Element.ALIGN_CENTER });//Ejemplo
            doc.Add(itemii);
            itemii = new PdfPTable(new float[] { 40f, 8.57f, 8.57f, 8.57f, 8.57f, 8.57f, 8.57f, 8.57f });
            itemii.AddCell(new PdfPCell(new Phrase("Detalle Horas Directas")) { Rowspan = 2 });
            itemii.AddCell(new PdfPCell(new Phrase("Cátedra ")) { HorizontalAlignment = Element.ALIGN_CENTER });
            itemii.AddCell(new PdfPCell(new Phrase("Ayudantía")) { HorizontalAlignment = Element.ALIGN_CENTER });
            itemii.AddCell(new PdfPCell(new Phrase("Laboratorio")) { HorizontalAlignment = Element.ALIGN_CENTER });
            itemii.AddCell(new PdfPCell(new Phrase("Taller")) { HorizontalAlignment = Element.ALIGN_CENTER });
            itemii.AddCell(new PdfPCell(new Phrase("Terreno")) { HorizontalAlignment = Element.ALIGN_CENTER });
            itemii.AddCell(new PdfPCell(new Phrase("Exp.Clínica")) { HorizontalAlignment = Element.ALIGN_CENTER });
            itemii.AddCell(new PdfPCell(new Phrase("Supervisión")) { HorizontalAlignment = Element.ALIGN_CENTER });
            itemii.AddCell(new PdfPCell(new Phrase("3 ")) { HorizontalAlignment = Element.ALIGN_CENTER });//Ejemplo
            itemii.AddCell(new PdfPCell(new Phrase("0")) { HorizontalAlignment = Element.ALIGN_CENTER });//Ejemplo
            itemii.AddCell(new PdfPCell(new Phrase("0")) { HorizontalAlignment = Element.ALIGN_CENTER });//Ejemplo
            itemii.AddCell(new PdfPCell(new Phrase("0")) { HorizontalAlignment = Element.ALIGN_CENTER });//Ejemplo
            itemii.AddCell(new PdfPCell(new Phrase("0")) { HorizontalAlignment = Element.ALIGN_CENTER });//Ejemplo
            itemii.AddCell(new PdfPCell(new Phrase("0")) { HorizontalAlignment = Element.ALIGN_CENTER });//Ejemplo
            itemii.AddCell(new PdfPCell(new Phrase("0")) { HorizontalAlignment = Element.ALIGN_CENTER });//Ejemplo
            doc.Add(itemii);
            doc.Add(espacio);


            //Item III
            PdfPTable itemiii = new PdfPTable(1);
            itemiii.AddCell(new PdfPCell(new Phrase("III. Identificación Docentes")) { BackgroundColor = new BaseColor(0, 166, 255) });
            doc.Add(itemiii);
            itemiii = new PdfPTable(new float[] { 10f, 90f });
            itemiii.AddCell(new PdfPCell(new Phrase("Coordinador(a):")));
            itemiii.AddCell(new PdfPCell(new Phrase("Eric Ross")));//Ejemplo
            itemiii.AddCell(new PdfPCell(new Phrase("Docente(s):")));
            itemiii.AddCell(new PdfPCell(new Phrase("ROSS ERIC")));//Ejemplo
            doc.Add(itemiii);
            itemiii = new PdfPTable(new float[] { 10f, 20f, 10f, 20f, 10f, 30f });
            itemiii.AddCell(new PdfPCell(new Phrase("Email:")));
            itemiii.AddCell(new PdfPCell(new Phrase("eross@ucn.cl")));//Ejemplo
            itemiii.AddCell(new PdfPCell(new Phrase("Teléfono:")));
            itemiii.AddCell(new PdfPCell(new Phrase(" ")));//Ejemplo
            itemiii.AddCell(new PdfPCell(new Phrase("Horario de atención:")));
            itemiii.AddCell(new PdfPCell(new Phrase("Todos los viernes de 13:15 a 14:30")));//Ejemplo
            doc.Add(itemiii);
            doc.Add(espacio);


            //Item IV
            PdfPTable itemiv = new PdfPTable(1);
            itemiv.AddCell(new PdfPCell(new Phrase("IV. Identificación Ayudantes")) { BackgroundColor = new BaseColor(0, 166, 255) });
            doc.Add(itemiv);
            itemiv = new PdfPTable(new float[] { 10f, 90f });
            itemiv.AddCell(new PdfPCell(new Phrase("Ayudante(s): ")));
            itemiv.AddCell(new PdfPCell(new Phrase(" ")));//Ejemplo
            doc.Add(itemiv);
            itemiv = new PdfPTable(new float[] { 10f, 20f, 10f, 20f, 10f, 30f });
            itemiv.AddCell(new PdfPCell(new Phrase("Email:")));
            itemiv.AddCell(new PdfPCell(new Phrase(" ")));//Ejemplo
            itemiv.AddCell(new PdfPCell(new Phrase("Teléfono:")));
            itemiv.AddCell(new PdfPCell(new Phrase(" ")));//Ejemplo
            itemiv.AddCell(new PdfPCell(new Phrase("Horario de atención")));
            itemiv.AddCell(new PdfPCell(new Phrase(" ")));//Ejemplo
            doc.Add(itemiv);
            doc.Add(espacio);

            //Item V
            PdfPTable itemv = new PdfPTable(1);
            itemv.AddCell(new PdfPCell(new Phrase("V. Propósito del curso")) { BackgroundColor = new BaseColor(0, 166, 255) });
            itemv.AddCell(new PdfPCell(new Phrase("Al final del curso el alumno podrá realizar el análisis, diseño orientado a objetos y construcción de un producto de software de calidad, que satisfaga los requisitos, necesidades y restricciones\r\nelicitadas, en base a un proceso iterativo e incremental. En este análisis y diseño utilizará el lenguaje de modelado UML, y será capaz de aplicar las buenas prácticas recomendadas. El trabajo lo\r\nrealizará con apoyo de herramientas de software.")));//Ejemplo
            doc.Add(itemv);
            doc.Add(espacio);


            PdfPTable itemvi = new PdfPTable(1);
            itemvi.AddCell(new PdfPCell(new Phrase("VI. Resultados de Aprendizajes del Curso")) { BackgroundColor = new BaseColor(0, 166, 255) });
            itemvi.AddCell(new PdfPCell(new Phrase("·Comprender los conceptos asociados a los procesos de la Ingeniería de Software\r\n·Seleccionar el modelo de proceso más adecuado para la aplicación a desarrollar\r\n·Aplicar el proceso de Ingeniería de Requisitos para la elicitación de las necesidades de los clientes y usuarios\r\n·Diseñar un producto de software utilizando UML. Este diseño considera el diseño de alto nivel, la arquitectura del sistema y la interfaz de usuario\r\n·Construir un producto de software de calidad en base a las buenas práctica recomendadas por los modelos de procesos\r\n·Realizar actividades de aseguramiento de la calidad en el desarrollo de software")));
            doc.Add(itemvi);
            doc.Add(espacio);


            PdfPTable itemvii = new PdfPTable(1);
            itemvii.AddCell(new PdfPCell(new Phrase("VII. Detalle Planificación Didáctica")) { BackgroundColor = new BaseColor(0, 166, 255) });
            doc.Add(itemvii);
            itemvii = new PdfPTable(new float[] { 20f, 80f });
            itemvii.AddCell(new PdfPCell(new Phrase("Resultados de Aprendizaje")));
            itemvii.AddCell(new PdfPCell(new Phrase(" ")));
            itemvii.AddCell(new PdfPCell(new Phrase("Unidades Temáticas")));
            itemvii.AddCell(new PdfPCell(new Phrase(" ")));
            itemvii.AddCell(new PdfPCell(new Phrase("Semana/Sesión/Fecha")));
            itemvii.AddCell(new PdfPCell(new Phrase(" ")));
            itemvii.AddCell(new PdfPCell(new Phrase("Corresponde a")));
            itemvii.AddCell(new PdfPCell(new Phrase(" ")));
            doc.Add(itemvii);
            itemvii = new PdfPTable(new float[] { 8f, 8f, 14f, 10f, 15f, 10f, 15f, 10f, 10f });
            itemvii.AddCell(new PdfPCell(new Phrase("Presencial")));
            itemvii.AddCell(new PdfPCell(new Phrase("Autónoma")));
            itemvii.AddCell(new PdfPCell(new Phrase("Descripción de la actividad ")));
            itemvii.AddCell(new PdfPCell(new Phrase("Metodología")));
            itemvii.AddCell(new PdfPCell(new Phrase("Producto (evidencia) ")));
            itemvii.AddCell(new PdfPCell(new Phrase("Evaluación")));
            itemvii.AddCell(new PdfPCell(new Phrase("Recursos de Aprendizaje ")));
            itemvii.AddCell(new PdfPCell(new Phrase("H.Directas")));
            itemvii.AddCell(new PdfPCell(new Phrase("H.Indirectas")));
            itemvii.AddCell(new PdfPCell(new Phrase(" ")));
            itemvii.AddCell(new PdfPCell(new Phrase(" ")));
            itemvii.AddCell(new PdfPCell(new Phrase(" ")));
            itemvii.AddCell(new PdfPCell(new Phrase(" ")));
            itemvii.AddCell(new PdfPCell(new Phrase(" ")));
            itemvii.AddCell(new PdfPCell(new Phrase(" ")));
            itemvii.AddCell(new PdfPCell(new Phrase(" ")));
            itemvii.AddCell(new PdfPCell(new Phrase(" ")));
            itemvii.AddCell(new PdfPCell(new Phrase(" ")));
            doc.Add(itemvii);
            doc.Add(espacio);

            PdfPTable itemviii = new PdfPTable(1);
            itemviii.AddCell(new PdfPCell(new Phrase("VIII. Consolidado del Proceso de Evaluacion")) { BackgroundColor = new BaseColor(0, 166, 255) });
            itemviii.AddCell(new PdfPCell(new Phrase("Resultados de Apredizaje")) { BackgroundColor = new BaseColor(0, 166, 255) });
            doc.Add(itemviii);
            itemviii = new PdfPTable(new float[] { 60f, 20f, 20f });
            itemviii.AddCell(new PdfPCell(new Phrase("Instrumento de evaluacion")) { BackgroundColor = new BaseColor(0, 166, 255) });
            itemviii.AddCell(new PdfPCell(new Phrase("Ponderacion(%)")) { BackgroundColor = new BaseColor(0, 166, 255) });
            itemviii.AddCell(new PdfPCell(new Phrase("Fecha")) { BackgroundColor = new BaseColor(0, 166, 255) });
            itemviii.AddCell(new PdfPCell(new Phrase("1")));
            itemviii.AddCell(new PdfPCell(new Phrase("1")));
            itemviii.AddCell(new PdfPCell(new Phrase("1")));
            itemviii.AddCell(new PdfPCell(new Phrase("2")));
            itemviii.AddCell(new PdfPCell(new Phrase("2")));
            itemviii.AddCell(new PdfPCell(new Phrase("2")));
            doc.Add(itemviii);
            doc.Add(espacio);

            PdfPTable itemix = new PdfPTable(1);
            itemix.AddCell(new PdfPCell(new Phrase("IX. Aspectos Administrativos")) { BackgroundColor = new BaseColor(0, 166, 255) });
            itemix.AddCell(new PdfPCell(new Phrase("relleno")));
            doc.Add(itemix);
            doc.Add(espacio);

            PdfPTable itemx = new PdfPTable(1);
            itemx.AddCell(new PdfPCell(new Phrase("X. Recursos de Aprendizaje")) { BackgroundColor = new BaseColor(0, 166, 255) });
            itemx.AddCell(new PdfPCell(new Phrase("relleno")));
            doc.Add(itemx);
            doc.Add(espacio);


            PdfPTable itemxi = new PdfPTable(1);
            itemxi.AddCell(new PdfPCell(new Phrase("XI. Resumen Carga Academica Estudiante")) { BackgroundColor = new BaseColor(0, 166, 255) });
            doc.Add(itemxi);
            itemxi = new PdfPTable(new float[] { 30f, 20f, 30f, 20f });
            itemxi.AddCell(new PdfPCell(new Phrase("Actividades Presenciales")));
            itemxi.AddCell(new PdfPCell(new Phrase("Horas Estimadas")));
            itemxi.AddCell(new PdfPCell(new Phrase("Actividades No Presenciales")));
            itemxi.AddCell(new PdfPCell(new Phrase("Horas Estimadas")));
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
            itemxi.AddCell(new PdfPCell(new Phrase("Total")));
            itemxi.AddCell(new PdfPCell(new Phrase("")));
            itemxi.AddCell(new PdfPCell(new Phrase("Total")));
            itemxi.AddCell(new PdfPCell(new Phrase("")));
            doc.Add(itemxi);
            doc.Add(espacio);
            return doc;
        }
    }
}