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



        //[HttpGet(nameof(GetJobList))]
        //public Task<List<AnalysisModel>> GetJobList(int status_id, int software_id)
        //{
        //    string sql = _dapper.ReadSqlText("r_JobList.sql");
        //    return _dapper.LoadData<AnalysisModel, dynamic>(sql, new { status_id, software_id });
        //}


        //[HttpGet(nameof(GetAnalysisList))]
        //public Task<List<AnalysisModel>> GetAnalysisList()
        //{
        //    string sql = _dapper.ReadSqlText("r_AnalysisList.sql");
        //    return _dapper.LoadData<AnalysisModel, dynamic>(sql, new { });
        //}

        //[HttpGet(nameof(GetAnalysisModel))]
        //public async Task<AnalysisModel> GetAnalysisModel(int analysis_id)
        //{
        //    string sql = _dapper.ReadSqlText("r_AnalysisModel.sql");
        //    List<AnalysisModel> analysisModels = await _dapper.LoadData<AnalysisModel, dynamic>(sql, new { analysis_id = analysis_id });
        //    return analysisModels[0];
        //}

        //[HttpGet(nameof(GetSolverList))]
        //public Task<List<SolverModel>> GetSolverList()
        //{
        //    string sql = _dapper.ReadSqlText("r_SolverList.sql");
        //    return _dapper.LoadData<SolverModel, dynamic>(sql, new { });
        //}

        //[HttpGet(nameof(GetServerList))]
        //public Task<List<ServerModel>> GetServerList()
        //{
        //    string sql = _dapper.ReadSqlText("r_ServerList.sql");
        //    return _dapper.LoadData<ServerModel, dynamic>(sql, new { });
        //}

        ////↓PostよりもPatchのほうが適切では？(2021/07/21 By加藤)
        //[HttpPost(nameof(JobSort))]
        //public async Task<int> JobSort(List<PriorityModel> priorityModels)
        //{
        //    var jsonstr = JsonConvert.SerializeObject(priorityModels, Formatting.Indented);
        //    DynamicParameters parameters = new ();
        //    parameters.Add("@JSONSTR", jsonstr, DbType.String, ParameterDirection.Input);

        //    string sql = _dapper.ReadSqlText("u_JobSort.sql");
        //    return await _dapper.Execute<int,DynamicParameters>(sql, parameters);
        //}

        ////↓PostよりもPatchのほうが適切では？(2021/07/21 By加藤)
        //[HttpPost(nameof(UpdateStatus))]
        //public Task<int> UpdateStatus(UStatusModel parameter)
        //{
        //    string sql = _dapper.ReadSqlText("u_Status.sql");
        //    return _dapper.Execute<int, dynamic > (sql, parameter);
        //}

        ////↓PostよりもPatchのほうが適切では？(2021/07/21 By加藤)
        //[HttpPost(nameof(UpdateMemo))]
        //public Task<int> UpdateMemo(AnalysisModel parameter)
        //{
        //    string sql = _dapper.ReadSqlText("u_Memo.sql");
        //    return _dapper.Execute<int, dynamic > (sql, parameter);
        //}


        //[HttpPost(nameof(InsertCatiaJob))]
        //public Task<int> InsertCatiaJob(AnalysisModel parameter)
        //{
        //    string sql = _dapper.ReadSqlText("c_CatiaJob.sql");
        //    return _dapper.Execute<int, dynamic>(sql, parameter);
        //}

        //[HttpPatch(nameof(UpdateLogPath))]
        //public Task<int> UpdateLogPath(AnalysisModel parameter)
        //{
        //    string sql = _dapper.ReadSqlText("u_JobLogPath.sql");
        //    return _dapper.Execute<int, dynamic>(sql, parameter);
        //}

        //[HttpPatch(nameof(UpdateJobEnd))]
        //public Task<int> UpdateJobEnd(UStatusModel parameter)
        //{
        //    string sql = _dapper.ReadSqlText("u_JobEnd.sql");
        //    return _dapper.Execute<int, dynamic>(sql, parameter);
        //}





    }
}
