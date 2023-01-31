using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachBook.Model;

namespace TeachBook.ViewModel
{
    public class AddOtchenkClass
    {
        Core bc = new Core();
        List<TeacherHasSubjects> hasSubjects = new List<TeacherHasSubjects>();
        public bool AddOtchenka(int idTeach, int i, int s,int g, int o)
        {
            if (o <= 5 && o >= 2)
            {
                hasSubjects = bc.contex.TeacherHasSubjects.Where(x => x.IdTeacher == idTeach && x.IdSubject == s).ToList();
                if (hasSubjects.Count()>0)
                {
                    Journals journalsAdd = new Journals()
                    {
                        IdStudent = i,
                        IdGroup = g,
                        Evaluation = o,
                        IdSubject = s
                    };
                    History historyAdd = new History()
                    {
                        IdStatus = 1,
                        IdStudent = i,
                        IdTeacher = idTeach,
                        DateEvent = DateTime.Now
                    };
                    bc.contex.History.Add(historyAdd);
                    bc.contex.Journals.Add(journalsAdd);
                    if (bc.contex.SaveChanges() > 0)
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
