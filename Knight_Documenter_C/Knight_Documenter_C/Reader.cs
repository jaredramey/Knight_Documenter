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

    class Reader
    {
        //Enum to differentiate between documentation styles
        //Starting with comment extraction and then from there i'll add more as 
        //I figure out what I want to include
        enum Method { eComments, eOther};

        //Buffer for file reading, edit to improve reading
        const Int32 BufferSize = 128;

        //public functions

        //Open file and call other methods as necessary for what is requested by user
        //ie: Comment extraction would be called as OpenFile("filePath", eComments)
        public void OperateOnFile(string filePath, Method method)
        {
            //Switch the enum for whatever is requested
            switch(method)
            {
                case Method.eComments:
                    //Call function to extract all commented lines
                    break;

                default:
                    break;
            }
        }


        //Function to get all commented lines
        private List<string> CommentExtraction(string FilePath)
        {
            //A string to temporarily store any lines starting with "//"
            string line;
            List<string> commentedLines = new List<string>();

            //Open up the file
            System.IO.StreamReader file = new System.IO.StreamReader(FilePath);

            while((line = file.ReadLine()) != null)
            {
                /*Might need to check to make sure the line has more then 0 characters. Will check on that after function works as expected*/
                /*Going to have to make sure that Line has more characters then 2. Will have to add that check later*/

                //Get first two characters of the line
                string firstTwo = line.Substring(0, 2);
                //Check to see if the first two characters are declaring a commented line
                if(firstTwo == "//")
                {
                    commentedLines.Add(line);
                }
                    //if not then continue through the loop
                else 
                {
                    continue;
                }
                //repeat till no other lines in the file
            }

            //close the file
            file.Close();

            //return the list of commented lines
            return commentedLines;
        }

    }
}
