using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace scg.Windows.Utils
{
    public static class UserControlExporter
    {
        public static void SaveAsImage(UserControl view, string filename)
        {
            var size = new Size(view.Width, view.Height);
            if (size.IsEmpty) throw new InvalidOperationException("Size is empty.");

            var renderTargetBitmap = new RenderTargetBitmap((int)size.Width, (int)size.Height, 96, 96, PixelFormats.Pbgra32);

            var drawingVisual = new DrawingVisual();
            using (var context = drawingVisual.RenderOpen())
            {
                context.DrawRectangle(new VisualBrush(view), null, new Rect(new Point(), size));
                context.Close();
            }

            renderTargetBitmap.Render(drawingVisual);

            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
            using var stream = System.IO.File.Open(filename, FileMode.OpenOrCreate);
            encoder.Save(stream);
        }
    }
}
