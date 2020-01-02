using DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// instancie and return differente objet
    /// </summary>
    public  class Factory_DAL
    {
      //  private static Idal instance = null;

        public static Idal getInstance(string type= "XML")
        {


            if ("XML" == type.ToUpper())
            {

                return DAL_IMP_XML.getInstance();
                //  instance = new Dal_imp();
            }
            else return Dal_imp.getInstance();
            
        }
    }
}