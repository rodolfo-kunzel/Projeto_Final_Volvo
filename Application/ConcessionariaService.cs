using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.Tokens;
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
                return concessionarias;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Concessionaria?> GetConcessionariaByIdAsync(int Id)
        {
            try
            {
                var concessionaria = await _concessionariaPersistence.GetConcessionariaByIdAsync(Id);
                return concessionaria;
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
                if (concessionaria != null) throw new Exception("CNPJ já cadastrado!");
                _geralPersistence.Add<Concessionaria>(model);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _concessionariaPersistence.GetConcessionariaByIdAsync(model.Id);
                }
                return null;
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
                var concessionaria = await _concessionariaPersistence.GetConcessionariaByIdAsync(Id)
                ?? throw new Exception("Concessionaria selecionada para update não encontrada!");

                model.Id = concessionaria.Id;
                _geralPersistence.Update<Concessionaria>(model);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _concessionariaPersistence.GetConcessionariaByIdAsync(model.Id);

                }
                return null;
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
                var concessionaria = await _concessionariaPersistence.GetConcessionariaByIdAsync(Id)
                ?? throw new Exception("Concessionaria selecionada para exclusão não encontrada!");
                _geralPersistence.Delete(concessionaria);
                return await _geralPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}