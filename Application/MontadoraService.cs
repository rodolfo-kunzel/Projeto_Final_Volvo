using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
                return montadoras;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Montadora?> GetMontadoraByIdAsync(int Id)
        {
            try
            {
                var montadora = await _montadoraPersistence.GetMontadoraByIdAsync(Id);
                return montadora;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Montadora?> AddMontadora(Montadora model)
        {
            try
            {
                var montadora = await _montadoraPersistence.GetMontadoraByCNPJAsync(model.CNPJ);
                if (montadora != null) throw new Exception("CNPJ já cadastrado!");
                _geralPersistence.Add<Montadora>(model);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _montadoraPersistence.GetMontadoraByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Montadora?> UpdateMontadora(int Id, Montadora model)
        {
            try
            {
                var montadora = await _montadoraPersistence.GetMontadoraByIdAsync(Id)
                ?? throw new Exception("Montadora selecionada para update não encontrada!");

                model.Id = montadora.Id;
                _geralPersistence.Update<Montadora>(model);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _montadoraPersistence.GetMontadoraByIdAsync(model.Id);

                }
                return null;
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
                var montadora = await _montadoraPersistence.GetMontadoraByIdAsync(Id)
                ?? throw new Exception("Montadora selecionada para exclusão não encontrada!");
                _geralPersistence.Delete(montadora);
                return await _geralPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}