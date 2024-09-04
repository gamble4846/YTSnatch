#pragma warning disable IDE0290 // Use primary constructor
using Newtonsoft.Json;
using YTSnatchAPI.Models.Configs;

namespace YTSnatchAPI.Utility
{
    public class ConfigHelper
    {
        private IWebHostEnvironment WebHostEnvironment { get; set; }
        public PathsConfigModel PathsConfigData { get; set;}

        public ConfigHelper(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
            UpdatePathsConfigData();
        }

        private void UpdatePathsConfigData()
        {
            var pathsConfigDataPath = WebHostEnvironment.ContentRootPath + "\\Configs\\PathsConfig.json";
            var pathsConfigDataJSON = File.ReadAllText(pathsConfigDataPath);

            if (string.IsNullOrEmpty(pathsConfigDataJSON)) {
                PathsConfigData = new PathsConfigModel();
                return;
            }

            var pathsConfigData = JsonConvert.DeserializeObject<PathsConfigModel>(pathsConfigDataJSON);

            if (pathsConfigData == null) {
                PathsConfigData = new PathsConfigModel();
                return;
            }

            PathsConfigData = pathsConfigData;
        }
    }
}
