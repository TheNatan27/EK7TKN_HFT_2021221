using EK7TKN_HFT_2021221.Data;
using EK7TKN_HFT_2021221.Models;
using EK7TKN_HFT_2021221.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using Newtonsoft.Json;
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
        
        [Test]
        public void CreateUser_Test()
        {
            //ARRANGE
            UserInformation uStandard = new UserInformation() { Full_Name = "	Desiri Wardington	", Email = "	dwardington1@rediff.com	", Age = 27, Height = 179, Weight = 71, UserID = 2, Premium = true };
            UserInformation uNoname = new UserInformation() { Email = "	kmaynard2@wisc.edu	", Age = 50, Height = 174, Weight = 65, UserID = 3, Premium = true };
            UserInformation uEmail = new UserInformation() { Full_Name = "	Dale Brannan	", Age = 62, Height = 196, Weight = 66, UserID = 4, Premium = false };

            string ustandard = JsonConvert.SerializeObject(uStandard);
            string unoname = JsonConvert.SerializeObject(uNoname);
            string uemail = JsonConvert.SerializeObject(uEmail);
           
            IUserRepository repository = new Repo_User(testContext);

            //ACT-ASSERT
            Assert.That(() => repository.Create(ustandard), Throws.Nothing);
            Assert.That(() => repository.Create(unoname), Throws.InnerException);
            Assert.That(() => repository.Create(uemail), Throws.InnerException);
        }

        [Test]
        public void CreatePassword_Test()
        {
            //ARRANGE
           
            PasswordSecurity pStandard = new PasswordSecurity() { PassId = 1, UserId = 1, TotallySecuredVeryHashedPassword = "	7ZK4pmNX	", RecoverPhoneNumber = "	06 404 3684" };
            PasswordSecurity pNopass = new PasswordSecurity() { PassId = 2, UserId = 2, RecoverPhoneNumber = "	06 815 6835" };
            PasswordSecurity pNouser = new PasswordSecurity() { PassId = 3, UserId = -4, TotallySecuredVeryHashedPassword = "	JcPogOYSCZr3	", RecoverPhoneNumber = "	06 684 7755" };
            PasswordSecurity pNophone = new PasswordSecurity() { PassId = 3, UserId = 3, TotallySecuredVeryHashedPassword = "	JcPogOYSCZr3	" };

            string pstandard = JsonConvert.SerializeObject(pStandard);
            string pnopass = JsonConvert.SerializeObject(pNopass);
            string pnosuer = JsonConvert.SerializeObject(pNouser);
            string pnophone = JsonConvert.SerializeObject(pNophone);

            IPassRepository repository = new Repo_Password(testContext);

            //ACT-ASSERT
            
            Assert.That(() => repository.Create(pstandard), Throws.Nothing);
            Assert.That(() => repository.Create(pnopass), Throws.InnerException);
            Assert.That(() => repository.Create(pnophone), Throws.InnerException);
            Assert.That(() => repository.Create(pnosuer), Throws.InnerException);
        }

        [Test]
        public void CreateRun_Test()
        {
            //ARRANGE

            RunInformation rStandard = new RunInformation() { RunID = 1, UserID = 3, Distance = 36.1, Time = "00:80:89", IsCompetition = false, Location = "	Japan	" };
            RunInformation rNodistance = new RunInformation() { RunID = 2, UserID = 99, Distance = -34.2, Time = "00:26:78", IsCompetition = false, Location = "	Luxembourg	" };
            RunInformation rNolocation = new RunInformation() { RunID = 3, UserID = 75, Distance = 39, Time = "00:87:19", IsCompetition = false };
            RunInformation rNouserid = new RunInformation() { RunID = 4, UserID = -5, Distance = 45.5, Time = "00:26:72", IsCompetition = false, Location = "	Poland	" };

            string rstandar = JsonConvert.SerializeObject(rStandard);
            string rnodistance = JsonConvert.SerializeObject(rNodistance);
            string rnolocation = JsonConvert.SerializeObject(rNolocation);
            string rnouserid = JsonConvert.SerializeObject(rNouserid);

            IRunRepository repository = new Repo_Run(testContext);

            //ACT-ASSERT
            Assert.That(() => repository.Create(rstandar), Throws.Nothing);
            Assert.That(() => repository.Create(rnodistance), Throws.InnerException);
            Assert.That(() => repository.Create(rnolocation), Throws.InnerException);
            Assert.That(() => repository.Create(rnouserid), Throws.InnerException);

        }

        #endregion

    }

}
