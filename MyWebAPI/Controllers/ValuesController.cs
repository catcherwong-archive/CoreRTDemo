namespace MyWebAPI.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;  
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Options;
    using MyLib;
    using MyLib.Data;


    //[Route("api/[controller]")]
    //[ApiController]
    public class ValuesController //: ControllerBase
    {
        //private readonly AppSettingModel _model;
        //private readonly IDataService _service;
        //private readonly IConfiguration _configuration;

        public ValuesController(
           //IOptions< AppSettingModel> model
            //,IConfiguration configuration
         //IDataService service
        )
        {
            //this._model = model.Value;
            //this._configuration = configuration;
            //this._service = service;
        }

        // GET /
        [HttpGet("/")]
        public ActionResult<string> GetName()
        {
            var model = new AppSettingModel{ Name = "catcher from CoreRT"};

            return model.Name;
            //return _configuration.GetSection("Name").Value.ToString();
            //return _model.Name;
        }

        // GET api/values
        [HttpGet("/api/values")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET /async
        [HttpGet("/async")]
        public async Task<ActionResult<string>> GetAsync()
        {
            return await Task.FromResult("123");
        }

        // GET /data
        [HttpGet("/data")]
        public ActionResult<string> GetData()
        {
            IDataService service = new DataService();

            return service.GetData();
            //return _service.GetData();
        }
    }
}
