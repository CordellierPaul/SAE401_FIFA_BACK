using FIFA_API.Models;
using FIFA_API.Models.DataManager;
using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FifaDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("FifaDbContext")));

builder.Services.AddScoped<IProduitRepository, ProduitManager>();
builder.Services.AddScoped<IDataRepository<FIFA_API.Models.EntityFramework.Action>, ActionManager>();
builder.Services.AddScoped<IDataRepository<Activite>, ActiviteManager>();
builder.Services.AddScoped<IDataRepository<Adresse>, AdresseManager>();
builder.Services.AddScoped<IDataRepository<Album>, AlbumManager>();
builder.Services.AddScoped<IDataRepository2clues<AlbumImage>, AlbumImageManager>();
builder.Services.AddScoped<IDataRepository2clues<LikeAlbum>, LikeAlbumManager>();
builder.Services.AddScoped<IDataRepository<Anecdote>, AnecdoteManager>();
builder.Services.AddScoped<IDataRepository<Article>, ArticleManager>();
builder.Services.AddScoped<IDataRepository<Blog>, BlogManager>();
builder.Services.AddScoped<IDataRepository2clues<BlogImage>, BlogImageManager>();
builder.Services.AddScoped<IDataRepository<Caracteristique>, CaracteristiqueManager>();
builder.Services.AddScoped<IDataRepository2clues<CaracteristiqueProduit>, CaracteristiqueProduitManager>();
builder.Services.AddScoped<IDataRepository<Categorie>, CategorieManager>();
builder.Services.AddScoped<IDataRepository<Club>, ClubManager>();
builder.Services.AddScoped<IColorisRepository, ColorisManager>();
builder.Services.AddScoped<IDataRepositoryWithoutStr<Commande>, CommandeManager>();
builder.Services.AddScoped<IDataRepositoryWithoutStr<Commentaire>, CommentaireManager>();
builder.Services.AddScoped<IDataRepository<Competition>, CompetitionManager>();
builder.Services.AddScoped<IDataRepository<Compte>, CompteManager>();
builder.Services.AddScoped<IDataRepository<Devis>, DevisManager>();
builder.Services.AddScoped<IDataRepository<Document>, DocumentManager>();
builder.Services.AddScoped<IDataRepositoryWithoutStr<Film>, FilmManager>();
builder.Services.AddScoped<IDataRepository<Genre>, GenreManager>();
builder.Services.AddScoped<IDataRepositoryWithoutStr<Image>, ImageManager>();
builder.Services.AddScoped<IDataRepository<InfosBancaires>, InfosBancairesManager>();
builder.Services.AddScoped<IJoueurRepository, JoueurManager>();
builder.Services.AddScoped<IDataRepository<Langue>, LangueManager>();
builder.Services.AddScoped<IDataRepositoryWithoutStr<LigneCommande>, LigneCommandeManager>();
builder.Services.AddScoped<IDataRepository<Livraison>, LivraisonManager>();
builder.Services.AddScoped<IDataRepositoryWithoutStr<Match>, MatchManager>();
builder.Services.AddScoped<IDataRepositoryWithoutStr<Media>, MediaManager>();
builder.Services.AddScoped<IDataRepository<Monnaie>, MonnaieManager>();
builder.Services.AddScoped<IDataRepository<Pays>, PaysManager>();
builder.Services.AddScoped<IDataRepository<Poste>, PosteManager>();
builder.Services.AddScoped<IDataRepositoryWithoutStr<Reglement>, ReglementManager>();
builder.Services.AddScoped<IDataRepositoryWithoutStr<Stock>, StockManager>();
builder.Services.AddScoped<IDataRepository<Taille>, TailleManager>();
builder.Services.AddScoped<IThemeRepository, ThemeManager>();
builder.Services.AddScoped<IDataRepository<Trophee>, TropheeManager>();
builder.Services.AddScoped<IDataRepositoryWithoutStr<VarianteProduit>, VarianteProduitManager>();
builder.Services.AddScoped<IDataRepository<Ville>, VilleManager>();



//Token
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
 {
     options.RequireHttpsMetadata = false;
     options.SaveToken = true;
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = builder.Configuration["Jwt:Issuer"],
         ValidAudience = builder.Configuration["Jwt:Audience"],
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])),
         ClockSkew = TimeSpan.Zero
     };
 });

//Gestion de l’autorisation
builder.Services.AddAuthorization(config =>
{
    config.AddPolicy(Policies.Admin, Policies.AdminPolicy());
    config.AddPolicy(Policies.User, Policies.UserPolicy());
});

// Le code suivant premet d'autoriser le site, qu'on développe en http, à accéder à l'api, en https.
// Cette façon de procéder n'est pas du tout sécurisée et il faudra supprimer ce code à la fin de la SAÉ
// TODO : supprimer/améliorer le code CORS 

const string CorsPolicyName = "CorsAllowPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsPolicyName, policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(CorsPolicyName);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
