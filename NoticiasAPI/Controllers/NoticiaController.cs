using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoticiasAPI.Models;
using NoticiasAPI.Services;

namespace NoticiasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private readonly NoticiaServices _noticiaServices;
        public NoticiaController(NoticiaServices noticiaServices)
        {
            _noticiaServices = noticiaServices;
        }

        [HttpGet]
        [Route("obtener")]
        public IActionResult ObtenerNoticia()
        {
            var resultado = _noticiaServices.ObtenerNoticia();
            return Ok(resultado);
        }

        [HttpPost]
        [Route("agregar")]
        public IActionResult AgregarNoticia([FromBody] Noticia _noticia)
        {
            var resultado = _noticiaServices.AgregarNoticia(_noticia);
            if (resultado)
            {
                return Ok();
            } else
            {
                return BadRequest();
            }
           
        }


        [HttpPut]
        [Route("editar")]
        public IActionResult EditarNoticia([FromBody] Noticia _noticia)
        {
            var resultado = _noticiaServices.EditarNoticia(_noticia);
            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("eliminar/{noticiaID}")]
        public IActionResult EliminarNoticia(int noticiaID)
        {
            var resultado = _noticiaServices.EliminarNoticia(noticiaID);
            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("listadoAutores")]
        public IActionResult listadoAutores()
        {
            return Ok(_noticiaServices.listadoAutor());
        }

    }
}