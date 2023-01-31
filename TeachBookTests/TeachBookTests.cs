using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TeachBook.ViewModel;
using TeachBook.Model;

namespace TeachBookTests
{
    [TestClass]
    public class TeachBookTests
    {
        /// <summary>
        /// Тест на проверку принадлежности учётной записи к учителю
        /// </summary>
        [TestMethod]
        public void CheckUsers_Test()
        {
            //arrange
            string log = "6";
            string pass = "173125";
            int id = 2;
            //act
            UsersViewModel obj = new UsersViewModel();
            bool actual = obj.CheckUsers(log, pass, id);
            //asert
            Assert.AreEqual(actual,true);
        }
        /// <summary>
        /// Проверка входа в приложение
        /// </summary>
        [TestMethod]
        public void CheckLoginEnter_Test()
        {
            //arrange
            string log = "2";
            string pas = "2";
            //act
            LoginClass obj = new LoginClass();
            bool actual = obj.LoginDoneEnter(log, pas);
            //asert
            Assert.AreEqual(actual, true);
        }
        /// <summary>
        /// Выбор группы и выдача её имени по первичному ключу
        /// </summary>
        [TestMethod]
        public void CheckGroup_Test()
        {
            //arrange
            int id = 1;
            string excul = "ИП-02к";
            //act
            GroupClass obj = new GroupClass();
            string actual = obj.GroupSelectString(id);
            //asert
            Assert.AreEqual(actual, excul);
        }
        /// <summary>
        /// Проверка удаления студента
        /// </summary>
        [TestMethod]
        public void CheckDelete_Test()
        {
            //arrange
            int id = 5;
            //act
            DeleteClass obj = new DeleteClass();
            bool actual = obj.DeleteStydent(id);
            //asert
            Assert.AreEqual(actual, true);
        }

        /// <summary>
        /// Проверка добавления студента
        /// </summary>
        [TestMethod]
        public void CheckAddStudent_Test()
        {
            //arrange
            int groupId = 1;
            int professionId = 1;
            int formTimeID = 1;
            string fiest = "Олег";
            string last = "Василевский";
            string patronomic = "Иванович";
            int year = 2018;
            //act
            AddStudentClass obj = new AddStudentClass();
            bool actual = obj.AddStudentDoom(groupId,professionId,formTimeID,fiest,last,patronomic,year);
            //asert
            Assert.AreEqual(actual, true);
        }
        /// <summary>
        /// Проверка добавления оценки
        /// </summary>
        [TestMethod]
        public void CheckAddOtchenka_Test()
        {
            //arrange
            int idTeach = 2; int i = 3; int s = 1; int g = 1; int o = 4;
            //act
            AddOtchenkClass obj = new AddOtchenkClass();
            bool actual = obj.AddOtchenka(idTeach,i,s,g,o);
            //asert
            Assert.AreEqual(actual, true);
        }
        /// <summary>
        /// Редактирование оценки
        /// </summary>
        [TestMethod]
        public void CheckRedactOtchenka_Test()
        {
            //arrange
            int idTeacher = 2;
            string otchenka = "3";
            int idjornals = 6;
            //act
            RedactClass obj = new RedactClass();
            bool actual = obj.RedactOtchenka(idTeacher,otchenka, idjornals);
            //asert
            Assert.AreEqual(actual, true);
        }
        /// <summary>
        /// Регистрация учётной записи
        /// </summary>
        [TestMethod]
        public void CheckRegistration_Test()
        {
            //arrange
            string log = "varchar";
            string pas = "varpass";
            string apas = "varpass";
            bool adCher = false;
            //act
            RegistrationClass obj = new RegistrationClass();
            bool actual = obj.ReginstrationDone(log,pas,apas,adCher);
            //asert
            Assert.AreEqual(actual, true);
        }
    }
}
