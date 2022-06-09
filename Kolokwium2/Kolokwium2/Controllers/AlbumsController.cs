using Kolokwium2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumDbService _service;

        public AlbumsController(IAlbumDbService service)
        {
            _service = service;
        }

        [HttpGet("{albumId}")]
        public async Task<IActionResult> GetAlbum(int albumId)
        {
            var a = _service.GetAlbum(albumId);
            var b = await a.FirstOrDefaultAsync();
            if (b == null)
            {
                return NotFound();
            }
            return Ok(b);
        }
    }
}
