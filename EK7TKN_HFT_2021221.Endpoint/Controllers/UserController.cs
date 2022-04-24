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
    // GET 
    

    //GET /id
    [HttpGet("read/{id}")]
    public UserInformation Get(int id)
    {
        return user.Read(id);
    }

   

    #endregion

  

}