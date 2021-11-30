using EK7TKN_HFT_2021221.Logic;
using EK7TKN_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;


[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    IUserLogic user;

    public UserController(IUserLogic uli)
    {
        this.user= uli;
    }

    #region crud methods
    // GET: /user
    [HttpGet]
    public IEnumerable<UserInformation> GetAll()
    {
        return user.ReadAll();
    }

    //GET read user
    [HttpGet("{id}")]
    public IQueryable<UserInformation> Get(int id)
    {
        return user.Read(id);
    }

    // POST /post
    [HttpPost("post")]
    public void PostCreate(string json)
    {
        user.Create(json);
    }

    // PUT update user
    [HttpPut("update/{userID}")]
    public void PostUpdate([FromBody] string filenameU, int userID)
    {
        user.Update(filenameU, userID);
    }

    // DELETE user
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        user.Delete(id);
    }

    #endregion

    #region non crud methods

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