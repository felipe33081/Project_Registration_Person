using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Registration.Data.Contracts;
using Registration.Model;
using Registration.Model.Provider;
using Registration.WebApi.Controllers.Core;
using Registration.WebApi.Models.Create.Provider;
using Registration.WebApi.Models.Read.Provider;
using Registration.WebApi.Models.Update.Provider;

namespace Registration.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ProviderController : CoreController
    {
        readonly IProviderRepository _providerRepository;
        readonly IMapper _mapper;
        readonly ILogger<ProviderController> _logger;

        public ProviderController(
            IProviderRepository providerRepository,
            IMapper mapper,
            ILogger<ProviderController> logger)
        {
            _providerRepository = providerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Lista todos os fornecedores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<ProviderReadModel>>> ProviderListAsync()
        {
            try
            {
                var providers = await _providerRepository.GetProviders();

                return Ok(providers);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Acessa um registro de fornecedor por Id(Código)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProviderReadModel), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var provider = await _providerRepository.GetProviderByIdAsync(id);
                if (provider == null)
                    return NotFound("Produto não encontrado");

                var readProvider = _mapper.Map<ProviderReadModel>(provider);

                return Ok(readProvider);
            }
            catch (Exception e)
            {
                return LoggerBadRequest(e, _logger);
            }
        }

        /// <summary>
        /// Cria um novo registro de um fornecedor
        /// </summary>
        /// <param name="providerCreateModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        public async Task<IActionResult> Create([FromBody] ProviderCreateModel providerCreateModel)
        {
            if (!ModelState.IsValid)
                return NotFound("Modelo não é válido");

            try
            {
                var provider = _mapper.Map<Provider>(providerCreateModel);
                await _providerRepository.AddProviderAsync(provider);

                return Ok(provider.Id);
            }
            catch (Exception e)
            {
                return LoggerBadRequest(e, _logger);
            }
        }

        /// <summary>
        /// Atualiza um registro de um fornecedor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="providerUpdateModel"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProviderUpdateModel providerUpdateModel)
        {
            if (!ModelState.IsValid)
                return NotFound("Modelo não é válido");

            try
            {
                var provider = await _providerRepository.GetProviderByIdAsync(id);
                _mapper.Map(providerUpdateModel, provider);

                await _providerRepository.SaveChangesAsync();
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
                var provider = await _providerRepository.GetProviderByIdAsync(id);
                if (provider == null)
                    return NotFound("Produto não encontrado");

                await _providerRepository.DeleteAsync(provider);

                return NoContent();
            }
            catch (Exception e)
            {
                return LoggerBadRequest(e, _logger);
            }
        }
    }
}
