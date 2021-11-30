using EK7TKN_HFT_2021221.Logic;
using EK7TKN_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;


[Route("[controller]")]
[ApiController]
public class RunController : ControllerBase
{
    IRunLogic run;

    public RunController(IRunLogic rl)
    {
        this.run = rl;
    }

    #region crud methods

    //GET 
    [HttpGet]
    public IEnumerable<RunInformation> GetAll()
    {
        return run.ReadAll();
    }

    //GET /id
    [HttpGet("{id}")]
    public IQueryable<RunInformation> Get(int id)
    {
        return run.Read(id);
    }

    // POST /post
    [HttpPost("post")]
    public void Post([FromBody] string json)
    {
        run.Create(json);

        System.Console.WriteLine(json);
    }
    // POST /put
    [HttpPut("put")]
    public void Update([FromBody] string filename, int runID)
    {
        run.Update(filename, runID);
    }


    // DELETE /delete/id
    [HttpDelete("delete/{id}")]
    public void Delete(int id)
    {
        run.Delete(id);
        System.Console.WriteLine("Run deleted!");
    }
    #endregion

    #region non crud methods

    // GetRunIDOfPremiumUsers
    [HttpGet("GetRunIDOfPremiumUsers")]
    public IEnumerable<int> GetRunIDOfPremiumUsers()
    {
        return run.GetRunIDOfPremiumUsers();
    }

    // GetRunIDOfPremiumUsers
    [HttpGet("GetTimeOfPremiumCompetitors")]
    public IEnumerable<string> GetTimeOfPremiumCompetitors()
    {
        return run.GetTimeOfPremiumCompetitors();
    }

    // GetRunIDOfLongDistanceJuniorRunners
    [HttpGet("GetRunIDOfLongDistanceJuniorRunners")]
    public IEnumerable<int> GetRunIDOfLongDistanceJuniorRunners()
    {
        return run.GetRunIDOfLongDistanceJuniorRunners();
    }

    // GetLocationOfChonkers
    [HttpGet("GetLocationOfChonkers")]
    public IEnumerable<string> GetLocationOfChonkers()
    {
        return run.GetLocationOfChonkers();
    }

    // GetLocationOfJuniorPremiumUsers
    [HttpGet("GetLocationOfJuniorPremiumUsers")]
    public IEnumerable<string> GetLocationOfJuniorPremiumUsers()
    {
        return run.GetLocationOfJuniorPremiumUsers();
    }

    #endregion
}