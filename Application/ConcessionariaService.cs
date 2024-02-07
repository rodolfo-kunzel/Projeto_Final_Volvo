using Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application
{

    public class ConcessionariaService
    {
        private readonly GeralPersistence _geralPersistence;
        private readonly ConcessionariaPersistence _concessionariaPersistence;

        public ConcessionariaService(GeralPersistence geralPersistence,
                                      ConcessionariaPersistence concessionariaPersistence)
        {
            _geralPersistence = geralPersistence;
            _concessionariaPersistence = concessionariaPersistence;
        }

        public async Task<Concessionaria[]> GetAllConcessionariasAsync()
        {
            try
            {
                var concessionarias = await _concessionariaPersistence.GetAllConcessionariasAsync();

                if (concessionarias == null || concessionarias.Length == 0) {
                    throw new ConcessionariasNaoEncontradasException(Messages.listaConcessionariasVazia);
                }
                
                return concessionarias;
            }
            catch (SqlException)
            {
                throw new AcessoDeDadosException(Messages.erroDados);
            }
            catch (DbUpdateException)
            {
                throw new AcessoDeDadosException(Messages.erroDados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Concessionaria> GetConcessionariaByIdAsync(int Id)
        {
            try
            {
                var concessionaria = await _concessionariaPersistence.GetConcessionariaByIdAsync(Id)??
                throw new ConcessionariaNuloException(Messages.concessionariaNula);

                return concessionaria;
            }
            catch (SqlException)
            {
                throw new AcessoDeDadosException(Messages.erroDados);
            }
            catch (DbUpdateException)
            {
                throw new AcessoDeDadosException(Messages.erroDados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // public async Task<double?> GetFaturamentoConcessionariaAsync(int Id)
        // {
        //     try
        //     {
        //         var concessionaria = await _concessionariaPersistence.GetConcessionariaByIdAsync(Id);

        //         double faturamento = 0;
                
        //         if (concessionaria == null) throw new Exception();
                
        //         if (!concessionaria.Caminhoes.IsNullOrEmpty())
        //         {
        //             foreach (var caminhao in concessionaria.Caminhoes!)
        //             {
        //                  if(caminhao.)
        //             }
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         throw new Exception(ex.Message);
        //     }
        // }

        public async Task<Concessionaria?> AddConcessionaria(Concessionaria model)
        {
            try
            {
                var concessionaria = await _concessionariaPersistence.GetConcessionariaByCNPJAsync(model.CNPJ);

                if (concessionaria != null){
                    throw new ConcessionariaRepetidaException(Messages.CNPJExistente);
                } 

                _geralPersistence.Add<Concessionaria>(model);

                var salvo = await _geralPersistence.SaveChangesAsync();

                if (!salvo)
                {
                    throw new ConcessionariaNaoSalvaException(Messages.erroAoSalvarConcessionaria);
                }

                concessionaria = await _concessionariaPersistence.GetConcessionariaByIdAsync(model.Id);

                return concessionaria;
            }
            catch (SqlException)
            {
                throw new AcessoDeDadosException(Messages.erroDados);
            }
            catch (DbUpdateException)
            {
                throw new AcessoDeDadosException(Messages.erroDados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Concessionaria?> UpdateConcessionaria(int Id, Concessionaria model)
        {
            try
            {
                var concessionaria = await _concessionariaPersistence.GetConcessionariaByIdAsync(Id) ??
                throw new ConcessionariaNuloException(Messages.concessionariaNula);

                model.Id = concessionaria.Id;

                _geralPersistence.Update<Concessionaria>(model);

                var salvo = await _geralPersistence.SaveChangesAsync();

                if (!salvo)
                {
                    throw new ConcessionariaNaoSalvaException(Messages.erroAoSalvarConcessionaria);
                }

                concessionaria =  await _concessionariaPersistence.GetConcessionariaByIdAsync(model.Id);

                return concessionaria;
            }
            catch (SqlException)
            {
                throw new AcessoDeDadosException(Messages.erroDados);
            }
            catch (DbUpdateException)
            {
                throw new AcessoDeDadosException(Messages.erroDados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteConcessionaria(int Id)
        {
            try
            {
                var concessionaria = await _concessionariaPersistence.GetConcessionariaByIdAsync(Id)??
                throw new ConcessionariaNuloException(Messages.concessionariaNula);

                _geralPersistence.Delete(concessionaria);

                var salvo = await _geralPersistence.SaveChangesAsync();

                if (!salvo)
                {
                     throw new ConcessionariaNaoSalvaException(Messages.erroAoSalvarConcessionaria);
                }
                return await _geralPersistence.SaveChangesAsync();
            }
            catch (SqlException)
            {
                throw new AcessoDeDadosException(Messages.erroDados);
            }
            catch (DbUpdateException)
            {
                throw new AcessoDeDadosException(Messages.erroDados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}