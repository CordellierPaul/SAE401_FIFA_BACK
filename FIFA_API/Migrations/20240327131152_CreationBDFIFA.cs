using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FIFA_API.Migrations
{
    public partial class CreationBDFIFA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FifaDB");

            migrationBuilder.CreateTable(
                name: "t_e_action_act",
                schema: "FifaDB",
                columns: table => new
                {
                    act_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    act_type = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_act", x => x.act_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_activite_ati",
                schema: "FifaDB",
                columns: table => new
                {
                    ati_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ati_nom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ati", x => x.ati_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_album_alb",
                schema: "FifaDB",
                columns: table => new
                {
                    alb_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    alb_date_heure = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "now()"),
                    alb_titre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    alb_resume = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_alb", x => x.alb_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_article_art",
                schema: "FifaDB",
                columns: table => new
                {
                    art_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    art_dateheure = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    art_titre = table.Column<string>(type: "text", nullable: false),
                    art_resume = table.Column<string>(type: "text", nullable: false),
                    art_texte = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_art", x => x.art_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_caracteristique_car",
                schema: "FifaDB",
                columns: table => new
                {
                    car_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    car_nom = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_car", x => x.car_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_categorie_cat",
                schema: "FifaDB",
                columns: table => new
                {
                    cat_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cat_nom = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat", x => x.cat_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_club_clb",
                schema: "FifaDB",
                columns: table => new
                {
                    clb_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clb_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    clb_initiales = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_clb", x => x.clb_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_coloris_clr",
                schema: "FifaDB",
                columns: table => new
                {
                    clr_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clr_nom = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_clr", x => x.clr_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_competition_cpn",
                schema: "FifaDB",
                columns: table => new
                {
                    cpn_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cpn_nom = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cpn", x => x.cpn_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_compte_cpt",
                schema: "FifaDB",
                columns: table => new
                {
                    cpt_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cpt_email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cpt_login = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    cpt_mdp = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    cpt_dateconnexion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    cpt_annonces = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    cpt_typecompte = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cpt", x => x.cpt_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_document_doc",
                schema: "FifaDB",
                columns: table => new
                {
                    doc_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    doc_dateheure = table.Column<DateTime>(type: "date", nullable: false),
                    doc_titre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    doc_resume = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    doc_lienpdf = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_doc", x => x.doc_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_genre_gen",
                schema: "FifaDB",
                columns: table => new
                {
                    gen_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    gen_nom = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_gen", x => x.gen_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_langue_lng",
                schema: "FifaDB",
                columns: table => new
                {
                    lng_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lng_nom = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lng", x => x.lng_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_livraison_liv",
                schema: "FifaDB",
                columns: table => new
                {
                    liv_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    liv_type = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    liv_prix = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_liv", x => x.liv_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_media_med",
                schema: "FifaDB",
                columns: table => new
                {
                    med_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    med_url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_med", x => x.med_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_monnaie_mon",
                schema: "FifaDB",
                columns: table => new
                {
                    mon_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mon_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    mon_symbole = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mon", x => x.mon_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_pays_pay",
                schema: "FifaDB",
                columns: table => new
                {
                    pay_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pay_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pay", x => x.pay_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_poste_pos",
                schema: "FifaDB",
                columns: table => new
                {
                    pos_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pos_libelle = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pos", x => x.pos_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_taille_tai",
                schema: "FifaDB",
                columns: table => new
                {
                    tai_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tai_libelle = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tai", x => x.tai_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_theme_the",
                schema: "FifaDB",
                columns: table => new
                {
                    the_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    the_libelle = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_the", x => x.the_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_trophee_tro",
                schema: "FifaDB",
                columns: table => new
                {
                    tro_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tro_nom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tro", x => x.tro_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_blog_blg",
                schema: "FifaDB",
                columns: table => new
                {
                    blg_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    art_id = table.Column<int>(type: "integer", nullable: false),
                    blg_dateheure = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    blg_titre = table.Column<string>(type: "text", nullable: false),
                    blg_resume = table.Column<string>(type: "text", nullable: false),
                    blg_description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_blg", x => x.blg_id);
                    table.ForeignKey(
                        name: "fk_blg_art",
                        column: x => x.art_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_article_art",
                        principalColumn: "art_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_sous_categorie_sct",
                schema: "FifaDB",
                columns: table => new
                {
                    cat_parent = table.Column<int>(type: "integer", nullable: false),
                    cat_enfant = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sct", x => new { x.cat_parent, x.cat_enfant });
                    table.ForeignKey(
                        name: "fk_sct_catenf",
                        column: x => x.cat_enfant,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_categorie_cat",
                        principalColumn: "cat_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_sct_catpar",
                        column: x => x.cat_parent,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_categorie_cat",
                        principalColumn: "cat_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_match_mch",
                schema: "FifaDB",
                columns: table => new
                {
                    mch_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clb_domicileid = table.Column<int>(type: "integer", nullable: false),
                    clb_exterieurid = table.Column<int>(type: "integer", nullable: false),
                    mch_datematch = table.Column<DateTime>(type: "date", nullable: false),
                    mch_score_domicile = table.Column<int>(type: "integer", nullable: false),
                    mch_score_exterieur = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mch", x => x.mch_id);
                    table.ForeignKey(
                        name: "fk_mchdom_clb",
                        column: x => x.clb_domicileid,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_mchext_clb",
                        column: x => x.clb_exterieurid,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_film_flm",
                schema: "FifaDB",
                columns: table => new
                {
                    flm_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    med_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_flm", x => x.flm_id);
                    table.ForeignKey(
                        name: "fk_flm_med",
                        column: x => x.med_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_media_med",
                        principalColumn: "med_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_image_img",
                schema: "FifaDB",
                columns: table => new
                {
                    img_id = table.Column<int>(type: "integer", nullable: false),
                    img_url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_img", x => x.img_id);
                    table.ForeignKey(
                        name: "fk_img_med",
                        column: x => x.img_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_media_med",
                        principalColumn: "med_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_articlemedia_atm",
                schema: "FifaDB",
                columns: table => new
                {
                    art_id = table.Column<int>(type: "integer", nullable: false),
                    med_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_atm", x => new { x.art_id, x.med_id });
                    table.ForeignKey(
                        name: "fk_atm_art",
                        column: x => x.art_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_article_art",
                        principalColumn: "art_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_atm_med",
                        column: x => x.med_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_media_med",
                        principalColumn: "med_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_produit_pro",
                schema: "FifaDB",
                columns: table => new
                {
                    pro_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    gen_id = table.Column<int>(type: "integer", nullable: false),
                    cat_id = table.Column<int>(type: "integer", nullable: false),
                    pro_nom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    pro_description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    comp_id = table.Column<int>(type: "integer", nullable: true),
                    pay_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pro", x => x.pro_id);
                    table.ForeignKey(
                        name: "fk_pro_cat",
                        column: x => x.cat_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_categorie_cat",
                        principalColumn: "cat_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_pro_cpn",
                        column: x => x.comp_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_competition_cpn",
                        principalColumn: "cpn_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_pro_gen",
                        column: x => x.gen_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_genre_gen",
                        principalColumn: "gen_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_pro_pay",
                        column: x => x.pay_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_pays_pay",
                        principalColumn: "pay_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_ville_vil",
                schema: "FifaDB",
                columns: table => new
                {
                    vil_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pay_id = table.Column<int>(type: "integer", nullable: false),
                    vil_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    vil_codepostal = table.Column<char>(type: "char(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vil", x => x.vil_id);
                    table.ForeignKey(
                        name: "fk_vil_pay",
                        column: x => x.pay_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_pays_pay",
                        principalColumn: "pay_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_albumimage_ali",
                schema: "FifaDB",
                columns: table => new
                {
                    alb_id = table.Column<int>(type: "integer", nullable: false),
                    img_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ali", x => new { x.alb_id, x.img_id });
                    table.ForeignKey(
                        name: "fk_ali_alb",
                        column: x => x.alb_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_album_alb",
                        principalColumn: "alb_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ali_img",
                        column: x => x.img_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_image_img",
                        principalColumn: "img_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_blogimage_bli",
                schema: "FifaDB",
                columns: table => new
                {
                    blg_id = table.Column<int>(type: "integer", nullable: false),
                    img_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bli", x => new { x.blg_id, x.img_id });
                    table.ForeignKey(
                        name: "fk_bli_blg",
                        column: x => x.blg_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_blog_blg",
                        principalColumn: "blg_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_bli_img",
                        column: x => x.img_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_image_img",
                        principalColumn: "img_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_variante_produit_vpd",
                schema: "FifaDB",
                columns: table => new
                {
                    vpd_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pro_id = table.Column<int>(type: "integer", nullable: false),
                    clr_id = table.Column<int>(type: "integer", nullable: false),
                    vpd_prix = table.Column<decimal>(type: "decimal", nullable: false),
                    vpd_promo = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vpd", x => x.vpd_id);
                    table.ForeignKey(
                        name: "fk_vpd_clr",
                        column: x => x.clr_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_coloris_clr",
                        principalColumn: "clr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_vpd_pro",
                        column: x => x.pro_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_produit_pro",
                        principalColumn: "pro_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_caracteristique_produit_cpd",
                schema: "FifaDB",
                columns: table => new
                {
                    car_id = table.Column<int>(type: "integer", nullable: false),
                    pro_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cpd", x => new { x.car_id, x.pro_id });
                    table.ForeignKey(
                        name: "fk_cpd_car",
                        column: x => x.car_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_caracteristique_car",
                        principalColumn: "car_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_cpd_pro",
                        column: x => x.pro_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_produit_pro",
                        principalColumn: "pro_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_produit_similaire_prs",
                schema: "FifaDB",
                columns: table => new
                {
                    pro_un_id = table.Column<int>(type: "integer", nullable: false),
                    pro_deux_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_prs", x => new { x.pro_un_id, x.pro_deux_id });
                    table.ForeignKey(
                        name: "fk_prs_pro_deux",
                        column: x => x.pro_deux_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_produit_pro",
                        principalColumn: "pro_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_prs_pro_un",
                        column: x => x.pro_un_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_produit_pro",
                        principalColumn: "pro_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_adresse_adr",
                schema: "FifaDB",
                columns: table => new
                {
                    adr_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    adr_rue = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    vil_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_adr", x => x.adr_id);
                    table.ForeignKey(
                        name: "fk_vil_adr",
                        column: x => x.vil_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_ville_vil",
                        principalColumn: "vil_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_joueur_jou",
                schema: "FifaDB",
                columns: table => new
                {
                    jou_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    jou_datenaissance = table.Column<DateTime>(type: "date", nullable: false),
                    pos_id = table.Column<int>(type: "integer", nullable: false),
                    clb_id = table.Column<int>(type: "integer", nullable: false),
                    vil_id = table.Column<int>(type: "integer", nullable: false),
                    jou_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    jou_prenom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    jou_pied = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    jou_poids = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    jou_taille = table.Column<int>(type: "integer", nullable: false),
                    jou_description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_jou", x => x.jou_id);
                    table.ForeignKey(
                        name: "fk_jou_clb",
                        column: x => x.clb_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_jou_pos",
                        column: x => x.pos_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_poste_pos",
                        principalColumn: "pos_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_jou_vil",
                        column: x => x.vil_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_ville_vil",
                        principalColumn: "vil_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_stock_stk",
                schema: "FifaDB",
                columns: table => new
                {
                    stk_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tai_id = table.Column<int>(type: "integer", nullable: false),
                    vpd_id = table.Column<int>(type: "integer", nullable: false),
                    stk_quantitestockee = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stk", x => x.stk_id);
                    table.ForeignKey(
                        name: "fk_stk_tai",
                        column: x => x.tai_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_taille_tai",
                        principalColumn: "tai_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_stk_vpd",
                        column: x => x.vpd_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_variante_produit_vpd",
                        principalColumn: "vpd_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_imagevariante_imv",
                schema: "FifaDB",
                columns: table => new
                {
                    vpd_id = table.Column<int>(type: "integer", nullable: false),
                    img_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_imv", x => new { x.img_id, x.vpd_id });
                    table.ForeignKey(
                        name: "fk_imv_img",
                        column: x => x.img_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_image_img",
                        principalColumn: "img_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_imv_vpd",
                        column: x => x.vpd_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_variante_produit_vpd",
                        principalColumn: "vpd_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_utilisateur_utl",
                schema: "FifaDB",
                columns: table => new
                {
                    utl_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    utl_prenom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    adr_id = table.Column<int>(type: "integer", nullable: true),
                    utl_datenaissance = table.Column<DateTime>(type: "date", nullable: false),
                    com_id = table.Column<int>(type: "integer", nullable: true),
                    mon_id = table.Column<int>(type: "integer", nullable: false),
                    lan_id = table.Column<int>(type: "integer", nullable: false),
                    pay_paysnaissance_id = table.Column<int>(type: "integer", nullable: false),
                    pay_paysfavori_id = table.Column<int>(type: "integer", nullable: true),
                    utl_nomacheteur = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    utl_telacheteur = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    act_id = table.Column<int>(type: "integer", nullable: true),
                    soc_id = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    utl_numtva = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_utl", x => x.utl_id);
                    table.ForeignKey(
                        name: "fk_pay_utl_pays_favori",
                        column: x => x.pay_paysfavori_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_pays_pay",
                        principalColumn: "pay_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_pay_utl_pays_naissance",
                        column: x => x.pay_paysnaissance_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_pays_pay",
                        principalColumn: "pay_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_utl_act",
                        column: x => x.act_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_activite_ati",
                        principalColumn: "ati_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_utl_adr",
                        column: x => x.adr_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_adresse_adr",
                        principalColumn: "adr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_utl_cpt",
                        column: x => x.com_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_compte_cpt",
                        principalColumn: "cpt_id");
                    table.ForeignKey(
                        name: "fk_utl_lng",
                        column: x => x.lan_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_langue_lng",
                        principalColumn: "lng_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_utl_mon",
                        column: x => x.mon_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_monnaie_mon",
                        principalColumn: "mon_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_anecdote_anc",
                schema: "FifaDB",
                columns: table => new
                {
                    anc_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    jou_id = table.Column<int>(type: "integer", nullable: false),
                    anc_question = table.Column<string>(type: "text", nullable: false),
                    anc_reponse = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_anc", x => x.anc_id);
                    table.ForeignKey(
                        name: "fk_anc_jou",
                        column: x => x.jou_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_joueur_jou",
                        principalColumn: "jou_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_articlejoueur_atj",
                schema: "FifaDB",
                columns: table => new
                {
                    art_id = table.Column<int>(type: "integer", nullable: false),
                    jou_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_atj", x => new { x.art_id, x.jou_id });
                    table.ForeignKey(
                        name: "fk_atj_art",
                        column: x => x.art_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_article_art",
                        principalColumn: "art_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_atj_jou",
                        column: x => x.jou_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_joueur_jou",
                        principalColumn: "jou_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_image_joueur_imj",
                schema: "FifaDB",
                columns: table => new
                {
                    img_id = table.Column<int>(type: "integer", nullable: false),
                    jou_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_imj", x => new { x.img_id, x.jou_id });
                    table.ForeignKey(
                        name: "fk_imj_img",
                        column: x => x.img_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_image_img",
                        principalColumn: "img_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_imj_jou",
                        column: x => x.jou_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_joueur_jou",
                        principalColumn: "jou_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_joueur_theme_jot",
                schema: "FifaDB",
                columns: table => new
                {
                    the_id = table.Column<int>(type: "integer", nullable: false),
                    jou_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_jot", x => new { x.the_id, x.jou_id });
                    table.ForeignKey(
                        name: "fk_jot_jou",
                        column: x => x.jou_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_joueur_jou",
                        principalColumn: "jou_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_jot_the",
                        column: x => x.the_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_theme_the",
                        principalColumn: "the_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_match_joue_mtj",
                schema: "FifaDB",
                columns: table => new
                {
                    jou_id = table.Column<int>(type: "integer", nullable: false),
                    mch_id = table.Column<int>(type: "integer", nullable: false),
                    mtj_nbbuts = table.Column<int>(type: "integer", nullable: false),
                    mtj_nbminutes = table.Column<int>(type: "integer", nullable: false),
                    mtj_titularisation = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    mtj_selection = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mtj", x => new { x.jou_id, x.mch_id });
                    table.ForeignKey(
                        name: "fk_mtj_jou",
                        column: x => x.jou_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_joueur_jou",
                        principalColumn: "jou_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_mtj_mch",
                        column: x => x.mch_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_match_mch",
                        principalColumn: "mch_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_remporte_rem",
                schema: "FifaDB",
                columns: table => new
                {
                    jou_id = table.Column<int>(type: "integer", nullable: false),
                    tro_id = table.Column<int>(type: "integer", nullable: false),
                    rem_annee = table.Column<char>(type: "char(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rem", x => new { x.jou_id, x.tro_id, x.rem_annee });
                    table.ForeignKey(
                        name: "fk_rem_jou",
                        column: x => x.jou_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_joueur_jou",
                        principalColumn: "jou_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_rem_tro",
                        column: x => x.tro_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_trophee_tro",
                        principalColumn: "tro_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_commande_cmd",
                schema: "FifaDB",
                columns: table => new
                {
                    cmd_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    utl_id = table.Column<int>(type: "integer", nullable: false),
                    adr_id = table.Column<int>(type: "integer", nullable: false),
                    liv_id = table.Column<int>(type: "integer", nullable: false),
                    cmd_prix = table.Column<decimal>(type: "numeric", nullable: false),
                    cmd_datecommande = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    cmd_etatcommande = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    cmd_domicile = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    cmd_datelivraison = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cmd", x => x.cmd_id);
                    table.ForeignKey(
                        name: "fk_cmd_adr",
                        column: x => x.adr_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_adresse_adr",
                        principalColumn: "adr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_cmd_liv",
                        column: x => x.liv_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_livraison_liv",
                        principalColumn: "liv_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_cmd_utl",
                        column: x => x.utl_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_utilisateur_utl",
                        principalColumn: "utl_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_commentaire_com",
                schema: "FifaDB",
                columns: table => new
                {
                    com_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    com_dateheure = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    utl_id = table.Column<int>(type: "integer", nullable: false),
                    com_texte = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    com_com_id = table.Column<int>(type: "integer", nullable: true),
                    doc_id = table.Column<int>(type: "integer", nullable: true),
                    alb_id = table.Column<int>(type: "integer", nullable: true),
                    blg_id = table.Column<int>(type: "integer", nullable: true),
                    art_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_com", x => x.com_id);
                    table.ForeignKey(
                        name: "fk_com_alb",
                        column: x => x.alb_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_album_alb",
                        principalColumn: "alb_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_com_art",
                        column: x => x.art_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_article_art",
                        principalColumn: "art_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_com_blg",
                        column: x => x.blg_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_blog_blg",
                        principalColumn: "blg_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_com_com",
                        column: x => x.com_com_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_commentaire_com",
                        principalColumn: "com_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_com_doc",
                        column: x => x.doc_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_document_doc",
                        principalColumn: "doc_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_com_utl",
                        column: x => x.utl_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_utilisateur_utl",
                        principalColumn: "utl_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_devis_dev",
                schema: "FifaDB",
                columns: table => new
                {
                    dev_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    utl_id = table.Column<int>(type: "integer", nullable: false),
                    pro_id = table.Column<int>(type: "integer", nullable: false),
                    dev_sujet = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    dev_message = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dev", x => x.dev_id);
                    table.ForeignKey(
                        name: "fk_dev_pro",
                        column: x => x.pro_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_produit_pro",
                        principalColumn: "pro_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_dev_utl",
                        column: x => x.utl_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_utilisateur_utl",
                        principalColumn: "utl_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_formulaireaide_foa",
                schema: "FifaDB",
                columns: table => new
                {
                    foa_id = table.Column<int>(type: "integer", nullable: false),
                    act_id = table.Column<int>(type: "integer", nullable: false),
                    utl_id = table.Column<int>(type: "integer", nullable: false),
                    foa_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    foa_telephone = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    foa_question = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_foa", x => x.foa_id);
                    table.ForeignKey(
                        name: "fk_foa_act",
                        column: x => x.act_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_action_act",
                        principalColumn: "act_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_foa_utl",
                        column: x => x.foa_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_utilisateur_utl",
                        principalColumn: "utl_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_infos_bancaires_inb",
                schema: "FifaDB",
                columns: table => new
                {
                    inb_id = table.Column<int>(type: "integer", nullable: false),
                    inb_numcarte = table.Column<string>(type: "character varying(228)", maxLength: 228, nullable: false),
                    inb_nomcarte = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    inb_moisexpiration = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    inb_anneeexpiration = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inb", x => x.inb_id);
                    table.ForeignKey(
                        name: "fk_inb_utl",
                        column: x => x.inb_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_utilisateur_utl",
                        principalColumn: "utl_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_vote_vot",
                schema: "FifaDB",
                columns: table => new
                {
                    utl_id = table.Column<int>(type: "integer", nullable: false),
                    the_id = table.Column<int>(type: "integer", nullable: false),
                    jou_id = table.Column<int>(type: "integer", nullable: false),
                    vot_note = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vot", x => new { x.utl_id, x.the_id, x.jou_id });
                    table.ForeignKey(
                        name: "fk_vot_jou",
                        column: x => x.jou_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_joueur_jou",
                        principalColumn: "jou_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_vot_the",
                        column: x => x.the_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_theme_the",
                        principalColumn: "the_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_vot_utl",
                        column: x => x.utl_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_utilisateur_utl",
                        principalColumn: "utl_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_like_album_lab",
                schema: "FifaDB",
                columns: table => new
                {
                    alb_id = table.Column<int>(type: "integer", nullable: false),
                    utl_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lab", x => new { x.alb_id, x.utl_id });
                    table.ForeignKey(
                        name: "fk_lab_alb",
                        column: x => x.alb_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_album_alb",
                        principalColumn: "alb_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_lab_utl",
                        column: x => x.utl_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_utilisateur_utl",
                        principalColumn: "utl_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_like_article_lar",
                schema: "FifaDB",
                columns: table => new
                {
                    art_id = table.Column<int>(type: "integer", nullable: false),
                    utl_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lar", x => new { x.art_id, x.utl_id });
                    table.ForeignKey(
                        name: "fk_lar_art",
                        column: x => x.art_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_article_art",
                        principalColumn: "art_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_lar_utl",
                        column: x => x.utl_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_utilisateur_utl",
                        principalColumn: "utl_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_like_blog_lbg",
                schema: "FifaDB",
                columns: table => new
                {
                    blg_id = table.Column<int>(type: "integer", nullable: false),
                    utl_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lbg", x => new { x.blg_id, x.utl_id });
                    table.ForeignKey(
                        name: "fk_lbg_blg",
                        column: x => x.blg_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_blog_blg",
                        principalColumn: "blg_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_lbg_utl",
                        column: x => x.utl_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_utilisateur_utl",
                        principalColumn: "utl_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_like_document_ldc",
                schema: "FifaDB",
                columns: table => new
                {
                    doc_id = table.Column<int>(type: "integer", nullable: false),
                    utl_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ldc", x => new { x.doc_id, x.utl_id });
                    table.ForeignKey(
                        name: "fk_ldc_doc",
                        column: x => x.doc_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_document_doc",
                        principalColumn: "doc_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ldc_utl",
                        column: x => x.utl_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_utilisateur_utl",
                        principalColumn: "utl_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_ligne_commande_lcd",
                schema: "FifaDB",
                columns: table => new
                {
                    lcd_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cmd_id = table.Column<int>(type: "integer", nullable: false),
                    lcd_num = table.Column<int>(type: "integer", nullable: false),
                    vpd_id = table.Column<int>(type: "integer", nullable: false),
                    tai_id = table.Column<int>(type: "integer", nullable: false),
                    lcd_quantite = table.Column<int>(type: "integer", nullable: false),
                    lcd_prix = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lcd", x => x.lcd_id);
                    table.ForeignKey(
                        name: "fk_lcd_cmd",
                        column: x => x.cmd_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_commande_cmd",
                        principalColumn: "cmd_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_lcd_tai",
                        column: x => x.tai_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_taille_tai",
                        principalColumn: "tai_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_lcd_vpd",
                        column: x => x.vpd_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_variante_produit_vpd",
                        principalColumn: "vpd_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_reglement_reg",
                schema: "FifaDB",
                columns: table => new
                {
                    tra_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    com_id = table.Column<int>(type: "integer", nullable: false),
                    reg_montant = table.Column<decimal>(type: "numeric", nullable: false),
                    reg_date = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reg", x => x.tra_id);
                    table.ForeignKey(
                        name: "fk_reg_cmd",
                        column: x => x.com_id,
                        principalSchema: "FifaDB",
                        principalTable: "t_e_commande_cmd",
                        principalColumn: "cmd_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_e_adresse_adr_vil_id",
                schema: "FifaDB",
                table: "t_e_adresse_adr",
                column: "vil_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_anecdote_anc_jou_id",
                schema: "FifaDB",
                table: "t_e_anecdote_anc",
                column: "jou_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_blog_blg_art_id",
                schema: "FifaDB",
                table: "t_e_blog_blg",
                column: "art_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commande_cmd_adr_id",
                schema: "FifaDB",
                table: "t_e_commande_cmd",
                column: "adr_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commande_cmd_liv_id",
                schema: "FifaDB",
                table: "t_e_commande_cmd",
                column: "liv_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commande_cmd_utl_id",
                schema: "FifaDB",
                table: "t_e_commande_cmd",
                column: "utl_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commentaire_com_alb_id",
                schema: "FifaDB",
                table: "t_e_commentaire_com",
                column: "alb_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commentaire_com_art_id",
                schema: "FifaDB",
                table: "t_e_commentaire_com",
                column: "art_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commentaire_com_blg_id",
                schema: "FifaDB",
                table: "t_e_commentaire_com",
                column: "blg_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commentaire_com_com_com_id",
                schema: "FifaDB",
                table: "t_e_commentaire_com",
                column: "com_com_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commentaire_com_doc_id",
                schema: "FifaDB",
                table: "t_e_commentaire_com",
                column: "doc_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commentaire_com_utl_id",
                schema: "FifaDB",
                table: "t_e_commentaire_com",
                column: "utl_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_compte_cpt_cpt_email",
                schema: "FifaDB",
                table: "t_e_compte_cpt",
                column: "cpt_email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_devis_dev_pro_id",
                schema: "FifaDB",
                table: "t_e_devis_dev",
                column: "pro_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_devis_dev_utl_id",
                schema: "FifaDB",
                table: "t_e_devis_dev",
                column: "utl_id");

            migrationBuilder.CreateIndex(
                name: "uq_doc_lienpdf",
                schema: "FifaDB",
                table: "t_e_document_doc",
                column: "doc_lienpdf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_film_flm_med_id",
                schema: "FifaDB",
                table: "t_e_film_flm",
                column: "med_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_formulaireaide_foa_act_id",
                schema: "FifaDB",
                table: "t_e_formulaireaide_foa",
                column: "act_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_joueur_jou_clb_id",
                schema: "FifaDB",
                table: "t_e_joueur_jou",
                column: "clb_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_joueur_jou_pos_id",
                schema: "FifaDB",
                table: "t_e_joueur_jou",
                column: "pos_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_joueur_jou_vil_id",
                schema: "FifaDB",
                table: "t_e_joueur_jou",
                column: "vil_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_ligne_commande_lcd_cmd_id",
                schema: "FifaDB",
                table: "t_e_ligne_commande_lcd",
                column: "cmd_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_ligne_commande_lcd_tai_id",
                schema: "FifaDB",
                table: "t_e_ligne_commande_lcd",
                column: "tai_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_ligne_commande_lcd_vpd_id",
                schema: "FifaDB",
                table: "t_e_ligne_commande_lcd",
                column: "vpd_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_match_mch_clb_domicileid",
                schema: "FifaDB",
                table: "t_e_match_mch",
                column: "clb_domicileid");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_match_mch_clb_exterieurid",
                schema: "FifaDB",
                table: "t_e_match_mch",
                column: "clb_exterieurid");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_produit_pro_cat_id",
                schema: "FifaDB",
                table: "t_e_produit_pro",
                column: "cat_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_produit_pro_comp_id",
                schema: "FifaDB",
                table: "t_e_produit_pro",
                column: "comp_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_produit_pro_gen_id",
                schema: "FifaDB",
                table: "t_e_produit_pro",
                column: "gen_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_produit_pro_pay_id",
                schema: "FifaDB",
                table: "t_e_produit_pro",
                column: "pay_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_reglement_reg_com_id",
                schema: "FifaDB",
                table: "t_e_reglement_reg",
                column: "com_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_stock_stk_tai_id",
                schema: "FifaDB",
                table: "t_e_stock_stk",
                column: "tai_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_stock_stk_vpd_id",
                schema: "FifaDB",
                table: "t_e_stock_stk",
                column: "vpd_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_utilisateur_utl_act_id",
                schema: "FifaDB",
                table: "t_e_utilisateur_utl",
                column: "act_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_utilisateur_utl_adr_id",
                schema: "FifaDB",
                table: "t_e_utilisateur_utl",
                column: "adr_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_utilisateur_utl_lan_id",
                schema: "FifaDB",
                table: "t_e_utilisateur_utl",
                column: "lan_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_utilisateur_utl_mon_id",
                schema: "FifaDB",
                table: "t_e_utilisateur_utl",
                column: "mon_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_utilisateur_utl_pay_paysfavori_id",
                schema: "FifaDB",
                table: "t_e_utilisateur_utl",
                column: "pay_paysfavori_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_utilisateur_utl_pay_paysnaissance_id",
                schema: "FifaDB",
                table: "t_e_utilisateur_utl",
                column: "pay_paysnaissance_id");

            migrationBuilder.CreateIndex(
                name: "uq_utl_idcompte",
                schema: "FifaDB",
                table: "t_e_utilisateur_utl",
                column: "com_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_utl_numSociete",
                schema: "FifaDB",
                table: "t_e_utilisateur_utl",
                column: "soc_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_utl_numtva",
                schema: "FifaDB",
                table: "t_e_utilisateur_utl",
                column: "utl_numtva",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_utl_telacheteur",
                schema: "FifaDB",
                table: "t_e_utilisateur_utl",
                column: "utl_telacheteur",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_variante_produit_vpd_clr_id",
                schema: "FifaDB",
                table: "t_e_variante_produit_vpd",
                column: "clr_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_variante_produit_vpd_pro_id",
                schema: "FifaDB",
                table: "t_e_variante_produit_vpd",
                column: "pro_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_ville_vil_pay_id",
                schema: "FifaDB",
                table: "t_e_ville_vil",
                column: "pay_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_vote_vot_jou_id",
                schema: "FifaDB",
                table: "t_e_vote_vot",
                column: "jou_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_vote_vot_the_id",
                schema: "FifaDB",
                table: "t_e_vote_vot",
                column: "the_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_albumimage_ali_img_id",
                schema: "FifaDB",
                table: "t_j_albumimage_ali",
                column: "img_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_articlejoueur_atj_jou_id",
                schema: "FifaDB",
                table: "t_j_articlejoueur_atj",
                column: "jou_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_articlemedia_atm_med_id",
                schema: "FifaDB",
                table: "t_j_articlemedia_atm",
                column: "med_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_blogimage_bli_img_id",
                schema: "FifaDB",
                table: "t_j_blogimage_bli",
                column: "img_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_caracteristique_produit_cpd_pro_id",
                schema: "FifaDB",
                table: "t_j_caracteristique_produit_cpd",
                column: "pro_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_image_joueur_imj_jou_id",
                schema: "FifaDB",
                table: "t_j_image_joueur_imj",
                column: "jou_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_imagevariante_imv_vpd_id",
                schema: "FifaDB",
                table: "t_j_imagevariante_imv",
                column: "vpd_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_joueur_theme_jot_jou_id",
                schema: "FifaDB",
                table: "t_j_joueur_theme_jot",
                column: "jou_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_like_album_lab_utl_id",
                schema: "FifaDB",
                table: "t_j_like_album_lab",
                column: "utl_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_like_article_lar_utl_id",
                schema: "FifaDB",
                table: "t_j_like_article_lar",
                column: "utl_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_like_blog_lbg_utl_id",
                schema: "FifaDB",
                table: "t_j_like_blog_lbg",
                column: "utl_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_like_document_ldc_utl_id",
                schema: "FifaDB",
                table: "t_j_like_document_ldc",
                column: "utl_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_match_joue_mtj_mch_id",
                schema: "FifaDB",
                table: "t_j_match_joue_mtj",
                column: "mch_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_produit_similaire_prs_pro_deux_id",
                schema: "FifaDB",
                table: "t_j_produit_similaire_prs",
                column: "pro_deux_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_remporte_rem_tro_id",
                schema: "FifaDB",
                table: "t_j_remporte_rem",
                column: "tro_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_sous_categorie_sct_cat_enfant",
                schema: "FifaDB",
                table: "t_j_sous_categorie_sct",
                column: "cat_enfant");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_e_anecdote_anc",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_commentaire_com",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_devis_dev",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_film_flm",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_formulaireaide_foa",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_infos_bancaires_inb",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_ligne_commande_lcd",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_reglement_reg",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_stock_stk",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_vote_vot",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_j_albumimage_ali",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_j_articlejoueur_atj",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_j_articlemedia_atm",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_j_blogimage_bli",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_j_caracteristique_produit_cpd",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_j_image_joueur_imj",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_j_imagevariante_imv",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_j_joueur_theme_jot",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_j_like_album_lab",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_j_like_article_lar",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_j_like_blog_lbg",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_j_like_document_ldc",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_j_match_joue_mtj",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_j_produit_similaire_prs",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_j_remporte_rem",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_j_sous_categorie_sct",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_action_act",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_commande_cmd",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_taille_tai",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_caracteristique_car",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_image_img",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_variante_produit_vpd",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_theme_the",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_album_alb",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_blog_blg",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_document_doc",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_match_mch",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_joueur_jou",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_trophee_tro",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_livraison_liv",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_utilisateur_utl",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_media_med",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_coloris_clr",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_produit_pro",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_article_art",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_club_clb",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_poste_pos",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_activite_ati",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_adresse_adr",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_compte_cpt",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_langue_lng",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_monnaie_mon",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_categorie_cat",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_competition_cpn",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_genre_gen",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_ville_vil",
                schema: "FifaDB");

            migrationBuilder.DropTable(
                name: "t_e_pays_pay",
                schema: "FifaDB");
        }
    }
}
