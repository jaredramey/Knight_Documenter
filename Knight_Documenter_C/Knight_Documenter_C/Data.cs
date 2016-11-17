using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knight_Documenter_C
{
    class Data
    {
        List<ClassStorage> data = new List<ClassStorage>();

        //Clears all current data
        private void ClearData()
        {
            data.Clear();
        }

        //Find a class by name
        public ClassStorage GetClassByName(string className)
        {
            if (data != null && data.Count > 0)
            {
                return data.Find(x => x.name == className);
            }

            else
            {
                return null;
            }
        }

        //returns all currently stored data
        public List<ClassStorage> GetAllData()
        {
            if(data != null && data.Count > 0)
            {
                return data;
            }

            else
            { 
                return null;
            }
        }
    }

    
}

//Reflection to store data and extract how I need to
private class ClassStorage
{
    //Store Class name
    public string name;
    //Store function names
    public List<string> functions;
    //Store refrences from class to class
    public List<string> functionRefrences;
    //Store all comments from class
    public List<string> comments;
}
