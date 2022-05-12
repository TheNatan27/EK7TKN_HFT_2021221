using EK7TKN_HFT_2021221.Endpoint.Services;
using EK7TKN_HFT_2021221.Logic;
using EK7TKN_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;

[Route("[controller]")]
[ApiController]
public class PassController : ControllerBase
{
    IPassLogic pass;
    IHubContext<SignalRHub> hub;
    public PassController(IPassLogic pl, IHubContext<SignalRHub> hub)
    {
        this.pass = pl;
        this.hub = hub;
    }

    #region crud methods

    //GET 
    [HttpGet]
    public IEnumerable<PasswordSecurity> GetAll()
    {
        return pass.ReadAll();
    }

    //GET /read/id
    [HttpGet("read/{id}")]
    public PasswordSecurity Get(int id)
    {
        return pass.Read(id);
    }

    // POST /post
    [HttpPost("post")]
    public void Post ([FromBody] string json)
    {
        pass.Create(json);
        this.hub.Clients.All.SendAsync("PasswordCreated", json);
    }
    
    // PUT /put
    [HttpPut("put")]
    public void Update([FromBody] string json)
    {
        pass.Update(json);
        this.hub.Clients.All.SendAsync("PasswordUpdated", json);

    }

    // DELETE /delete/od
    [HttpDelete("delete/{id}")]
    public void Delete(int id)
    {
        var passToDelete = pass.Read(id);
        pass.Delete(id);
        this.hub.Clients.All.SendAsync("PasswordDeleted", passToDelete);

    }

    #endregion


    #region non crud methods
    // GetOldPeoplesPassID
    [HttpGet("GetOldPeoplesPassID")]
    public IEnumerable<int> GetOldPeoplesPassID()
    {
        return pass.GetOldPeoplesPassID();
    }

    // GetOldPeoplesPassIDWithWeakPassword
    [HttpGet("GetOldPeoplesPassIDWithWeakPassword")]
    public IEnumerable<int> GetOldPeoplesPassIDWithWeakPassword()
    {
        return pass.GetOldPeoplesPassIDWithWeakPassword();
    }

    // GetPassIDOfPremiumUsers
    [HttpGet("GetPassIDOfPremiumUsers")]
    public IEnumerable<int> GetPassIDOfPremiumUsers()
    {
        return pass.GetPassIDOfPremiumUsers();
    }

    // GetPhoneNumberOfPremiumUsers
    [HttpGet("GetPhoneNumberOfPremiumUsers")]
    public IEnumerable<string> GetPhoneNumberOfPremiumUsers()
    {
        return pass.GetPhoneNumberOfPremiumUsers();
    }

    // GetPhoneNumberOfCompetitors
    [HttpGet("GetPhoneNumberOfCompetitors")]
    public IEnumerable<string> GetPhoneNumberOfCompetitors()
    {
        return pass.GetPhoneNumberOfCompetitors();
    }



    #endregion
}
