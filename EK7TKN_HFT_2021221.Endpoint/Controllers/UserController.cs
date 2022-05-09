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
public class UserController : ControllerBase
{
    IUserLogic user;
    IHubContext<SignalRHub> hub;

    public UserController(IUserLogic uli, IHubContext<SignalRHub> hub)
    {
        this.user= uli;
        this.hub = hub;
    }

    #region crud methods
    // GET 
    [HttpGet]
    public IEnumerable<UserInformation> GetAll()
    {
        System.Console.WriteLine("all users read");
        return user.ReadAll();
    }

    //GET /id
    [HttpGet("read/{id}")]
    public UserInformation Get(int id)
    {
        return user.Read(id);
    }

    // POST /post
    [HttpPost]
    public void PostCreate([FromBody] string json)
    {
        //user.Create(json);
        System.Console.WriteLine($"user {json} created");
        this.user.Create(json);
        this.hub.Clients.All.SendAsync("UserCreated", json);
    }

    // PUT update user
    [HttpPut("put")]
    public void PostUpdate([FromBody] string json)
    {
        user.Update(json);
        this.hub.Clients.All.SendAsync("UserUpdated", json);
    }

    // DELETE /delete/id
    [HttpDelete("delete/{id}")]
    public void Delete(int id)
    {
        var userToDelet = user.Read(id);
        user.Delete(id);
        this.hub.Clients.All.SendAsync("UserDeleted", userToDelet);
        System.Console.WriteLine($"user {id} deleted");
    }

    #endregion

    #region non crud methods
    //GET /ReadRunsOfUser/id
    [HttpGet("ReadRunsOfUser/{id}")]
    public IEnumerable<KeyValuePair<int, string>> ReadRunsOfUser(int id)
    {
        return user.ReadRunsOfUser(id);
    }


    // GetEmailOfWeakPasswordUsers
    [HttpGet("GetEmailOfWeakPasswordUsers")]
    public IEnumerable<string> GetEmailOfWeakPasswordUsers()
    {
        return user.GetEmailOfWeakPasswordUsers();
    }

    // GetCompetitorsEmailAddress
    [HttpGet("GetCompetitorsEmailAddress")]
    public IEnumerable<string> GetCompetitorsEmailAddress()
    {
        return user.GetCompetitorsEmailAddress();
    }

    // GetAmericanUsersNames
    [HttpGet("GetAmericanUsersNames")]
    public IEnumerable<string> GetAmericanUsersNames()
    {
        return user.GetAmericanUsersNames();
    }

    // GetLongDistanceCompetitorsNames
    [HttpGet("GetLongDistanceCompetitorsNames")]
    public IEnumerable<string> GetLongDistanceCompetitorsNames()
    {
        return user.GetLongDistanceCompetitorsNames();
    }

    // GetNameOfLongDistanceOldRunners
    [HttpGet("GetNameOfLongDistanceOldRunners")]
    public IEnumerable<string> GetNameOfLongDistanceOldRunners()
    {
        return user.GetNameOfLongDistanceOldRunners();
    }


    #endregion


}