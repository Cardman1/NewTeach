using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachBook.Model;

namespace TeachBook.ViewModel
{
    public class RedactClass
    {
        Core bc = new Core();
        public bool RedactOtchenka(int idTeacher,string otchenka, int idjornals)
        {
            if (otchenka != "")
            {
                if(Convert.ToInt32(otchenka) <=5 && Convert.ToInt32(otchenka) >= 2)
                {
                    Journals item = new Journals();
                    item = bc.contex.Journals.Where(x => x.IdJournal == idjornals).First();
                    History historyAdd = new History()
                    {
                        IdStatus = 2,
                        IdStudent = item.IdStudent,
                        IdTeacher = idTeacher,
                        DateEvent = DateTime.Now
                    };
                    bc.contex.History.Add(historyAdd);
                    item.Evaluation = Convert.ToInt32(otchenka);
                    bc.contex.Journals.Add(item);
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
            else
            {
                return false;
            }
        }
    }
}
