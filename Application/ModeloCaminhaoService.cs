using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
                return modeloCaminhoes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ModeloCaminhao?> GetModeloCaminhaoByIdAsync(int Id)
        {
            try
            {
                var modeloCaminhao = await _modeloCaminhaoPersistence.GetModeloCaminhaoByIdAsync(Id);
                return modeloCaminhao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ModeloCaminhao?> AddModeloCaminhao(ModeloCaminhao model)
        {
            try
            {
                _geralPersistence.Add<ModeloCaminhao>(model);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _modeloCaminhaoPersistence.GetModeloCaminhaoByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ModeloCaminhao?> UpdateModeloCaminhao(int Id, ModeloCaminhao model)
        {
            try
            {
                var modeloCaminhao = await _modeloCaminhaoPersistence.GetModeloCaminhaoByIdAsync(Id)
                ?? throw new Exception("ModeloCaminhao selecionada para update não encontrada!");

                model.Id = modeloCaminhao.Id;
                _geralPersistence.Update<ModeloCaminhao>(model);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _modeloCaminhaoPersistence.GetModeloCaminhaoByIdAsync(model.Id);

                }
                return null;
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
                var modeloCaminhao = await _modeloCaminhaoPersistence.GetModeloCaminhaoByIdAsync(Id)
                ?? throw new Exception("ModeloCaminhao selecionada para exclusão não encontrada!");
                _geralPersistence.Delete(modeloCaminhao);
                return await _geralPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}