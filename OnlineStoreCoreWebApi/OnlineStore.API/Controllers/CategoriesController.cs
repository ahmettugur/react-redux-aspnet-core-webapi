using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Business.Contracts;
using OnlineStore.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using System.Threading;
using ATCommon.Aspect.Contracts.Proxy;

namespace OnlineStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = CommonAspect<ICategoryService>.Create(categoryService);
            //_categoryService = categoryService;
        }

        [Route("")]
        [HttpGet]
        public IActionResult CategoryList()
        {
            try
            {
                return Ok(_categoryService.GetAll().OrderByDescending(_ => _.Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                var category = _categoryService.Get(_ => _.Id == id);

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [Route("")]
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            try
            {
                _categoryService.Add(category);
                return Created("", category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [Route("")]
        [HttpPut]
        public IActionResult Put([FromBody] Category category)
        {
            try
            {
                _categoryService.Update(category);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var category = new Category { Id = id };
                _categoryService.Delete(category);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}