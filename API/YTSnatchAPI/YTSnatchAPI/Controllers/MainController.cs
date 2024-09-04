#pragma warning disable IDE0290 // Use primary constructor
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.Intrinsics.Arm;
using YTSnatchAPI.Models.ControllerModels.Main;
using YTSnatchAPI.Utility;

namespace YTSnatchAPI.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        public ConfigHelper ConfigHelper { get; set; }
        public MainController(IWebHostEnvironment webHostEnvironment) {
            ConfigHelper = new ConfigHelper(webHostEnvironment);
        } 

        [HttpPost]
        [Route("Main/RunCommand")]
        public ActionResult RunCommand(RunCommandRequestModel model)
        {
            try
            {
            //D:/ Git / YTSnatch / Files / yt - dlp.exe - P "C:\Users\rohan\Downloads\jklhybjk"--ffmpeg - location D:/ Git / YTSnatch / Files / FFMPEG / bin https://www.youtube.com/watch?v=QrI6bGo51f0 -S res,ext:mp4:m4a
                var x = ConfigHelper.PathsConfigData;
                return null;
            }
            catch (Exception ex)
            {
                return Problem(JsonConvert.SerializeObject(ex), null, 500, ex.Message, "Exception");
            }
        }
    }
}
