using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TeachBook.ViewModel;
using TeachBook.Model;

namespace TeachBookTests
{
    [TestClass]
    public class TeachBookTests
    {
        [TestMethod]
        public void CheckUsers()
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
    }
}
