using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Registration.Data.Contracts.Account;
using Registration.Model.Account;
using Registration.WebApi.Controllers.Core;
using Registration.WebApi.Models.Create.Account;
using Registration.WebApi.Models.Read.Account;
using Registration.WebApi.Models.Update.Account;

namespace Registration.WebApi.Controllers.Account
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ProductController : CoreController
    {
        readonly IProductRepository _productRepository;
        readonly IMapper _mapper;
        readonly ILogger<ProductController> _logger;

        public ProductController(
            IProductRepository productRepository,
            IMapper mapper,
            ILogger<ProductController> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Lista todos os produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<ProductReadModel>>> ProductListAsync()
        {
            try
            {
                var products = await _productRepository.GetProducts();

                return Ok(products);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Acessa um registro de produto por Id(Código)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductReadModel), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _productRepository.GetProductByIdAsync(id);
                if (product == null)
                    return NotFound("Produto não encontrado");

                var readProduct = _mapper.Map<ProductReadModel>(product);

                return Ok(readProduct);
            }
            catch (Exception e)
            {
                return LoggerBadRequest(e, _logger);
            }
        }

        /// <summary>
        /// Cria um novo registro de um produto
        /// </summary>
        /// <param name="productCreateModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        public async Task<IActionResult> Create([FromBody] ProductCreateModel productCreateModel)
        {
            if (!ModelState.IsValid)
                return NotFound("Modelo não é válido");

            try
            {
                var product = _mapper.Map<Product>(productCreateModel);
                await _productRepository.AddProductAsync(product);
                
                return Ok(product.Id);
            }
            catch (Exception e)
            {
                return LoggerBadRequest(e, _logger);
            }
        }

        /// <summary>
        /// Atualiza um registro de um produto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productUpdateModel"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductUpdateModel productUpdateModel)
        {
            if (!ModelState.IsValid)
                return NotFound("Modelo não é válido");

            try
            {
                var product = await _productRepository.GetProductByIdAsync(id);
                _mapper.Map(productUpdateModel, product);

                await _productRepository.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return LoggerBadRequest(e, _logger);
            }

            return NoContent();
        }

        /// <summary>
        /// Exclui um registro de um produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await _productRepository.GetProductByIdAsync(id);
                if (product == null)
                    return NotFound("Produto não encontrado");

                await _productRepository.DeleteAsync(product);

                return NoContent();
            }
            catch (Exception e)
            {
                return LoggerBadRequest(e, _logger);
            }
        }

        private async Task<bool> PersonExists(int id)
        {
            try
            {
                var product = await _productRepository.ListAsync();
                var hasProduct = product.Any(x => x.Id == id);

                return hasProduct;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
    }
}
