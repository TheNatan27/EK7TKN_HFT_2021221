using EK7TKN_HFT_2021221.Logic;
using EK7TKN_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
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

    public PassController(IPassLogic pl)
    {
        this.pass = pl;
    }

    #region crud methods

    //GET 
    [HttpGet]
    public IEnumerable<PasswordSecurity> GetAll()
    {
        return pass.ReadAll();
    }

    //GET /id
    [HttpGet("{id}")]
    public IQueryable<PasswordSecurity> Get(int id)
    {
        return pass.Read(id);
    }

    // POST /post
    [HttpPost("post")]
    public void Post ([FromBody] string json)
    {
        pass.Create(json);

        System.Console.WriteLine(json);
    }
    
    // PUT /put
    [HttpPut("put/{id}")]
    public void Update([FromBody] string json, int id)
    {
        pass.Update(json, id);
    }

    // DELETE /delete/od
    [HttpDelete("delete/{id}")]
    public void Delete(int id)
    {
        pass.Delete(id);
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

    // GetPasswordOfUserByName
    [HttpGet("GetPasswordOfUserByName/{name}")]
    public IEnumerable<string> GetPasswordOfUserByName(string name)
    {
        return pass.GetPasswordOfUserByName(name);
    }

    #endregion
}
