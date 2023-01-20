using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachBook.Model;

namespace TeachBook.ViewModel
{
    public class UsersViewModel
    {
        Core bc = new Core();
        public bool CheckUsers (string log, string password, int idrole)
        {
            if (password != null && log != null && idrole != null)
            {   
                Users newUsers = new Users(){
                    Login = log,
                    Password = password,
                    IdRole = idrole
                };
                bc.contex.Users.Add(newUsers);
                if (bc.contex.SaveChanges()>0)
                {
                    return true;
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
