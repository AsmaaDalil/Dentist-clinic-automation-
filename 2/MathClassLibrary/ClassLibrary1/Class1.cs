using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Math
{
    namespace SuMi
    {
        public class suMi
        {
            public double sum(double x1, double x2,ref string error)
            {
                double res = 0;
                try
                {
                    res = x1 + x2;
                }
                catch(Exception e)
                {
                    error = e.ToString();//or error ="خطأ!!لايمكن إجراء عملية الحساب";
                }
                finally
                {

                }
                return res;
            }
            public void mines(double x1, ref double x2, ref string error)
            {
                try
                {
                    x2 = x1 - x2;
                }
                catch (Exception e)
                {
                    error = e.ToString();//or error ="خطأ!!لايمكن إجراء عملية الحساب";
                }
                finally
                {

                }
            }
        }
    }
    namespace MuDi
    {
        public class muDi
        {
            public static void multiply(double x1, double x2,out double res, out string error)
            {
                res = 0;
                error = "";
                try
                {
                    res = x1 * x2;
                }
                catch (Exception e)
                {
                    error = e.ToString();//or error ="خطأ!!لايمكن إجراء عملية الحساب";
                }
                finally
                {

                }
            }
            public double res = 0;
            public void divide(double x1, double x2, out string error)
            {
                double res = 0;
                error = "";
                try
                {
                    res = x1 / x2;
                }
                catch (Exception e)
                {
                    error = e.ToString();//or error ="خطأ!!لايمكن إجراء عملية الحساب";
                }
                finally
                {
                    this.res = res;
                }
            }
        }
    }
}
