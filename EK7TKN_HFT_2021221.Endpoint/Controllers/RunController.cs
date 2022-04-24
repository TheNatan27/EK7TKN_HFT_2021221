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



    //GET /id
    [HttpGet("read/{id}")]
    public RunInformation Get(int id)
    {
        return run.Read(id);
    }

    // POST /post
    #endregion


}