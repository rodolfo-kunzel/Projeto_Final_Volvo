using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
                return caminhoes;
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
                throw new CaminhaoNuloOuVazioException();
                return caminhao;
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
                throw new CaminhaoNuloOuVazioException();
                return caminhao;
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
                throw new CaminhaoNuloOuVazioException();
                return caminhao;
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
                if (caminhao != null) throw new Exception();
                _geralPersistence.Add<Caminhao>(model);
                if (await _geralPersistence.SaveChangesAsync())
                {

                    caminhao = await _caminhaoPersistence.GetCaminhaoByIdAsync(model.Id);

                    if (caminhao == null) {
                    throw new CaminhaoNuloOuVazioException();
                    }

                    return caminhao;

                }
                return null;
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
                var caminhao = await _caminhaoPersistence.GetCaminhaoByIdAsync(Id) ?? throw new CaminhaoNuloOuVazioException("Caminhao selecionado para update não encontrada!");
                model.Id = caminhao.Id;
                _geralPersistence.Update<Caminhao>(model);
                if (await _geralPersistence.SaveChangesAsync())
                {

                    caminhao = await _caminhaoPersistence.GetCaminhaoByIdAsync(model.Id);

                    if (caminhao == null) {
                    throw new CaminhaoNuloOuVazioException();
                    }

                    return caminhao;

                }
                return null;
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
                throw new CaminhaoNuloOuVazioException("Caminhao selecionado para exclusão não encontrada!");
                _geralPersistence.Delete(caminhao);
                return await _geralPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}