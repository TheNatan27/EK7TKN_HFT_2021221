using EK7TKN_HFT_2021221.Logic;
using EK7TKN_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

    //GET read all passwords
    [HttpGet]
    public IEnumerable<PasswordSecurity> GetAll()
    {
        return pass.ReadAll();
    }

    //GET read password
    [HttpGet("{id}")]
    public IQueryable<PasswordSecurity> Get(int id)
    {
        return pass.Read(id);
    }

    // POST create a password
    [HttpPost]
    public void Post ([FromBody] string filename)
    {
        pass.Create(filename);
    }
    
    // PUT update a password
    [HttpPut]
    public void Update([FromBody] string filename, int runID)
    {
        pass.Update(filename, runID);
    }

    // DELETE delete a password
    [HttpDelete("{id}")]
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
    [HttpGet("GetPasswordOfUserByName")]
    public IEnumerable<string> GetPasswordOfUserByName()
    {
        return pass.GetPasswordOfUserByName();
    }

    #endregion
}
