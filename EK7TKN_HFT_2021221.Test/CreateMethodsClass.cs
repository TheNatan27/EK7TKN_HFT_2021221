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
    public class CreateMethodsClass
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

        [TestCase("testUser_noname.txt")]
        [TestCase("testUser_noemail.txt")]
        [TestCase("testUser_noage.txt")]
        [TestCase("testUser_nopremium.txt")]
        public void CreateUser_Test(string filename)
        {
            //ARRANGE
            IUserRepository repository = new Repo_User(testContext);

            //ACT-ASSERT
            Assert.That(() => repository.Create(filename), Throws.Exception);
        }
    }

}
