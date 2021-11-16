using EK7TKN_HFT_2021221.Data;
using EK7TKN_HFT_2021221.Logic;
using EK7TKN_HFT_2021221.Repository;
using System;
using System.Collections.Generic;

namespace EK7TKN_HFT_2021221.Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            xDbContext context = new xDbContext();
            Repo_User testUser = new Repo_User(context);
            Repo_Run testRun = new Repo_Run(context);
            Repo_Password testPass = new Repo_Password(context);

            Logic_Password loPass = new Logic_Password(testUser, testPass, testRun);
            loPass.GetWeakPasswordUsers();

        }

    }
}
