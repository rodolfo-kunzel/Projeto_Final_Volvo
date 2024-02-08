using Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

                if (faturas == null || faturas.Length == 0) {
                    throw new ClientesNaoEncontradosException(Mensagens.listaClientesVazia);
                }

                return faturas;
            }
            catch (SqlException)
            {
                throw new AcessoDeDadosException(Mensagens.erroDados);
            }
            catch (DbUpdateException)
            {
                throw new AcessoDeDadosException(Mensagens.erroDados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Faturamento> GetFaturaByConcIdYearMonthAsync(int idConcessionaria, int ano, int mes)
        {
            try
            {
                var fatura = await _faturamentoPersistence.GetFaturaByConcIdYearMonthAsync(idConcessionaria, ano, mes)??
                throw new FaturamentoNuloException(Mensagens.faturamentoNulo);

                return fatura;
            }
            catch (SqlException)
            {
                throw new AcessoDeDadosException(Mensagens.erroDados);
            }
            catch (DbUpdateException)
            {
                throw new AcessoDeDadosException(Mensagens.erroDados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Faturamento> AddFatura(int idConcessionaria, double valorFatura)
        {
            try
            {
                Faturamento? model = CreateModel(idConcessionaria, valorFatura) ??
                throw new FaturamentoGerarModeloException(Mensagens.erroModelo);

                _geralPersistence.Add<Faturamento>(model);

                var salvo = await _geralPersistence.SaveChangesAsync();

                if (!salvo)
                {
                    throw new FaturamentoNaoSalvoException(Mensagens.erroAoSalvarFaturamento);
                }

                var faturamento = await _faturamentoPersistence.GetFaturaByIdAsync(model.Id)??
                throw new FaturamentoNuloException(Mensagens.faturamentoNulo);

                return faturamento;

            }
            catch (SqlException)
            {
                throw new AcessoDeDadosException(Mensagens.erroDados);
            }
            catch (DbUpdateException)
            {
                throw new AcessoDeDadosException(Mensagens.erroDados);
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
                        .GetFaturaByConcIdYearMonthAsync(idConcessionaria, DateTime.Now.Year, DateTime.Now.Month)??
                throw new FaturamentoInvalidoException(Mensagens.faturamentoIdInvalido);

                _geralPersistence.Update<Faturamento>(faturamento);

                var salvo = await _geralPersistence.SaveChangesAsync();

                if (!salvo)
                {
                    throw new FaturamentoNaoSalvoException(Mensagens.erroAoSalvarFaturamento);
                }

                return salvo;
            }
            catch (SqlException)
            {
                throw new AcessoDeDadosException(Mensagens.erroDados);
            }
            catch (DbUpdateException)
            {
                throw new AcessoDeDadosException(Mensagens.erroDados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Faturamento CreateModel(int idConcessionaria, double valorFatura)
        {
            try
            {
                Faturamento model = new()
                {
                    DataFatura = DateTime.Now,
                    ValorFatura = valorFatura,
                    ConcessionariaId = idConcessionaria,
                    MontadoraId = 1
                };

                return model;
            }
            catch (SqlException)
            {
                throw new AcessoDeDadosException(Mensagens.erroDados);
            }
            catch (DbUpdateException)
            {
                throw new AcessoDeDadosException(Mensagens.erroDados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}