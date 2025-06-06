using Microsoft.AspNetCore.Mvc;

namespace VolumeTest1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        private readonly string logPath = "/Logs/logs.txt";

        [HttpPost("info")]
        public IActionResult LogInfo([FromBody] string message)
        {
            WriteLog("INFO", message);
            return Ok("Info log yazıldı.");
        }

        [HttpPost("error")]
        public IActionResult LogError([FromBody] string message)
        {
            WriteLog("ERROR", message);
            return Ok("Error log yazıldı.");
        }

        private void WriteLog(string level, string message)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(logPath)!);

            using (var stream = new FileStream(logPath, FileMode.Append, FileAccess.Write, FileShare.Read))
            using (var writer = new StreamWriter(stream))
            {
                writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}");
            }
        }
    }
}
