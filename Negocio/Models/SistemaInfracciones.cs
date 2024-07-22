using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Business.BLL;
using Business.Enums;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using SkiaSharp;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.SkiaSharp.Rendering;

namespace Business.Models
{
    public class SistemaInfracciones
    {
        private readonly InfraccionesBLL _infracciones = new InfraccionesBLL();
        private readonly RegistrosInfraccionesBLL _registros = new RegistrosInfraccionesBLL();
        private readonly VehiculosBLL _vehiculos = new VehiculosBLL();

        public List<Infraccion> Infracciones => _infracciones.GetAllInfracciones();
        public List<Vehiculo> Vehiculos => _vehiculos.GetAllVehiculos();
        public List<RegistroInfraccion> Registros => _registros.GetAllRegistros();

        public List<RegistroInfraccion> GetRegistrosPendientes(string dominio)
        {
            return _registros.GetRegistrosPendientes(dominio);
        }

        public List<RegistroInfraccion> GetRegistrosPagos(string dominio)
        {
            return _registros.GetRegistrosPagos(dominio);
        }

        public void CrearInfraccion(string descripcion, decimal importe, TipoInfraccion tipo)
        {
            _infracciones.Agregar(new Infraccion(descripcion, importe, tipo));
        }

        public void EditarInfraccion(int id, string descripcion, decimal importe, TipoInfraccion tipo)
        {
            _infracciones.Editar(new Infraccion(id, descripcion, importe, tipo));
        }

        public void DarBajaInfraccion(int id)
        {
            _infracciones.Eliminar(id);
        }

        public void CrearVehiculo(string dominio)
        {
            _vehiculos.Agregar(new Vehiculo(dominio));
        }

        public void DarBajaVehiculo(int id)
        {
            _vehiculos.Eliminar(id);
        }

        public void PagarRegistroInfraccion(int id)
        {
            _registros.Pagar(id);
        }

        public void CrearRegistro(Infraccion infraccion, string dominio, DateTime fs)
        {
            _registros.Agregar(new RegistroInfraccion(infraccion, dominio, fs));
        }

        public void EditarRegistro(int id, Infraccion infraccion, string dominio, DateTime fs)
        {
            _registros.Editar(new RegistroInfraccion(id, infraccion, dominio, fs));
        }

        public void EliminarRegistro(int id)
        {
            _registros.Eliminar(id);
        }

        public Vehiculo BuscarVehiculo(string dominio)
        {
            return _vehiculos.GetVehiculo(dominio);
        }

        public void DescargarPDF(int id, MemoryStream memoryStream)
        {
            var registro = Registros.Find(i => i.ID == id);

            if (registro == null)
            {
                throw new Exception("No se encontró el registro de infracción.");
            }

            var vencimiento = registro.FechaVencimiento.ToString("dd/MM/yyyy");
            var dominio = registro.VehiculoDominio;

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var doc = new PdfDocument();
            var page = doc.AddPage();

            var gfx = XGraphics.FromPdfPage(page);
            var font = new XFont("Arial", 20, XFontStyleEx.Bold);
            var smallFont = new XFont("Arial", 12);
            var linePen = new XPen(XColors.Black, 1);

            double marginTop = 40;
            const double lineHeight = 30;
            const double qrCodeSize = 100;
            const double barcodeWidth = 200;
            const double barcodeHeight = 50;

            // Dibujar los datos de la orden
            gfx.DrawString("ORDEN DE PAGO INFRACCIÓN DE TRÁNSITO", font, XBrushes.Black,
                new XRect(0, marginTop, page.Width, lineHeight), XStringFormats.TopCenter);
            marginTop += lineHeight + 20;

            gfx.DrawString("Orden de pago: " + id, smallFont, XBrushes.Black,
                new XRect(40, marginTop, page.Width - 80, lineHeight), XStringFormats.TopLeft);
            marginTop += lineHeight;

            gfx.DrawString("Dominio: " + dominio, smallFont, XBrushes.Black,
                new XRect(40, marginTop, page.Width - 80, lineHeight), XStringFormats.TopLeft);
            marginTop += lineHeight;

            gfx.DrawString("Monto a pagar: $" + registro.ImporteFinal.ToString("N2"), smallFont, XBrushes.Black,
                new XRect(40, marginTop, page.Width - 80, lineHeight), XStringFormats.TopLeft);
            marginTop += lineHeight;

            gfx.DrawString("Vencimiento: " + vencimiento, smallFont, XBrushes.Black,
                new XRect(40, marginTop, page.Width - 80, lineHeight), XStringFormats.TopLeft);
            marginTop += lineHeight;

            // Separador
            marginTop += 10;
            gfx.DrawLine(linePen, 40, marginTop, page.Width - 40, marginTop);

            //marginTop += 20;
            // //Agregar imagen
            //var imagePath = "C:\\Users\\Admin\\Downloads\\b241f605f14ef4ff22fb92806041df2b.jpg";
            //var backgroundImage = XImage.FromFile(imagePath);
            //gfx.DrawImage(backgroundImage, 40, marginTop, page.Width - 80, page.Height - marginTop - qrCodeSize - 40);

            // Generar y dibujar código QR
            var qrWriter = new BarcodeWriter<SKBitmap>
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    Width = (int)qrCodeSize,
                    Height = (int)qrCodeSize
                },
                Renderer = new SKBitmapRenderer()
            };
            var qrBitmap = qrWriter.Write("Orden de pago: " + id);
            using (var qrStream = new MemoryStream())
            {
                qrBitmap.Encode(qrStream, SKEncodedImageFormat.Png, 100);
                qrStream.Seek(0, SeekOrigin.Begin);
                var qrImage = XImage.FromStream(qrStream);
                double qrImageY = page.Height - qrCodeSize - 20;
                gfx.DrawImage(qrImage, 40, qrImageY);
            }

            // Generar y dibujar código de barras
            var barcodeWriter = new BarcodeWriter<SKBitmap>
            {
                Format = BarcodeFormat.CODE_128,
                Options = new EncodingOptions
                {
                    Width = (int)barcodeWidth,
                    Height = (int)barcodeHeight
                },
                Renderer = new SKBitmapRenderer()
            };
            var barcodeBitmap = barcodeWriter.Write(id.ToString());
            using (var barcodeStream = new MemoryStream())
            {
                barcodeBitmap.Encode(barcodeStream, SKEncodedImageFormat.Png, 100);
                barcodeStream.Seek(0, SeekOrigin.Begin);
                var barImage = XImage.FromStream(barcodeStream);
                double barcodeImageX = page.Width - barcodeWidth - 40;
                double barcodeImageY = page.Height - barcodeHeight - 20;
                gfx.DrawImage(barImage, barcodeImageX, barcodeImageY);
            }

            doc.Save(memoryStream, false);
        }
    }
}