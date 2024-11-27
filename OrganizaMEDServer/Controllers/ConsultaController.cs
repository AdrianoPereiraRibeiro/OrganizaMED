using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganizaMED.Aplicacao.ModuloConsulta;
using OrganizaMED.Aplicacao.ModuloConsulta;
using OrganizaMED.Dominio.ModuloConsulta;
using OrganizaMED.Dominio.ModuloConsulta;
using OrganizaMEDServer.Views;
using Serilog;

namespace OrganizaMEDServer.Controllers
{
    [Route("api/consultas")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly ServiceConsulta servicoConsulta;
        private readonly IMapper mapeador;


        public ConsultaController(ServiceConsulta servicoConsulta, IMapper mapeador)
        {
            this.servicoConsulta = servicoConsulta;
            this.mapeador = mapeador;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resultado = await servicoConsulta.SelecionarTodosAsync();

            if (resultado.IsFailed)
                return StatusCode(500);

            var viewModel = mapeador.Map<ListarConsultaViewModel[]>(resultado.Value);

            Log.Information("Foram selecionados {QuantidadeRegistros}", viewModel.Count());

            return Ok(resultado.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ConsultaResult = await servicoConsulta.SelecionarPorIdAsync(id);

            if (ConsultaResult.IsFailed)
            {
                return StatusCode(500);
            }

            if (ConsultaResult.IsSuccess && ConsultaResult.Value is null)
            {
                return NotFound(ConsultaResult.Errors);
            }

            var viewModel = mapeador.Map<VisualizarConsultaViewModel>(ConsultaResult.Value);

            return Ok(viewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Post(InserirConsultaViewModel ConsultaVm)
        {
            var Consulta = mapeador.Map<Consulta>(ConsultaVm);

            var resultado = await servicoConsulta.InserirAsync(Consulta);

            if (resultado.IsFailed)
                return BadRequest(resultado.Errors);

            return Ok(ConsultaVm);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, EditarConsultaViewModel ConsultaVm)
        {
            var selecaoConsultasOriginal = await servicoConsulta.SelecionarPorIdAsync(id);

            if (selecaoConsultasOriginal.IsFailed)
            {
                return NotFound(selecaoConsultasOriginal.Errors);
            }

            var ConsultaEditada = mapeador.Map(ConsultaVm, selecaoConsultasOriginal.Value);

            var edicaoResult = await servicoConsulta.EditarAsync(ConsultaEditada);
            if (edicaoResult.IsFailed)
            {
                return BadRequest(edicaoResult.Errors);
            }

            return Ok(edicaoResult.Value);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ConsultaResult = await servicoConsulta.ExcluirAsync(id);

            if (ConsultaResult.IsFailed)
            {
                return NotFound(ConsultaResult.Errors);
            }

            return Ok();

        }




    }
}