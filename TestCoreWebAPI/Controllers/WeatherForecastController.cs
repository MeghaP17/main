using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO.Pipelines;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace TestCoreWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
        [HttpPost]
        [Consumes("application/xml")]
        public  bool Post([FromBody] ICEMessage model)
        {

            //var stream = weatherForecast.XMLData;
            ////string content = string.Empty;
            //var xmlDocument = new XmlDocument();
            //xmlDocument.Load(stream);
            //using (var reader = new StreamReader(
            //Request.InputStream, System.Text.Encoding.UTF8, true, 4096, true))
            //{
            //    content = reader.ReadToEnd();
            //}

            // string requestBody = await new StreamReader(Request.Body req.Body).ReadToEndAsync();

            //xmlDocument.Load(stream);

            // Process XML document

            return true;
        }

 //       string content = "";
 //       System.Web.HttpContext.Current.Request.InputStream.Position = 0;
 //using (var reader = new StreamReader(
 //         Request.InputStream, System.Text.Encoding.UTF8, true, 4096, true))
 //     {
 //        content = reader.ReadToEnd();
 //     }
 //   //Rest
 //   System.Web.HttpContext.Current.Request.InputStream.Position = 0;
    }
}
