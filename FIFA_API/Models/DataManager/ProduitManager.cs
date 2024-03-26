using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Xml.Linq;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

#nullable disable

namespace FIFA_API.Models.DataManager
{
    public class ProduitManager : IProduitRepository
    {
        private readonly FifaDbContext fifaDbContext;

        public ProduitManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Produit>>> GetAllAsync()
        {
            return await fifaDbContext.Produit.ToListAsync();

            // Les commentaires suivant montrent ce que j'essayais de faire. (c'est Paul qui écrit)
            // Je voulais qui à partir de GetAllAsync, on puisse accéder à une image du produit.
            // Mais pour accéder à une image depuis produit il faut faire :
            // Produit -> VarianteProduit -> ImageVariante -> Image
            // J'ai essayé de faire le lien mais ça ne marchait pas. Voici ce que j'essayais de faire : 


            //return await fifaDbContext.Produit
            //    .Include(p => p.VariantesProduit)
            //    .ThenInclude(vp => vp.LienImages)
            //    .ToListAsync();

            // Résultat : fonctionne mais on ne peut pas accéder à ImageUrl


            //return await fifaDbContext.Produit
            //    .Include(p => p.VariantesProduit)
            //    .ThenInclude(vp => vp.LienImages)
            //    .ThenInclude(iv => iv.ImageNavigation)
            //    .ToListAsync();

            // Erreur : A possible object cycle was detected. This can either be due to a cycle or if the
            // object depth is larger than the maximum allowed depth of 32. Consider using
            // ReferenceHandler.Preserve on JsonSerializerOptions to support cycles. Path:
            // $.VariantesProduit.LienImages.ImageNavigation.ImagesVariante.VarianteProduitNavigation.
            // LienImages.ImageNavigation.ImagesVariante.VarianteProduitNavigation.ProduitVariante.
            // VariantesProduit.LienImages.ImageNavigation.ImagesVariante.VarianteProduitNavigation.
            // LienImages.ImageNavigation.ImagesVariante.VarianteProduitNavigation.ProduitVariante.
            // ProduitId.


            // à la place j'ai créé GetAnImagePathOfProduitById
        }

