using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Persistence;

namespace Application
{

    public class FaturamentoService
    {
        private readonly GeralPersistence _geralPersistence;
        private readonly FaturamentoPersistence _faturamentoPersistence;

        public FaturamentoService(GeralPersistence geralPersistence,
                                      FaturamentoPersistence faturamentoPersistence)
        {
            _geralPersistence = geralPersistence;
            _faturamentoPersistence = faturamentoPersistence;
        }

        public async Task<Faturamento[]> GetFaturaByConcessionariaIdAsync(int idConcessionaria)
        {
            try
            {
                var faturas = await _faturamentoPersistence.GetFaturaByConcessionariaIdAsync(idConcessionaria);
                return faturas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Faturamento?> GetFaturaByConcIdYearMonthAsync(int idConcessionaria, int ano, int mes)
        {
            try
            {
                var fatura = await _faturamentoPersistence.GetFaturaByConcIdYearMonthAsync(idConcessionaria, ano, mes);
                return fatura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Faturamento?> AddFatura(int idConcessionaria, double valorFatura)
        {
            try
            {
                Faturamento? model = CreateModel(idConcessionaria, valorFatura);
                if (model == null) throw new Exception("Não foi possivel criar o modelo");

                _geralPersistence.Add<Faturamento>(model);

                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _faturamentoPersistence.GetFaturaByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateFatura(int idConcessionaria, int valor)
        {
            try
            {
                var faturamento = await _faturamentoPersistence
                        .GetFaturaByConcIdYearMonthAsync((int)idConcessionaria, DateTime.Now.Year, DateTime.Now.Month);
                if (faturamento == null) throw new Exception("Concessionária inválida");

                _geralPersistence.Update<Faturamento>(faturamento);

                return await _geralPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Faturamento? CreateModel(int idConcessionaria, double valorFatura)
        {
            try
            {
                Faturamento model = new();

                model.DataFatura = DateTime.Now;
                model.ValorFatura = valorFatura;
                model.ConcessionariaId = idConcessionaria;
                model.MontadoraId = 1;

                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}