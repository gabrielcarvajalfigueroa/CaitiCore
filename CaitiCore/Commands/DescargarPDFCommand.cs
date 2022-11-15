
using CaitiCore.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
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

            string file = String.Format("C:\\Users\\gcarv\\Desktop\\Planificacion[{0}]2020-1.pdf",curso.Nombre_Curso);
            //Aquí se instancia el documento, estableciendo el tamaño de hoja y su orientación. A la hora de instanciar el FileStream se le indica dónde crear el PDF.
            FileStream fs = new FileStream(@file, FileMode.Create);//Cambiar según corresponda.
            Document doc = new Document(PageSize.Legal.Rotate());
            doc.SetMargins(0f, 0f, 10f, 10f);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.AddTitle("Planificación Didáctica");
            doc.Open();//importante tener el documento abierto antes de hacer cambios.

            //Se declara una tabla vacía y sin bordes que simula un salto de línea.
            PdfPTable espacio = new PdfPTable(1);
            espacio.AddCell(new PdfPCell(new Phrase(" ")) { Border = 0 });

            //Imagen del logo UCN y el título del documento.
            PdfPTable tbl = new PdfPTable(new float[] { 10f, 90f }) { HorizontalAlignment = Element.ALIGN_CENTER };
            string fileName = "UCN.png";
            string path = Path.Combine(Environment.CurrentDirectory, @"Images\", fileName);
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(path);//Cambiar según corresponda.
            logo.ScalePercent(6f);
            tbl.AddCell(new PdfPCell(logo) { Border = 0 });
            tbl.AddCell(new PdfPCell(new Phrase("Planificación Didáctica")) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0 });
            doc.Add(tbl);
            doc.Add(espacio);


            //Item I
            PdfPTable itemi = new PdfPTable(1);
            itemi.AddCell(new PdfPCell(new Phrase("I. Identificación del curso")));
            doc.Add(itemi);
            itemi = new PdfPTable(new float[] { 20f, 80f });
            itemi.AddCell(new PdfPCell(new Phrase("Carrera/Programa")));
            itemi.AddCell(new PdfPCell(new Phrase("ICCI")));//Ejemplo
            itemi.AddCell(new PdfPCell(new Phrase("Unidad responsable")));
            itemi.AddCell(new PdfPCell(new Phrase("EIC")));//Ejemplo
            itemi.AddCell(new PdfPCell(new Phrase("Nombre del curso")));
            itemi.AddCell(new PdfPCell(new Phrase(curso.Nombre_Curso)));//Ejemplo
            doc.Add(itemi);
            itemi = new PdfPTable(new float[] { 20f, 30f, 20f, 30f });
            itemi.AddCell(new PdfPCell(new Phrase("Código/NRC")));
            itemi.AddCell(new PdfPCell(new Phrase("ECIN-00610/12145 ")));//Ejemplo
            itemi.AddCell(new PdfPCell(new Phrase("Semestre en la malla")));
            itemi.AddCell(new PdfPCell(new Phrase("6")));//Ejemplo
            itemi.AddCell(new PdfPCell(new Phrase("Semestre/Año")));
            itemi.AddCell(new PdfPCell(new Phrase("1/2020")));//Ejemplo
            itemi.AddCell(new PdfPCell(new Phrase("Créditos SCT")));
            itemi.AddCell(new PdfPCell(new Phrase("5")));//Ejemplo
            doc.Add(itemi);
            itemi = new PdfPTable(new float[] { 20f, 20f, 20f, 20f, 20f });
            itemi.AddCell(new PdfPCell(new Phrase("Tipo de Asignatura ")));
            itemi.AddCell(new PdfPCell(new Phrase("Obligatoria ")));
            itemi.AddCell(new PdfPCell(new Phrase("X")));//Ejemplo
            itemi.AddCell(new PdfPCell(new Phrase("Electiva")));
            itemi.AddCell(new PdfPCell(new Phrase(" ")));//Ejemplo
            doc.Add(itemi);
            doc.Add(espacio);


            //Item II
            PdfPTable itemii = new PdfPTable(1);
            itemii.AddCell(new PdfPCell(new Phrase("II. Organización Semestral del Curso")));
            doc.Add(itemii);
            itemii = new PdfPTable(new float[] { 40f, 10f, 10f, 10f, 10f, 10f, 10f });
            itemii.AddCell(new PdfPCell(new Phrase("Horas Dedicación Semanal (Cronológicas)")));
            itemii.AddCell(new PdfPCell(new Phrase("Docencia Directa")) { HorizontalAlignment = Element.ALIGN_CENTER });
            itemii.AddCell(new PdfPCell(new Phrase("3")) { HorizontalAlignment = Element.ALIGN_CENTER });//Ejemplo
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
            itemiii.AddCell(new PdfPCell(new Phrase("III. Identificación Docentes")));
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
            itemiv.AddCell(new PdfPCell(new Phrase("IV. Identificación Ayudantes")));
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


            PdfPTable itemv = new PdfPTable(1);
            itemv.AddCell(new PdfPCell(new Phrase("V. Propósito del curso")));
            itemv.AddCell(new PdfPCell(new Phrase("Al final del curso el alumno podrá realizar el análisis, diseño orientado a objetos y construcción de un producto de software de calidad, que satisfaga los requisitos, necesidades y restricciones\r\nelicitadas, en base a un proceso iterativo e incremental. En este análisis y diseño utilizará el lenguaje de modelado UML, y será capaz de aplicar las buenas prácticas recomendadas. El trabajo lo\r\nrealizará con apoyo de herramientas de software.")));//Ejemplo
            doc.Add(itemv);


            //Importante cerrar el documento y el PDFWriter.
            doc.Close();
            writer.Close();
            fs.Close();

            MessageBox.Show("PDF Descargado/Actualizado con exito", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
