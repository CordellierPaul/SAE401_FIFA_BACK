using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Xml.Linq;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace FIFA_API.Models.DataManager
{
    public class JoueurManager : IJoueurRepository
    {
        private readonly FifaDbContext fifaDbContext;

        public JoueurManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Joueur>>> GetAllAsync()
        {
            return await fifaDbContext.Joueur.ToListAsync();
        }

        public async Task AddAsync(Joueur entity)
        {
            await fifaDbContext.Joueur.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Joueur entity)
        {
            fifaDbContext.Joueur.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Joueur>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Joueur.FirstOrDefaultAsync(u => u.JoueurId == id);

        }

        
        public async Task<IEnumerable<Joueur>> GetJoueursByIdsAsync(int[] ids)
        {
            IEnumerable<Joueur> joueurs = await fifaDbContext.Joueur.Where(p => ids.Contains(p.JoueurId)).ToListAsync();

            if (joueurs == null || !joueurs.Any())
                return null;

            foreach (var joueur in joueurs)
            {
                EntityEntry<Joueur> joueurEntityEntry = fifaDbContext.Entry(joueur);

                await joueurEntityEntry.Reference(p => p.VilleJoueur).LoadAsync();
                await joueurEntityEntry.Reference(p => p.ClubJoueur).LoadAsync();
                await joueurEntityEntry.Reference(p => p.PosteJoueur).LoadAsync();


                await joueurEntityEntry.Collection(p => p.LiensArticles).LoadAsync();
                await joueurEntityEntry.Collection(p => p.Matches_joue).LoadAsync();
                await joueurEntityEntry.Collection(p => p.RemportesJoueur).LoadAsync();
                await joueurEntityEntry.Collection(p => p.LiensImages).LoadAsync();
                await joueurEntityEntry.Collection(p => p.LienAnecdotes).LoadAsync();
                await joueurEntityEntry.Collection(p => p.VotesJoueur).LoadAsync();
                await joueurEntityEntry.Collection(p => p.LienTheme).LoadAsync();
            }

            return joueurs.ToList();
        }

        public async Task<ActionResult<Joueur>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Joueur.FirstOrDefaultAsync(u => u.JoueurNom.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Joueur entityToUpdate, Joueur entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.JoueurId = entity.JoueurId;
            entityToUpdate.JoueurDateNaissance = entity.JoueurDateNaissance;
            entityToUpdate.PosteId = entity.PosteId;
            entityToUpdate.ClubId = entity.ClubId;
            entityToUpdate.VilleId = entity.VilleId;
            entityToUpdate.JoueurNom = entity.JoueurNom;
            entityToUpdate.JoueurPrenom = entity.JoueurPrenom;
            entityToUpdate.JoueurPied = entity.JoueurPied;
            entityToUpdate.JoueurPoids = entity.JoueurPoids;
            entityToUpdate.JoueurTaille = entity.JoueurTaille;
            entityToUpdate.JoueurDescription = entity.JoueurDescription;
            entityToUpdate.LiensArticles = entity.LiensArticles;
            entityToUpdate.Matches_joue = entity.Matches_joue;
            entityToUpdate.RemportesJoueur = entity.RemportesJoueur;
            entityToUpdate.LiensImages = entity.LiensImages;
            entityToUpdate.LienAnecdotes = entity.LienAnecdotes;
            entityToUpdate.VotesJoueur = entity.VotesJoueur;
            entityToUpdate.LienTheme = entity.LienTheme;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
