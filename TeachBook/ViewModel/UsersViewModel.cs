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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        /// <param name="password"></param>
        /// <param name="idrole"></param>
        /// <returns></returns>
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
        public bool AddStudent(string fName, string lName, string pName, int idGroup, int Years, int idFormTime, int idProfessia)
        {
            if (idProfessia == 0) return false;
            else
            {
                if (idFormTime == 0) return false;
                else
                {
                    if (idGroup == 0) return false;
                    else
                    {
                        if (fName == null || lName == null || pName == null) return false;
                        else
                        {
                            YearAdd addYearMass = new YearAdd()
                            {
                                Year = Years
                            };
                            bc.contex.YearAdd.Add(addYearMass);
                            bc.contex.SaveChanges();
                            YearAdd yearAdd = bc.contex.YearAdd.Where(x => x.Year == Years).FirstOrDefault();
                            Students addStudentMass = new Students()
                            {
                                FiestName = fName,
                                LastName = lName,
                                PatronomicName = pName,
                                IdProfession = idProfessia,
                                IdFormTime =idFormTime,
                                IdGroup = idGroup,
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
