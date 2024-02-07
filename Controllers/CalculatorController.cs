using Calculator.Models.RequestModels;
using Calculator.Services;
using Calculator.Services.Interfaces;
using Calculator.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService calculatorService;
        private readonly ICustomLoggerService loggerService;

        public CalculatorController(ICalculatorService calculatorService, ICustomLoggerService loggerService)
        {
            this.calculatorService = calculatorService;
            this.loggerService = loggerService;
        }

        [HttpPost("Sum")]
        public async Task<ActionResult<double>> Sum([FromBody] SumRequest request)
        {
            try
            {
                var result = await calculatorService.SumAsync(request.Numbers);

                return Ok(result);
            }
            catch (Exception ex)
            {
                loggerService.ErrorLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Diff")]
        public async Task<ActionResult<double>> Diff([FromBody] DiffRequest request)
        {
            try
            {
                var result = await calculatorService.DifferenceAsync(request.Numbers);

                return Ok(result);
            }
            catch (Exception ex)
            {
                loggerService.ErrorLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Multiply")]
        public async Task<ActionResult<double>> Multiply([FromBody] MultiplyRequest request)
        {
            try
            {
                var result = await calculatorService.MultiplyAsync(request.Numbers);

                return Ok(result);
            }
            catch (Exception ex)
            {
                loggerService.ErrorLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Div")]
        public async Task<ActionResult<double>> Div([FromBody] DivisionRequest request)
        {
            try
            {
                var result = await calculatorService.DivisionAsync(request.Numbers);

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                loggerService.WarnLog(ex);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                loggerService.ErrorLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Pow")]
        public async Task<ActionResult<double>> Pow([FromBody] ExpRequest request)
        {
            try
            {
                var result = await calculatorService.PowAsync(request.Foundation, request.Power);

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                loggerService.WarnLog(ex);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                loggerService.ErrorLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Sqrt")]
        public async Task<ActionResult> Sqrt([FromBody] SqrtRequest request)
        {
            try
            {
                var result = await calculatorService.SqrtAsync(request.Value);

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                loggerService.WarnLog(ex);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                loggerService.ErrorLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Expression")]
        public async Task<ActionResult> CalcExpression([FromBody] string expression)
        {
            try
            {
                Lexer lexer = new Lexer(expression);
                lexer.LexAnalysis();

                // Parser parser = new Parser(lexer.TokenList, lexer.TokenTypesDictionary);

                // var rootNode = parser.ParseString();

                // parser.Run(rootNode);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
