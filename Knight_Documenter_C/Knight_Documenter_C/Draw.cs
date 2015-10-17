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
                    
                    break;

                    //If the user wants a XAML diagram
                case VisualMethod.eXAMLDaig:
                    break;

                    //Filler enum until I know what other functions i'm making
                case VisualMethod.eOther:
                    break;

                    //default case just in case the user some how forces
                    //through function selection
                default:
                    
                    break;
            }
        }

        /*
         * Temp placement of function until I know what the return type is
         * and how to proceede with function
         */
        private void CreateClassDiag()
        {
            
        }

        private void CreateXAMLDiag()
        {

        }

    }
}
