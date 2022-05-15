using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchTreat.Data;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DutchTreat.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private IDutchRepository _repository;

        public ProductsController(IDutchRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IEnumerable<Product>>> Get() // TODO I was not getting the problems w/ IEnumerable and ControllerBase that he discussed (because Task?)
        {
            try
            {
                var products = await _repository.GetAllProducts();

                return products;
            }
            catch
            {
                return BadRequest("Failed to GET products.");
            }
        }
    }
}

