#pragma warning disable IDE0290 // Use primary constructor
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Text;
using YTSnatchAPI.Models.ControllerModels.Main;
using YTSnatchAPI.Utility;

namespace YTSnatchAPI.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        public ConfigHelper ConfigHelper { get; set; }
        public CommonFunctions CommonFunctions { get; set; }
        public MainController(IWebHostEnvironment webHostEnvironment) {
            ConfigHelper = new ConfigHelper(webHostEnvironment);
            CommonFunctions = new CommonFunctions();
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

        [HttpGet]
        [Route("ws/Main/DownloadVideo")]
        public async Task DownloadVideo()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                WebSocket webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                var buffer = new byte[1024 * 4];
                WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                while (!result.CloseStatus.HasValue)
                {
                    string messageReceived = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    var messageToSend = Encoding.UTF8.GetBytes("rohan");
                    await webSocket.SendAsync(new ArraySegment<byte>(messageToSend), result.MessageType, result.EndOfMessage, CancellationToken.None);
                    result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                }
                await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }
    }
}
