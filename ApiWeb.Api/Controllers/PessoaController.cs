using System.Net;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

using Azure;
using ApiWeb.Application.AppService.Interface;
using Swashbuckle.AspNetCore.Annotations;
using ApiWeb.Domain.Entidades;

namespace ApiBase.Api.Controllers;


[Route("[controller]")]
public class PessoaController : Controller
{
    private readonly IPessoaAppService _pessoaAppService;

    public PessoaController(IPessoaAppService pessoaAppServic)
    {
        _pessoaAppService = pessoaAppServic;
    }

    [HttpPost("criar"), AllowAnonymous]
    [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(Response<Pessoa>))]
    [SwaggerOperation(Summary = "Criar pessoa")]
    public async Task<IActionResult> Criar([FromBody] Pessoa request)
    {
        Pessoa pessoa = await _pessoaAppService.Criar(request);
        return Ok(pessoa);
    }
}
