using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Business.Contracts;
using OnlineStore.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace OnlineStore.API.Controllers
{
    //[Produces("application/json")]
    //[Route("api/Categories")]
    public class CategoriesController : Controller
    {
        private ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("api/categories")]
        [HttpGet]
        public IActionResult CategoryList()
        {
            return Ok(_categoryService.GetAll().OrderByDescending(_ => _.Id));
        }

        [Route("api/categories/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var category = _categoryService.Get(_ => _.Id == id);

            return Ok(category);
        }

        [Authorize(Roles = "Admin")]
        [Route("api/categories")]
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            _categoryService.Add(category);

            return Ok(category);
        }

        [Authorize(Roles = "Admin")]
        [Route("api/categories")]
        [HttpPut]
        public IActionResult Put([FromBody] Category category)
        {
            _categoryService.Update(category);

            return Ok(category);
        }

        [Authorize(Roles = "Admin")]
        [Route("api/categories/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var category = new Category { Id = id };
                _categoryService.Delete(category);

                return NoContent();
            }
            catch
            {
                return NoContent();
            }
        }
    }
}