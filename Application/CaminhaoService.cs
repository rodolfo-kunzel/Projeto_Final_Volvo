using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Domain;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
                    throw new CaminhoesNaoEncontradosException(Messages.listaCaminhoesVazia);
                }

                return caminhoes;
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

        public async Task<Caminhao> GetCaminhaoByIdAsync(int Id)
        {
            try
            {
                var caminhao = await _caminhaoPersistence.GetCaminhaoByIdAsync(Id) ?? 
                throw new CaminhaoNuloException(Messages.caminhaoNulo);
                
                return caminhao;
            }
            catch (SqlException)
            {
                throw new AcessoDeDadosException(Messages.erroDados);
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
                throw new AcessoDeDadosException(Messages.erroDados);
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
                throw new CaminhaoNuloException(Messages.caminhaoNulo);
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
                throw new CaminhaoNuloException(Messages.caminhaoNulo);
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
                if (caminhao != null) throw new Exception(Messages.numeroChassiExistente);
                _geralPersistence.Add<Caminhao>(model);
                if (await _geralPersistence.SaveChangesAsync())
                {

                    caminhao = await _caminhaoPersistence.GetCaminhaoByIdAsync(model.Id) ??
                    throw new CaminhaoNuloException(Messages.caminhaoNulo);;

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
                var caminhao = await _caminhaoPersistence.GetCaminhaoByIdAsync(Id) ?? 
                throw new CaminhaoNuloException(Messages.caminhaoNulo);

                model.Id = caminhao.Id;

                _geralPersistence.Update<Caminhao>(model);

                if (await _geralPersistence.SaveChangesAsync())
                {
                    caminhao = await _caminhaoPersistence.GetCaminhaoByIdAsync(model.Id)??
                    throw new CaminhaoNuloException(Messages.caminhaoNulo);;

                    return caminhao;

                }
                return null;
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
                var caminhao = await _caminhaoPersistence.GetCaminhaoByIdAsync(IdCaminhao, false, false, false)
                ?? throw new Exception("Caminhao selecionado para update não encontrada!");

                caminhao.PedidoId = idPedido;
                _geralPersistence.Update<Caminhao>(caminhao);

                //return await _geralPersistence.SaveChangesAsync();
                return true;
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
                throw new CaminhaoNuloException(Messages.caminhaoNulo);
                _geralPersistence.Delete(caminhao);
                return await _geralPersistence.SaveChangesAsync();
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
                    var caminhao = await GetCaminhaoByIdAsync(Id);
                    if (caminhao == null) throw new Exception("Caminhão selecionado inválido");
                    if (caminhao.PedidoId != null)
                        throw new Exception("O Caminhao de id " + Id +" já possui um pedido");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}