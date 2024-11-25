using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using FluentValidation.Results;
using OrganizaMED.Dominio.ModuloMedico;

namespace OrganizaMED.Aplicacao.ModuloMedico
{
    public class ServiceMedico
    {
        private readonly IRepositorioMedico _repositorioMedico;

        public ServiceMedico(IRepositorioMedico repositorioMedico)
        {
            _repositorioMedico = repositorioMedico;
        }

        public async Task<Result<Medico>> InserirAsync(Medico Medico)
        {
            var validador = new ValidatorMedico();


            ValidationResult resultadoValidacao = await validador.ValidateAsync(Medico);

            if (!resultadoValidacao.IsValid)
            {
                var erros = resultadoValidacao.Errors.Select(failure => failure.ErrorMessage).ToList();
                return Result.Fail(erros);
            }

            await _repositorioMedico.InserirAsync(Medico);

            return Result.Ok(Medico);
        }

        public async Task<Result<Medico>> EditarAsync(Medico Medico)
        {
            var validador = new ValidatorMedico();


            ValidationResult resultadoValidacao = await validador.ValidateAsync(Medico);

            if (!resultadoValidacao.IsValid)
            {
                var erros = resultadoValidacao.Errors.Select(failure => failure.ErrorMessage).ToList();
                return Result.Fail(erros);
            }

            _repositorioMedico.Editar(Medico);

            return Result.Ok(Medico);
        }

        public async Task<Result> ExcluirAsync(Guid id)
        {
            var Medico = await _repositorioMedico.SelecionarPorIdAsync(id);

            if (Medico == null)
                return Result.Fail($"Medico {id} não encontrada");

            _repositorioMedico.Excluir(Medico);

            return Result.Ok();
        }

        public async Task<Result<List<Medico>>> SelecionarTodosAsync()
        {

            var categorias = await _repositorioMedico.SelecionarTodosAsync();

            return Result.Ok(categorias);
        }

        public async Task<Result<Medico>> SelecionarPorIdAsync(Guid id)
        {
            var Medico = await _repositorioMedico.SelecionarPorIdAsync(id);

            return Result.Ok(Medico);
        }
    }
}
