using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace Knight_Documenter_C
{
    class Drawing
    {
        private Canvas ResultCanvas { get; set; }

        public void CreateCanvas()
        {
            ResultCanvas = new Canvas();
        }

        public Canvas GetCanvas()
        {
            return ResultCanvas;
        }

        public float[] GetTextBlockSize(string TextToCheck)
        {
            float[] size = new float[1];
        }

        public void WriteTextOnObject(string TextToWrite, int ObjectPositionInList)
        {
            TextBlock textToWrite = new TextBlock() { Text = TextToWrite};


        }

        //Draw a shape to the new canvas.
        public void DrawRectanlgeAtPosition(Canvas CanvasToDrawOn, float _X, float _Y, float _Height, float _Width)
        {
            Shape ObjectToDraw = new Rectangle() { Height = _Height, Width = _Width, Stroke = Brushes.Black};
            ResultCanvas.Children.Add(ObjectToDraw);

            Canvas.SetLeft(CanvasToDrawOn, _X);
            Canvas.SetTop(CanvasToDrawOn, _Y);
        }
    }
}
