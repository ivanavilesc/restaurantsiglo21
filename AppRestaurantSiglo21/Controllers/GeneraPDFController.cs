﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppRestaurantSiglo21.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace AppRestaurantSiglo21.Controllers
{
    public class GeneraPDFController : Controller
    {
        // GET: GeneraPDF
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult Index_Post()
        {

            //crea documento y asigna tam pagina y margenes
            Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 15);
            //crea instancia de PDFWriter
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();

            // ############# FORMATEO DE DOCUMENTO #########################

            Chunk chunk = new Chunk("DETALLE DE TU PAGO", FontFactory.GetFont("Arial", 20, Font.BOLD, BaseColor.BLACK));
            pdfDoc.Add(chunk);

            Paragraph line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            pdfDoc.Add(line);

            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            table.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;

            //Cell no 1
            PdfPCell cell = new PdfPCell();
            cell.Border = 0;
            Image image = Image.GetInstance(Server.MapPath("~/Content/Images/RestSiglo21Logo.png"));
            image.ScaleAbsolute(200, 150);
            cell.AddElement(image);
            table.AddCell(cell);

            //Cell no 2
            chunk = new Chunk("Restaurant SIGLO XXI\nDirección: Avda Siempreviva 742\nComuna: Santiago\nTelefono: 56 22 5703212\nemail: reservarestaurantsigloxxi@gmail.com", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK));
            cell = new PdfPCell();
            cell.Border = 0;
            cell.AddElement(chunk);
            table.AddCell(cell);

            //Add table to document    
            pdfDoc.Add(table);

            //Image image = Image.GetInstance(Server.MapPath("~/Content/Images/RestSiglo21Logo.png") );
            image.ScalePercent(50f);
            image.SetAbsolutePosition(440, 10);
            image.ScaleToFit(120f, 155.25f);





            Paragraph para = new Paragraph("Gracias por preferir RESTAURANT SIGLO XXI, a continuación tienes el detalle de tu boleta:");
            pdfDoc.Add(para);


            //var resumenCompra = System.Web.HttpContext.Current.Session["resumenCompra"];

            List<VistaDetOrdenes> vistaDetOrdenes = new List<VistaDetOrdenes>();
            vistaDetOrdenes = (List<VistaDetOrdenes>)System.Web.HttpContext.Current.Session["resumenCompra"];
            VistaDetOrdenes objVista = new VistaDetOrdenes();

            //vistaDetOrdenes = objVistaOrdenes;
            //var objVistaOrdenes2 = (List<VistaDetOrdenes>)System.Web.HttpContext.Current.Session["resumenCompra"];
            //var objVistaOrdenes2 = (List<VistaDetOrdenes>)objVistaOrdenes;
            string hoy = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString();
            int x = 9;



            x = 10;


            //Table
            table = new PdfPTable(5);
            table.WidthPercentage = 100;
            table.HorizontalAlignment = 0;
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;
            //Celda
            cell = new PdfPCell();
            chunk = new Chunk("Productos consumidos");
            cell.AddElement(chunk);
            cell.Colspan = 5;
            cell.BackgroundColor = BaseColor.GRAY;
            table.AddCell(cell);

            table.AddCell("#");
            table.AddCell("Producto");
            table.AddCell("Cantidad");
            table.AddCell("P.Unitario");
            table.AddCell("Total");
            int i = 1;
            foreach (var item in vistaDetOrdenes)
            {
                table.AddCell(i.ToString());
                table.AddCell(item.DescProducto1.ToString());
                table.AddCell(item.Cantidad1.ToString());
                table.AddCell(item.PrecioProducto1.ToString());
                table.AddCell(item.Total1.ToString());
                i++;
            }
            //Cell



            //Add table to document
            pdfDoc.Add(table);

            //###################################

            PdfPTable table2 = new PdfPTable(2);
            table2.WidthPercentage = 100;
            table2.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
            table2.SpacingBefore = 20f;
            table2.SpacingAfter = 30f;

            //Cell no 1
            cell = new PdfPCell();
            cell.Border = 0;
            Chunk chunk2 = new Chunk("TOTAL A PAGAR", FontFactory.GetFont("Arial", 15, Font.BOLD, BaseColor.BLACK));
            cell.AddElement(chunk2);
            table2.AddCell(cell);

            //Cell no 2
            string total = "$ " + Session["totalBoleta"].ToString();
            int y = 7;
            cell = new PdfPCell();
            cell.Border = 0;
            Chunk chunk3 = new Chunk(total, FontFactory.GetFont("Arial", 15, Font.BOLD, BaseColor.BLACK));
            cell.AddElement(chunk3);
            table2.AddCell(cell);


            pdfDoc.Add(table2);

            //#################   FIN DE FORMATEO DE DOCUMENTO  ###############


            pdfWriter.CloseStream = false;
            pdfDoc.Close();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            string attach = "attachment;filename=" + hoy + " Comprobante_Pago.pdf";
            Response.AddHeader("content-disposition", attach);
            //Response.AddHeader("content-disposition", "attachment;filename=hoy+Comprobante_Pago.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();

            return View();
        }

        public ActionResult TopProductos()
        {
            return View();
        }

        [HttpPost]
        [ActionName("TopProductos")]
        public ActionResult TopProductos_Post()
        {

            //crea documento y asigna tam pagina y margenes
            Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 15);
            //crea instancia de PDFWriter
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();

            // ############# FORMATEO DE DOCUMENTO #########################

            Chunk chunk = new Chunk("REPORTE TOP 10 PRODUCTOS VENDIDOS", FontFactory.GetFont("Arial", 20, Font.BOLD, BaseColor.BLACK));
            pdfDoc.Add(chunk);

            Paragraph line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            pdfDoc.Add(line);

            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            table.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;

            //Cell no 1
            PdfPCell cell = new PdfPCell();
            cell.Border = 0;
            Image image = Image.GetInstance(Server.MapPath("~/Content/Images/RestSiglo21Logo.png"));
            image.ScaleAbsolute(200, 150);
            cell.AddElement(image);
            table.AddCell(cell);

            //Cell no 2
            chunk = new Chunk("Restaurant SIGLO XXI\nInformes de Gestión\nTop 10 productos mas vendidos", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK));
            cell = new PdfPCell();
            cell.Border = 0;
            cell.AddElement(chunk);
            table.AddCell(cell);

            //Add table to document    
            pdfDoc.Add(table);

            //Image image = Image.GetInstance(Server.MapPath("~/Content/Images/RestSiglo21Logo.png") );
            image.ScalePercent(50f);
            image.SetAbsolutePosition(440, 10);
            image.ScaleToFit(120f, 155.25f);





            Paragraph para = new Paragraph("Detalle del reporte:");
            pdfDoc.Add(para);


            //var resumenCompra = System.Web.HttpContext.Current.Session["resumenCompra"];

            List<TopProductosViewModel> listaTopProductos = new List<TopProductosViewModel>();
            listaTopProductos = (List<TopProductosViewModel>)System.Web.HttpContext.Current.Session["topProductos"];
            TopProductosViewModel objVista = new TopProductosViewModel();

            //vistaDetOrdenes = objVistaOrdenes;
            //var objVistaOrdenes2 = (List<VistaDetOrdenes>)System.Web.HttpContext.Current.Session["resumenCompra"];
            //var objVistaOrdenes2 = (List<VistaDetOrdenes>)objVistaOrdenes;
            string hoy = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString();
            int x = 9;



            x = 10;


            //Table
            table = new PdfPTable(3);
            table.WidthPercentage = 100;
            table.HorizontalAlignment = 0;
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;
            //Celda
            cell = new PdfPCell();
            chunk = new Chunk("Productos consumidos");
            cell.AddElement(chunk);
            cell.Colspan = 5;
            cell.BackgroundColor = BaseColor.GRAY;
            table.AddCell(cell);

            table.AddCell("#");
            table.AddCell("Producto");
            table.AddCell("Cantidad");

            int i = 1;
            foreach (var item in listaTopProductos)
            {
                table.AddCell(i.ToString());
                table.AddCell(item.DescripcionProducto.ToString());
                table.AddCell(item.CantidadProductos.ToString());

                i++;
            }
            //Cell



            //Add table to document
            pdfDoc.Add(table);

            //###################################


            //#################   FIN DE FORMATEO DE DOCUMENTO  ###############


            pdfWriter.CloseStream = false;
            pdfDoc.Close();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            string attach = "attachment;filename=" + hoy + " Reporte_TopProductos.pdf";
            Response.AddHeader("content-disposition", attach);
            //Response.AddHeader("content-disposition", "attachment;filename=hoy+Comprobante_Pago.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();

            return View();
        }

        public ActionResult IngresoDiario()
        {
            return View();
        }

        [HttpPost]
        [ActionName("IngresoDiario")]
        public ActionResult IngresoDiario_Post()
        {

            //crea documento y asigna tam pagina y margenes
            Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 15);
            //crea instancia de PDFWriter
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();

            // ############# FORMATEO DE DOCUMENTO #########################

            Chunk chunk = new Chunk("REPORTE INGRESOS DIARIOS", FontFactory.GetFont("Arial", 20, Font.BOLD, BaseColor.BLACK));
            pdfDoc.Add(chunk);

            Paragraph line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            pdfDoc.Add(line);

            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            table.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;

            //Cell no 1
            PdfPCell cell = new PdfPCell();
            cell.Border = 0;
            Image image = Image.GetInstance(Server.MapPath("~/Content/Images/RestSiglo21Logo.png"));
            image.ScaleAbsolute(200, 150);
            cell.AddElement(image);
            table.AddCell(cell);

            //Cell no 2
            chunk = new Chunk("Restaurant SIGLO XXI\nInformes de Gestión\nMonto de ventas por día", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK));
            cell = new PdfPCell();
            cell.Border = 0;
            cell.AddElement(chunk);
            table.AddCell(cell);

            //Add table to document    
            pdfDoc.Add(table);

            //Image image = Image.GetInstance(Server.MapPath("~/Content/Images/RestSiglo21Logo.png") );
            image.ScalePercent(50f);
            image.SetAbsolutePosition(440, 10);
            image.ScaleToFit(120f, 155.25f);





            Paragraph para = new Paragraph("Detalle del reporte:");
            pdfDoc.Add(para);


            //var resumenCompra = System.Web.HttpContext.Current.Session["resumenCompra"];

            List<IngresoDiarioViewModel> listaIngresoDiario = new List<IngresoDiarioViewModel>();
            listaIngresoDiario = (List<IngresoDiarioViewModel>)System.Web.HttpContext.Current.Session["ingresoDiario"];
            IngresoDiarioViewModel objVista = new IngresoDiarioViewModel();

            //vistaDetOrdenes = objVistaOrdenes;
            //var objVistaOrdenes2 = (List<VistaDetOrdenes>)System.Web.HttpContext.Current.Session["resumenCompra"];
            //var objVistaOrdenes2 = (List<VistaDetOrdenes>)objVistaOrdenes;
            string hoy = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString();
            int x = 9;



            x = 10;


            //Table
            table = new PdfPTable(3);
            table.WidthPercentage = 100;
            table.HorizontalAlignment = 0;
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;
            //Celda
            cell = new PdfPCell();
            chunk = new Chunk("Ingresos Diarios");
            cell.AddElement(chunk);
            cell.Colspan = 5;
            cell.BackgroundColor = BaseColor.GRAY;
            table.AddCell(cell);

            table.AddCell("#");
            table.AddCell("Fecha");
            table.AddCell("Monto");

            int i = 1;
            foreach (var item in listaIngresoDiario)
            {
                table.AddCell(i.ToString());
                table.AddCell(item.FechaIngreso.ToString());
                table.AddCell(item.TotalIngreso.ToString());

                i++;
            }
            //Cell



            //Add table to document
            pdfDoc.Add(table);

            //###################################


            //#################   FIN DE FORMATEO DE DOCUMENTO  ###############


            pdfWriter.CloseStream = false;
            pdfDoc.Close();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            string attach = "attachment;filename=" + hoy + " Reporte_IngresoDiario.pdf";
            Response.AddHeader("content-disposition", attach);
            //Response.AddHeader("content-disposition", "attachment;filename=hoy+Comprobante_Pago.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();

            return View();
        }

        public ActionResult AtencionesPorDia()
        {
            return View();
        }

        [HttpPost]
        [ActionName("AtencionesPorDia")]
        public ActionResult AtencionesPorDia_Post()
        {
            //crea documento y asigna tam pagina y margenes
            Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 15);
            //crea instancia de PDFWriter
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();

            // ############# FORMATEO DE DOCUMENTO #########################

            Chunk chunk = new Chunk("REPORTE ATENCIONES DIARIAS", FontFactory.GetFont("Arial", 20, Font.BOLD, BaseColor.BLACK));
            pdfDoc.Add(chunk);

            Paragraph line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            pdfDoc.Add(line);

            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            table.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;

            //Cell no 1
            PdfPCell cell = new PdfPCell();
            cell.Border = 0;
            Image image = Image.GetInstance(Server.MapPath("~/Content/Images/RestSiglo21Logo.png"));
            image.ScaleAbsolute(200, 150);
            cell.AddElement(image);
            table.AddCell(cell);

            //Cell no 2
            chunk = new Chunk("Restaurant SIGLO XXI\nInformes de Gestión\nCantidad de Atenciones por día", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK));
            cell = new PdfPCell();
            cell.Border = 0;
            cell.AddElement(chunk);
            table.AddCell(cell);

            //Add table to document    
            pdfDoc.Add(table);

            //Image image = Image.GetInstance(Server.MapPath("~/Content/Images/RestSiglo21Logo.png") );
            image.ScalePercent(50f);
            image.SetAbsolutePosition(440, 10);
            image.ScaleToFit(120f, 155.25f);





            Paragraph para = new Paragraph("Detalle del reporte:");
            pdfDoc.Add(para);


            //var resumenCompra = System.Web.HttpContext.Current.Session["resumenCompra"];

            List<VentaDiaViewModel> listaAtencionesDiarias = new List<VentaDiaViewModel>();
            listaAtencionesDiarias = (List<VentaDiaViewModel>)System.Web.HttpContext.Current.Session["atencionesDiarias"];
            VentaDiaViewModel objVista = new VentaDiaViewModel();

            //vistaDetOrdenes = objVistaOrdenes;
            //var objVistaOrdenes2 = (List<VistaDetOrdenes>)System.Web.HttpContext.Current.Session["resumenCompra"];
            //var objVistaOrdenes2 = (List<VistaDetOrdenes>)objVistaOrdenes;
            string hoy = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString();
            int x = 9;



            x = 10;


            //Table
            table = new PdfPTable(3);
            table.WidthPercentage = 100;
            table.HorizontalAlignment = 0;
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;
            //Celda
            cell = new PdfPCell();
            chunk = new Chunk("Atenciones Diarias");
            cell.AddElement(chunk);
            cell.Colspan = 5;
            cell.BackgroundColor = BaseColor.GRAY;
            table.AddCell(cell);

            table.AddCell("#");
            table.AddCell("Fecha");
            table.AddCell("Cantidad de Atenciones");

            int i = 1;
            foreach (var item in listaAtencionesDiarias)
            {
                DateTime date = (DateTime)item.FechaVenta;

                DateTime fechaMod = date.Date;

                string fecha = fechaMod.Day.ToString() + "/" + fechaMod.Month.ToString() + "/" + fechaMod.Year.ToString();
                int y = 5;
                table.AddCell(i.ToString());
                table.AddCell(fecha);
                //table.AddCell(item.FechaVenta.ToString());
                table.AddCell(item.CantidadVentas.ToString());

                i++;
            }
            //Cell



            //Add table to document
            pdfDoc.Add(table);

            //###################################


            //#################   FIN DE FORMATEO DE DOCUMENTO  ###############


            pdfWriter.CloseStream = false;
            pdfDoc.Close();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            string attach = "attachment;filename=" + hoy + " Reporte_AtencionesDiarias.pdf";
            Response.AddHeader("content-disposition", attach);
            //Response.AddHeader("content-disposition", "attachment;filename=hoy+Comprobante_Pago.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();

            return View();
        }

    }
}