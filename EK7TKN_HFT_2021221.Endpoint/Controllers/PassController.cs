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


    //GET /read/id
    [HttpGet("read/{id}")]
    public PasswordSecurity Get(int id)
    {
        return pass.Read(id);
    }



    #endregion

}
