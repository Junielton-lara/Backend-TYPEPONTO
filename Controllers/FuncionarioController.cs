using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_TYPEPONTO.Controllers
{
    [@ApiController]
    [Route("api/funcionario")]
    public class FuncionarioController : ControllerBase
    {
        //POST: api/funcionario/
        [HttpPost]
        [Route("create")]
        public Funcionario Create(Funcionario funcionario)
        {
            return funcionario;
        }
    }
}