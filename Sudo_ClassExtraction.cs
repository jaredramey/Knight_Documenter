/*
* Class Diagram sudo code
*/

private List<string> GetAllClasses(string[] filePaths)
{
	List<string> classes;
	
	for(int i =0; i < filePaths.length; i++)
	{
		while ((line = file.ReadLine()) != null)
                {
					if(line.contains("class"))
					{
						classes.Add(line);
					}
					else
					{
						
					}

                    //repeat till no other lines in the file
                }
	}
}