using System;
using Microsoft.AspNetCore.Mvc;
using SortArray.Data;
using SortArray.Helpers;

namespace SortArray.Controllers
{
    [Route("api/[controller]")]
    public class SortArrayController : Controller
    {
        private ISortArrayService _service;
        public SortArrayController(ISortArrayService service)
        {
            this._service = service;
        }

        /// <summary>Sorts input and returns sorting steps based on selected inputType parameter.</summary>
        [HttpGet("[action]")]
        public IActionResult GetSortArray(string inputType, string input)
        {
            try
            {
                string NotValid = Validation.ValidateInput(inputType, input);
                if (NotValid == "")
                {
                    var steps = _service.GetSortArray(inputType, input);
                    return Ok(steps);
                }
                else
                {
                    return BadRequest(NotValid);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}