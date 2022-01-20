using AutoMapper;
using DAL.Conexion.Contratos;
using DAL.CRUD.Implementacion;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WbApiHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        #region Propiedades
        private readonly IUsuarioDAL _usuarioDAL;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public UsuarioController(
               IUsuarioDAL usuarioDAL,
               IMapper mapper
               )
        {
            _usuarioDAL = usuarioDAL;
            _mapper = mapper;

        }
        #endregion

        // GET: api/<UsuarioController>
       
        [HttpGet]
        public IActionResult Get()
        {
            List<UsuarioDto> lisUsuarioDto = new();
            var lisUsuarios = _usuarioDAL.GetAllUsuario();
            foreach (var item in lisUsuarios)
            {
                lisUsuarioDto.Add(_mapper.Map<UsuarioDto>(item));
            }
            return Ok(lisUsuarioDto) ;
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
