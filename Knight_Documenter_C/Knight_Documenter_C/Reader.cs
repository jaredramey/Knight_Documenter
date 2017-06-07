using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Knight_Documenter_C
{
    class Reader
    {
        //Buffer for file reading
        private const Int32 BufferSize = 128;

        public enum Method { eComments, eClasses, eFunctions};

        #region Public_Interface
        /* Function for interacting with files based on what info you want to extract.
         * Reader.Method.Comments  = Extraction of all commented lines in selected files.
         * Reader.Method.Classes   = Extraction of all lines that contain the class keyword.
         * Reader.Method.Functions = Extraction of all lines that contain a function declaration.
         *                           (ie: "public", "private" or "void" as well as a closing bracket ")")
         */
        public List<string> OperateOnFile(string[] filePaths, Method selectedMethod)
        {
            //Stored Lines
            List<string> returnedLines;

            //Switch to handle which parsing function is used
            switch(selectedMethod)
            {
                case Method.eComments:
                    returnedLines = CommentExtraction(filePaths);
                    return returnedLines;

                case Method.eClasses:
                    returnedLines = ClassExtraction(filePaths);
                    return returnedLines;

                case Method.eFunctions:
                    returnedLines = FunctionExtraction(filePaths);
                    return returnedLines;

                default:
                    return null;
            }
        }
        #endregion

        #region ParsingFunctions
        // This function extracts all comments in a file declared via "//"
        private List<string> CommentExtraction(string[] filePaths)
        {
            //All found lines
            List<string> commentedLines = null;
            //Temp variable to store currently parsed line
            string line;
            //Two temp variables to hold values in order to check if a comment declaration has started anywhere in the line.
            char newChar = '\0', preChar = '\0';

            //Loop to parse each selected file
            for (int i = 0; i <= filePaths.Length; i++ )
            {
                //Open the file
                System.IO.StreamReader file = new System.IO.StreamReader(filePaths[i]);

                //Loop through each line of the current file
                while((line = file.ReadLine()) != null)
                {
                    //Check to see if current line is longer then 2 characters in order to avoid errors as well
                    //as setting up a check for comment declaration at the start of the line.
                    string firstTwo = line.Substring(0, 2);

                    //Check to see if a comment declaration has been made.
                    if(firstTwo == "//")
                    {
                        //If a comment declaration has been made then add it to the list of found lines.
                        commentedLines.Add(line);
                    }

                    //If no function declaration was found at the start of the line then check the rest of the line.
                    else
                    {
                        //Loop through the characters in the line
                        for(int j = 0; j <= line.Length; j++)
                        {
                            newChar = line[j];

                            //Make sure previous character isn't nothing
                            if(preChar != '\0')
                            {
                                //Check to see if both prevChar and newChar are both "/"
                                //if so then a comment has been declared.
                                if((preChar == '/' && newChar == '/') && j > 0)
                                {
                                    //If a comment has been declared then remove everything else up to this point
                                    //and add the line to the list of found lines.
                                    commentedLines.Add(line.Remove(0, j - 2));
                                }
                            }

                            //Set preChar to the character we just looped over in the line
                            else
                            {
                                preChar = newChar;
                            }
                        }

                        //Set temp variables back to default value in order to prevent
                        //character matching from the end of one line to the start of another.
                        preChar = '\0';
                        newChar = '\0';
                    }

                //Repeat until there are no other lines in the file.
                }

                //Close the file
                file.Close();
            }

                return commentedLines;
        }

        private List<string> ClassExtraction(string[] filePaths)
        {
            List<string> classLines = null;

            return classLines;
        }

        private List<string> FunctionExtraction(string[] filePaths)
        {
            List<string> functionLines = null;

                return functionLines;
        }
        #endregion
    }
}
