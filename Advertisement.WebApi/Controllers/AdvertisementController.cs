using System;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Advertisements.Application.Advertisements.Queries.GetAdvertisementList;
using Advertisements.Application.Advertisements.Queries.GetAdvertisementDetails;
using Advertisements.Application.Advertisements.Commands.CreateAdvertisement;
using Advertisements.Application.Advertisements.Commands.UpdateAdvertisement;
using Advertisements.Application.Advertisements.Commands.DeleteCommand;
using Advertisement.WebApi.Models;
using System.Linq;

namespace Advertisement.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AdvertisementController : BaseController
    {
        private readonly IMapper _mapper;

        public AdvertisementController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of advertisements
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /advertisement
        /// </remarks>
        /// <returns>Returns AdvertisementListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        public async Task<ActionResult<AdvertisementListVm>> GetAll(string? text, int? number, int page = 1)
        {
            int pageSize = 4;
            var query = new GetAdvertisementListQuery
            {
                UserId = UserId
            };

            var vm = await Mediator.Send(query);

            if (!String.IsNullOrEmpty(text))
            {
                return Ok(vm.Advertisements
                    .Where(advertisement => advertisement.Text.ToUpper().Contains(text.ToUpper()))
                    .OrderBy(advertisement => advertisement.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize));
            }

            else if(number == null)
            {
                return Ok(vm.Advertisements
                    .OrderBy(advertisement => advertisement.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize));
            }
            else
            {
                return Ok(vm.Advertisements
                    .Where(advertisement => advertisement.Number == number)
                    .OrderBy(advertisement => advertisement.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize));
            }
        }

        /// <summary>
        /// Gets the advertisement by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /advertisement/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id">Advertisements id (guid)</param>
        /// <returns>Returns AdvertisementsDetailVm</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<AdvertisementDetailVm>> Get(Guid id)
        {
            var query = new GetAdvertisementDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the advertisement
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /advertisement
        /// {
        ///     text: "advertisement title",
        ///     image: "advertisements image"
        /// }
        /// </remarks>
        /// <param name="createAdvertisementDto"> CreateAdvertisementsDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAdvertisementDto createAdvertisementDto)
        {
            var command = _mapper.Map<CreateAdvertisementCommand>(createAdvertisementDto);
            command.UserId = UserId;
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        /// <summary>
        /// Updates the advertisement
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /advertisement
        /// {
        ///     text: "updated advertisement title"
        /// }
        /// </remarks>
        /// <param name="updateAdvertisementDto">UpdateAdvertisementDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAdvertisementDto updateAdvertisementDto)
        {
            var command = _mapper.Map<UpdateAdvertisementCommand>(updateAdvertisementDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the advertisement by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /advertisement/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the advertisement (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteAdvertisementCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}

