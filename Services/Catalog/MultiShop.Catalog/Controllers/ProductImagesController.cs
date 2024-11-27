using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImagesDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImagesService;

        public ProductImagesController(IProductImageService ProductImagesService)
        {
            _productImagesService = ProductImagesService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImagesList()
        {
            var values = await _productImagesService.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImagesById(string id)
        {
            var values = await _productImagesService.GetByIdProductImageAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductImages(CreateProductImageDto createProductImagesDto)
        {
            await _productImagesService.CreateProductImageAsync(createProductImagesDto);
            return Ok("Ürün görselleri Başarılı bir şekilde eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImages(string id)
        {
            await _productImagesService.DeleteProductImageAsync(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductImages(UpdateProductImageDto updateProductImagesDto)
        {
            await _productImagesService.UpdateProductImageAsync(updateProductImagesDto);
            return Ok("Ürün görselleri başarılı bir şekilde güncellendi.");
        }
    }
}