        public async Task AddAsync(Produit entity)
        {
            await fifaDbContext.Produit.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Produit entity)
        {
            fifaDbContext.Produit.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Produit>> GetByIdAsync(int id)
        {
            Produit produit = await fifaDbContext.Produit.FirstOrDefaultAsync(u => u.ProduitId == id);

            if (produit is null)
                return produit;

            EntityEntry<Produit> produitEntityEntry = fifaDbContext.Entry(produit);

            await produitEntityEntry.Reference(p => p.PaysProduit).LoadAsync();
            await produitEntityEntry.Reference(p => p.CategorieNavigation).LoadAsync();

            await produitEntityEntry.Collection(p => p.ProduitSimilaireLienUn).LoadAsync();
            await produitEntityEntry.Collection(p => p.ProduitSimilaireLienDeux).LoadAsync();
            await produitEntityEntry.Collection(p => p.VariantesProduit).LoadAsync();
            await produitEntityEntry.Collection(p => p.LienCaracteristiques).LoadAsync();
            await produitEntityEntry.Collection(p => p.DevisProduit).LoadAsync();

            return produit;
        }

        public async Task<IEnumerable<Produit>> GetProduitsByIdsAsync(int[] ids)
        {
            IEnumerable<Produit> produits = await fifaDbContext.Produit.Where(p => ids.Contains(p.ProduitId)).ToListAsync();

            if (produits == null || !produits.Any())
                return null;

            foreach (var produit in produits)
            {
                var produitEntityEntry = fifaDbContext.Entry(produit);

                await produitEntityEntry.Reference(p => p.PaysProduit).LoadAsync();
                await produitEntityEntry.Reference(p => p.CategorieNavigation).LoadAsync();

                await produitEntityEntry.Collection(p => p.ProduitSimilaireLienUn).LoadAsync();
                await produitEntityEntry.Collection(p => p.ProduitSimilaireLienDeux).LoadAsync();
                await produitEntityEntry.Collection(p => p.VariantesProduit).LoadAsync();
                await produitEntityEntry.Collection(p => p.LienCaracteristiques).LoadAsync();
                await produitEntityEntry.Collection(p => p.DevisProduit).LoadAsync();
            }

            return produits.ToList();
        }



        public async Task<ActionResult<Produit>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Produit.FirstOrDefaultAsync(u => u.ProduitNom.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Produit entityToUpdate, Produit entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.ProduitId = entity.ProduitId;
            entityToUpdate.GenreId = entity.GenreId;
            entityToUpdate.CategorieId = entity.CategorieId;
            entityToUpdate.ProduitNom = entity.ProduitNom;
            entityToUpdate.ProduitDescription = entity.ProduitDescription;
            entityToUpdate.CompetitionId = entity.CompetitionId;
            entityToUpdate.PaysId = entity.PaysId;
            entityToUpdate.ProduitSimilaireLienDeux = entity.ProduitSimilaireLienDeux;
            entityToUpdate.ProduitSimilaireLienUn = entity.ProduitSimilaireLienUn;
            entityToUpdate.DevisProduit = entity.DevisProduit;
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<string>> GetAnImagePathOfProduitById(int id)
        {
            Produit leProduit = await fifaDbContext.Produit.FindAsync(id);
            if (leProduit is null)
                return null;
            await fifaDbContext.Entry(leProduit).Collection(p => p.VariantesProduit).LoadAsync();

            VarianteProduit uneVarianteProduit = leProduit.VariantesProduit.FirstOrDefault();
            if (uneVarianteProduit is null)
                return null;
            await fifaDbContext.Entry(uneVarianteProduit).Collection(vp => vp.LienImages).LoadAsync();

            ImageVariante imageVariante = uneVarianteProduit.LienImages.FirstOrDefault();
            if (imageVariante is null)
                return null;
            await fifaDbContext.Entry(imageVariante).Reference(iv => iv.ImageNavigation).LoadAsync();

            return imageVariante.ImageNavigation.ImageUrl;
        }

        public async Task<ActionResult<IEnumerable<Produit>>> GetSearchResults(string searchInput)
        {
            string[] keywords = searchInput.ToLower().Split(' ');

            searchInput = searchInput.ToLower();

            var result = await GetAllAsync();

            if (result.Value is null)
                return result;

            IEnumerable<Produit> produits = result.Value;
                
            await Task.Run(() =>
            {
                // Filtrage des produits :

                // Filtrage par texte :
                produits = produits.Where(x => NameMatchWithKeywords(x.ProduitNom.ToLower(), keywords));

                // Filtrer par catégorie ici

                return produits.ToList();   // Calcul de toutes les données en asyncrone
            });

            return new ActionResult<IEnumerable<Produit>>(produits);
        }

        public async Task<ActionResult<IEnumerable<Produit>>> GetByFilter(int? catId, int? taiId = null, int?[] colId = null, int? genreId = null, int? paysId=null)
        {

            var result = await GetAllAsync();

            if (result.Value is null)
                return result;

            IEnumerable<Produit> produits = result.Value;

            await Task.Run(() =>
            {
                // Filtrer par catégorie ici
                if(catId != null && catId!=0)
                    produits = produits.Where(x => x.CategorieId == catId);

                //Filtrage par Pays :
                if (paysId != null && paysId != 0)
                    produits = produits.Where(x => x.PaysId == paysId);

                //Filtrage par Genre :
                if (genreId != null && genreId != 0)
                    produits = produits.Where(x => x.GenreId == genreId);

                // Filtrage par coloris :
                if (colId != null && colId.Length !=0)
                {
                    bool possedeCol = false;
                    foreach (Produit produit in produits)
                        {
                            foreach (VarianteProduit variante in produit.VariantesProduit)
                            {
                                if (colId.Contains(variante.ColorisId))
                                {
                                    possedeCol = true;
                                    break;
                                }

                            }
                            if (possedeCol)
                            {
                                possedeCol = false;
                            }
                            else
                            {
                                produits.ToList().Remove(produit);
                            }
                    }
                }

                // Filtrage par taille
                if (taiId != null && taiId != 0)
                {
                    bool possedeTai = false;
                    foreach (Produit produit in produits)
                    {
                        foreach (VarianteProduit variante in produit.VariantesProduit)
                        {
                            foreach (Stock stck in variante.StocksVariante)
                            {
                                if (stck.TailleId == taiId)
                                {
                                    possedeTai = true;
                                    break;
                                }
                            }

                        }
                        if (possedeTai)
                        {
                            possedeTai = false;
                        }
                        else
                        {
                            produits.ToList().Remove(produit);
                        }


                    }

                }


                return produits.ToList();   // Calcul de toutes les données en asyncrone
            });

            return new ActionResult<IEnumerable<Produit>>(produits);
        }

        private static bool NameMatchWithKeywords(string name, string[] keywords)
        {
            return keywords.All(x => name.Contains(x));
        }
    }
}
