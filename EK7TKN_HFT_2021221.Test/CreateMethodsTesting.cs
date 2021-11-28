using EK7TKN_HFT_2021221.Data;
using EK7TKN_HFT_2021221.Models;
using EK7TKN_HFT_2021221.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Test
{



    [TestFixture]
    public class CreateMethodsTesting
    {
        private xDbContext testContext { get; set; }

        [SetUp]
        public void SetUp()
        {
            var contextBuilder = new DbContextOptionsBuilder<xDbContext>();

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

            contextBuilder.UseSqlServer(connectionString);

            testContext = new xDbContext(contextBuilder.Options);

        }

        #region create tests

        [TestCase("testUser_noname.txt")]
        [TestCase("testUser_noemail.txt")]
        [TestCase("testUser_noage.txt")]
        [TestCase("testUser_nopremium.txt")]
        public void CreateUser_Test(string filename)
        {
            //ARRANGE
            IUserRepository repository = new Repo_User(testContext);

            //ACT-ASSERT
            Assert.That(() => repository.Create(filename), Throws.InnerException);
        }

        [TestCase("testRun_nodistance.txt")]
        [TestCase("testRun_nolocation.txt")]
        [TestCase("testRun_notime.txt")]
        [TestCase("testRun_nouserid.txt")]
        [TestCase("testRun_nocompetition.txt")]
        //[TestCase("testRun_Standard.txt")]

        public void CreateRun_Test(string filename)
        {
            //ARRANGE
            IRunRepository repository = new Repo_Run(testContext);

            //ACT-ASSERT
            Assert.That(() => repository.Create(filename), Throws.InnerException);

        }
        [TestCase("testPass_nouser.txt")]
        [TestCase("testPass_nopass.txt")]
        [TestCase("testPass_nophone.txt")]
        public void CreatePassword_Test(string filename)
        {
            //ARRANGE
            IPassRepository repository = new Repo_Password(testContext);

            //ACT-ASSERT
            Assert.That(() => repository.Create(filename), Throws.InnerException);

        }

        #endregion
     
    }

}
