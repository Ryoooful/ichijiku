using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace api.Controllers
{
    [Route("api")]
    [ApiController]
    public class Controllers : ControllerBase
    {
        private readonly IDapper _dapper;
        public Controllers(IDapper dapper)
        {
            _dapper = dapper;
        }

        [HttpGet(nameof(GetUserModel))]
        public async Task<string> GetUserModel(string? user_cd , string? dept_cd)
        {
            user_cd = user_cd ?? "";
            user_cd = user_cd.Replace("DIRECTRI\\", "");
            string sql = _dapper.ReadSqlText("r_UserList.sql");
            return await _dapper.LoadData<dynamic>(sql, new { user_cd = user_cd, dept_cd = dept_cd ?? "" }); 
        }



    }
}
