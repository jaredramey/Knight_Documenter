using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

        public Dictionary<string, string> ClassFuncs = new Dictionary<string,string>();

        /*
         * Temp placement of function until I know what the return type is
         * and how to proceede with function
         */
        public void OperateOnFiles(VisualMethod method)
        {

            switch(method)
            {
                    //If the user wants a class diagram
                case VisualMethod.eClassDiag:
                    CreateClassDiag();
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
        private void CreateClassDiag()
        {
            /*
             * From my understanding of how dictionaries work (so far), the idea
             * is to fill out the dictionary like [className][classFunction]. So I should
             * be able to cycle through that and build the basis of a class diagram
             * (ie. build and fill class 'boxes'). From there I need to figure out how to capture
             * references from one class function to another while i'm parssing all the info. If I
             * get that then it should just be as simple as drawing a line from one class to another.
             */
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
