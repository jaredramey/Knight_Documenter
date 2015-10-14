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

    //Enum to differentiate between documentation styles
    //Starting with comment extraction and then from there i'll add more as 
    //I figure out what I want to include
    enum Method { eComments, eOther };

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

                default:
                    return null;
            }
        }


        //Function to get all commented lines
        /*
         * Will have to update this function later
         * Need to loop through the entire line to check if "//" is ever
         * done later in the line and pull all characters after that
         * just in case someone decides to comment on a line of coode after
         * the line is done
         */
        private List<string> CommentExtraction(string[] FilePath)
        {
            //A string to temporarily store any lines starting with "//"
            string line;
            List<string> commentedLines = new List<string>();

            //two characters to hold values in order to check
            //if a comment declaration has started anywhere in the line
            char newChar = '\0', preChar = '\0';

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

    }
}
