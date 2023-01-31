using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachBook.Model;

namespace TeachBook.ViewModel
{
    public class GroupClass
    {
        Core bc = new Core();
        public string GroupSelectString(int id)
        {
            Groups group = new Groups();
            group = bc.contex.Groups.Where(x => x.IdGroup == id).FirstOrDefault();
            string str = Convert.ToString(group.NameGroup);
            return str;
        }
    }
}
