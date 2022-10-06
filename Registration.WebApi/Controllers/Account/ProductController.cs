using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Registration.Data.Contracts.Account;
using Registration.Model;
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
        readonly IProductRepository _personRepository;
        readonly IMapper _mapper;
        readonly ILogger<ProductController> _logger;

        public ProductController(
            IProductRepository personRepository,
            IMapper mapper,
            ILogger<ProductController> logger)
        {
            _personRepository = personRepository;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Lista todas as pessoas inseridas anteriormente
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ListDataPagination<ProductReadModel>), 200)]
        public async Task<IActionResult> PersonListAsync([FromQuery] int page = 0, [FromQuery] int size = 15,
            [FromQuery] string? searchString = null,
            [FromQuery] DateTimeOffset? initialDate = null, [FromQuery] DateTimeOffset? finalDate = null,
            [FromQuery] string? orderBy = null)
        {
            try
            {
                ListDataPagination<Product> listData = await _personRepository.ListPersonAsync(searchString, page, size, initialDate, finalDate, orderBy);

                var newData = new ListDataPagination<ProductReadModel>()
                {
                    Data = listData.Data.Select(c => _mapper.Map<ProductReadModel>(c)).ToList(),
                    Page = page,
                    TotalItems = listData.TotalItems,
                    TotalPages = listData.TotalPages
                };
                return Ok(newData);
            }
            catch (Exception e)
            {
                return LoggerBadRequest(e, _logger);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductReadModel), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var person = await _personRepository.GetProductByIdAsync(id);
                if (person == null)
                    return NotFound("Produto não encontrado");

                var readPerson = _mapper.Map<ProductReadModel>(person);

                return Ok(readPerson);
            }
            catch (Exception e)
            {
                return LoggerBadRequest(e, _logger);
            }
        }

        /// <summary>
        /// Cria um novo registro de pessoa
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        public async Task<IActionResult> Create([FromBody] ProductCreateModel personCreateModel)
        {
            if (!ModelState.IsValid)
                return NotFound("Modelo não é válido");

            try
            {
                var person = _mapper.Map<Product>(personCreateModel);
                await _personRepository.AddProductAsync(person);
                
                return Ok(person.Id);
            }
            catch (Exception e)
            {
                return LoggerBadRequest(e, _logger);
            }
        }

        /// <summary>
        /// Atualiza um registro de pessoa
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductUpdateModel personUpdateModel)
        {
            if (!ModelState.IsValid)
                return NotFound("Modelo não é válido");

            try
            {
                var person = await _personRepository.GetProductByIdAsync(id);
                _mapper.Map(personUpdateModel, person);

                await _personRepository.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return LoggerBadRequest(e, _logger);
            }

            return NoContent();
        }

        /// <summary>
        /// Exclui um registro de pessoa
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var person = await _personRepository.GetProductByIdAsync(id);
                if (person == null)
                    return NotFound("Produto não encontrado");

                person.UpdatedAt = DateTimeOffset.UtcNow;
                person.IsDeleted = true;
                await _personRepository.SaveChangesAsync();

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
                var person = await _personRepository.ListAsync();
                var hasPerson = person.Any(x => x.Id == id);

                return hasPerson;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
    }
}
