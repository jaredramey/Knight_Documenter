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
    public class TextandShape
    {
        public Canvas canvasToDrawOn;
        public double posX = 0, posY = 0;
        public double recHieght = 0, recWidth = 0;
        public TextBlock textToShow = new TextBlock();
        public Shape shape = new Rectangle();
    }

    class Drawing
    {
        private Canvas ResultCanvas { get; set; }
        public Drawing Instance {get; set;}
        

        public void CreateCanvas()
        {
            ResultCanvas = new Canvas();
        }

        public Canvas GetCanvas()
        {
            return ResultCanvas;
        }

        public void GetTextBlockSize(string TextToCheck)
        {
            
        }

        public void WriteTextOnObject(string TextToWrite)
        {
            TextBlock textToWrite = new TextBlock() { Text = TextToWrite};


        }

        //Create and prep for drawing a new shape.
        public TextandShape CreateRectangleWithText(Canvas CanvasToDrawOn, string TextToWrite, float _X, float _Y)
        {
            //Create new object to populate
            TextandShape newRect = new TextandShape();
            newRect.textToShow.Text = TextToWrite;

            //Measure to get how big the rectangle will need to be
            newRect.textToShow.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
            newRect.textToShow.Arrange(new Rect(newRect.textToShow.DesiredSize));

            //Populate new object with all necessary information
            newRect.recHieght = newRect.textToShow.ActualHeight;
            newRect.recWidth = newRect.textToShow.ActualWidth;
            newRect.posX = _X;
            newRect.posY = _Y;
            newRect.canvasToDrawOn = CanvasToDrawOn;

            //Create the rectangle
            newRect.shape = new Rectangle() { Height = newRect.recHieght, Width = newRect.recWidth, Stroke = Brushes.Black };
            newRect.canvasToDrawOn.Children.Add(newRect.shape);
            newRect.canvasToDrawOn.Children.Add(newRect.textToShow);

            //Set the objects position on the canvas
            Canvas.SetLeft(newRect.shape, newRect.posX);
            Canvas.SetTop(newRect.shape, newRect.posY);
            Canvas.SetLeft(newRect.textToShow, newRect.posX);
            Canvas.SetTop(newRect.textToShow, newRect.posY);

            //Return the object so the object can be added to a set later.
            return newRect;
        }
    }
}
