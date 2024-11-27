using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganizaMED.Aplicacao.ModuloMedico;
using OrganizaMED.Dominio.ModuloMedico;
using OrganizaMEDServer.Views;
using Serilog;

namespace OrganizaMEDServer.Controllers
{
    [Route("api/medicos")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly ServiceMedico servicoMedico;
        private readonly IMapper mapeador;


        public MedicoController(ServiceMedico servicoMedico, IMapper mapeador)
        {
            this.servicoMedico = servicoMedico;
            this.mapeador = mapeador;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resultado = await servicoMedico.SelecionarTodosAsync();

            if (resultado.IsFailed)
                return StatusCode(500);

            var viewModel = mapeador.Map<ListarMedicoViewModel[]>(resultado.Value);

            Log.Information("Foram selecionados {QuantidadeRegistros}", viewModel.Count());

            return Ok(resultado.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var MedicoResult = await servicoMedico.SelecionarPorIdAsync(id);

            if (MedicoResult.IsFailed)
            {
                return StatusCode(500);
            }

            if (MedicoResult.IsSuccess && MedicoResult.Value is null)
            {
                return NotFound(MedicoResult.Errors);
            }

            var viewModel = mapeador.Map<VisualizarMedicoViewModel>(MedicoResult.Value);

            return Ok(viewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Post(InserirMedicoViewModel MedicoVm)
        {
            var Medico = mapeador.Map<Medico>(MedicoVm);

            var resultado = await servicoMedico.InserirAsync(Medico);

            if (resultado.IsFailed)
                return BadRequest(resultado.Errors);

            return Ok(MedicoVm);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, EditarMedicoViewModel MedicoVm)
        {
            var selecaoMedicosOriginal = await servicoMedico.SelecionarPorIdAsync(id);

            if (selecaoMedicosOriginal.IsFailed)
            {
                return NotFound(selecaoMedicosOriginal.Errors);
            }

            var MedicoEditada = mapeador.Map(MedicoVm, selecaoMedicosOriginal.Value);

            var edicaoResult = await servicoMedico.EditarAsync(MedicoEditada);
            if (edicaoResult.IsFailed)
            {
                return BadRequest(edicaoResult.Errors);
            }

            return Ok(edicaoResult.Value);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var MedicoResult = await servicoMedico.ExcluirAsync(id);

            if (MedicoResult.IsFailed)
            {
                return NotFound(MedicoResult.Errors);
            }

            return Ok();

        }




    }
}