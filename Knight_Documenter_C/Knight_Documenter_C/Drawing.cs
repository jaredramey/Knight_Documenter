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

        private void GetTextBlockSize(TextandShape shapeObject)
        {
            shapeObject.textToShow.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
            shapeObject.textToShow.Arrange(new Rect(shapeObject.textToShow.DesiredSize));
        }

        private void WriteTextOnObject(string TextToWrite, TextandShape shapeObject)
        {
            shapeObject.textToShow.Text = TextToWrite;
            GetTextBlockSize(shapeObject);
            shapeObject.recHieght = shapeObject.textToShow.ActualHeight;
            shapeObject.recWidth = shapeObject.textToShow.ActualWidth;
        }

        private void SetObjectPos(TextandShape shapeObject, double X, double Y)
        {
            shapeObject.posX = X;
            shapeObject.posY = Y;
        }

        private Shape DrawLine(float[] posA, float[] posB)
        {
            Shape line = new Line() { X1 = posA[0], Y1 = posA[1], X2 = posB[0], Y2 = posB[1]};
            return line;
        }

        public void DrawLineBetweenBoxes(TextandShape obj1, TextandShape obj2, Canvas CanvasToDrawOn)
        {
            float[] pos1 = {(float)obj1.posX, (float)obj2.posY};
            float[] pos2 = {(float)obj2.posX, (float)obj2.posY};

            CanvasToDrawOn.Children.Add(DrawLine(pos1, pos2));
        }

        //Create and prep for drawing a new shape.
        public TextandShape CreateRectangleWithText(Canvas CanvasToDrawOn, string TextToWrite, float _X, float _Y)
        {
            //Create new object to populate
            TextandShape newRect = new TextandShape();
            WriteTextOnObject(TextToWrite, newRect);
            SetObjectPos(newRect, _X, _Y);
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
