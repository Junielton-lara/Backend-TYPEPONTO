using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TypePonto.Data;
using TypePonto.Models;

namespace TypePonto.Controllers
{
    [ApiController]
    [Route("api/marcacao")]
    public class MarcacaoController : ControllerBase
    {
        private readonly DataContext _context;

        public MarcacaoController(DataContext context)
        {
            _context = context;
        }

        // POST api/marcacao/create
        [HttpPost]
        [Route("create")]

        public IActionResult Create([FromBody] Marcacao marcacao)
        {
            var fun = _context.TabFuncionarios.FirstOrDefault(
                f => f.Id == marcacao.FuncionarioId

            );
            marcacao.calculo();
            _context.TabMarcacoes.Add(marcacao);
            _context.SaveChanges();


            return Created("", marcacao);
        }

        [HttpGet]
        [Route("list")]
        public IActionResult List() => Ok(_context.TabMarcacoes.Include(f => f.funcionario).ToList());

        [HttpGet]
        [Route("list/{id}")]

        public IActionResult GetById([FromRoute] int id)
        {
            Marcacao marcacao = _context.TabMarcacoes.Find(id);

            if (marcacao == null)
            {
                return NotFound();
            }

            return Ok(marcacao);
        }

        [HttpDelete]
        [Route("delete/{id}")]

        public IActionResult DeleteById([FromRoute] int id)
        {
            Marcacao marcacao = _context.TabMarcacoes.FirstOrDefault(
                marcacao => marcacao.Id == id
            );
            if (marcacao == null)
            {
                return NotFound();
            }
            _context.TabMarcacoes.Remove(marcacao);
            _context.SaveChanges();
            return Ok(marcacao);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] Marcacao marcacao)
        {
            marcacao.calculo();
            _context.TabMarcacoes.Update(marcacao);
            _context.SaveChanges();
            return Ok(marcacao);
        }
    }
}