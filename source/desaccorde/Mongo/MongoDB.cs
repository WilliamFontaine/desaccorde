using Modele;
using System;
using System.Collections.Generic;

namespace Mongo
{
    public class MongoDB : IPersistanceManager
    {
        static void Main(string[] args)
        {
#pragma warning restore IDE0079 // Retirer la suppression inutile
#pragma warning disable IDE0059 // Assignation inutile d'une valeur
            MongoCRUD db = new();
#pragma warning restore IDE0059 // Assignation inutile d'une valeur

            Utilisateur user = new("admin", "admin", "admin", new DateTime(1994, 01, 01), "admin@admin.fr", "admin", "");
            Utilisateur user1 = new("Jean", "Martin", "Jmart", new DateTime(2000, 04, 24), "jean.martin@free.fr", "marjean24", "");
            Utilisateur user2 = new("Marie", "Dupont", "Marie37", new DateTime(2004, 10, 10), "marie.dup37@gmail.com", "Marie.37", "");
            //db.InsertOne("Users", user);
            //db.InsertOne("Users", user1);
            //db.InsertOne("Users", user2);

            //db.Delete("Users", user.Id);
            //db.InsertOne("CurrentUser", user);

            Artiste septJaws = new("7 jaws", "7 Jaws est un rappeur français, ancien combattant de MMA. " +
                                "Son style de rap mêlant ego-trip et mélancolie fait de lui un rappeur unique en son genre. " +
                                "Il s’inspire de différents univers : Japon, MMA, métal, rap émo américain, etc.", new DateTime(1995, 06, 26), "7jaws.jpg");
            Artiste quaranteSeptTer = new("47ter", "47Ter (prononcé « 47 Terre ») est un groupe de rap et de hip-hop français, originaire de l'ouest de Paris." +
                " Il est fondé en 2017 et se compose des rappeurs Pierre-Paul, Blaise et Miguel.", new DateTime(2017), "47ter.png");
            Artiste alphaWann = new("Alpha Wann", "Alpha Omar Wann, dit Alpha Wann, né le 2 juillet 1989 dans le 14e arrondissement de Paris, est un rappeur (auteur-interprète) français. " +
                "Il est membre de l'ancien groupe 1995 et du collectif L'Entourage. Membre fondateur de 1995, Alpha Wann est un pilier du groupe avec Nekfeu." +
                "Après s'être lancé dans une carrière en solo, il sort trois EP successifs, la trilogie Alph Lauren. Le 21 septembre 2018, Wann publie son premier album, Une main lave l’autre " +
                "(UMLA) qui sera certifié disque d'or plus d'un an après.", new DateTime(1989, 07, 02), "alphawann.png");
            Artiste colombine = new("Colombine", "Columbine est un collectif de rap français originaire de Rennes, en Bretagne, formé en 2014. Les principaux membres actuels en sont Lujipeka," +
            " Foda C, Yro, Chaps, KCIV, Chaman et Sully (en duo aussi), Veskki (Alias Sacha) et Larry Garcia (connu sous le pseudonyme de Lorenzo dans sa carrière solo). Après un premier album," +
            " Clubbing for Columbine, sorti en 2016, le groupe sort Enfants terribles en 2017 et Adieu bientôt en 2018.", new DateTime(2014), "columbine.jpg");
            Artiste damso = new("Damso", "Damso, de son vrai nom William Kalubi Mwamba, né le 10 mai 1992 à Kinshasa, est un rappeur et auteur-compositeur-interprète belgo-congolais. " +
                "Actif dans le monde du rap depuis 2006, Damso débute dans la publication de projets avec sa première mixtape Salle d'attente, sortie en 2014.", new DateTime(1992, 05, 10), "Damso.jpg");
            Artiste nekfeu = new("Nekfeu", "Nekfeu, de son vrai nom Ken Samaras, né le 3 avril 1990 à La Trinité, dans les Alpes-Maritimes, est un rappeur (auteur-interprète) et acteur français. " +
                "Il est aussi, dans une moindre mesure, réalisateur et directeur de photographie. Membre du groupe S-Crew et 1995, il appartient au collectif L'Entourage et a également fait partie " +
                "du collectif 5 Majeur. Sorti en 2015, son premier album solo, Feu, bénéficie d'une couverture médiatique importante ; pour cet album, il remporte en 2016 la Victoire de l'album de musiques urbaines. " +
                "Son deuxième album, intitulé Cyborg, sort en 2016, et son troisième, Les Étoiles vagabondes, en 2019. Au cours de sa carrière, Il a vendu plus de 1, 5 million d'albums et " +
                "détient trois disques de diamant pour ses trois albums studios.", new DateTime(1990, 04, 03), "Nekfeu.jpg");
            Artiste ninho = new("Ninho", "Ninho, pseudonyme de William Nzobazola, est un rappeur et auteur-compositeur français né le 2 avril 1996 à Longjumeau dans l'Essonne.", new DateTime(1996, 04, 02), "Ninho.jpg");
            Artiste YGpablo = new("YGpablo", "Né à la fin des années 90’s, YG Pablo est un chanteur / rappeur originaire de Bruxelles, en Belgique. " +
                    "Alors qu’il commence à écrire ses premiers textes à l’âge de 14 ans, YG se fait rapidement repéré pour ses talents de basketteur et se verra allouer une bourse d’étude pour rejoindre les Etats Unis. " +
                    "Revenu à fond dans le rap, il balance son premier EP, Super, en Avril 2019.L’année de sa signature chez le label Believe." +
                    "Fort d’un buzz de plus en plus insistant, en témoigne le succès de son titre AVM, il décide de sortir son deuxième projet, VEDA, le 22 Janvier 2021.", new(1990, 03, 09), "YGPablo.jpg");
            Artiste MichealJackson = new("Micheal Jackson", "né le 29 août 1958 à Gary (Indiana) et mort le 25 juin 2009 à Los Angeles (Californie), est un auteur-compositeur-interprète, danseur-chorégraphe et acteur américain." +
                    "Reconnu comme l’artiste le plus titré de tous les temps, il est une figure principale de l'histoire de l'industrie du spectacle et l'une des icônes culturelles majeures du xxe siècle.)" + "Dans les années 1980, " +
                    "il devient une figure majeure de la musique pop. Ses clips musicaux, ambitieux et novateurs, sont réalisés comme des courts métrages, notamment pour les titres Beat It, Billie Jean, Thriller, Bad ou Smooth Criminal." +
                    " Il popularise de nombreux pas de danse, dont le moonwalk, qui devient sa signature.", new DateTime(1958, 08, 29), "MJ.jpg");
            Artiste Nirvana = new("Nirvana", "Nirvana est un groupe de grunge américain,originaire d'Aberdeen, dans l'État de Washington, formé en 1987 par le chanteur-guitariste Kurt Cobain et le bassiste Krist Novoselic. Après Bleach en 1989," +
                " son premier album studio produit par e label indépendant Sub Pop et une succession de batteurs,la formation se stabilise avec l'arrivée de Dave Grohl en octobre 1990.", new DateTime(1987), "nirvana.jpg");
            Artiste JohnnyHallyday = new("Johnny Hallyday", "Johnny Hallyday, nom de scène de Jean-Philippe Smet, né le 15 juin 1943 dans le 9e arrondissement de Paris et mort le 5 décembre 2017 à Marnes-la-Coquette (Hauts-de-Seine), est un chanteur, " +
                "compositeur et acteur français.Durant ses 57 ans de carrière, il s'impose comme l'un des plus célèbres chanteurs francophones et l'une des personnalités les plus présentes dans le paysage médiatique français.", new DateTime(1943, 06, 15), "JohnnyHallyday.jpg");
            Artiste Carmel = new("Carmel", "Carmel McCourt est une chanteuse britannique, née le 24 novembre 1958 à Scunthorpe, dans le Lincolnshire en Angleterre. Elle est surtout connue comme chanteuse éponyme du groupe Carmel," +
                " aux côtés du bassiste Jim Parris et du batteur Gerry Darby.Son single Sally(mélange de soul / R & B et cha - cha - cha), sorti en 1986, a eu beaucoup de succès en France et Johnny Hallyday l'a invitée pour le duo" +
                " J'oublierai ton nom, sur son album Gang.", new DateTime(1958, 11, 24), "Carmel.jpg");

            //db.InsertOne("Artistes", septJaws);
            //db.InsertOne("Artistes", quaranteSeptTer);
            //db.InsertOne("Artistes", alphaWann);
            //db.InsertOne("Artistes", colombine);
            //db.InsertOne("Artistes", damso);
            //db.InsertOne("Artistes", nekfeu);
            //db.InsertOne("Artistes", ninho);
            //db.InsertOne("Artistes", YGpablo);
            //db.InsertOne("Artistes", MichealJackson);
            //db.InsertOne("Artistes", Nirvana);
            //db.InsertOne("Artistes", JohnnyHallyday);
            //db.InsertOne("Artistes", Carmel);


            Morceau SousLeRegardDesAnges = new("Sous le regard des anges", septJaws, "2:37", new DateTime(2020, 11, 27), "Dalton.jpg", Genre.Rap, "SousLeRegardDesAnges.mp3");
            Morceau Shoot = new("Shoot", septJaws, "2:20", new DateTime(2020, 11, 27), "Dalton.jpg", Genre.Rap, "Shoot.mp3");
            Morceau Flammes = new("Flamme", septJaws, "2:59", new DateTime(2020, 11, 27), "Dalton.jpg", Genre.Rap, "Flamme.mp3");
            Morceau CaMRegale = new("Ca m'régale", septJaws, "2:50", new DateTime(2020, 11, 27), "Dalton.jpg", Genre.Rap, "CaMRegale.mp3");

            Morceau CoteOuest = new("Cote Ouest", quaranteSeptTer, "3:52", new DateTime(2019, 06, 25), "CoteOuest.jpg", Genre.Rap, "CoteOuest.mp3");
            Morceau SoleilNoir = new("Soleil Noir", quaranteSeptTer, "3:09", new DateTime(2019, 10, 25), "SoleilNoir.jpg", Genre.Rap, "SoleilNoir.mp3");
            Morceau aaa = new("aaa", alphaWann, "2:45", new DateTime(2020, 12, 18), "dondadamixtape.jpg", new List<Artiste>() { nekfeu }, Genre.Rap, "aaa.mp3");

            Morceau OG = new("O. OG", damso, "1:40", new DateTime(2021, 04, 29), "QALFInfinity.jpg", Genre.Rap, "OG.mp3");
            Morceau VANTABLACK = new("Π. VANTABLACK", damso, "2:33", new DateTime(2021, 04, 29), "QALFInfinity.jpg", Genre.Rap, "VANTABLACK.mp3");
            Morceau DOSE = new("P. DOSE", damso, "3:10", new DateTime(2021, 04, 29), "QALFInfinity.jpg", Genre.Rap, "DOSE.mp3");
            Morceau MOROSE = new("Σ. MOROSE", damso, "4:23", new DateTime(2021, 04, 29), "QALFInfinity.jpg", Genre.Rap, "MOROSE.mp3");
            Morceau CHIALER = new("T. CHIALER", damso, "3:48", new DateTime(2021, 04, 29), "QALFInfinity.jpg", new List<Artiste>() { YGpablo }, Genre.Rap, "CHIALER.mp3");
            Morceau DEUXDIAMANTS = new("Y. 2 DIAMANTS", damso, "3:17", new DateTime(2021, 04, 29), "QALFInfinity.jpg", Genre.Rap, "2DIAMANTS.mp3");
            Morceau THEVIERADIO = new("Φ. THEVIE RADIO", damso, "3:54", new DateTime(2021, 04, 29), "QALFInfinity.jpg", Genre.Rap, "THEVIERADIO.mp3");
            Morceau ZWAAR = new("X. ZWAAR", damso, "3:21", new DateTime(2021, 04, 29), "QALFInfinity.jpg", Genre.Rap, "ZWAAR.mp3");
            Morceau PASSION = new("Ψ. PASSION", damso, "4:37", new DateTime(2021, 04, 29), "QALFInfinity.jpg", Genre.Rap, "PASSION.mp3");
            Morceau VIVREUNPEU = new("Ω. VIVRE UN PEU", damso, "3:55", new DateTime(2021, 04, 29), "QALFInfinity.jpg", Genre.Rap, "VIVREUNPEU.mp3");
            Morceau YOUVOI = new("YOUVOI", damso, "2:51", new DateTime(2021, 04, 29), "QALFInfinity.jpg", Genre.Rap, "YOUVOI.mp3");
            Morceau NineOneOne = new("911", damso, "2:52", new DateTime(2020, 09, 18), "QALF.jpg", Genre.Rap, "911.mp3");

            Morceau WannaBeStartin = new("Wanna Be Startin' Somethin'", MichealJackson, "6:02", new DateTime(1982, 11, 30), "Thriller.jpg", Genre.Pop, "WannaBeStartin.mp3");
            Morceau BabyBeMine = new("Baby Be Mine", MichealJackson, "4:20", new DateTime(1982, 11, 30), "Thriller.jpg", Genre.Pop, "BabyBeMine.mp3");
            Morceau TheGirlIsMine = new("The Girl Is Mine", MichealJackson, "3:42", new DateTime(1982, 11, 30), "TheGirlIsMine.jpg", Genre.Pop, "TheGirlIsMine.mp3");
            Morceau ThrillerM = new("Thriller", MichealJackson, "5:57", new DateTime(1982, 11, 30), "ThrillerM.jpg", Genre.Pop, "Thriller.mp3");
            Morceau BeatIt = new("Beat It", MichealJackson, "4:17", new DateTime(1982, 11, 30), "BeatIt.jpg", Genre.Pop, "BeatIt.mp3");
            Morceau BillieJean = new("Billie Jean", MichealJackson, "4:54", new DateTime(1982, 11, 30), "BillieJean.jpg", Genre.Pop, "BillieJean.mp3");
            Morceau HumanNature = new("Human Nature", MichealJackson, "4:05", new DateTime(1982, 11, 30), "Thriller.jpg", Genre.Pop, "HumanNature.mp3");
            Morceau PYT = new("P. Y. T.", MichealJackson, "3:58", new DateTime(1982, 11, 30), "Thriller.jpg", Genre.Pop, "PYT.mp3");
            Morceau TheLadyInMyLife = new("The Lady In My Life", MichealJackson, "4:59", new DateTime(1982, 11, 30), "Thriller.jpg", Genre.Pop, "TheLadyInMyLife.mp3");

            Morceau SmellsLikeTeenSpirit = new("Smells Like Teen Spirit", Nirvana, "5:01", new DateTime(1991, 09, 10), "SmellsLikeTeenSpirit.jpg", Genre.Rock, "SmellsLikeTeenSpirit.mp3");
            Morceau InBloom = new("In Bloom", Nirvana, "4:14", new DateTime(1992, 11, 30), "Nevermind.jpg", Genre.Rock, "InBloom.mp3");
            Morceau ComeAsYouAre = new("Come As Your Are", Nirvana, "3:39", new DateTime(1992, 02, 24), "Nevermind.jpg", Genre.Rock, "ComeAsYouAre.mp3");
            Morceau Breed = new("Breed", Nirvana, "3:04", new DateTime(1991, 09, 24), "Nevermind.jpg", Genre.Rock, "Breed.mp3");
            Morceau Lithium = new("Lithium", Nirvana, "4:16", new DateTime(1992, 07, 13), "Nevermind.jpg", Genre.Rock, "Lithium.mp3");
            Morceau Polly = new("Polly", Nirvana, "2:57", new DateTime(1991, 09, 24), "Nevermind.jpg", Genre.Rock, "Polly.mp3");
            Morceau TerritorialPissings = new("Territorial Pissings", Nirvana, "2:23", new DateTime(1991, 09, 24), "Nevermind.jpg", Genre.Rock, "TerritorialPissings.mp3");
            Morceau DrainYou = new("Drain You", Nirvana, "3:43", new DateTime(1991, 09, 24), "Nevermind.jpg", Genre.Rock, "DrainYou.mp3");
            Morceau LoungeAct = new("Lounge Act", Nirvana, "2:37", new DateTime(1991, 09, 24), "Nevermind.jpg", Genre.Rock, "LoungeAct.mp3");
            Morceau StayAway = new("Stay Away", Nirvana, "3:32", new DateTime(1991, 09, 24), "Nevermind.jpg", Genre.Rock, "StayAway.mp3");
            Morceau OnAPlain = new("On A Plain", Nirvana, "3:16", new DateTime(1991, 09, 24), "Nevermind.jpg", Genre.Rock, "OnAPlain.mp3");
            Morceau SomethingInTheWay = new("Something In The Way", Nirvana, "3:51", new DateTime(1991, 09, 24), "Nevermind.jpg", Genre.Rock, "SomethingInTheWay.mp3");

            Morceau LEnvie = new("L'envie", JohnnyHallyday, "3:51", new DateTime(1986, 12, 6), "Gang.jpg", Genre.Pop, "Lenvie.mp3");
            Morceau JeTAttends = new("Je t'attends", JohnnyHallyday, "3:57", new DateTime(1986, 11, 01), "JeTAttends.jpg", Genre.Pop, "JeTAttends.mp3");
            Morceau JOublieraiTonNom = new("J'oublierai ton nom", JohnnyHallyday, "4:41", new DateTime(1986, 12, 6), "Gang.jpg", new List<Artiste>() { Carmel }, Genre.Pop, "JoublieraiTonNom.mp3");
            Morceau TouteSeule = new("Toute seule", JohnnyHallyday, "4:22", new DateTime(1986, 12, 6), "Gang.jpg", Genre.Pop, "TouteSeule.mp3");
            Morceau JeTePromets = new("Je te promets", JohnnyHallyday, "4:35", new DateTime(1986, 12, 6), "Gang.jpg", Genre.Pop, "JeTePromets.mp3");
            Morceau Laura = new("Laura", JohnnyHallyday, "4:42", new DateTime(1986, 12, 6), "Gang.jpg", Genre.Pop, "Laura.mp3");
            Morceau TuPeuxChercher = new("Tu peux chercher", JohnnyHallyday, "4:53", new DateTime(1986, 12, 6), "Gang.jpg", Genre.Pop, "TuPeuxChercher.mp3");
            Morceau DansMesNuitsOnOublie = new("L'envie", JohnnyHallyday, "3:44", new DateTime(1986, 12, 6), "Gang.jpg", Genre.Pop, "DansMesNuits.mp3");
            Morceau TonFils = new("Dans mes nuits ... on oublie", JohnnyHallyday, "3:47", new DateTime(1986, 12, 6), "Gang.jpg", Genre.Pop, "TonFils.mp3");
            Morceau Encore = new("Encore", JohnnyHallyday, "3:30", new DateTime(1986, 12, 6), "Gang.jpg", Genre.Pop, "Encore.mp3");

            Album Thriller = new("Thriller", "Thriller est le sixième album studio de l'artiste américain Michael Jackson. Coproduit par Quincy Jones, il sort le 30" +
                " novembre 1982 chez Epic Records, à la suite du succès commercial et critique de l'album Off the Wall (1979). Thriller explore des genres similaires à ceux d'Off the Wall, " +
                "tels le funk, le post-disco, la musique soul, le soft rock, le R&B et la pop.", MichealJackson, "Thriller.jpg", new DateTime(1982, 12, 01),
                new List<Morceau>() { WannaBeStartin, BabyBeMine, TheGirlIsMine, ThrillerM, BeatIt, BillieJean, HumanNature, PYT, TheLadyInMyLife });

            Album DALTON = new("DALTON", "Dalton est un EP de 4 titres de 7 Jaws, sorti le 27 novembre 2020", septJaws, "Dalton.jpg", new DateTime(2020, 11, 27),
            new List<Morceau>() { SousLeRegardDesAnges, Shoot, Flammes, CaMRegale });

            Album QALFINFINITY = new("QALF infinity", "Le 28 avril 2021, Damso révèle sur France Inter la réédition QALF infinity de l'album, et explique qu'il s'agira de la « suite du projet QALF ».",
            damso, "QALFInfinity.jpg", new DateTime(2021, 04, 29), new List<Morceau>() { OG, VANTABLACK, DOSE, MOROSE, CHIALER, DEUXDIAMANTS, THEVIERADIO, ZWAAR, PASSION, VIVREUNPEU, YOUVOI, NineOneOne });

            Album NeverMind = new("Nevermind", "Nevermind est le deuxième album studio du groupe américain de grunge Nirvana, sorti le 24 septembre 1991 par le label DGC Records. Kurt Cobain écrit et compose " +
                "seul quasiment toutes les chansons de l'album et le groupe commence à enregistrer en avril 1990 avec le producteur Butch Vig mais la session est interrompue prématurément.", Nirvana, "Nevermind.jpg",
                new DateTime(1991, 09, 24), new List<Morceau>() { SmellsLikeTeenSpirit, InBloom, ComeAsYouAre, Breed, Lithium, Polly, TerritorialPissings, DrainYou, LoungeAct, StayAway, OnAPlain, SomethingInTheWay });

            Album Gang = new("Gang", "Gang est le 35e album studio de Johnny Hallyday. Écrit et réalisé par Jean-Jacques Goldman, il sort le 6 décembre 1986. Les singles Je t'attends, J'oublierai ton nom (en duo avec Carmel)," +
                " Je te promets et Laura en sont extraits.L'Envie, autre succès de l'opus, est diffusé en single en 1988, dans une version enregistrée en public à Bercy, extraite de l'album Johnny à Bercy.",
                JohnnyHallyday, "Gang.jpg", new DateTime(1986, 12, 6), new List<Morceau>() { LEnvie, JeTAttends, JOublieraiTonNom, TouteSeule, JeTePromets, Laura, TuPeuxChercher, DansMesNuitsOnOublie, TonFils, Encore });

            //db.UpdateOeuvresArtiste(JohnnyHallyday, LEnvie);
            //db.UpdateOeuvresArtiste(JohnnyHallyday, JeTAttends);
            //db.UpdateOeuvresArtiste(JohnnyHallyday, JOublieraiTonNom);
            //db.UpdateOeuvresArtiste(JohnnyHallyday, TouteSeule);
            //db.UpdateOeuvresArtiste(JohnnyHallyday, JeTePromets);
            //db.UpdateOeuvresArtiste(JohnnyHallyday, Laura);
            //db.UpdateOeuvresArtiste(JohnnyHallyday, TuPeuxChercher);
            //db.UpdateOeuvresArtiste(JohnnyHallyday, DansMesNuitsOnOublie);
            //db.UpdateOeuvresArtiste(JohnnyHallyday, TonFils);
            //db.UpdateOeuvresArtiste(JohnnyHallyday, Encore);
            //db.UpdateOeuvresArtiste(JohnnyHallyday, Gang);

            //db.UpdateOeuvresArtiste(Nirvana, SmellsLikeTeenSpirit);
            //db.UpdateOeuvresArtiste(Nirvana, InBloom);
            //db.UpdateOeuvresArtiste(Nirvana, ComeAsYouAre);
            //db.UpdateOeuvresArtiste(Nirvana, Breed);
            //db.UpdateOeuvresArtiste(Nirvana, Lithium);
            //db.UpdateOeuvresArtiste(Nirvana, Polly);
            //db.UpdateOeuvresArtiste(Nirvana, TerritorialPissings);
            //db.UpdateOeuvresArtiste(Nirvana, DrainYou);
            //db.UpdateOeuvresArtiste(Nirvana, LoungeAct);
            //db.UpdateOeuvresArtiste(Nirvana, StayAway);
            //db.UpdateOeuvresArtiste(Nirvana, OnAPlain);
            //db.UpdateOeuvresArtiste(Nirvana, SomethingInTheWay);
            //db.UpdateOeuvresArtiste(Nirvana, NeverMind);
            //db.UpdateOeuvresArtiste(MichealJackson, WannaBeStartin);
            //db.UpdateOeuvresArtiste(MichealJackson, BabyBeMine);
            //db.UpdateOeuvresArtiste(MichealJackson, TheGirlIsMine);
            //db.UpdateOeuvresArtiste(MichealJackson, ThrillerM);
            //db.UpdateOeuvresArtiste(MichealJackson, BeatIt);
            //db.UpdateOeuvresArtiste(MichealJackson, BillieJean);
            //db.UpdateOeuvresArtiste(MichealJackson, HumanNature);
            //db.UpdateOeuvresArtiste(MichealJackson, PYT);
            //db.UpdateOeuvresArtiste(MichealJackson, TheLadyInMyLife);
            //db.UpdateOeuvresArtiste(MichealJackson, Thriller);

            //db.UpdateOeuvresArtiste(septJaws, SousLeRegardDesAnges);
            //db.UpdateOeuvresArtiste(septJaws, Shoot);
            //db.UpdateOeuvresArtiste(septJaws, Flammes);
            //db.UpdateOeuvresArtiste(septJaws, CaMRegale);
            //db.UpdateOeuvresArtiste(septJaws, DALTON);

            //db.UpdateOeuvresArtiste(quaranteSeptTer, CoteOuest);
            //db.UpdateOeuvresArtiste(quaranteSeptTer, SoleilNoir);
            //db.UpdateOeuvresArtiste(alphaWann, aaa);

            //db.UpdateOeuvresArtiste(damso, OG);
            //db.UpdateOeuvresArtiste(damso, VANTABLACK);
            //db.UpdateOeuvresArtiste(damso, DOSE);
            //db.UpdateOeuvresArtiste(damso, MOROSE);
            //db.UpdateOeuvresArtiste(damso, CHIALER);
            //db.UpdateOeuvresArtiste(damso, DEUXDIAMANTS);
            //db.UpdateOeuvresArtiste(damso, THEVIERADIO);
            //db.UpdateOeuvresArtiste(damso, ZWAAR);
            //db.UpdateOeuvresArtiste(damso, PASSION);
            //db.UpdateOeuvresArtiste(damso, VIVREUNPEU);
            //db.UpdateOeuvresArtiste(damso, YOUVOI);
            //db.UpdateOeuvresArtiste(damso, NineOneOne);
            //db.UpdateOeuvresArtiste(damso, QALFINFINITY);



            AvisDB avis1 = new("Super !", user, Modele.Type.Like, QALFINFINITY);
            AvisDB avis2 = new("génial.", user2, Modele.Type.Like, QALFINFINITY);
            AvisDB avis3 = new("Le rap c'est pas mon truc", user1, Modele.Type.Indesirable, DALTON);
            //db.InsertOne("Avis", avis1);
            //db.InsertOne("Avis", avis2);
            //db.InsertOne("Avis", avis3);

            //db.DeleteAvis(new Avis("génial.", user2, Modele.Type.Like), QALFINFINITY);
            //db.UpdateAvis(new Avis("rarararar", user1, Modele.Type.Indesirable), DALTON);
        }

