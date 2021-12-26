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
        public async Task<LoginUserModel> GetUserModel(string domainName)
        {
            string user_id = domainName.Replace("DIRECTRI\\", "");
            string sql = _dapper.ReadSqlText("r_LoginUser.sql");
            List<LoginUserModel> loginUserModels = await _dapper.LoadData<LoginUserModel, dynamic>(sql, new { user_id = user_id });
            return loginUserModels[0];
        }




    }
}
