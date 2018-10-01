using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BAL
{
    public class Student_BAL
    {
        private Student_DAL dalObj;
        public Student_BAL(Student_DAL dalObj)
        {
            this.dalObj = dalObj;
        }
        public void Save()
        {
            dalObj.save();
        }
    }
}
