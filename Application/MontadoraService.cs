using Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application
{

    public class MontadoraService
    {
        private readonly GeralPersistence _geralPersistence;
        private readonly MontadoraPersistence _montadoraPersistence;

        public MontadoraService(GeralPersistence geralPersistence,
                                      MontadoraPersistence montadoraPersistence)
        {
            _geralPersistence = geralPersistence;
            _montadoraPersistence = montadoraPersistence;
        }

        public async Task<Montadora[]> GetAllMontadorasAsync()
        {
            try
            {
                var montadoras = await _montadoraPersistence.GetAllMontadorasAsync();

                if (montadoras == null || montadoras.Length == 0) {
                    throw new MontadorasNaoEncontradasException(Mensagens.listaModelosCaminhoesVazia);
                }

                return montadoras;
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

        public async Task<Montadora> GetMontadoraByIdAsync(int Id)
        {
            try
            {
                var montadora = await _montadoraPersistence.GetMontadoraByIdAsync(Id) ?? 
                throw new MontadoraNuloException(Mensagens.modeloCaminhaoNulo);

                return montadora;
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

        public async Task<Montadora> AddMontadora(Montadora model)
        {
            try
            {
                var montadora = await _montadoraPersistence.GetMontadoraByCNPJAsync(model.CNPJ);
                if (montadora != null)
                {
                    throw new MontadoraRepetidaException(Mensagens.CNPJExistente);
                } 

                _geralPersistence.Add<Montadora>(model);

                var salvo = await _geralPersistence.SaveChangesAsync();

                if (!salvo)
                {
                    throw new MontadoraNaoSalvaException(Mensagens.erroAoSalvarMontadora);
                }

                montadora = await _montadoraPersistence.GetMontadoraByIdAsync(model.Id) ?? 
                throw new MontadoraNuloException(Mensagens.modeloCaminhaoNulo);

                return montadora;
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

        public async Task<Montadora> UpdateMontadora(int Id, Montadora model)
        {
            try
            {
                var montadora = await _montadoraPersistence.GetMontadoraByIdAsync(Id) ?? 
                throw new MontadoraNuloException(Mensagens.modeloCaminhaoNulo);

                model.Id = montadora.Id;
                _geralPersistence.Update<Montadora>(model);

                var salvo = await _geralPersistence.SaveChangesAsync();

                if (!salvo)
                {
                    throw new MontadoraNaoSalvaException(Mensagens.erroAoSalvarMontadora);
                }

                montadora = await _montadoraPersistence.GetMontadoraByIdAsync(model.Id) ?? 
                throw new MontadoraNuloException(Mensagens.modeloCaminhaoNulo);

                return montadora;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteMontadora(int Id)
        {
            try
            {
                var montadora = await _montadoraPersistence.GetMontadoraByIdAsync(Id)?? 
                throw new MontadoraNuloException(Mensagens.modeloCaminhaoNulo);

                _geralPersistence.Delete(montadora);

                var salvo = await _geralPersistence.SaveChangesAsync();

                if (!salvo)
                {
                     throw new MontadoraNaoSalvaException(Mensagens.erroAoSalvarMontadora);
                }

                return salvo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}