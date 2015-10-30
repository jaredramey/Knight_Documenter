using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Knight_Documenter_C
{
    /*
     * This class is to be designed for the use of opening, reading and extracting information/ text
     * from C# and Cpp files (Reading from .txt format)
     */

    /*
     * Documentation Types so far:
     * + Comment Extraction
     */
    //=================================\\
    /*
     * Possible Documentation Types to add
     * - Save Comment Extraction as a .txt/ .pdf file
     * - Class Diagram
     * - XAML Diagram
     * - Program Flow Diagram
     * 
     * ================ *
     * Need to do research on the following:
     * = Open all C++/ C# files off a .sln fileioo
     * = Drawing to a picture
     * = Other forms of Documentation
     */

    //Enum to differentiate between documentation styles
    //Starting with comment extraction and then from there i'll add more as 
    //I figure out different documentation types and how to impliment them.
    enum Method { eComments, eClasses, eClassFunc, eOther };

    class Reader
    {

        //Buffer for file reading, edit to improve reading
        const Int32 BufferSize = 128;

        //public functions


        //Open file and call other methods as necessary for what is requested by user
        //ie: Comment extraction would be called as OpenFile("filePath", eComments)
                        /*=============================================================================================================*/
                        /*Main function that all data/ functions will be passed through for reading and extracting data from text files*/
                        /*=============================================================================================================*/
        public List<string> OperateOnFile(string[] filePaths, Method method)
        {
            //List to return
            List<string> returnedLines;

            //Switch the enum for whatever is requested
            switch(method)
            {
                case Method.eComments:
                    //Call function to extract all commented lines
                    returnedLines = CommentExtraction(filePaths);
                    //return all commented lines from file (commented via "//")
                    return returnedLines;

                case Method.eClasses:
                    //Call function to extract all classes
                    returnedLines = GetAllClasses(filePaths);
                    /*
                     * Placing this function here temporarily in order
                     * to test it as it's created.
                     */
                    GetClassFuncs(filePaths);
                    //return the extracted class references
                    return returnedLines;



                default:
                    return null;
            }
        }


        //Function to get all commented lines
        /*
         * This function can now extract all comments in a file
         * declared via "//"
         */
        private List<string> CommentExtraction(string[] FilePath)
        {
            //A string to temporarily store any lines starting with "//"
            string line;
            List<string> commentedLines = new List<string>();

            //two characters to hold values in order to check
            //if a comment declaration has started anywhere in the line
            char newChar = '\0', preChar = '\0';

            //Loop through each file
            for (int i = 0; i < FilePath.Length; i++)
            {
                //Open up the file
                System.IO.StreamReader file = new System.IO.StreamReader(FilePath[i]);

                while ((line = file.ReadLine()) != null)
                {
                    //check to make sure line is longer then 2 characters as to not get an error
                    if (line.Length >= 2)
                    {
                        //Get first two characters of the line
                        string firstTwo = line.Substring(0, 2);
                        //Check to see if the first two characters are declaring a commented line
                        if (firstTwo == "//")
                        {
                            commentedLines.Add(line);
                        }

                        //if not then check the rest of the line for a comment
                        else
                        {

                            //loop through and check to see if a comment is made anywhere in the line
                            for (int j = 0; j < line.Length; j++)
                            {
                                newChar = line[j];

                                //make sure the previous character isn't nothing
                                if (preChar != '\0')
                                {
                                    //check to see if the previous character and the newest characters match.
                                    //if they do then a comment has begun
                                    if(preChar == newChar && j > 0)
                                    {
                                        commentedLines.Add(line.Remove(0, j-2));
                                        
                                    }
                                }

                                //set previous character to the character we just went over in the line
                                //set new character to the next character in the line
                                else 
                                {
                                    preChar = newChar;
                                }
                            }

                            //Set the previousChar and newChar to thier default value
                            //in order to prevent character matching between the end
                            //of one line and the start of another
                            preChar = '\0';
                            newChar = '\0';
                        }
                    }

                    //if the length is less then 2 then continue through the loop
                    else
                    {
                    }

                    //repeat till no other lines in the file
                }

                //close the file
                file.Close();
            }

            //return the list of commented lines
            return commentedLines;
        }


        //This function call is used to extract class names
        /*
         * This function is used to cycle through all given files
         * and return a list of Class Names
         */
        private List<string> GetAllClasses(string[] filePaths)
        {
            //String to temporarily store any lines that contain "class"
            string line; 
            List<string> classes = new List<string>();

            //Loop through each filepath given
            for (int i = 0; i < filePaths.Length; i++)
            {
                //Open up the file
                System.IO.StreamReader file = new System.IO.StreamReader(filePaths[i]);

                //Loop through current file until there are no more lines to read
                while ((line = file.ReadLine()) != null)
                {
                    //if the line contains class or Class then add it to the List to be returned
                    if(line.Contains("class") || line.Contains("Class"))
                    {
                        classes.Add(line);
                    }

                    else 
                    {
                        //Continue through the loop if there is no reference to a class
                    }
                }
            }

            return classes;
        }

        /*
         * This function is to be designed for pulling out all functions of classes and the classes themselfs.
         * After that it is to pair each function to it's respective class in a dictionary.
         * ===================================================================================================
         * Namely this function in particular is for the use of extracting information out of files for
         * the Draw class so it can populate all the class squares(?) it makes with text to make it more
         * readable.
         * 
         * (?) -- Not sure yet as to if that's how i'm going to roll the class diagram as of yet. Still
         *        need to research class diagrams furthur in order to make sure that the diagrams my tool
         *        creates are up to the standards of the industry.
         */
        //|====================================================================================================|\\
        /*
         * Ect. Thoughts:
         * - For more user diversity should I set a flag between pulling out just the fucntion name
         *   or pulling both the function name and what the function calls for?
         */
        public Dictionary<string, string> GetClassFuncs(string[] filePaths)
        {
            //temp string to store located value
            string line;
            Dictionary<string, string> result = new Dictionary<string, string>();

            //Loop through each filepath given
            for (int i = 0; i < filePaths.Length; i++)
            {
                //Open up the file
                System.IO.StreamReader file = new System.IO.StreamReader(filePaths[i]);

                //int to hold amount of lines there are in the file currently being worked on
                int linesInFile = 0;
                while ((line = file.ReadLine()) != null)
                {
                    linesInFile++;
                }

                //Loop through current file until there are no more lines to read
                while ((line = file.ReadLine()) != null)
                {
                    if(line.Contains("Class"))
                    {
                        /*Had a for loop sitting here for no apparent reason(?)
                         * If I figure out why it was here later then i'll put it back
                         */
                            //removing
                            result.Add("class", line.Remove(0, 6));
                    }

                    /*
                     * Basic function extraction
                     * Will have to find a better way to parse for functions
                    */
                    else if (line.Contains("public") || line.Contains("private") || line.Contains("protected") || line.Contains("::"))
                    {
                        result.Add("func", line);
                    }
                     
                }
            }
            return result;
        }

    }
}
