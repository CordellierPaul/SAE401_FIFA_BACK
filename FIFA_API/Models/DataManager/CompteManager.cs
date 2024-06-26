﻿using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NuGet.Protocol;
using System.Numerics;

namespace FIFA_API.Models.DataManager
{
    public class CompteManager : ICompteRepository
    {

        readonly FifaDbContext fifaDbContext;

        public CompteManager() { }
        public CompteManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<Compte>>> GetAllAsync()
        {
            return await fifaDbContext.Compte.ToListAsync();
        }

        public async Task AddAsync(Compte entity)
        {
            entity.CompteEmail = entity.CompteEmail.ToLower();
            await fifaDbContext.Compte.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }
        
        public async Task DeleteAsync(Compte entity)
        {
            fifaDbContext.Compte.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Compte>> GetByIdAsync(int id)
        {
            Compte compte = await fifaDbContext.Compte.FirstOrDefaultAsync(u => u.CompteId == id);

            if (compte is null)
                return compte;

            EntityEntry<Compte> compteEntityEntry = fifaDbContext.Entry(compte);

            await compteEntityEntry.Reference(c => c.UtilisateurCompte).Query().Include(u => u.AdresseUtilisateur).ThenInclude(a => a.LienVille).LoadAsync();

            return new ActionResult<Compte>(compteEntityEntry.Entity);
        }


        public async Task<ActionResult<Compte>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Compte.FirstOrDefaultAsync(u => u.CompteEmail.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Compte entityToUpdate, Compte entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.CompteId = entity.CompteId;
            entityToUpdate.CompteEmail = entity.CompteEmail.ToLower();
            entityToUpdate.Comptelogin = entity.Comptelogin;
            entityToUpdate.CompteMdp = entity.CompteMdp;
            entityToUpdate.CompteDateConnexion = entity.CompteDateConnexion;
            entityToUpdate.CompteAnnonces = entity.CompteAnnonces;
            entityToUpdate.TypeCompte = entity.TypeCompte;

            if (entityToUpdate.UtilisateurCompte is null)
                throw new ArgumentException("Le compte n'a pas d'utilisateur");

            entityToUpdate.UtilisateurCompte.PrenomUtilisateur = entity.UtilisateurCompte.PrenomUtilisateur;
            entityToUpdate.UtilisateurCompte.AdresseId = entity.UtilisateurCompte.AdresseId;
            entityToUpdate.UtilisateurCompte.UtilisateurDateNaissance = entity.UtilisateurCompte.UtilisateurDateNaissance;
            entityToUpdate.UtilisateurCompte.CompteId = entity.CompteId;
            entityToUpdate.UtilisateurCompte.MonnaieId = entity.UtilisateurCompte.MonnaieId;
            entityToUpdate.UtilisateurCompte.LangueId = entity.UtilisateurCompte.LangueId;
            entityToUpdate.UtilisateurCompte.PaysNaissanceId= entity.UtilisateurCompte.PaysNaissanceId;
            entityToUpdate.UtilisateurCompte.PaysFavoriId = entity.UtilisateurCompte.PaysFavoriId;
            entityToUpdate.UtilisateurCompte.UtilisateurNomAcheteur = entity.UtilisateurCompte.UtilisateurNomAcheteur;
            entityToUpdate.UtilisateurCompte.UtilisateurTelAcheteur = entity.UtilisateurCompte.UtilisateurTelAcheteur;
            entityToUpdate.UtilisateurCompte.ActiviteId = entity.UtilisateurCompte.ActiviteId;
            entityToUpdate.UtilisateurCompte.SocieteId = entity.UtilisateurCompte.SocieteId;
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task<Compte?> GetCompteByCompte(Compte user)
        {
            var response = await GetAllAsync();
            if (response == null || response.Value == null)
                return null;

            Compte? compte = response.Value.SingleOrDefault(x => x.CompteEmail.ToUpper() == user.CompteEmail.ToUpper() && x.CompteMdp == user.CompteMdp);

            if (compte == null)
                return null;

            EntityEntry<Compte> compteEntityEntry = fifaDbContext.Entry(compte);
            await compteEntityEntry.Reference(c => c.UtilisateurCompte).LoadAsync();

            return compte;
        }
    }
}
