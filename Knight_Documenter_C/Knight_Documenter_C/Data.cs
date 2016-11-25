using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knight_Documenter_C
{
    public sealed class Data
    {
        //readonly makes it so this can only be allocated once
        private static readonly Data currentData = new Data();
        private List<ClassStorage> data = new List<ClassStorage>();

        #region SingletonConstruction
        //TODO: Improve singleton instance
        private Data()
        {

        }

        public static Data Instance
        {
            get 
            {
                return Instance;
            }
        }
        #endregion

        //Clears all current data
        private void ClearData()
        {
            data.Clear();
        }

        #region DataInput
        public void NewEntry(ClassStorage newData)
        {
            data.Add(newData);
        }
        #endregion

        #region DataOutput
        //Find a class by name
        public ClassStorage GetClassByName(string className)
        {
            if (data != null && data.Count > 0)
            {
                //Find data store that matches given class name
                return data.Find(x => x.name == className);
            }

            else
            {
                //If no matching class names were found then return null
                return null;
            }
        }

        //returns all currently stored data
        public List<ClassStorage> GetAllData()
        {
            //So long as there is stored data then return a data dump
            if(data != null && data.Count > 0)
            {
                return data;
            }

            else
            { 
                return null;
            }
        }
        #endregion
    }

    
}

//Reflection to store data and extract how I need to
public class ClassStorage
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
