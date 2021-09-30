using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TypePonto.Data;
using TypePonto.Models;

namespace TypePonto.Controllers
{
    [ApiController]
    [Route("api/funcionario")]
    public class FuncionarioController : ControllerBase
    {

        private readonly DataContext _context;

        public FuncionarioController(DataContext context)
        {
            _context = context;
        }

        //POST api/funcionario/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Funcionario funcionario)
        {
            funcionario.calculoData();
            _context.TabFuncionarios.Add(funcionario);
            _context.SaveChanges();
            return Created("", funcionario);
        }

        //GET api/funcionario/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() =>
            Ok(_context.TabFuncionarios.ToList());



        //GET api/funcionario/getbyid/1
        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            Funcionario funcionario = _context.TabFuncionarios.Find(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return Ok(funcionario);
        }

        //Delete api/funcionario/delete/Ademilson
        [HttpDelete]
        [Route("delete/{pis}")]
        public IActionResult DeleteByName([FromRoute] String pis)
        {
            Funcionario funcionario = _context.TabFuncionarios.FirstOrDefault(
                funcionario => funcionario.Pis == pis
            );
            if (funcionario == null)
            {
                return NotFound();
            }
            _context.TabFuncionarios.Remove(funcionario);
            _context.SaveChanges();
            return Ok(funcionario);
        }

        //Update api/funcionario/update
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] Funcionario funcionario)
        {
            _context.TabFuncionarios.Update(funcionario);
            _context.SaveChanges();
            return Ok(funcionario);
        }


    }
}