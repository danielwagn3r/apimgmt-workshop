using System;
using CalcApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CalcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationsController : ControllerBase
    {
        private readonly ILogger<CalculationsController> _logger;

        public CalculationsController(ILogger<CalculationsController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        ///     Calculate sum of two numbers.
        /// </summary>
        [HttpPost]
        [Route("Add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult<CalculationsResponseModel> Add(
            [FromBody] BasicCalcuationRequestModel basicCalcuationRequestModel)
        {
            _logger.LogInformation("Add({0},{1})", basicCalcuationRequestModel.Number1,
                basicCalcuationRequestModel.Number2);

            return new CalculationsResponseModel
            {
                Result = basicCalcuationRequestModel.Number1 + basicCalcuationRequestModel.Number2
            };
        }

        /// <summary>
        ///     Calculate difference of two numbers.
        /// </summary>
        [HttpPost]
        [Route("Sub")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult<CalculationsResponseModel> Sub(
            [FromBody] BasicCalcuationRequestModel basicCalcuationRequestModel)
        {
            _logger.LogInformation("Sub({0},{1})", basicCalcuationRequestModel.Number1,
                basicCalcuationRequestModel.Number2);

            return new CalculationsResponseModel
            {
                Result = basicCalcuationRequestModel.Number1 - basicCalcuationRequestModel.Number2
            };
        }

        /// <summary>
        ///     Calculate product of two numbers.
        /// </summary>
        [HttpPost]
        [Route("Mul")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult<CalculationsResponseModel> Mul(
            [FromBody] BasicCalcuationRequestModel basicCalcuationRequestModel)
        {
            _logger.LogInformation("Mul({0},{1})", basicCalcuationRequestModel.Number1,
                basicCalcuationRequestModel.Number2);

            return new CalculationsResponseModel
            {
                Result = basicCalcuationRequestModel.Number1 * basicCalcuationRequestModel.Number2
            };
        }

        /// <summary>
        ///     Calculate dividend of two numbers.
        /// </summary>
        /// <response code="400">Attemted division by zero.</response>
        [HttpPost]
        [Route("Div")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CalculationsResponseModel> Div(
            [FromBody] BasicCalcuationRequestModel basicCalcuationRequestModel)
        {
            _logger.LogInformation("Div({0},{1})", basicCalcuationRequestModel.Number1,
                basicCalcuationRequestModel.Number2);

            if (basicCalcuationRequestModel.Number2 == 0)
            {
                _logger.LogError("Division by zero!");
                return BadRequest(new ErrorResponseModel
                {
                    Cause = "Division by zero"
                });
            }

            return new CalculationsResponseModel
            {
                Result = basicCalcuationRequestModel.Number1 / basicCalcuationRequestModel.Number2
            };
        }

        /// <summary>
        ///     Calculate square of a number.
        /// </summary>
        [HttpPost]
        [Route("Pow")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult<CalculationsResponseModel> Pwr(
            [FromBody] AdvancedCalcuationRequestModel advancedCalcuationRequestModel)
        {
            _logger.LogInformation("Pwr({0})", advancedCalcuationRequestModel.Number);

            return new CalculationsResponseModel
            {
                Result = advancedCalcuationRequestModel.Number * advancedCalcuationRequestModel.Number
            };
        }

        /// <summary>
        ///     Calculate square root of a number.
        /// </summary>
        [HttpPost]
        [Route("Sqr")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult<CalculationsResponseModel> Sqr(
            [FromBody] AdvancedCalcuationRequestModel advancedCalcuationRequestModel)
        {
            _logger.LogInformation("Sqr({0})", advancedCalcuationRequestModel.Number);

            return new CalculationsResponseModel
            {
                Result = Math.Sqrt(advancedCalcuationRequestModel.Number)
            };
        }
    }
}