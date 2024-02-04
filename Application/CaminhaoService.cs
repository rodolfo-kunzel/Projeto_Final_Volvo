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
                var caminhao = await _caminhaoPersistence.GetCaminhaoByIdAsync(Id);
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
                var caminhao = await _caminhaoPersistence.GetCaminhaoByNumeroChassiAsync(numeroChassi);
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
                var caminhao = await _caminhaoPersistence.GetCaminhaoByModeloAsync(modelo);
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
                if (caminhao != null) throw new Exception("CNPJ já cadastrado!");
                _geralPersistence.Add<Caminhao>(model);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _caminhaoPersistence.GetCaminhaoByIdAsync(model.Id);
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
                var caminhao = await _caminhaoPersistence.GetCaminhaoByIdAsync(Id)
                ?? throw new Exception("Caminhao selecionado para update não encontrada!");

                model.Id = caminhao.Id;
                _geralPersistence.Update<Caminhao>(model);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _caminhaoPersistence.GetCaminhaoByIdAsync(model.Id);

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
                var caminhao = await _caminhaoPersistence.GetCaminhaoByIdAsync(Id)
                ?? throw new Exception("Caminhao selecionado para exclusão não encontrada!");
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