using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachBook.Model;

namespace TeachBook.ViewModel
{
    public class RegistrationClass
    {
        Core bc = new Core();
        public bool ReginstrationDone(string log, string pas, string apas, bool adCher)
        {
            int i = 2;
            if (pas != "" && log != "" && apas != "")
            {
                if (apas == pas)
                {
                    if (adCher == true) i = 3;
                    try
                    {
                        Users newUsers = new Users()
                        {
                            Login = log,
                            Password = pas,
                            IdRole = i
                        };
                        bc.contex.Users.Add(newUsers);
                        if (bc.contex.SaveChanges() > 0) return true; else return false;
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
