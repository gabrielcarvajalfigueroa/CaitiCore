
using CaitiCore.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            FileStream fs = new FileStream(@"C:\Users\pablo\Desktop\app.pdf", FileMode.Create);
            Document doc = new Document(PageSize.Legal.Rotate());
            doc.SetMargins(20f, 20f, 20f, 20f);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.AddTitle("Planificación Didáctica");
            doc.Open();

            PdfPTable tbl = new PdfPTable(new float[] { 10f, 90f }) { HorizontalAlignment = Element.ALIGN_CENTER };
            tbl.AddCell(new PdfPCell(new Phrase("UCN")) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.Blue });
            tbl.AddCell(new PdfPCell(new Phrase("Planificación Didáctica")) { HorizontalAlignment = Element.ALIGN_CENTER });
            doc.Add(tbl);

            doc.Add(Chunk.Newline);

            PdfPTable itemi = new PdfPTable(1);
            itemi.AddCell(new PdfPCell(new Phrase("I. Identificación del curso")));
            doc.Add(itemi);
            itemi = new PdfPTable(new float[] { 20f, 80f });
            itemi.AddCell(new PdfPCell(new Phrase("Carrera/Programa")));
            itemi.AddCell(new PdfPCell(new Phrase(curso.Carrera)));
            itemi.AddCell(new PdfPCell(new Phrase("Unidad responsable")));
            itemi.AddCell(new PdfPCell(new Phrase("EIC")));
            itemi.AddCell(new PdfPCell(new Phrase("Nombre del curso")));
            itemi.AddCell(new PdfPCell(new Phrase(curso.Nombre_Curso)));
            doc.Add(itemi);
            itemi = new PdfPTable(new float[] { 20f, 30f, 20f, 30f });
            itemi.AddCell(new PdfPCell(new Phrase("Código/NRC")));
            itemi.AddCell(new PdfPCell(new Phrase(curso.Codigo_NRC)));
            itemi.AddCell(new PdfPCell(new Phrase("Semestre en la malla")));
            itemi.AddCell(new PdfPCell(new Phrase("6")));
            itemi.AddCell(new PdfPCell(new Phrase("Semestre/Año")));
            itemi.AddCell(new PdfPCell(new Phrase("1/2020")));
            itemi.AddCell(new PdfPCell(new Phrase("Créditos SCT")));
            itemi.AddCell(new PdfPCell(new Phrase("5")));
            doc.Add(itemi);
            itemi = new PdfPTable(new float[] { 20f, 20f, 20f, 20f, 20f });

            itemi.AddCell(new PdfPCell(new Phrase("Tipo de Asignatura ")));
            itemi.AddCell(new PdfPCell(new Phrase("Obligatoria ")));
            itemi.AddCell(new PdfPCell(new Phrase("X")));
            itemi.AddCell(new PdfPCell(new Phrase("Electiva")));
            itemi.AddCell(new PdfPCell(new Phrase(" ")));
            doc.Add(itemi);
            doc.Close();
            writer.Close();
        }
    }
}
