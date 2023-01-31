using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachBook.Model;

namespace TeachBook.ViewModel
{
    public class LoginClass
    {
        Core bc = new Core();
        public bool LoginDoneEnter(string log, string pas)
        {
            try
            {
                Users loginArray = bc.contex.Users.Where(x => x.Login == log && x.Password == pas).FirstOrDefault();
                if (loginArray == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
