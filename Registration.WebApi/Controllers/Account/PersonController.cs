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
    public class PersonController : CoreController
    {
        readonly IPersonRepository _personRepository;
        readonly IMapper _mapper;
        readonly ILogger<PersonController> _logger;

        public PersonController(
            IPersonRepository personRepository,
            IMapper mapper,
            ILogger<PersonController> logger)
        {
            _personRepository = personRepository;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Lista todas as pessoas inseridas anteriormente
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ListDataPagination<PersonReadModel>), 200)]
        public async Task<IActionResult> PersonListAsync([FromQuery] int page = 0, [FromQuery] int size = 15,
            [FromQuery] string? searchString = null,
            [FromQuery] DateTimeOffset? initialDate = null, [FromQuery] DateTimeOffset? finalDate = null,
            [FromQuery] string? orderBy = null)
        {
            try
            {
                ListDataPagination<Person> listData = await _personRepository.ListPersonAsync(searchString, page, size, initialDate, finalDate, orderBy);

                var newData = new ListDataPagination<PersonReadModel>()
                {
                    Data = listData.Data.Select(c => _mapper.Map<PersonReadModel>(c)).ToList(),
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
        [ProducesResponseType(typeof(PersonReadModel), 200)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var person = await _personRepository.GetPersonByIdAsync(id);
                if (person == null)
                    return NotFound("Pessoa não encontrada");

                var readPerson = _mapper.Map<PersonReadModel>(person);

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
        [ValidateAntiForgeryToken]
        [ProducesResponseType(typeof(Guid), 200)]
        public async Task<IActionResult> Create([FromBody] PersonCreateModel personCreateModel)
        {
            if (!ModelState.IsValid)
                return NotFound("Modelo não é válido");

            try
            {
                var person = _mapper.Map<Person>(personCreateModel);
                await _personRepository.AddPersonAsync(person);
                
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Guid id, [FromBody] PersonUpdateModel personUpdateModel)
        {
            if (!ModelState.IsValid)
                return NotFound("Modelo não é válido");

            try
            {
                var person = await _personRepository.GetPersonByIdAsync(id);
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var person = await _personRepository.GetPersonByIdAsync(id);
                if (person == null)
                    return NotFound("Pessoa não encontrada");

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

        private async Task<bool> PersonExists(Guid id)
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
