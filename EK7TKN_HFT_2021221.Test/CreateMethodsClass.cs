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

        //[TestCase("testuser", 1, "testmail", 10,100, true)]
        //[TestCase("testUser1.txt")]
        
        [TestCase("testUser3.txt")]
        public void CreateUser_Test(string filename)
        {
            //ARRANGE
            IUserRepository repository = new Repo_User(testContext);

            //ACT
            repository.Create(filename);
            List<UserInformation> information = repository.ReadAll().ToList();

            //ASSERT
            //Assert.Throws<MissingNameException>(repository.Create(filename);
            

        }
    }

}
