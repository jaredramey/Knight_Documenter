using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Knight_Documenter_C
{
    /*
     * This class is to be designed for the use of taking extracted data from .cs/.cpp files
     * and creating any visual type of documentation.
     */

    //Enum to differentiate (<-- spell check that later) in between the different function calls
    enum VisualMethod { eClassDiag, eXAMLDaig, eOther};

    class Draw
    {
        canvasWindow myCanvas;

        public Dictionary<string, string> ClassFuncs = new Dictionary<string,string>();

        /*
         * Temp placement of function until I know what the return type is
         * and how to proceede with function
         */
        public void OperateOnFiles(VisualMethod method, Dictionary<string, string> DictionaryToOperateOn)
        {

            switch(method)
            {
                    //If the user wants a class diagram
                case VisualMethod.eClassDiag:
                    CreateClassDiag(DictionaryToOperateOn);
                    break;

                    //If the user wants a XAML diagram
                case VisualMethod.eXAMLDaig:
                    CreateXAMLDiag();
                    break;

                    //Filler enum until I know what other functions i'm making
                case VisualMethod.eOther:
                    break;

                    //default case just in case the user some how forces
                    //through function selection
                default:
                    /*
                     * Need to find a way to make a message box showing an error
                     * Or should I push up the error to the main window to spit it out?
                     */
                    break;
            }
        }

        /*
         * Temp placement of function until I know what the return type is
         * and how to proceede with function
         */
        private List<string> CreateClassDiag(Dictionary<string, string> ClassDictionary)
        {
            List<string> returnedLines = new List<string>();

            /*
             * From my understanding of how dictionaries work (so far), the idea
             * is to fill out the dictionary like [className][classFunction]. So I should
             * be able to cycle through that and build the basis of a class diagram
             * (ie. build and fill class 'boxes'). From there I need to figure out how to capture
             * references from one class function to another while i'm parssing all the info. If I
             * get that then it should just be as simple as drawing a line from one class to another.
             */

            /* EDIT: =============================================================================================
             * Might have to scrap the dictionary idea and plan to use reflection. It might work better if I     |
             * just have a ParsedClass class and have a list of function names within that. Then I don't have    |
             * to mess around with Dictionaries since they're something I don't know and i'll be able to visualy |
             * see what should be in the class bassed off of my example text files that i'm using for testing.   |
             * 
             * ALSO:
             * Need to move this function over to the reader class. This class should be doing nothing but taking
             * the data I extract and draw it onto a new window. Might add the save function in here as well but
             * there should be no harm done in putting the save function in this class.
             */

            //TODO
            /*
             * Create New Window
             * Add text boxes to window
             *      LAYOUT:
             *          _________________
             *          | Class Name    |
             *          |---------------|
             *          | Function One  |
             *          | Function Two  |
             *          | Ect. Function |
             *          |---------------|
             *  Figure out a way to draw a line connecting classes that
             *  interact with each other
             *  Display all that info to the user via the window
             *  Figure out a way to save that as a either a .jpg or as a .png
             */

                //TODO: Figure out how to loop through each key and then each value in each key.
            foreach(KeyValuePair<string, string> entry in ClassDictionary)
            {
                //add current key + value to a list for debuggin purposes
                returnedLines.Add(entry.Key + entry.Value);

                TextBlock ClassBox = new TextBlock();
                ClassBox.Text = entry.Key + entry.Value;
            }

            //show window and wait to continue function till that window closes
            myCanvas.ShowDialog();


            return returnedLines;
        }

        private void CreateXAMLDiag()
        {

        }

        private void SaveDiag()
        {
            /*
             * this function should be called in order to save the diagram that has been drawn
             * to a specified path. Maybe create a default path for a folder that the tool creates
             * upon install and let the user have the choice of editing the path from there?
             */
        }

    }
}
