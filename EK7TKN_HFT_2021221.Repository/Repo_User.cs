using EK7TKN_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Repository
{
    public class MissingNameException : Exception
    {
        public MissingNameException()
        {
            Console.WriteLine("Error: No name specified");
        }
    }
    public class MissingEmailException : Exception
    {
        public MissingEmailException()
        {
            Console.WriteLine("Error: No email provided");
        }
    }

    public class Repo_User : AbRepo<UserInformation>, IUserRepository
    {
        MongoClient client;
        IMongoDatabase mDbContext;
        IMongoCollection<BsonDocument> ctx;

        public Repo_User()
        {
            this.client = new MongoClient("mongodb+srv://TheNatan28:vgMeikS7-ME7uuJ@clusterl02.jg4jv.mongodb.net/myFirstDatabase?retryWrites=true&w=majority"
);
            this.mDbContext = client.GetDatabase("mDbContext");
            this.ctx = mDbContext.GetCollection<BsonDocument>("userTable");
        }

        //CRUD Methods


        public UserInformation Read(int userID)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("UserID",userID);
            var doc = ctx.Find(filter).FirstOrDefault();

            string es = doc.ToJson();
            string ese = es.Trim('{');
            string eese = ese.Trim('}');
            string[] jj = eese.Split(',');

            List<string> lkj = new List<string>();

            UserInformation user = new UserInformation();

            for (int j = 0; j < jj.Length; j++)
            {
                string[] ll = jj[j].Split(':');
                lkj.Add(ll[1].ToString());
            }

            for (int i = 0; i < lkj.Count; i++)
            {
                Console.WriteLine(lkj[i].ToString());
            }

            user._id = lkj[0];
            user.UserID = int.Parse(lkj[1]);
            user.Full_Name= lkj[2];
            user.Age = int.Parse(lkj[3]);
            user.Weight = int.Parse(lkj[4]);
            user.Height = int.Parse(lkj[5]);
            user.Email = lkj[6];
            user.Premium = bool.Parse(lkj[7]);

            Console.WriteLine($"User {userID} read!");

            return user;
        }
 


    }
}
