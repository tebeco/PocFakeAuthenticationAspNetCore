using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiMultiIndexEls.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogGenerator _logGenerator;

        public LogController(ILogGenerator logGenerator)
        {
            _logGenerator = logGenerator;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Unhandled");
            sb.AppendLine("Trace");
            sb.AppendLine("Debug");
            sb.AppendLine("Info");
            sb.AppendLine("Warning");
            sb.AppendLine("Error");
            sb.AppendLine("ErrorEx");
            sb.AppendLine("ErrorExStack");
            sb.AppendLine("Crticial");

            return sb.ToString();
        }

        [HttpGet]
        public async Task All()
        {
            Trace();
            Debug();
            Info();
            Warn();
            Error();
            ErrorEx();
            await ErrorExStack();
            Critical();
            Unhandled();
        }

        [HttpGet]
        public void Unhandled()
        {
            _logGenerator.Unhandled();
        }

        [HttpGet]
        public void Trace()
        {
            _logGenerator.Trace();
        }

        [HttpGet]
        public void Debug()
        {
            _logGenerator.Debug();
        }

        [HttpGet]
        public void Info()
        {
            _logGenerator.Info();
        }

        [HttpGet]
        public void Warn()
        {
            _logGenerator.Warn();
        }

        [HttpGet]
        public void Error()
        {
            _logGenerator.Error();
        }


        [HttpGet]
        public void ErrorEx()
        {
            var ex = new Exception("Here is an exception for the logger");

            _logGenerator.ErrorFromException(ex);
        }

        [HttpGet]
        public async Task<float> ErrorExStack()
        {
            var result = 0f;
            try
            {
                result = await Task.Run(async () =>
                {
                    await Task.Delay(1);
                    return await Task.Run(async () =>
                    {
                        await Task.Delay(1);
                        return await Task.Run(async () =>
                        {
                            await Task.Delay(1);

                            return await Task.Run(async () =>
                            {
                                await Task.Delay(1);
                                var i = 1 - 1;
                                return 1 / i;
                            });
                        });
                    });
                });
            }
            catch (Exception ex)
            {
                _logGenerator.ErrorFromException(ex);
            }
            return result;
        }


        [HttpGet]
        public void Critical()
        {
            _logGenerator.Critical();
        }
    }
}