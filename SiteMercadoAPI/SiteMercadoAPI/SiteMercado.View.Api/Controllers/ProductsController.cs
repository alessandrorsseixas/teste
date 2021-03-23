using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SiteMercado.Domain.Model;
using SiteMercado.Domain.Model.ViewModels;
using SiteMercado.Domain.SeedWorks.Interfaces.Services;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Net.Http.Headers;

namespace SiteMercado.View.Api.Controllers
{
    [Route("api/v{version:apiVersion}/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly INotificator _notificator;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public static IWebHostEnvironment _environment;
        public ProductsController(IProductService productService,IMapper mapper,INotificator notificator, IWebHostEnvironment environment)
        {
            _productService = productService;
            _mapper = mapper;
            _notificator = notificator;
            _environment = environment;
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody]ProductViewModel productViewModel)
        {

            try
            {

                var product = _mapper.Map<Product>(productViewModel);
                product.CreatedDate = DateTime.Now;
                product.Active = true;
                product.SetNotificator(_notificator);
                if (await _productService.Exist(product))
                {
                    return StatusCode(409, "Já existe um Produto cadastrado com o mesmo ID");

                }
                else
                {
                    if (!product.IsValidObject(product)) return StatusCode(409, product.GetNotifications());


                    //_pilotoRepositorio.Adicionar(piloto);
                    await _productService.Add(product);
                    return StatusCode(201,"Produto Cadastrado com sucesso");
                }


            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado");

            }
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody]ProductViewModel productViewModel)
        {
            try
            {
                var product = _mapper.Map<Product>(productViewModel);
                product.UpdatedDate = DateTime.Now;
          
                if (!await _productService.Exist(product))
                    return NoContent();
                await _productService.Update(product);
                return Ok("Produto Atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado");

            }
        }


        [HttpPatch("id")]
        public async Task<IActionResult> Patch(int id, [FromBody]JsonPatchDocument<ProductViewModel> patchProduct)
        {
            try
            {

                var product = await _productService.GetById(id);
                if (!await _productService.Exist(product))
                    return NoContent();

                var productViewModel = _mapper.Map<ProductViewModel>(product);
                patchProduct.ApplyTo(productViewModel);

                product = _mapper.Map<Product>(productViewModel);

                await _productService.Update(product);


                return Ok("Produto Atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado");

            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await _productService.GetById(id);
                if (!await _productService.Exist(product))
                    return NoContent();
                await _productService.Delete(product);

                return Ok("Producto Excluído com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado");

            }
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> UploadAsync()
        {
            try
            {
                var files = Request.Form.Files;
                var folderName = Path.Combine("StaticFiles", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (files.Any(f => f.Length == 0))
                {
                    return BadRequest();
                }
                foreach (var file in files)
                {

                    if (!Directory.Exists(_environment.WebRootPath + "\\imagens\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\imagens\\");
                    }
                    using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\imagens\\" + file.FileName))
                    {
                        await file.CopyToAsync(filestream);
                        filestream.Flush();
                    }
                }

            
                return Ok("All the files are successfully uploaded.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }




        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                
                var products = await _productService.GetAll();
                if (!products.Any())
                    return NoContent();

                return Ok(_mapper.Map<IEnumerable<ProductViewModel>>(products));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado");

            }


        }


        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> GetById(int id)
        {

            try
            {
                var product = await _productService.GetById(id);
                if (product == null)
                    return NoContent();

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado");

            }


        }


    }
}