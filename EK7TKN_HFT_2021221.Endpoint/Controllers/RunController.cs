using EK7TKN_HFT_2021221.Endpoint.Services;
using EK7TKN_HFT_2021221.Logic;
using EK7TKN_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;


[Route("[controller]")]
[ApiController]
public class RunController : ControllerBase
{
    IRunLogic run;
    IHubContext<SignalRHub> hub;

    public RunController(IRunLogic rl, IHubContext<SignalRHub> hub)
    {
        this.run = rl;
        this.hub = hub;
    }

    #region crud methods

    //GET 
    [HttpGet]
    public IEnumerable<RunInformation> GetAll()
    {
        return run.ReadAll();
    }

    //GET /id
    [HttpGet("read/{id}")]
    public RunInformation Get(int id)
    {
        return run.Read(id);
    }

    // POST /post
    [HttpPost("post")]
    public void Post([FromBody] string json)
    {
        run.Create(json);
        this.hub.Clients.All.SendAsync("RunCreated", json);
    }
    // POST /put
    [HttpPut("put/{id}")]
    public void Update([FromBody] string json, int id)
    {
        run.Update(json, id);
        this.hub.Clients.All.SendAsync("RunUpdated", json);
    }


    // DELETE /delete/id
    [HttpDelete("delete/{id}")]
    public void Delete(int id)
    {
        var runToDelet = run.Read(id);
        run.Delete(id);
        System.Console.WriteLine("Run deleted!");
        this.hub.Clients.All.SendAsync("RunDeleted", runToDelet);
    }
    #endregion

    #region non crud methods

    // GetRunIDOfPremiumUsers
    [HttpGet("GetRunIDOfPremiumUsers")]
    public IEnumerable<int> GetRunIDOfPremiumUsers()
    {
        return run.GetRunIDOfPremiumUsers();
    }

    // GetTimeOfPremiumCompetitors
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