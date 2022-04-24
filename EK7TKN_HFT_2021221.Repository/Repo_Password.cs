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
using System.Text.Json;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Repository
{
    public class MissingPasswordException : Exception
    {
        public MissingPasswordException()
        {
            Console.WriteLine("Error: No name specified");
        }
    }
    public class MissingPhoneNumberException : Exception
    {
        public MissingPhoneNumberException()
        {
            Console.WriteLine("Error: No email provided");
        }
    }
    public class Repo_Password : AbRepo<Repo_Password>, IPassRepository
    {
        MongoClient client;
        IMongoDatabase mDbContext;
        IMongoCollection<BsonDocument> ctx;
        public Repo_Password()
        {
            this.client = new MongoClient("mongodb+srv://TheNatan28:vgMeikS7-ME7uuJ@clusterl02.jg4jv.mongodb.net/myFirstDatabase?retryWrites=true&w=majority"
);
            this.mDbContext = client.GetDatabase("mDbContext");
            this.ctx = mDbContext.GetCollection<BsonDocument>("passTable");

        }

        //CRUD Methods
       
        public PasswordSecurity Read(int passId)
        {

            var filter = Builders<BsonDocument>.Filter.Eq("PassId", passId);
            var doc = ctx.Find(filter).FirstOrDefault();

            string es = doc.ToJson();
            string ese = es.Trim('{');
            string eese = ese.Trim('}');
            string[] jj = eese.Split(',');

            List<string> lkj = new List<string>();

            PasswordSecurity pass = new PasswordSecurity();

            for (int j = 0; j < jj.Length; j++)
            {
                string[] ll = jj[j].Split(':');
                lkj.Add(ll[1].ToString());
            }

            for (int i = 0; i < lkj.Count; i++)
            {
                Console.WriteLine(lkj[i].ToString());
            }

            pass._id = lkj[0];
            pass.PassId = int.Parse(lkj[1]);
            pass.UserId = int.Parse(lkj[2]);
            pass.RecoverPhoneNumber = lkj[3];
            pass.TotallySecuredVeryHashedPassword = lkj[4];

            Console.WriteLine($"User {passId} read!");

            return pass;

        }
       

    }
}
