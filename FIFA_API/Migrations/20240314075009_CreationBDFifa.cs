﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FIFA_API.Migrations
{
    public partial class CreationBDFifa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_e_action_act",
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
                columns: table => new
                {
                    alb_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    alb_date_heure = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    alb_titre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    alb_resume = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_alb", x => x.alb_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_article_art",
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
                name: "t_e_blog_blg",
                columns: table => new
                {
                    blg_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    art_id = table.Column<int>(type: "integer", nullable: false),
                    blg_dateheure = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    blg_titre = table.Column<string>(type: "text", nullable: false),
                    blg_resume = table.Column<string>(type: "text", nullable: false),
                    blg_descriptionblog = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_blg", x => x.blg_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_caracteristique_car",
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
                columns: table => new
                {
                    cpt_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cpt_email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cpt_login = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    cpt_mdp = table.Column<string>(type: "char(128)", nullable: true),
                    cpt_dateconnexion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    cpt_annonces = table.Column<bool>(type: "boolean", nullable: false),
                    cpt_offres = table.Column<bool>(type: "boolean", nullable: false),
                    cpt_typecompte = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cpt", x => x.cpt_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_document_doc",
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
                columns: table => new
                {
                    lng_num = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lng_nom = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lng", x => x.lng_num);
                });

            migrationBuilder.CreateTable(
                name: "t_e_livraison_liv",
                columns: table => new
                {
                    liv_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    liv_type = table.Column<string>(type: "text", nullable: false),
                    liv_prix = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_liv", x => x.liv_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_media_med",
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
                columns: table => new
                {
                    mon_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mon_nom = table.Column<string>(type: "text", nullable: false),
                    mon_symbole = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mon", x => x.mon_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_pays_pay",
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
                columns: table => new
                {
                    pos_num = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pos_libelle = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pos", x => x.pos_num);
                });

            migrationBuilder.CreateTable(
                name: "t_e_taille_tai",
                columns: table => new
                {
                    tai_num = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tai_libelle = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tai", x => x.tai_num);
                });

            migrationBuilder.CreateTable(
                name: "t_e_trophee_tro",
                columns: table => new
                {
                    tro_num = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tro_nom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tro", x => x.tro_num);
                });

            migrationBuilder.CreateTable(
                name: "t_j_theme_the",
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
                name: "t_j_sous_categorie_sct",
                columns: table => new
                {
                    cat_parent = table.Column<int>(type: "integer", nullable: false),
                    cat_enfant = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sct", x => new { x.cat_parent, x.cat_enfant });
                    table.ForeignKey(
                        name: "FK_t_j_sous_categorie_sct_t_e_categorie_cat_cat_enfant",
                        column: x => x.cat_enfant,
                        principalTable: "t_e_categorie_cat",
                        principalColumn: "cat_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_j_sous_categorie_sct_t_e_categorie_cat_cat_parent",
                        column: x => x.cat_parent,
                        principalTable: "t_e_categorie_cat",
                        principalColumn: "cat_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_match_mch",
                columns: table => new
                {
                    mch_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clb_domicileid = table.Column<int>(type: "integer", nullable: false),
                    clb_exterieurid = table.Column<int>(type: "integer", nullable: false),
                    mch_datematch = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    mch_scoredomicile = table.Column<int>(type: "integer", nullable: false),
                    mch_ScoreExterieur = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mch", x => x.mch_id);
                    table.ForeignKey(
                        name: "fk_mchdom_clb",
                        column: x => x.clb_domicileid,
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_mchext_clb",
                        column: x => x.clb_exterieurid,
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_film_flm",
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
                        principalTable: "t_e_media_med",
                        principalColumn: "med_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_image_img",
                columns: table => new
                {
                    img_id = table.Column<int>(type: "integer", nullable: false),
                    img_url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_img", x => x.img_id);
                    table.ForeignKey(
                        name: "FK_t_e_image_img_t_e_media_med_img_id",
                        column: x => x.img_id,
                        principalTable: "t_e_media_med",
                        principalColumn: "med_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_articlemedia_atm",
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
                        principalTable: "t_e_article_art",
                        principalColumn: "art_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_atm_med",
                        column: x => x.med_id,
                        principalTable: "t_e_media_med",
                        principalColumn: "med_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_produit_pro",
                columns: table => new
                {
                    pro_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    gen_id = table.Column<int>(type: "integer", nullable: false),
                    cat_num = table.Column<int>(type: "integer", nullable: false),
                    pro_nom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    pro_description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    comp_id = table.Column<int>(type: "integer", nullable: false),
                    pay_num = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pro", x => x.pro_id);
                    table.ForeignKey(
                        name: "fk_pro_cat",
                        column: x => x.cat_num,
                        principalTable: "t_e_categorie_cat",
                        principalColumn: "cat_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_pro_cpn",
                        column: x => x.comp_id,
                        principalTable: "t_e_competition_cpn",
                        principalColumn: "cpn_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_pro_gen",
                        column: x => x.gen_id,
                        principalTable: "t_e_genre_gen",
                        principalColumn: "gen_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_pro_pay",
                        column: x => x.pay_num,
                        principalTable: "t_e_pays_pay",
                        principalColumn: "pay_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_ville_vil",
                columns: table => new
                {
                    vil_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pay_id = table.Column<int>(type: "integer", nullable: false),
                    vil_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    vil_codepostal = table.Column<char>(type: "char(5)", nullable: false),
                    PaysId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vil", x => x.vil_id);
                    table.ForeignKey(
                        name: "FK_t_e_ville_vil_t_e_pays_pay_pay_id",
                        column: x => x.pay_id,
                        principalTable: "t_e_pays_pay",
                        principalColumn: "pay_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_e_ville_vil_t_e_pays_pay_PaysId",
                        column: x => x.PaysId,
                        principalTable: "t_e_pays_pay",
                        principalColumn: "pay_id");
                });

            migrationBuilder.CreateTable(
                name: "t_j_albumimage_ali",
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
                        principalTable: "t_e_album_alb",
                        principalColumn: "alb_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ali_img",
                        column: x => x.img_id,
                        principalTable: "t_e_image_img",
                        principalColumn: "img_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_blogimage_bli",
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
                        principalTable: "t_e_blog_blg",
                        principalColumn: "blg_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_bli_img",
                        column: x => x.img_id,
                        principalTable: "t_e_image_img",
                        principalColumn: "img_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_variante_produit_vpd",
                columns: table => new
                {
                    vpd_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pro_id = table.Column<int>(type: "integer", nullable: false),
                    clr_id = table.Column<int>(type: "integer", nullable: false),
                    vpd_prixvariante = table.Column<decimal>(type: "decimal", nullable: false),
                    vpd_promo = table.Column<decimal>(type: "decimal", nullable: false),
                    ColorisId1 = table.Column<int>(type: "integer", nullable: true),
                    ProduitIdProduit = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vpd", x => x.vpd_id);
                    table.ForeignKey(
                        name: "FK_t_e_variante_produit_vpd_t_e_coloris_clr_clr_id",
                        column: x => x.clr_id,
                        principalTable: "t_e_coloris_clr",
                        principalColumn: "clr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_e_variante_produit_vpd_t_e_coloris_clr_ColorisId1",
                        column: x => x.ColorisId1,
                        principalTable: "t_e_coloris_clr",
                        principalColumn: "clr_id");
                    table.ForeignKey(
                        name: "FK_t_e_variante_produit_vpd_t_e_produit_pro_pro_id",
                        column: x => x.pro_id,
                        principalTable: "t_e_produit_pro",
                        principalColumn: "pro_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_e_variante_produit_vpd_t_e_produit_pro_ProduitIdProduit",
                        column: x => x.ProduitIdProduit,
                        principalTable: "t_e_produit_pro",
                        principalColumn: "pro_id");
                });

            migrationBuilder.CreateTable(
                name: "t_j_caracteristique_produit_cpd",
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
                        principalTable: "t_e_caracteristique_car",
                        principalColumn: "car_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_cpd_pro",
                        column: x => x.pro_id,
                        principalTable: "t_e_produit_pro",
                        principalColumn: "pro_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_produit_similaire_prs",
                columns: table => new
                {
                    pro_id_un = table.Column<int>(type: "integer", nullable: false),
                    pro_id_deux = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_prs", x => new { x.pro_id_un, x.pro_id_deux });
                    table.ForeignKey(
                        name: "fk_prs_pro_deux",
                        column: x => x.pro_id_deux,
                        principalTable: "t_e_produit_pro",
                        principalColumn: "pro_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_prs_pro_un",
                        column: x => x.pro_id_un,
                        principalTable: "t_e_produit_pro",
                        principalColumn: "pro_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_adresse_adr",
                columns: table => new
                {
                    adr_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    adr_rue = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    VilleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_adr", x => x.adr_id);
                    table.ForeignKey(
                        name: "pk_ali",
                        column: x => x.VilleId,
                        principalTable: "t_e_ville_vil",
                        principalColumn: "vil_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_joueur_jou",
                columns: table => new
                {
                    jou_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    jou_datenaissance = table.Column<DateTime>(type: "date", nullable: false),
                    jou_numposte = table.Column<int>(type: "integer", nullable: false),
                    clb_id = table.Column<int>(type: "integer", nullable: false),
                    vil_id = table.Column<int>(type: "integer", nullable: false),
                    jou_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    jou_prenom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    jou_pied = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    jou_poids = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    jou_taille = table.Column<int>(type: "integer", nullable: false),
                    jou_description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    ClubId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_jou", x => x.jou_id);
                    table.ForeignKey(
                        name: "FK_t_e_joueur_jou_t_e_club_clb_clb_id",
                        column: x => x.clb_id,
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_e_joueur_jou_t_e_club_clb_ClubId",
                        column: x => x.ClubId,
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id");
                    table.ForeignKey(
                        name: "FK_t_e_joueur_jou_t_e_poste_pos_jou_numposte",
                        column: x => x.jou_numposte,
                        principalTable: "t_e_poste_pos",
                        principalColumn: "pos_num",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_e_joueur_jou_t_e_ville_vil_vil_id",
                        column: x => x.vil_id,
                        principalTable: "t_e_ville_vil",
                        principalColumn: "vil_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_stock_stk",
                columns: table => new
                {
                    stk_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tai_num = table.Column<int>(type: "integer", nullable: false),
                    vpd_id = table.Column<int>(type: "integer", nullable: false),
                    stk_quantitestockee = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stk", x => x.stk_id);
                    table.ForeignKey(
                        name: "FK_t_e_stock_stk_t_e_taille_tai_tai_num",
                        column: x => x.tai_num,
                        principalTable: "t_e_taille_tai",
                        principalColumn: "tai_num",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_e_stock_stk_t_e_variante_produit_vpd_vpd_id",
                        column: x => x.vpd_id,
                        principalTable: "t_e_variante_produit_vpd",
                        principalColumn: "vpd_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_imagevariante_imv",
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
                        principalTable: "t_e_image_img",
                        principalColumn: "img_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_imv_vpd",
                        column: x => x.vpd_id,
                        principalTable: "t_e_variante_produit_vpd",
                        principalColumn: "vpd_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_utilisateur_utl",
                columns: table => new
                {
                    utl_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    utl_prenom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    adr_id = table.Column<int>(type: "integer", nullable: false),
                    utl_datenaissance = table.Column<DateTime>(type: "date", nullable: false),
                    com_id = table.Column<int>(type: "integer", nullable: false),
                    mon_id = table.Column<int>(type: "integer", nullable: false),
                    lan_id = table.Column<int>(type: "integer", nullable: false),
                    pay_paysnaissance_id = table.Column<int>(type: "integer", nullable: false),
                    pay_paysfavori_id = table.Column<int>(type: "integer", nullable: false),
                    utl_nomacheteur = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    utl_telacheteur = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    act_id = table.Column<int>(type: "integer", nullable: true),
                    soc_num = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    utl_numtva = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    AdresseId1 = table.Column<int>(type: "integer", nullable: true),
                    CompteId1 = table.Column<int>(type: "integer", nullable: true),
                    LangueNum = table.Column<int>(type: "integer", nullable: true),
                    MonnaieId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_utl", x => x.utl_id);
                    table.ForeignKey(
                        name: "fk_pay_utl_pays_favori",
                        column: x => x.pay_paysfavori_id,
                        principalTable: "t_e_pays_pay",
                        principalColumn: "pay_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_pay_utl_pays_nassance",
                        column: x => x.pay_paysnaissance_id,
                        principalTable: "t_e_pays_pay",
                        principalColumn: "pay_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_e_utilisateur_utl_t_e_activite_ati_act_id",
                        column: x => x.act_id,
                        principalTable: "t_e_activite_ati",
                        principalColumn: "ati_id");
                    table.ForeignKey(
                        name: "FK_t_e_utilisateur_utl_t_e_adresse_adr_adr_id",
                        column: x => x.adr_id,
                        principalTable: "t_e_adresse_adr",
                        principalColumn: "adr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_e_utilisateur_utl_t_e_adresse_adr_AdresseId1",
                        column: x => x.AdresseId1,
                        principalTable: "t_e_adresse_adr",
                        principalColumn: "adr_id");
                    table.ForeignKey(
                        name: "FK_t_e_utilisateur_utl_t_e_compte_cpt_com_id",
                        column: x => x.com_id,
                        principalTable: "t_e_compte_cpt",
                        principalColumn: "cpt_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_e_utilisateur_utl_t_e_compte_cpt_CompteId1",
                        column: x => x.CompteId1,
                        principalTable: "t_e_compte_cpt",
                        principalColumn: "cpt_id");
                    table.ForeignKey(
                        name: "FK_t_e_utilisateur_utl_t_e_langue_lng_lan_id",
                        column: x => x.lan_id,
                        principalTable: "t_e_langue_lng",
                        principalColumn: "lng_num",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_e_utilisateur_utl_t_e_langue_lng_LangueNum",
                        column: x => x.LangueNum,
                        principalTable: "t_e_langue_lng",
                        principalColumn: "lng_num");
                    table.ForeignKey(
                        name: "FK_t_e_utilisateur_utl_t_e_monnaie_mon_mon_id",
                        column: x => x.mon_id,
                        principalTable: "t_e_monnaie_mon",
                        principalColumn: "mon_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_e_utilisateur_utl_t_e_monnaie_mon_MonnaieId",
                        column: x => x.MonnaieId,
                        principalTable: "t_e_monnaie_mon",
                        principalColumn: "mon_id");
                });

            migrationBuilder.CreateTable(
                name: "t_e_anecdote_anc",
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
                        principalTable: "t_e_joueur_jou",
                        principalColumn: "jou_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_articlejoueur_atj",
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
                        principalTable: "t_e_article_art",
                        principalColumn: "art_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_atj_jou",
                        column: x => x.jou_id,
                        principalTable: "t_e_joueur_jou",
                        principalColumn: "jou_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_image_joueur_imj",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "integer", nullable: false),
                    JoueurId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_imj", x => new { x.ImageId, x.JoueurId });
                    table.ForeignKey(
                        name: "fk_imj_img",
                        column: x => x.ImageId,
                        principalTable: "t_e_image_img",
                        principalColumn: "img_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_imj_jou",
                        column: x => x.JoueurId,
                        principalTable: "t_e_joueur_jou",
                        principalColumn: "jou_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_joueur_theme_jot",
                columns: table => new
                {
                    the_num = table.Column<int>(type: "integer", nullable: false),
                    jou_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_jot", x => new { x.the_num, x.jou_id });
                    table.ForeignKey(
                        name: "fk_jot_jou",
                        column: x => x.jou_id,
                        principalTable: "t_e_joueur_jou",
                        principalColumn: "jou_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_jot_the",
                        column: x => x.the_num,
                        principalTable: "t_j_theme_the",
                        principalColumn: "the_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_match_joue_mtj",
                columns: table => new
                {
                    jou_id = table.Column<int>(type: "integer", nullable: false),
                    mch_id = table.Column<int>(type: "integer", nullable: false),
                    mtj_nbbuts = table.Column<int>(type: "integer", nullable: false),
                    mtj_nbminutes = table.Column<int>(type: "integer", nullable: false),
                    mtj_titularisation = table.Column<string>(type: "text", nullable: false),
                    mtj_selection = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mtj", x => new { x.jou_id, x.mch_id });
                    table.ForeignKey(
                        name: "fk_mtj_jou",
                        column: x => x.jou_id,
                        principalTable: "t_e_joueur_jou",
                        principalColumn: "jou_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_mtj_mch",
                        column: x => x.mch_id,
                        principalTable: "t_e_match_mch",
                        principalColumn: "mch_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_remporte_rem",
                columns: table => new
                {
                    jou_id = table.Column<int>(type: "integer", nullable: false),
                    tro_num = table.Column<int>(type: "integer", nullable: false),
                    rem_annee = table.Column<char>(type: "char(4)", nullable: false),
                    TropheeNumTrophee = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rem", x => new { x.jou_id, x.tro_num, x.rem_annee });
                    table.ForeignKey(
                        name: "FK_t_j_remporte_rem_t_e_joueur_jou_jou_id",
                        column: x => x.jou_id,
                        principalTable: "t_e_joueur_jou",
                        principalColumn: "jou_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_j_remporte_rem_t_e_trophee_tro_tro_num",
                        column: x => x.tro_num,
                        principalTable: "t_e_trophee_tro",
                        principalColumn: "tro_num",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_j_remporte_rem_t_e_trophee_tro_TropheeNumTrophee",
                        column: x => x.TropheeNumTrophee,
                        principalTable: "t_e_trophee_tro",
                        principalColumn: "tro_num");
                });

            migrationBuilder.CreateTable(
                name: "t_e_commande_cmd",
                columns: table => new
                {
                    cmd_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    utl_id = table.Column<int>(type: "integer", nullable: false),
                    adr_id = table.Column<int>(type: "integer", nullable: false),
                    liv_id = table.Column<int>(type: "integer", nullable: false),
                    cmd_prix = table.Column<decimal>(type: "numeric", nullable: false),
                    cmd_datecommande = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    cmd_etatcommande = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    cmd_domicile = table.Column<bool>(type: "boolean", nullable: false),
                    cmd_datelivraison = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cmd", x => x.cmd_id);
                    table.ForeignKey(
                        name: "FK_t_e_commande_cmd_t_e_adresse_adr_adr_id",
                        column: x => x.adr_id,
                        principalTable: "t_e_adresse_adr",
                        principalColumn: "adr_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_e_commande_cmd_t_e_livraison_liv_liv_id",
                        column: x => x.liv_id,
                        principalTable: "t_e_livraison_liv",
                        principalColumn: "liv_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_e_commande_cmd_t_e_utilisateur_utl_utl_id",
                        column: x => x.utl_id,
                        principalTable: "t_e_utilisateur_utl",
                        principalColumn: "utl_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_commentaire_com",
                columns: table => new
                {
                    com_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    com_dateheure = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    utl_id = table.Column<int>(type: "integer", nullable: false),
                    com_texte = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    doc_id = table.Column<int>(type: "integer", nullable: false),
                    alb_id = table.Column<int>(type: "integer", nullable: false),
                    blg_id = table.Column<int>(type: "integer", nullable: false),
                    art_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_com", x => x.com_id);
                    table.ForeignKey(
                        name: "FK_t_e_commentaire_com_t_e_album_alb_alb_id",
                        column: x => x.alb_id,
                        principalTable: "t_e_album_alb",
                        principalColumn: "alb_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_e_commentaire_com_t_e_article_art_art_id",
                        column: x => x.art_id,
                        principalTable: "t_e_article_art",
                        principalColumn: "art_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_e_commentaire_com_t_e_blog_blg_blg_id",
                        column: x => x.blg_id,
                        principalTable: "t_e_blog_blg",
                        principalColumn: "blg_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_e_commentaire_com_t_e_document_doc_doc_id",
                        column: x => x.doc_id,
                        principalTable: "t_e_document_doc",
                        principalColumn: "doc_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_e_commentaire_com_t_e_utilisateur_utl_utl_id",
                        column: x => x.utl_id,
                        principalTable: "t_e_utilisateur_utl",
                        principalColumn: "utl_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_devis_dev",
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
                        principalTable: "t_e_produit_pro",
                        principalColumn: "pro_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_dev_utl",
                        column: x => x.utl_id,
                        principalTable: "t_e_utilisateur_utl",
                        principalColumn: "utl_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_formulaireaide_foa",
                columns: table => new
                {
                    foa_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    foa_numaction = table.Column<int>(type: "integer", nullable: false),
                    utl_id = table.Column<int>(type: "integer", nullable: false),
                    utl_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    foa_telephone = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    foa_question = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_foa", x => x.foa_id);
                    table.ForeignKey(
                        name: "fk_foa_act",
                        column: x => x.foa_numaction,
                        principalTable: "t_e_action_act",
                        principalColumn: "act_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_foa_utl",
                        column: x => x.utl_id,
                        principalTable: "t_e_utilisateur_utl",
                        principalColumn: "utl_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_infos_bancaires_inb",
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
                        principalTable: "t_e_utilisateur_utl",
                        principalColumn: "utl_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_vote_vot",
                columns: table => new
                {
                    utl_id = table.Column<int>(type: "integer", nullable: false),
                    the_num = table.Column<int>(type: "integer", nullable: false),
                    jou_id = table.Column<int>(type: "integer", nullable: false),
                    vot_note = table.Column<int>(type: "integer", nullable: false),
                    ThemeId = table.Column<int>(type: "integer", nullable: true),
                    UtilisateurId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vot", x => new { x.utl_id, x.the_num, x.jou_id });
                    table.ForeignKey(
                        name: "FK_t_e_vote_vot_t_e_joueur_jou_jou_id",
                        column: x => x.jou_id,
                        principalTable: "t_e_joueur_jou",
                        principalColumn: "jou_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_e_vote_vot_t_e_utilisateur_utl_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "t_e_utilisateur_utl",
                        principalColumn: "utl_id");
                    table.ForeignKey(
                        name: "FK_t_e_vote_vot_t_e_utilisateur_utl_utl_id",
                        column: x => x.utl_id,
                        principalTable: "t_e_utilisateur_utl",
                        principalColumn: "utl_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_e_vote_vot_t_j_theme_the_the_num",
                        column: x => x.the_num,
                        principalTable: "t_j_theme_the",
                        principalColumn: "the_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_e_vote_vot_t_j_theme_the_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "t_j_theme_the",
                        principalColumn: "the_id");
                });

            migrationBuilder.CreateTable(
                name: "t_j_like_album_lab",
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
                        principalTable: "t_e_album_alb",
                        principalColumn: "alb_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_lab_utl",
                        column: x => x.utl_id,
                        principalTable: "t_e_utilisateur_utl",
                        principalColumn: "utl_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_like_article_lar",
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
                        principalTable: "t_e_article_art",
                        principalColumn: "art_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_lar_utl",
                        column: x => x.utl_id,
                        principalTable: "t_e_utilisateur_utl",
                        principalColumn: "utl_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_like_blog_lbg",
                columns: table => new
                {
                    blg_id = table.Column<int>(type: "integer", nullable: false),
                    utl_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lab", x => new { x.blg_id, x.utl_id });
                    table.ForeignKey(
                        name: "fk_lbg_blg",
                        column: x => x.blg_id,
                        principalTable: "t_e_blog_blg",
                        principalColumn: "blg_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_lbg_utl",
                        column: x => x.utl_id,
                        principalTable: "t_e_utilisateur_utl",
                        principalColumn: "utl_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_like_document_ldc",
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
                        principalTable: "t_e_document_doc",
                        principalColumn: "doc_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ldc_utl",
                        column: x => x.utl_id,
                        principalTable: "t_e_utilisateur_utl",
                        principalColumn: "utl_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_ligne_commande_lcd",
                columns: table => new
                {
                    lcd_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cmd_numcommande = table.Column<int>(type: "integer", nullable: false),
                    lcd_num = table.Column<int>(type: "integer", nullable: false),
                    vpd_id = table.Column<int>(type: "integer", nullable: false),
                    tll_numtaille = table.Column<int>(type: "integer", nullable: false),
                    lcd_quantite = table.Column<int>(type: "integer", nullable: false),
                    lcd_prix = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lcd", x => x.lcd_id);
                    table.ForeignKey(
                        name: "fk_lcd_cmd",
                        column: x => x.cmd_numcommande,
                        principalTable: "t_e_commande_cmd",
                        principalColumn: "cmd_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_lcd_tai",
                        column: x => x.tll_numtaille,
                        principalTable: "t_e_taille_tai",
                        principalColumn: "tai_num",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_lcd_vpd",
                        column: x => x.vpd_id,
                        principalTable: "t_e_variante_produit_vpd",
                        principalColumn: "vpd_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_reglement_reg",
                columns: table => new
                {
                    tra_num = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    com_num = table.Column<int>(type: "integer", nullable: false),
                    reg_montant = table.Column<decimal>(type: "numeric", nullable: false),
                    reg_date = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reg", x => x.tra_num);
                    table.ForeignKey(
                        name: "FK_t_e_reglement_reg_t_e_commande_cmd_com_num",
                        column: x => x.com_num,
                        principalTable: "t_e_commande_cmd",
                        principalColumn: "cmd_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_e_adresse_adr_VilleId",
                table: "t_e_adresse_adr",
                column: "VilleId");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_anecdote_anc_jou_id",
                table: "t_e_anecdote_anc",
                column: "jou_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commande_cmd_adr_id",
                table: "t_e_commande_cmd",
                column: "adr_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commande_cmd_liv_id",
                table: "t_e_commande_cmd",
                column: "liv_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commande_cmd_utl_id",
                table: "t_e_commande_cmd",
                column: "utl_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commentaire_com_alb_id",
                table: "t_e_commentaire_com",
                column: "alb_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commentaire_com_art_id",
                table: "t_e_commentaire_com",
                column: "art_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commentaire_com_blg_id",
                table: "t_e_commentaire_com",
                column: "blg_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commentaire_com_com_id",
                table: "t_e_commentaire_com",
                column: "com_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commentaire_com_doc_id",
                table: "t_e_commentaire_com",
                column: "doc_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commentaire_com_utl_id",
                table: "t_e_commentaire_com",
                column: "utl_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_devis_dev_pro_id",
                table: "t_e_devis_dev",
                column: "pro_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_devis_dev_utl_id",
                table: "t_e_devis_dev",
                column: "utl_id");

            migrationBuilder.CreateIndex(
                name: "uq_doc_lienpdf",
                table: "t_e_document_doc",
                column: "doc_lienpdf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_film_flm_med_id",
                table: "t_e_film_flm",
                column: "med_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_formulaireaide_foa_foa_numaction",
                table: "t_e_formulaireaide_foa",
                column: "foa_numaction");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_formulaireaide_foa_utl_id",
                table: "t_e_formulaireaide_foa",
                column: "utl_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_joueur_jou_clb_id",
                table: "t_e_joueur_jou",
                column: "clb_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_joueur_jou_ClubId",
                table: "t_e_joueur_jou",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_joueur_jou_jou_numposte",
                table: "t_e_joueur_jou",
                column: "jou_numposte");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_joueur_jou_vil_id",
                table: "t_e_joueur_jou",
                column: "vil_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_ligne_commande_lcd_cmd_numcommande",
                table: "t_e_ligne_commande_lcd",
                column: "cmd_numcommande");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_ligne_commande_lcd_tll_numtaille",
                table: "t_e_ligne_commande_lcd",
                column: "tll_numtaille");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_ligne_commande_lcd_vpd_id",
                table: "t_e_ligne_commande_lcd",
                column: "vpd_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_match_mch_clb_domicileid",
                table: "t_e_match_mch",
                column: "clb_domicileid");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_match_mch_clb_exterieurid",
                table: "t_e_match_mch",
                column: "clb_exterieurid");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_produit_pro_cat_num",
                table: "t_e_produit_pro",
                column: "cat_num");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_produit_pro_comp_id",
                table: "t_e_produit_pro",
                column: "comp_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_produit_pro_gen_id",
                table: "t_e_produit_pro",
                column: "gen_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_produit_pro_pay_num",
                table: "t_e_produit_pro",
                column: "pay_num");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_reglement_reg_com_num",
                table: "t_e_reglement_reg",
                column: "com_num");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_stock_stk_tai_num",
                table: "t_e_stock_stk",
                column: "tai_num");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_stock_stk_vpd_id",
                table: "t_e_stock_stk",
                column: "vpd_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_utilisateur_utl_act_id",
                table: "t_e_utilisateur_utl",
                column: "act_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_utilisateur_utl_adr_id",
                table: "t_e_utilisateur_utl",
                column: "adr_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_utilisateur_utl_AdresseId1",
                table: "t_e_utilisateur_utl",
                column: "AdresseId1");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_utilisateur_utl_CompteId1",
                table: "t_e_utilisateur_utl",
                column: "CompteId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_utilisateur_utl_lan_id",
                table: "t_e_utilisateur_utl",
                column: "lan_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_utilisateur_utl_LangueNum",
                table: "t_e_utilisateur_utl",
                column: "LangueNum");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_utilisateur_utl_mon_id",
                table: "t_e_utilisateur_utl",
                column: "mon_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_utilisateur_utl_MonnaieId",
                table: "t_e_utilisateur_utl",
                column: "MonnaieId");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_utilisateur_utl_pay_paysfavori_id",
                table: "t_e_utilisateur_utl",
                column: "pay_paysfavori_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_utilisateur_utl_pay_paysnaissance_id",
                table: "t_e_utilisateur_utl",
                column: "pay_paysnaissance_id");

            migrationBuilder.CreateIndex(
                name: "uq_utl_idcompte",
                table: "t_e_utilisateur_utl",
                column: "com_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_utl_numSociete",
                table: "t_e_utilisateur_utl",
                column: "soc_num",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_utl_numtva",
                table: "t_e_utilisateur_utl",
                column: "utl_numtva",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_utl_telacheteur",
                table: "t_e_utilisateur_utl",
                column: "utl_telacheteur",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_variante_produit_vpd_clr_id",
                table: "t_e_variante_produit_vpd",
                column: "clr_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_variante_produit_vpd_ColorisId1",
                table: "t_e_variante_produit_vpd",
                column: "ColorisId1");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_variante_produit_vpd_pro_id",
                table: "t_e_variante_produit_vpd",
                column: "pro_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_variante_produit_vpd_ProduitIdProduit",
                table: "t_e_variante_produit_vpd",
                column: "ProduitIdProduit");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_ville_vil_pay_id",
                table: "t_e_ville_vil",
                column: "pay_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_ville_vil_PaysId",
                table: "t_e_ville_vil",
                column: "PaysId");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_vote_vot_jou_id",
                table: "t_e_vote_vot",
                column: "jou_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_vote_vot_the_num",
                table: "t_e_vote_vot",
                column: "the_num");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_vote_vot_ThemeId",
                table: "t_e_vote_vot",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_vote_vot_UtilisateurId",
                table: "t_e_vote_vot",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_albumimage_ali_img_id",
                table: "t_j_albumimage_ali",
                column: "img_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_articlejoueur_atj_jou_id",
                table: "t_j_articlejoueur_atj",
                column: "jou_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_articlemedia_atm_med_id",
                table: "t_j_articlemedia_atm",
                column: "med_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_blogimage_bli_img_id",
                table: "t_j_blogimage_bli",
                column: "img_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_caracteristique_produit_cpd_pro_id",
                table: "t_j_caracteristique_produit_cpd",
                column: "pro_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_image_joueur_imj_JoueurId",
                table: "t_j_image_joueur_imj",
                column: "JoueurId");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_imagevariante_imv_vpd_id",
                table: "t_j_imagevariante_imv",
                column: "vpd_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_joueur_theme_jot_jou_id",
                table: "t_j_joueur_theme_jot",
                column: "jou_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_like_album_lab_utl_id",
                table: "t_j_like_album_lab",
                column: "utl_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_like_article_lar_utl_id",
                table: "t_j_like_article_lar",
                column: "utl_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_like_blog_lbg_utl_id",
                table: "t_j_like_blog_lbg",
                column: "utl_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_like_document_ldc_utl_id",
                table: "t_j_like_document_ldc",
                column: "utl_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_match_joue_mtj_mch_id",
                table: "t_j_match_joue_mtj",
                column: "mch_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_produit_similaire_prs_pro_id_deux",
                table: "t_j_produit_similaire_prs",
                column: "pro_id_deux");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_remporte_rem_tro_num",
                table: "t_j_remporte_rem",
                column: "tro_num");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_remporte_rem_TropheeNumTrophee",
                table: "t_j_remporte_rem",
                column: "TropheeNumTrophee");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_sous_categorie_sct_cat_enfant",
                table: "t_j_sous_categorie_sct",
                column: "cat_enfant");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_e_anecdote_anc");

            migrationBuilder.DropTable(
                name: "t_e_commentaire_com");

            migrationBuilder.DropTable(
                name: "t_e_devis_dev");

            migrationBuilder.DropTable(
                name: "t_e_film_flm");

            migrationBuilder.DropTable(
                name: "t_e_formulaireaide_foa");

            migrationBuilder.DropTable(
                name: "t_e_infos_bancaires_inb");

            migrationBuilder.DropTable(
                name: "t_e_ligne_commande_lcd");

            migrationBuilder.DropTable(
                name: "t_e_reglement_reg");

            migrationBuilder.DropTable(
                name: "t_e_stock_stk");

            migrationBuilder.DropTable(
                name: "t_e_vote_vot");

            migrationBuilder.DropTable(
                name: "t_j_albumimage_ali");

            migrationBuilder.DropTable(
                name: "t_j_articlejoueur_atj");

            migrationBuilder.DropTable(
                name: "t_j_articlemedia_atm");

            migrationBuilder.DropTable(
                name: "t_j_blogimage_bli");

            migrationBuilder.DropTable(
                name: "t_j_caracteristique_produit_cpd");

            migrationBuilder.DropTable(
                name: "t_j_image_joueur_imj");

            migrationBuilder.DropTable(
                name: "t_j_imagevariante_imv");

            migrationBuilder.DropTable(
                name: "t_j_joueur_theme_jot");

            migrationBuilder.DropTable(
                name: "t_j_like_album_lab");

            migrationBuilder.DropTable(
                name: "t_j_like_article_lar");

            migrationBuilder.DropTable(
                name: "t_j_like_blog_lbg");

            migrationBuilder.DropTable(
                name: "t_j_like_document_ldc");

            migrationBuilder.DropTable(
                name: "t_j_match_joue_mtj");

            migrationBuilder.DropTable(
                name: "t_j_produit_similaire_prs");

            migrationBuilder.DropTable(
                name: "t_j_remporte_rem");

            migrationBuilder.DropTable(
                name: "t_j_sous_categorie_sct");

            migrationBuilder.DropTable(
                name: "t_e_action_act");

            migrationBuilder.DropTable(
                name: "t_e_commande_cmd");

            migrationBuilder.DropTable(
                name: "t_e_taille_tai");

            migrationBuilder.DropTable(
                name: "t_e_caracteristique_car");

            migrationBuilder.DropTable(
                name: "t_e_image_img");

            migrationBuilder.DropTable(
                name: "t_e_variante_produit_vpd");

            migrationBuilder.DropTable(
                name: "t_j_theme_the");

            migrationBuilder.DropTable(
                name: "t_e_album_alb");

            migrationBuilder.DropTable(
                name: "t_e_article_art");

            migrationBuilder.DropTable(
                name: "t_e_blog_blg");

            migrationBuilder.DropTable(
                name: "t_e_document_doc");

            migrationBuilder.DropTable(
                name: "t_e_match_mch");

            migrationBuilder.DropTable(
                name: "t_e_joueur_jou");

            migrationBuilder.DropTable(
                name: "t_e_trophee_tro");

            migrationBuilder.DropTable(
                name: "t_e_livraison_liv");

            migrationBuilder.DropTable(
                name: "t_e_utilisateur_utl");

            migrationBuilder.DropTable(
                name: "t_e_media_med");

            migrationBuilder.DropTable(
                name: "t_e_coloris_clr");

            migrationBuilder.DropTable(
                name: "t_e_produit_pro");

            migrationBuilder.DropTable(
                name: "t_e_club_clb");

            migrationBuilder.DropTable(
                name: "t_e_poste_pos");

            migrationBuilder.DropTable(
                name: "t_e_activite_ati");

            migrationBuilder.DropTable(
                name: "t_e_adresse_adr");

            migrationBuilder.DropTable(
                name: "t_e_compte_cpt");

            migrationBuilder.DropTable(
                name: "t_e_langue_lng");

            migrationBuilder.DropTable(
                name: "t_e_monnaie_mon");

            migrationBuilder.DropTable(
                name: "t_e_categorie_cat");

            migrationBuilder.DropTable(
                name: "t_e_competition_cpn");

            migrationBuilder.DropTable(
                name: "t_e_genre_gen");

            migrationBuilder.DropTable(
                name: "t_e_ville_vil");

            migrationBuilder.DropTable(
                name: "t_e_pays_pay");
        }
    }
}
