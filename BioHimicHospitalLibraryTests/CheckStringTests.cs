using BioHimicHospitalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BioHimicHospitalLibraryTests
{
    /// <summary>
    /// Сводное описание для CheckStringTests
    /// </summary>
    [TestClass]
    public class CheckStringTests
    {
        CheckStringClass csc = new CheckStringClass();

        [TestMethod]
        public void LoginCheck_CorrectLogin_TrueExpected()
        {
            // Arrange
            string login = "fdsfwfw21";
            // Act
            bool result = csc.LoginCheck(login);
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LoginCheck_InCorrectLogin_FalseExpected()
        {
            // Arrange
            string login = "fdsfwfw21@#";
            // Act 
            bool result = csc.LoginCheck(login);
            // Assert
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void LoginCheck_CyrillicSimbols_FalseExpected()
        {
            // Arrange
            string login = "выапыу";
            // Act 
            bool result = csc.LoginCheck(login);
            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LoginCheck_UpperCaseSimbols_TrueExpected()
        {
            // Arrange
            string login = "UInjhUBEjd";
            // Act 
            bool result = csc.LoginCheck(login);
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LoginCheck_EndsWithPoint_FalseExpected()
        {
            // Arrange
            string login = "gdfgwsc.";
            // Act 
            bool result = csc.LoginCheck(login);
            // Assert
            Assert.IsFalse(result);
        }
    }
}
