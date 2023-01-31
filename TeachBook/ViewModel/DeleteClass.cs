using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachBook.Model;

namespace TeachBook.ViewModel
{
    public class DeleteClass
    {
        Core bc = new Core();
        public bool DeleteStydent(int idStydent)
        {
            Students stu = new Students();
            stu = bc.contex.Students.Where(x => x.IdStudent == idStydent).FirstOrDefault();
            bc.contex.Students.Remove(stu);
            if (bc.contex.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
