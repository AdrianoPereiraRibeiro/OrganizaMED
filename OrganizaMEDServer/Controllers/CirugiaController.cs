using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganizaMED.Aplicacao.ModuloCirugia;
using OrganizaMED.Aplicacao.ModuloCirugia;
using OrganizaMED.Aplicacao.ModuloMedico;
using OrganizaMED.Dominio.ModuloCirugia;
using OrganizaMED.Dominio.ModuloMedico;
using OrganizaMEDServer.Views;
using Serilog;

namespace OrganizaMEDServer.Controllers
{
    [Route("api/cirugias")]
    [ApiController]
    public class CirugiaController : ControllerBase
    {
        private readonly ServiceCirugia servicoCirugia;
        private readonly ServiceMedico serviceMedico;
        private readonly IMapper mapeador;


        public CirugiaController(ServiceCirugia servicoCirugia, IMapper mapeador,ServiceMedico serviceMedico)
        {
            this.servicoCirugia = servicoCirugia;
            this.mapeador = mapeador;
            this.serviceMedico = serviceMedico;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resultado = await servicoCirugia.SelecionarTodosAsync();

            if (resultado.IsFailed)
                return StatusCode(500);

            var viewModel = mapeador.Map<ListarCirugiaViewModel[]>(resultado.Value);

            Log.Information("Foram selecionados {QuantidadeRegistros}", viewModel.Count());

            return Ok(resultado.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var CirugiaResult = await servicoCirugia.SelecionarPorIdAsync(id);

            if (CirugiaResult.IsFailed)
            {
                return StatusCode(500);
            }

            if (CirugiaResult.IsSuccess && CirugiaResult.Value is null)
            {
                return NotFound(CirugiaResult.Errors);
            }

            var viewModel = mapeador.Map<VisualizarCirugiaViewModel>(CirugiaResult.Value);

            return Ok(viewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Post(InserirCirugiaViewModel CirugiaVm)
        {
            var Cirugia = mapeador.Map<Cirugia>(CirugiaVm);
            Cirugia.atualizarTermino();
            Cirugia.prencherMedicos(CirugiaVm.MedicosIds,serviceMedico.SelecionarTodosAsync().Result.Value);
            var resultado = await servicoCirugia.InserirAsync(Cirugia);

            if (resultado.IsFailed)
                return BadRequest(resultado.Errors);

            return Ok(CirugiaVm);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, EditarCirugiaViewModel CirugiaVm)
        {
            var selecaoCirugiasOriginal = await servicoCirugia.SelecionarPorIdAsync(id);
            selecaoCirugiasOriginal.Value.Medicos = new List<Medico>();
            if (selecaoCirugiasOriginal.IsFailed)
            {
                return NotFound(selecaoCirugiasOriginal.Errors);
            }

            var CirugiaEditada = mapeador.Map(CirugiaVm, selecaoCirugiasOriginal.Value);
            CirugiaEditada.atualizarTermino();
            CirugiaEditada.prencherMedicos(CirugiaVm.MedicosIds, serviceMedico.SelecionarTodosAsync().Result.Value);
            var edicaoResult = await servicoCirugia.EditarAsync(CirugiaEditada);
            if (edicaoResult.IsFailed)
            {
                return BadRequest(edicaoResult.Errors);
            }

            return Ok(edicaoResult.Value);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var CirugiaResult = await servicoCirugia.ExcluirAsync(id);

            if (CirugiaResult.IsFailed)
            {
                return NotFound(CirugiaResult.Errors);
            }

            return Ok();

        }




    }
}