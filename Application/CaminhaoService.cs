using System.Text.RegularExpressions;
using Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application
{

    public class CaminhaoService
    {
        private readonly GeralPersistence _geralPersistence;
        private readonly CaminhaoPersistence _caminhaoPersistence;

        public CaminhaoService(GeralPersistence geralPersistence,
                                      CaminhaoPersistence caminhaoPersistence)
        {
            _geralPersistence = geralPersistence;
            _caminhaoPersistence = caminhaoPersistence;
        }

        public async Task<Caminhao[]> GetAllCaminhoesAsync()
        {
            try
            {
                var caminhoes = await _caminhaoPersistence.GetAllCaminhoesAsync();

                if (caminhoes == null || caminhoes.Length == 0) {
                    throw new CaminhoesNaoEncontradosException(Mensagens.listaCaminhoesVazia);
                }

                return caminhoes;
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

        public async Task<Caminhao> GetCaminhaoByIdAsync(int Id)
        {
            try
            {
                var caminhao = await _caminhaoPersistence.GetCaminhaoByIdAsync(Id) ?? 
                throw new CaminhaoNuloException(Mensagens.caminhaoNulo);
                
                return caminhao;
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

        public async Task<Caminhao[]> GetSoldCaminhaoByConcessionariaIdAsync(int idConcessionaria)
        {
            try
            {
                var caminhoes = await _caminhaoPersistence.GetSoldCaminhaoByConcessionariaIdAsync(idConcessionaria);

                return caminhoes;
            }
            catch (SqlException)
            {
                throw new AcessoDeDadosException(Mensagens.erroDados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Caminhao> GetCaminhaoByNumeroChassiAsync(string numeroChassi)
        {
            try
            {
                var caminhao = await _caminhaoPersistence.GetCaminhaoByNumeroChassiAsync(numeroChassi) ?? 
                throw new CaminhaoNuloException(Mensagens.caminhaoNulo);
                return caminhao;
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

        public async Task<Caminhao> GetCaminhaoByModeloAsync(ModeloCaminhao modelo)
        {
            try
            {
                var caminhao = await _caminhaoPersistence.GetCaminhaoByModeloAsync(modelo) ?? 
                throw new CaminhaoNuloException(Mensagens.caminhaoNulo);
                return caminhao;
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

        public async Task<Caminhao[]> GetCaminhaoByRangePriceAsync(double minValue, double maxValue)
        {
            try
            {
                var caminhoes = await _caminhaoPersistence.GetCaminhaoByRangePriceAsync(minValue, maxValue);
                return caminhoes;
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

        public async Task<Caminhao> AddCaminhao(Caminhao model)
        {
            try
            {
                var caminhao = await _caminhaoPersistence.GetCaminhaoByNumeroChassiAsync(model.NumeroChassi);

                if (caminhao != null) throw new CaminhaoRepetidoException(Mensagens.numeroChassiExistente);

                _geralPersistence.Add<Caminhao>(model);

                var salvo = await _geralPersistence.SaveChangesAsync();

                if (!salvo)
                {
                    throw new CaminhaoNaoSalvoException(Mensagens.erroAoSalvarCaminhao);
                }

                caminhao = await _caminhaoPersistence.GetCaminhaoByIdAsync(model.Id) ??
                throw new CaminhaoNuloException(Mensagens.caminhaoNulo);

                return caminhao;
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

        public async Task<Caminhao> UpdateCaminhao(int Id, Caminhao model)
        {
            try
            {
                var caminhao = await _caminhaoPersistence.GetCaminhaoByIdAsync(Id) ?? 
                throw new CaminhaoNuloException(Mensagens.caminhaoNulo);

                model.Id = caminhao.Id;

                _geralPersistence.Update<Caminhao>(model);

                var salvo = await _geralPersistence.SaveChangesAsync();

                if (!salvo)
                {
                    throw new CaminhaoNaoSalvoException(Mensagens.erroAoSalvarCaminhao);
                }

                caminhao = await _caminhaoPersistence.GetCaminhaoByIdAsync(model.Id) ??
                throw new CaminhaoNuloException(Mensagens.caminhaoNulo);

                return caminhao;
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

         public async Task<bool> UpdateCaminhaoPedido(int IdCaminhao, int idPedido)
        {
            try
            {
                var caminhao = await _caminhaoPersistence.GetCaminhaoByIdAsync(IdCaminhao, false, false, false) ?? 
                throw new CaminhaoNuloException(Mensagens.caminhaoNulo);

                caminhao.PedidoId = idPedido;
                _geralPersistence.Update<Caminhao>(caminhao);

                var salvo = await _geralPersistence.SaveChangesAsync();

                if (!salvo)
                {
                    throw new CaminhaoNaoSalvoException(Mensagens.erroAoSalvarCaminhao);
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

        public async Task<bool> DeleteCaminhao(int Id)
        {
            try
            {
                var caminhao = await _caminhaoPersistence.GetCaminhaoByIdAsync(Id) ?? 
                throw new CaminhaoNuloException(Mensagens.caminhaoNulo);

                _geralPersistence.Delete(caminhao);

                var salvo = await _geralPersistence.SaveChangesAsync();

                if (!salvo)
                {
                    throw new CaminhaoNaoPodeSerDeletadoException(Mensagens.caminhaoRemovidoErro);
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

        public async Task<bool> DeletePedidoIdFromCaminhao(int Id)
        {
            try
            {
                var caminhao = await _caminhaoPersistence.GetCaminhaoByIdAsync(Id, false, false, false) ?? 
                throw new CaminhaoNuloException(Mensagens.caminhaoNulo);

                caminhao.PedidoId = null;

                _geralPersistence.Update(caminhao);


                var salvo = await _geralPersistence.SaveChangesAsync();

                if (!salvo)
                {
                    throw new CaminhaoNaoPodeSerDeletadoException(Mensagens.caminhaoRemovidoErro);
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

        public async Task<bool> IdListIsValid(List<int> IDs)
        {
            try
            {
                foreach (int Id in IDs)
                {
                    var caminhao = await GetCaminhaoByIdAsync(Id) ?? 
                    throw new CaminhaoInvalidoException(Mensagens.caminhaoInvalido);

                    if (caminhao.PedidoId != null)
                    {
                        throw new Exception("O Caminhao de id " + Id +" já possui um pedido");
                    }
                        
                }
                return true;
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