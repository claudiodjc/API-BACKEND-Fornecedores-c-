using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Bll;
using Presentation.Dto;
using Presentation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private FornecedorBll _fornecedorBll;

        public FornecedorController(FornecedorBll fornecedorBll)
        {
            _fornecedorBll = fornecedorBll;
        }

        [HttpGet]
        public IActionResult ListaFornecedores([FromHeader] string nome, [FromHeader] string razaoSocial, [FromHeader] string cnpj, [FromHeader] string segmento, [FromHeader] string endereco, [FromHeader] string telefone, [FromHeader] string email)
        {
            var validate = _fornecedorBll.ListaFornecedores( nome,  razaoSocial,  cnpj,  segmento,  endereco,  telefone,  email);
            switch (validate.Keys.GetCode())
            {
                case 400:
                    return BadRequest(new
                    {
                        status = "BadRequest",
                        message = validate.Values.GetFirstValue()
                    });
                case 401:
                    return Unauthorized(new
                    {
                        status = "Unauthorized",
                        message = validate.Values.GetFirstValue()
                    });
                default:
                    return Ok(new
                    {
                        status = "Success",
                        message = validate.Values.GetFirstValue()
                    });

            }
        }

        [HttpGet("{fornecedorId}")]
        public IActionResult BuscaFornecedor(string fornecedorId)
        {
            var validate = _fornecedorBll.BuscaFornecedor(fornecedorId);
            switch (validate.Keys.GetCode())
            {
                case 400:
                    return BadRequest(new
                    {
                        status = "BadRequest",
                        message = validate.Values.GetFirstValue()
                    });
                case 401:
                    return Unauthorized(new
                    {
                        status = "Unauthorized",
                        message = validate.Values.GetFirstValue()
                    });
                default:
                    return Ok(new
                    {
                        status = "Success",
                        message = validate.Values.GetFirstValue()
                    });

            }
        }

        [HttpPost]
        public IActionResult CriarFornecedor([FromBody] RequestFornecedorDto value)
        {
            var validate = _fornecedorBll.CriarFornecedor(value);
            switch (validate.Keys.GetCode())
            {
                case 400:
                    return BadRequest(new
                    {
                        status = "BadRequest",
                        message = validate.Values.GetFirstValue()
                    });
                case 401:
                    return Unauthorized(new
                    {
                        status = "Unauthorized",
                        message = validate.Values.GetFirstValue()
                    });
                default:
                    return Ok(new
                    {
                        status = "Success",
                        message = validate.Values.GetFirstValue()
                    });

            }
        }

        [HttpPut("{fornecedorId}")]
        public IActionResult AtualizarFornecedor(string fornecedorId, [FromBody] RequestFornecedorDto value)
        {
            var validate = _fornecedorBll.AtualizarFornecedor(fornecedorId, value);
            switch (validate.Keys.GetCode())
            {
                case 400:
                    return BadRequest(new
                    {
                        status = "BadRequest",
                        message = validate.Values.GetFirstValue()
                    });
                case 401:
                    return Unauthorized(new
                    {
                        status = "Unauthorized",
                        message = validate.Values.GetFirstValue()
                    });
                default:
                    return Ok(new
                    {
                        status = "Success",
                        message = validate.Values.GetFirstValue()
                    });

            }
        }

        [HttpDelete("{fornecedorId}")]
        public IActionResult DesabilitarFornecedor(string fornecedorId)
        {
            var validate = _fornecedorBll.DesabilitarFornecedor(fornecedorId);
            switch (validate.Keys.GetCode())
            {
                case 400:
                    return BadRequest(new
                    {
                        status = "BadRequest",
                        message = validate.Values.GetFirstValue()
                    });
                case 401:
                    return Unauthorized(new
                    {
                        status = "Unauthorized",
                        message = validate.Values.GetFirstValue()
                    });
                default:
                    return Ok(new
                    {
                        status = "Success",
                        message = validate.Values.GetFirstValue()
                    });

            }
        }
    }
}
