using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachBook.Model;

namespace TeachBook.ViewModel
{
    public class AddStudentClass
    {
        Core bc = new Core();
        public bool AddStudentDoom(int groupId, int professionId, int formTimeID, string fiest, string last, string patronomic, int year)
        {
            var groupMass = new List<Groups>
            {
                new Groups
                {
                    IdGroup = 0,
                    NameGroup = "Выбрать группу"
                }
            };
            groupMass.AddRange(bc.contex.Groups.ToList());
            var professionMass = new List<Professions>
            {
                new Professions
                {
                    IdProfession = 0,
                    NameProfession = "Выбрать специальность"
                }
            };
            professionMass.AddRange(bc.contex.Professions.ToList());
            var formTimeMass = new List<FormTime>
            {
                new FormTime
                {
                    Id = 0,
                    Name = "Выбрать форму обучения"
                }
            };
            formTimeMass.AddRange(bc.contex.FormTime.ToList());
            int i = groupId;
            if (i == 0) return false;
            else
            {
                int y = professionId;
                if (y == 0) return false;
                else
                {
                    int l = formTimeID;
                    if (l == 0) return false;
                    else
                    {
                        if (fiest == "" || last == "" || patronomic == "") return false;
                        else
                        {
                            YearAdd addYearMass = new YearAdd()
                            {
                                Year = Convert.ToInt32(year)
                            };
                            bc.contex.YearAdd.Add(addYearMass);
                            bc.contex.SaveChanges();
                            i = Convert.ToInt32(year);
                            YearAdd yearAdd = bc.contex.YearAdd.Where(x => x.Year == i).FirstOrDefault();
                            Students addStudentMass = new Students()
                            {
                                FiestName = fiest,
                                LastName = last,
                                PatronomicName = patronomic,
                                IdProfession = professionId,
                                IdFormTime = formTimeID,
                                IdGroup = groupId,
                                IdYearAdd = yearAdd.idYear
                            };
                            bc.contex.Students.Add(addStudentMass);
                            if (bc.contex.SaveChanges() > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        };
                    }
                }
            }
        }
    }
}
