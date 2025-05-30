using System;
using System.Diagnostics;
using System.IO;
using LoginV1.Models;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace LoginV1.Models
{
    public class FacturaService
    {
        /// <summary>
        /// Genera un PDF con la factura de la multa completamente pagada.
        /// </summary>
        /// <param name="multa">Objeto MultaDetalle con toda la info.</param>
        /// <param name="rutaArchivo">
        /// Ruta de archivo opcional. Si es null o vacío, se guarda en el Escritorio.
        /// </param>
        /// <returns>Ruta completa del PDF generado.</returns>
        public string GenerarFacturaMulta(MultaDetalle multa, string rutaArchivo = null)
        {
            if (multa == null)
                throw new ArgumentNullException(nameof(multa));

            // 1. Creación del documento y configuración
            using (var documento = new PdfDocument())
            {
                documento.Info.Title = $"Factura Multa #{multa.IdMulta}";

                PdfPage pagina = documento.AddPage();
                using (XGraphics gfx = XGraphics.FromPdfPage(pagina))
                {
                    // 2. Fuentes PDFsharp
                    var fuenteTitulo = new XFont("Verdana", 14, XFontStyle.Bold);
                    var fuenteNormal = new XFont("Verdana", 10, XFontStyle.Regular);

                    int y = 40;
                    const int salto = 25;

                    void Escribir(string texto, XFont fuente = null)
                    {
                        if (fuente == null)
                        {
                            fuente = fuenteNormal;
                        }
                        gfx.DrawString(
                            texto,
                            fuente,
                            XBrushes.Black,
                            new XRect(40, y, pagina.Width - 80, salto),
                            XStringFormats.TopLeft);
                        y += salto;
                    }

                    // 3. Cabecera
                    Escribir("📚 El Faro del Saber", fuenteTitulo);
                    Escribir($"📄 Factura Multa ID: {multa.IdMulta}");
                    Escribir($"Fecha emisión: {DateTime.Now:dd/MM/yyyy}");
                    Escribir("");

                    // 4. Datos de usuario
                    Escribir("🧍 Usuario:");
                    Escribir($"Nombre: {multa.NombreUsuario}");
                    Escribir($"Documento: {multa.DocumentoIdentidad}");
                    Escribir($"Tipo: {multa.TipoUsuario}");
                    Escribir("");

                    // 5. Datos de préstamo y libro
                    Escribir("📘 Préstamo:");
                    Escribir($"Libro: {multa.TituloLibro}");
                    Escribir($"ISBN: {multa.ISBN}");
                    Escribir($"Fecha préstamo: {multa.FechaPrestamo:dd/MM/yyyy}");
                    Escribir($"Límite devolución: {multa.FechaLimite:dd/MM/yyyy}");
                    Escribir($"Devolución real: {(multa.FechaDevolucionReal?.ToString("dd/MM/yyyy") ?? "Pendiente")}");
                    Escribir($"Días retraso: {multa.DiasRetraso}");
                    Escribir("");

                    // 6. Detalle de la multa
                    Escribir("💰 Detalle multa:");
                    Escribir($"Tarifa diaria: {multa.TarifaDiaria:C}");
                    Escribir($"Monto total: {multa.MontoTotal:C}", fuenteTitulo);
                    Escribir($"Estado: {multa.Estado}");
                    Escribir("");
                }

                // 7. Ruta de guardado por defecto
                if (string.IsNullOrWhiteSpace(rutaArchivo))
                {
                    string fileName = $"Factura_Multa_{multa.IdMulta}_{DateTime.Now:yyyyMMddHHmmss}.pdf";
                    rutaArchivo = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                        fileName);
                }

                // 8. Guardar y retornar ruta
                documento.Save(rutaArchivo);
                return rutaArchivo;
            }

        }

        /// <summary>
        /// Abre el PDF generado con el visor predeterminado del sistema.
        /// </summary>
        public void AbrirFactura(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
                throw new FileNotFoundException("No se encontró el archivo de factura.", rutaArchivo);

            Process.Start(new ProcessStartInfo
            {
                FileName = rutaArchivo,
                UseShellExecute = true
            });
        }
    }
}

