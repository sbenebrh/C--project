using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BE;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            BL.IBL bl;
            bl = BL.FactoryBL.GetBL();

           /*  specialization S = new specialization();
             S.specialization_id = 333;
             S.minWage = 33;
             S.maxWage = 55;
             bl.addExpert(S);

            specialization t = new specialization();
            t.specialization_id = 336;
            t.minWage = 33;
            t.maxWage = 55;
            bl.addExpert(t);
            */
            //  bl.removeExpert(333);
            specialization P = new specialization();
            P.specialization_id = 336;
            P.minWage = 100;
            P.maxWage = 55;
           
            bl.updateExpert(P);
        }

    }
}
