using Kolokwium2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicanController : ControllerBase
    {
        private readonly IAlbumDbService _service;

        public MusicanController(IAlbumDbService service)
        {
            _service = service;
        }

        [HttpDelete("{musicanId}")]
        public async Task<IActionResult> GetAlbum(int musicanId)
        {

            if (await _service.CheckMusicanForDeletion(musicanId))
            {
                await _service.DeleteMusican(musicanId);
                return Ok();
            }
            else
            {
                return Conflict();
            }
            
        }

    }
}