        /// <summary>
        /// Méthode de chargement de données
        /// </summary>
        /// <returns></returns>
        public (IEnumerable<Artiste> artistes, IEnumerable<Album> albums, IEnumerable<Morceau> morceaux, IEnumerable<Utilisateur> utilisateurs, Utilisateur currentUser, Dictionary<Oeuvre, List<Avis>> avis) ChargeDonnees()
        {
            MongoCRUD db = new();

            List<Artiste> aDB = db.LoadRecords<Artiste>("Artistes");
            List<Morceau> mDB = db.LoadRecords<Morceau>("Morceaux");
            List<Album> alDB = db.LoadRecords<Album>("Albums");
            List<Utilisateur> uDB = db.LoadRecords<Utilisateur>("Users");
            Utilisateur cuDB;
            try
            {
                cuDB = db.LoadRecord<Utilisateur>("CurrentUser");
            }
            catch
            {
                cuDB = null;
            }
            List<AvisDB> avDB = db.LoadRecords<AvisDB>("Avis");
            Dictionary<Oeuvre, List<Avis>> avisDB = new();

            foreach (AvisDB a in avDB)
            {
                if (!avisDB.ContainsKey(a.O))
                {
                    avisDB.Add(a.O, new List<Avis> { new Avis(a.Commentaire, a.User, a.Type) });
                }
                else
                {
                    List<Avis> result = new();
                    avisDB.TryGetValue(a.O, out result);
                    result.Add(new Avis(a.Commentaire, a.User, a.Type));
                }
            }
            return (aDB, alDB, mDB, uDB, cuDB, avisDB);
        }

        /// <summary>
        /// Méthode de sauvegarde de données, non utilisé car chaque changement est directement intégré à la base de données
        /// </summary>
        /// <param name="artistes"></param>
        /// <param name="albums"></param>
        /// <param name="morceaux"></param>
        /// <param name="utilisateurs"></param>
        /// <param name="currentUser"></param>
        /// <param name="avis"></param>
        public void SauvegardeDonnees(IEnumerable<Artiste> artistes, IEnumerable<Album> albums, IEnumerable<Morceau> morceaux, IEnumerable<Utilisateur> utilisateurs, Utilisateur currentUser, Dictionary<Oeuvre, List<Avis>> avis)
        {
            throw new NotImplementedException();
        }
    }
}