﻿using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FIFA_API.Models.DataManager
{
    public class CommentaireManager : ICommentaireRepository
    {
        private readonly FifaDbContext fifaDbContext;

        public CommentaireManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Commentaire>>> GetAllAsync()
        {
            return await fifaDbContext.Commentaire.ToListAsync();
        }

        public async Task AddAsync(Commentaire entity)
        {
            await fifaDbContext.Commentaire.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Commentaire entity)
        {
            fifaDbContext.Commentaire.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Commentaire?>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Commentaire.FirstOrDefaultAsync(u => u.CommentaireId == id);

        }


        public async Task UpdateAsync(Commentaire entityToUpdate, Commentaire entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.CommentaireId = entity.CommentaireId;
            entityToUpdate.CommentaireDateHeure = entity.CommentaireDateHeure;
            entityToUpdate.UtilisateurId = entity.UtilisateurId;
            entityToUpdate.CommentaireTexte = entity.CommentaireTexte;
            entityToUpdate.CommentaireIdCommentaire = entity.CommentaireIdCommentaire;
            entityToUpdate.DocumentId = entity.DocumentId;
            entityToUpdate.AlbumId = entity.AlbumId;
            entityToUpdate.BlogId = entity.BlogId;
            entityToUpdate.ArticleId = entity.ArticleId;
            entityToUpdate.CommenteCommentaire = entity.CommenteCommentaire;
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<Commentaire>> GetResponseOfCommentaire(int idCommentaire)
        {
            Commentaire? leCommentaire = await fifaDbContext.Commentaire.FirstOrDefaultAsync(x => x.CommentaireId == idCommentaire);

            if (leCommentaire is null)
                return null;


            EntityEntry<Commentaire> CommentaireEntityEntry = fifaDbContext.Entry(leCommentaire);

            await CommentaireEntityEntry.Reference(c => c.CommentaireCommente).LoadAsync();

            return leCommentaire.CommentaireCommente;
        }

    }
}
