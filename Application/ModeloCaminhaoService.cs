using Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application
{

    public class ModeloCaminhaoService
    {
        private readonly GeralPersistence _geralPersistence;
        private readonly ModeloCaminhaoPersistence _modeloCaminhaoPersistence;

        public ModeloCaminhaoService(GeralPersistence geralPersistence,
                                      ModeloCaminhaoPersistence modeloCaminhaoPersistence)
        {
            _geralPersistence = geralPersistence;
            _modeloCaminhaoPersistence = modeloCaminhaoPersistence;
        }

        public async Task<ModeloCaminhao[]> GetAllModeloCaminhoesAsync()
        {
            try
            {
                var modeloCaminhoes = await _modeloCaminhaoPersistence.GetAllModeloCaminhoesAsync();

                if (modeloCaminhoes == null || modeloCaminhoes.Length == 0) {
                    throw new ModelosCaminhoesNaoEncontradoException(Mensagens.listaCaminhoesVazia);
                }

                return modeloCaminhoes;
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
  
        public async Task<ModeloCaminhao> GetModeloCaminhaoByIdAsync(int Id)
        {
            try
            {
                var modeloCaminhao = await _modeloCaminhaoPersistence.GetModeloCaminhaoByIdAsync(Id) ?? 
                throw new ModeloCaminhaoNuloException(Mensagens.modeloCaminhaoNulo);

                return modeloCaminhao;
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

        public async Task<ModeloCaminhao> AddModeloCaminhao(ModeloCaminhao model)
        {
            try
            {
                _geralPersistence.Add<ModeloCaminhao>(model);

                var salvo = await _geralPersistence.SaveChangesAsync();

                if (!salvo)
                {
                    throw new ModeloCaminhaoNaoSalvoException(Mensagens.erroAoSalvarModeloCaminhao);
                }

                var modeloCaminhao = await _modeloCaminhaoPersistence.GetModeloCaminhaoByIdAsync(model.Id) ??
                throw new ModeloCaminhaoNuloException(Mensagens.clienteNulo);

                return modeloCaminhao;
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

        public async Task<ModeloCaminhao> UpdateModeloCaminhao(int Id, ModeloCaminhao model)
        {
            try
            {
                var modeloCaminhao = await _modeloCaminhaoPersistence.GetModeloCaminhaoByIdAsync(Id) ??
                throw new ModeloCaminhaoNuloException(Mensagens.clienteNulo);

                model.Id = modeloCaminhao.Id;
                _geralPersistence.Update<ModeloCaminhao>(model);

                var salvo = await _geralPersistence.SaveChangesAsync();

                if (!salvo)
                {
                    throw new ModeloCaminhaoNaoSalvoException(Mensagens.erroAoSalvarModeloCaminhao);
                }

                modeloCaminhao = await _modeloCaminhaoPersistence.GetModeloCaminhaoByIdAsync(model.Id) ??
                throw new ModeloCaminhaoNuloException(Mensagens.clienteNulo);

                return modeloCaminhao;
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
 
        public async Task<bool> DeleteModeloCaminhao(int Id)
        {
            try
            {
                var modeloCaminhao = await _modeloCaminhaoPersistence.GetModeloCaminhaoByIdAsync(Id) ?? 
                throw new ModeloCaminhaoNaoSalvoException(Mensagens.caminhaoRemovidoErro);

                _geralPersistence.Delete(modeloCaminhao);

                var salvo = await _geralPersistence.SaveChangesAsync();

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
    }
}