﻿using FluentResults;
using OrganizaMED.Dominio.ModuloMedico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using OrganizaMED.Dominio.ModuloConsulta;

namespace OrganizaMED.Aplicacao.ModuloConsulta
{
    public class ServiceConsulta
    {
        private readonly IRepositorioConsulta _repositorioConsulta;
        private readonly IRepositorioMedico _repositorioMedico;

        public ServiceConsulta(IRepositorioConsulta repositorioConsulta,IRepositorioMedico repositorioMedico)
        {
            _repositorioConsulta = repositorioConsulta;
            _repositorioMedico = repositorioMedico;
        }

        public async Task<Result<Consulta>> InserirAsync(Consulta Consulta)
        {
            
            Consulta.Medico = _repositorioMedico.SelecionarPorId(Consulta.MedicoId);
            Consulta.AtualizarTermino();
            var validador = new ValidatorConsulta();


            ValidationResult resultadoValidacao = await validador.ValidateAsync(Consulta);

            if (!resultadoValidacao.IsValid)
            {
                var erros = resultadoValidacao.Errors.Select(failure => failure.ErrorMessage).ToList();
                return Result.Fail(erros);
            }
            Consulta.Medico.Agenda.Add(Consulta.DataDeInicio);
            _repositorioMedico.Editar(Consulta.Medico);
            


            await _repositorioConsulta.InserirAsync(Consulta);

            return Result.Ok(Consulta);
        }

        public async Task<Result<Consulta>> EditarAsync(Consulta Consulta)
        {
            var validador = new ValidatorConsulta();


            ValidationResult resultadoValidacao = await validador.ValidateAsync(Consulta);

            if (!resultadoValidacao.IsValid)
            {
                var erros = resultadoValidacao.Errors.Select(failure => failure.ErrorMessage).ToList();
                return Result.Fail(erros);
            }
            Consulta.Medico.Agenda.Add(Consulta.DataDeInicio);
            _repositorioMedico.Editar(Consulta.Medico);
            _repositorioConsulta.Editar(Consulta);

            return Result.Ok(Consulta);
        }

        public async Task<Result> ExcluirAsync(Guid id)
        {
            var Consulta = await _repositorioConsulta.SelecionarPorIdAsync(id);

            if (Consulta == null)
                return Result.Fail($"Consulta {id} não encontrada");

            _repositorioConsulta.Excluir(Consulta);

            return Result.Ok();
        }

        public async Task<Result<List<Consulta>>> SelecionarTodosAsync()
        {

            var categorias = await _repositorioConsulta.SelecionarTodosAsync();

            return Result.Ok(categorias);
        }

        public async Task<Result<Consulta>> SelecionarPorIdAsync(Guid id)
        {
            var Consulta = await _repositorioConsulta.SelecionarPorIdAsync(id);

            return Result.Ok(Consulta);
        }
    }
}
