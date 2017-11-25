using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OnlineStore.API.Models;
using OnlineStore.Business.Contracts;
using OnlineStore.Entity.ComplexType;
using OnlineStore.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace OnlineStore.API.Controllers
{
    //[Produces("application/json")]
    //[Route("api/Products")]
    public class ProductsController : Controller
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        //[Authorize(Roles = "Admin")]
        //[Route("api/products")]
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    //var currentUser = HttpContext.User.Claims.Single(claim => claim.Type == ClaimTypes.UserData);

        //    var products = _productService.GetAll();
        //    return Ok(products);
        //}

        [Route("api/products/{categoryId?}/{page?}")]
        [HttpGet]
        public IActionResult ProductList(int categoryId = 0, int page = 1)
        {
            int pageSize = 12;
            var products = (categoryId == 0 ? _productService.GetAll() : _productService.GetAll(_ => _.CategoryId == categoryId)).OrderByDescending(_ => _.Id).ToList();

            ProductResponse productResponse = new ProductResponse
            {
                Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageCount = (int)Math.Ceiling(products.Count / (double)pageSize),
                PageSize = pageSize,
                CurrentCategory = categoryId,
                CurrentPage = page

            };
            return Ok(productResponse);
        }

        [Route("api/products/detail/{productId?}")]
        [HttpGet]
        public IActionResult ProductDetail(int productId)
        {
            try
            {
                if (productId == 0)
                {
                    return BadRequest("ProductId can not be zero. ProductId: " + productId);
                }
                else
                {
                    var product = _productService.Get(_ => _.Id == productId);
                    if (product == null)
                    {
                        return BadRequest("Product not found. ProductId: " + productId);
                    }
                    else
                    {
                        return Ok(product);
                    }
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [Route("api/admin/products/{page?}")]
        [HttpGet]
        public IActionResult ProductComplexList(int page = 1)
        {
            //Thread.Sleep(5000);

            try
            {
                int pageSize = 10;
                var productComplex = _productService.GetAllProductWithCategory().OrderByDescending(_ => _.ProductId).ToList();

                ProductWithCategoryResponse ProductComplexResponse = new ProductWithCategoryResponse
                {
                    Products = productComplex.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                    PageCount = (int)Math.Ceiling(productComplex.Count / (double)pageSize),
                    PageSize = pageSize,

                };

                return Ok(ProductComplexResponse);
            }
            catch
            {
                return BadRequest("An error has occurred");
            }
        }

        [Authorize(Roles = "Admin")]
        [Route("api/admin/products")]
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            try
            {
                _productService.Add(product);

                return Created("", product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [Route("api/admin/products")]
        [HttpPut]
        public IActionResult Put([FromBody]Product product)
        {
            try
            {
                if (product.Id == 0)
                {
                    return BadRequest("ProductId can not be zero. ProductId: " + product.Id);
                }
                else
                {
                    _productService.Update(product);
                    return NoContent();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [Route("api/admin/products/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("ProductId can not be zero. ProductId: " + id);
                }
                else
                {
                    Product product = new Product { Id = id };
                    _productService.Delete(product);

                    return NoContent();

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("api/admin/products/download")]
        [HttpGet]
        public IActionResult Download()
        {
            string XlsxContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            string fileName = "Product List - " + DateTime.Now.ToShortDateString() + ".xlsx";
            byte[] excelFile = ExcelSheet(fileName, _productService.GetAllProductWithCategory());

            return File(excelFile, XlsxContentType, fileName + ".xlsx");
        }

        public byte[] ExcelSheet(string fileName, List<ProductWithCategory> productList)
        {
            using (var package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(fileName.Replace(".xlsx", string.Empty));
                worksheet.Row(1).Height = 30;
                worksheet.Row(1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheet.Cells[1, 1].Value = "Product Id";
                //worksheet.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, 1].AutoFitColumns();


                worksheet.Cells[1, 2].Value = "Product Name";
                //worksheet.Cells[1, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, 2].AutoFitColumns();

                worksheet.Cells[1, 3].Value = "Category";
                //worksheet.Cells[1, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, 3].AutoFitColumns();

                worksheet.Cells[1, 4].Value = "Price";
                //worksheet.Cells[1, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, 4].AutoFitColumns();

                worksheet.Cells[1, 5].Value = "Stock Quantity";
                //worksheet.Cells[1, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, 5].AutoFitColumns();

                for (int i = 1; i <= 5; i++)
                {
                    worksheet.Cells[1, i].Style.Font.Bold = true;
                    worksheet.Cells[1, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[1, i].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#448AFF"));
                    worksheet.Cells[1, i].Style.Font.Color.SetColor(Color.White);
                }

                for (int k = 0; k < productList.Count; k++)
                {
                    worksheet.Cells[k + 2, 1].Value = productList[k].ProductId;
                    worksheet.Cells[k + 2, 2].Value = productList[k].Name;
                    worksheet.Cells[k + 2, 3].Value = productList[k].CategoryName;
                    worksheet.Cells[k + 2, 4].Value = productList[k].Price;
                    worksheet.Cells[k + 2, 5].Value = productList[k].StockQuantity;
                    if (productList[k].StockQuantity <= 10)
                    {
                        worksheet.Cells[k + 2, 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[k + 2, 5].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#D50000"));
                        worksheet.Cells[k + 2, 5].Style.Font.Color.SetColor(Color.White);
                    }

                }
                byte[] bytes = package.GetAsByteArray();
                return bytes;
            }
        }
    }
}