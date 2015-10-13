string filePaths;

for(int i = 0; i < filePaths.size(); i++)
{
	char previousChar, newChar;
	
	newChar = filePaths[i].begin();

	//default value of char is '\0' as referenced from
	//Microsofts default value chart
	if(previousChar != '\0')
	{
		for(int k = 0; k < filePaths[i].size(); j++)
		{
			if(previousChar == newChar)
			{
				filePaths[i].Remove(0, k);
			}
		}
		
		previousChar = newChar;
	}
	
	else
	{
		filePaths[i].Remove(0,1);
		previousChar = newChar;
		newChar = filePaths[i].begin();
	}
}

//string.Remove(StartIndex, EndIndex);