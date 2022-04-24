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
    public class NegativeDistanceException : Exception
    {
        public NegativeDistanceException()
        {
            Console.WriteLine("Error: No name specified");
        }
    }
    public class MissingLocationException : Exception
    {
        public MissingLocationException()
        {
            Console.WriteLine("Error: No location provided");
        }
    }
    public class WrongUserIDException : Exception
    {
        public WrongUserIDException()
        {
            Console.WriteLine("Error: Wrong user id provided");
        }
    }
    public class Repo_Run : AbRepo<RunInformation>, IRunRepository
    {
        MongoClient client;
        IMongoDatabase mDbContext;
        IMongoCollection<BsonDocument> ctx;
        public Repo_Run()
        {
            this.client = new MongoClient("mongodb+srv://TheNatan28:vgMeikS7-ME7uuJ@clusterl02.jg4jv.mongodb.net/myFirstDatabase?retryWrites=true&w=majority"
);
            this.mDbContext = client.GetDatabase("mDbContext");
            this.ctx = mDbContext.GetCollection<BsonDocument>("runTable");

        }

        //CRUD Methods

       
        public RunInformation Read(int runID)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("RunID", runID);
            var doc = ctx.Find(filter).FirstOrDefault();

            string es = doc.ToJson();
            string ese = es.Trim('{');
            string eese = ese.Trim('}');
            string[] jj = eese.Split(',');

            List<string> lkj = new List<string>();

            RunInformation run = new RunInformation();

            for (int j = 0; j < jj.Length; j++)
            {
                string[] ll = jj[j].Split(':');
                lkj.Add(ll[1].ToString());
            }

            for (int i = 0; i < lkj.Count; i++)
            {
                Console.WriteLine(lkj[i].ToString());
            }

            run._id = lkj[0];
            run.RunID = int.Parse(lkj[1]);
            run.UserID = int.Parse(lkj[2]);
            run.Distance = double.Parse(lkj[3]);
            run.Time = lkj[4];
            run.IsCompetition = bool.Parse(lkj[5]);
            run.Location = lkj[6];

            Console.WriteLine($"User {runID} read!");

            return run;
        }
        


    }

    
}
