using FluentResults;
using OrganizaMED.Dominio.ModuloMedico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using OrganizaMED.Dominio.ModuloCirugia;

namespace OrganizaMED.Aplicacao.ModuloCirugia
{
    public class ServiceCirugia
    {
        private readonly IRepositorioCirugia _repositorioCirugia;

        public ServiceCirugia(IRepositorioCirugia repositorioCirugia)
        {
            _repositorioCirugia = repositorioCirugia;
        }

        public async Task<Result<Cirugia>> InserirAsync(Cirugia Cirugia)
        {
            var validador = new ValidatorCirugia();


            ValidationResult resultadoValidacao = await validador.ValidateAsync(Cirugia);

            if (!resultadoValidacao.IsValid)
            {
                var erros = resultadoValidacao.Errors.Select(failure => failure.ErrorMessage).ToList();
                return Result.Fail(erros);
            }

            await _repositorioCirugia.InserirAsync(Cirugia);

            return Result.Ok(Cirugia);
        }

        public async Task<Result<Cirugia>> EditarAsync(Cirugia Cirugia)
        {
            var validador = new ValidatorCirugia();


            ValidationResult resultadoValidacao = await validador.ValidateAsync(Cirugia);

            if (!resultadoValidacao.IsValid)
            {
                var erros = resultadoValidacao.Errors.Select(failure => failure.ErrorMessage).ToList();
                return Result.Fail(erros);
            }

            _repositorioCirugia.Editar(Cirugia);

            return Result.Ok(Cirugia);
        }

        public async Task<Result> ExcluirAsync(Guid id)
        {
            var Cirugia = await _repositorioCirugia.SelecionarPorIdAsync(id);

            if (Cirugia == null)
                return Result.Fail($"Cirugia {id} não encontrada");

            _repositorioCirugia.Excluir(Cirugia);

            return Result.Ok();
        }

        public async Task<Result<List<Cirugia>>> SelecionarTodosAsync()
        {

            var categorias = await _repositorioCirugia.SelecionarTodosAsync();

            return Result.Ok(categorias);
        }

        public async Task<Result<Cirugia>> SelecionarPorIdAsync(Guid id)
        {
            var Cirugia = await _repositorioCirugia.SelecionarPorIdAsync(id);

            return Result.Ok(Cirugia);
        }
    }
}
