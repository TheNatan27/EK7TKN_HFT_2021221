using EK7TKN_HFT_2021221.Data;
using EK7TKN_HFT_2021221.Logic;
using EK7TKN_HFT_2021221.Models;
using EK7TKN_HFT_2021221.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EK7TKN_HFT_2021221.Test
{

    class MoqTestClass
    {
        private Mock<xDbContext> mockeryContext { get; set; }

        [SetUp]
        public void RunSetUp()
        {
            Mock<xDbContext> contextMock = new Mock<xDbContext>();


            #region runs
            List<RunInformation> testRunData = new List<RunInformation>
            {
                new RunInformation() { RunID=   1   ,UserID=    1   ,Distance=  42.9    ,Time="00:32:41", IsCompetition=    true    ,Location="	Japan	"},
new RunInformation() { RunID=   2   ,UserID=    5   ,Distance=  29.5    ,Time="00:38:06", IsCompetition=    true    ,Location="	Poland	"},
new RunInformation() { RunID=   3   ,UserID=    2   ,Distance=  37.2    ,Time="00:72:95", IsCompetition=    false   ,Location="	Poland	"},
new RunInformation() { RunID=   4   ,UserID=    4   ,Distance=  6.0 ,Time="00:06:62", IsCompetition=    false   ,Location="	Netherlands	"},
new RunInformation() { RunID=   5   ,UserID=    3   ,Distance=  6.4 ,Time="00:09:96", IsCompetition=    false   ,Location="	Poland	"},
new RunInformation() { RunID=   6   ,UserID=    5   ,Distance=  8.5 ,Time="00:61:21", IsCompetition=    false    ,Location="	United States	"},
new RunInformation() { RunID=   7   ,UserID=    3   ,Distance=  38.4    ,Time="00:18:18", IsCompetition=    false,Location="	Poland	"},
new RunInformation() { RunID=   8   ,UserID=    4   ,Distance=  23.4    ,Time="00:49:48", IsCompetition=    false   ,Location="	Poland	"},
new RunInformation() { RunID=   9   ,UserID=    2   ,Distance=  13.5    ,Time="00:97:20", IsCompetition=    false    ,Location="	Poland	"},
new RunInformation() { RunID=   10  ,UserID=    3   ,Distance=  42.3    ,Time="00:09:14", IsCompetition=    false   ,Location="	United States	"}
            };

            IQueryable<RunInformation> quaRun = testRunData.AsQueryable();

            Mock<DbSet<RunInformation>> runDb = new Mock<DbSet<RunInformation>>();

            runDb.As<IQueryable<RunInformation>>().Setup(m => m.Provider).Returns(quaRun.Provider);
            runDb.As<IQueryable<RunInformation>>().Setup(m => m.Expression).Returns(quaRun.Expression);
            runDb.As<IQueryable<RunInformation>>().Setup(m => m.ElementType).Returns(quaRun.ElementType);
            runDb.As<IQueryable<RunInformation>>().Setup(m => m.GetEnumerator()).Returns(quaRun.GetEnumerator());

            contextMock
                .Setup(mock => mock.Runs)
                .Returns(runDb.Object);


            this.mockeryContext = contextMock;
            #endregion

            #region users
            List<UserInformation> testUserData = new List<UserInformation>
            {
new UserInformation() { Full_Name="	Chrisse Lacroix	",Email="	clacroix0@europa.eu	",Age=  64  ,Height=    185 ,Weight=    103 ,UserID=    1   ,Premium=   true   },
new UserInformation() { Full_Name="	Ivett Raddish	",Email="	iraddish1@webnode.com	",Age=  51  ,Height=    168 ,Weight=    92  ,UserID=    2   ,Premium=   true   },
new UserInformation() { Full_Name="	Lief Sheirlaw	",Email="	lsheirlaw2@addtoany.com	",Age=  58  ,Height=    173 ,Weight=    66  ,UserID=    3   ,Premium=   false   },
new UserInformation() { Full_Name="	Tiff Weems	",Email="	tweems3@addtoany.com	",Age=  55  ,Height=    184 ,Weight=    80  ,UserID=    4   ,Premium=   false   },
new UserInformation() { Full_Name="	Nada Grgic	",Email="	ngrgic4@sitemeter.com	",Age=  66  ,Height=    187 ,Weight=    82  ,UserID=    5   ,Premium=   false   }
            };

            IQueryable<UserInformation> quaUser = testUserData.AsQueryable();

            Mock<DbSet<UserInformation>> userDb = new Mock<DbSet<UserInformation>>();

            userDb.As<IQueryable<UserInformation>>().Setup(m => m.Provider).Returns(quaUser.Provider);
            userDb.As<IQueryable<UserInformation>>().Setup(m => m.Expression).Returns(quaUser.Expression);
            userDb.As<IQueryable<UserInformation>>().Setup(m => m.ElementType).Returns(quaUser.ElementType);
            userDb.As<IQueryable<UserInformation>>().Setup(m => m.GetEnumerator()).Returns(quaUser.GetEnumerator());

            contextMock
                .Setup(mock => mock.Users)
                .Returns(userDb.Object);


            this.mockeryContext = contextMock;
            #endregion

            #region passwords

            List<PasswordSecurity> testPassData = new List<PasswordSecurity>
                        {
            new PasswordSecurity() { PassId=    1   ,UserId=    1   ,TotallySecuredVeryHashedPassword="	8USrXl708t	",RecoverPhoneNumber="	06 707 1849"},
            new PasswordSecurity() { PassId=    2   ,UserId=    2   ,TotallySecuredVeryHashedPassword="	kUXTEef	",RecoverPhoneNumber="	06 468 9848"},
            new PasswordSecurity() { PassId=    3   ,UserId=    3   ,TotallySecuredVeryHashedPassword="	gRAPzMUp	",RecoverPhoneNumber="	06 622 1971"},
            new PasswordSecurity() { PassId=    4   ,UserId=    4   ,TotallySecuredVeryHashedPassword="	WVjebFQt2	",RecoverPhoneNumber="	06 480 0104"},
            new PasswordSecurity() { PassId=    5   ,UserId=    5   ,TotallySecuredVeryHashedPassword="	1oQypGOQ	",RecoverPhoneNumber="	06 032 0862"}
                        };


            IQueryable<PasswordSecurity> quaPass = testPassData.AsQueryable();

            Mock<DbSet<PasswordSecurity>> passDb = new Mock<DbSet<PasswordSecurity>>();

            passDb.As<IQueryable<PasswordSecurity>>().Setup(m => m.Provider).Returns(quaPass.Provider);
            passDb.As<IQueryable<PasswordSecurity>>().Setup(m => m.Expression).Returns(quaPass.Expression);
            passDb.As<IQueryable<PasswordSecurity>>().Setup(m => m.ElementType).Returns(quaPass.ElementType);
            passDb.As<IQueryable<PasswordSecurity>>().Setup(m => m.GetEnumerator()).Returns(quaPass.GetEnumerator());

            contextMock
                .Setup(mock => mock.Passwords)
                .Returns(passDb.Object);


            this.mockeryContext = contextMock;
            #endregion

        }




        //CRUD Method Tests
        [Test]
        public void ReadAll_Test()
        {
            IRunRepository runRepository = new Repo_Run(mockeryContext.Object);
            IPassRepository passRepository = new Repo_Password(mockeryContext.Object);
            IUserRepository userRepository = new Repo_User(mockeryContext.Object);

            //ACT 

            List<RunInformation> runs = runRepository.ReadAll().ToList();
            List<PasswordSecurity> passwords = passRepository.ReadAll().ToList();
            List<UserInformation> users = userRepository.ReadAll().ToList();

            //ASSERT

            Assert.NotNull(runs);
            Assert.AreEqual(10, runs.Count);

            Assert.NotNull(passwords);
            Assert.AreEqual(5, passwords.Count);

            Assert.NotNull(users);
            Assert.AreEqual(5, users.Count);

        }


        //Non CRUD Tests
        [Test]
        public void GetCompetitorsEmailAddress_Test()
        {
            //ARRANGE
            IRunRepository runRepository = new Repo_Run(mockeryContext.Object);
            IPassRepository passRepository = new Repo_Password(mockeryContext.Object);
            IUserRepository userRepository = new Repo_User(mockeryContext.Object);

            IUserLogic userLogic = new Logic_User(userRepository, passRepository, runRepository);

            //ACT

            var to = userLogic.GetCompetitorsEmailAddress();

            List<string> testResult = new List<string>();

            foreach (var item in to)
            {
                testResult.Add(item.Trim());
            }

            List<string> actual = new List<string> {
                "clacroix0@europa.eu","ngrgic4@sitemeter.com" };

            //ASSERT
            Assert.That(testResult, Is.EqualTo(actual));

        }
        [Test]
        public void GetAmericanUsersNames_Test()
        {
            //ARRANGE
            IRunRepository runRepository = new Repo_Run(mockeryContext.Object);
            IPassRepository passRepository = new Repo_Password(mockeryContext.Object);
            IUserRepository userRepository = new Repo_User(mockeryContext.Object);

            IUserLogic userLogic = new Logic_User(userRepository, passRepository, runRepository);

            //ACT

            var to = userLogic.GetAmericanUsersNames();

            List<string> testResult = new List<string>();

            foreach (var item in to)
            {
                testResult.Add(item.Trim());
            }

            List<string> actual = new List<string> {
                "Lief Sheirlaw","Nada Grgic" };

            //ASSERT
            Assert.That(testResult, Is.EqualTo(actual));

        }
        [Test]
        public void GetPassIDOfPremiumUsers_Test()
        {
            //ARRANGE
            IRunRepository runRepository = new Repo_Run(mockeryContext.Object);
            IPassRepository passRepository = new Repo_Password(mockeryContext.Object);
            IUserRepository userRepository = new Repo_User(mockeryContext.Object);

            IPassLogic passLogic = new Logic_Password(userRepository, passRepository, runRepository);

            //ACT

            var to = passLogic.GetPassIDOfPremiumUsers();

            List<int> testResult = new List<int>();

            foreach (var item in to)
            {
                testResult.Add(item);
            }

            List<int> actual = new List<int> {
                1,2 };

            //ASSERT
            Assert.That(testResult, Is.EqualTo(actual));
        }
        [Test]
        public void GetLocationOfChonkers_Test()
        {
            //ARRANGE
            IRunRepository runRepository = new Repo_Run(mockeryContext.Object);
            IPassRepository passRepository = new Repo_Password(mockeryContext.Object);
            IUserRepository userRepository = new Repo_User(mockeryContext.Object);

            IRunLogic runLogic = new Logic_Run(userRepository, passRepository, runRepository);

            //ACT

            var to = runLogic.GetLocationOfChonkers();

            List<string> testResult = new List<string>();

            foreach (var item in to)
            {
                testResult.Add(item.Trim());
            }

            List<string> actual = new List<string> {
                "Poland","Poland"};

            //ASSERT
            Assert.That(testResult, Is.EqualTo(actual));
            
        }
        [Test]
        public void GetTimeOfPremiumCompetitors_Test()
        {
            //ARRANGE
            IRunRepository runRepository = new Repo_Run(mockeryContext.Object);
            IPassRepository passRepository = new Repo_Password(mockeryContext.Object);
            IUserRepository userRepository = new Repo_User(mockeryContext.Object);

            IRunLogic runLogic = new Logic_Run(userRepository, passRepository, runRepository);

            //ACT

            var to = runLogic.GetTimeOfPremiumCompetitors();

            List<string> testResult = new List<string>();

            foreach (var item in to)
            {
                testResult.Add(item.Trim());
            }

            List<string> actual = new List<string> {
                "00:32:41"};

            //ASSERT
            Assert.That(testResult, Is.EqualTo(actual));
        }
        [TestCase(5)]
        public void ReadRunsOfUser_Test(int userID)
        {
            IRunRepository runRepository = new Repo_Run(mockeryContext.Object);
            IPassRepository passRepository = new Repo_Password(mockeryContext.Object);
            IUserRepository userRepository = new Repo_User(mockeryContext.Object);

            IUserLogic userLogic = new Logic_User(userRepository, passRepository, runRepository);

            //ACT

            IEnumerable<KeyValuePair<double, string>> to = userLogic.ReadRunsOfUser(userID);

            List<double> re1 = new List<double>();
            List<string> re2 = new List<string>();

            foreach (var item in to)
            {
                re1.Add(item.Key);
                re2.Add(item.Value);
            }

            List<double> ac1 = new List<double>() { 29.5, 8.5};
            List<string> ac2 = new List<string>() { "00:38:06" , "00:61:21" };

            //ASSERT

            Assert.That(re1, Is.EquivalentTo(ac1));
            Assert.That(re2, Is.EquivalentTo(ac2));


        }
    }
}



