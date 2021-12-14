using Modele;
using System;
using System.Collections.Generic;

namespace Stub
{
    public class Stub : IPersistanceManager
    {
        public (IEnumerable<Artiste> artistes, IEnumerable<Album> albums, IEnumerable<Morceau> morceaux, IEnumerable<Utilisateur> utilisateurs, Utilisateur currentUser, Dictionary<Oeuvre, List<Avis>> avis) ChargeDonnees()
        {
            {
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
                List<Artiste> lesArtistes = new()
                {
                    septJaws,
                    quaranteSeptTer,
                    alphaWann,
                    colombine,
                    damso,
                    nekfeu,
                    ninho,
                    YGpablo,
                    MichealJackson,
                };


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
                Album Thriller = new("Thriller", "Thriller est le sixième album studio de l'artiste américain Michael Jackson. Coproduit par Quincy Jones, il sort le 30" +
                    " novembre 1982 chez Epic Records, à la suite du succès commercial et critique de l'album Off the Wall (1979). Thriller explore des genres similaires à ceux d'Off the Wall, " +
                    "tels le funk, le post-disco, la musique soul, le soft rock, le R&B et la pop.", MichealJackson, "Thriller.jpg", new DateTime(1982, 12, 01), new List<Morceau>() { WannaBeStartin });
                Album DALTON = new("DALTON", "Dalton est un EP de 4 titres de 7 Jaws, sorti le 27 novembre 2020", septJaws, "Dalton.jpg", new DateTime(2020, 11, 27),
                new List<Morceau>() { SousLeRegardDesAnges, Shoot, Flammes, CaMRegale });
                Album QALFINFINITY = new("QALF infinity", "Le 28 avril 2021, Damso révèle sur France Inter la réédition QALF infinity de l'album, et explique qu'il s'agira de la « suite du projet QALF ».",
                damso, "QALFInfinity.jpg", new DateTime(2021, 04, 29), new List<Morceau>() { OG, VANTABLACK, DOSE, MOROSE, CHIALER, DEUXDIAMANTS, THEVIERADIO, ZWAAR, PASSION, VIVREUNPEU, YOUVOI, NineOneOne });

                List<Morceau> lesMorceaux = new()
                {
                    SousLeRegardDesAnges,
                    Shoot,
                    Flammes,
                    CaMRegale,
                    CoteOuest,
                    SoleilNoir,
                    aaa,
                    OG,
                    VANTABLACK,
                    DOSE,
                    MOROSE,
                    CHIALER,
                    DEUXDIAMANTS,
                    THEVIERADIO,
                    ZWAAR,
                    PASSION,
                    VIVREUNPEU,
                    YOUVOI,
                    NineOneOne,
                    WannaBeStartin,

                };
                List<Album> lesAlbums = new()
                {
                    DALTON,
                    QALFINFINITY,
                    Thriller,
                };

                List<Utilisateur> lesUsers = new()
                {
                    new("admin", "admin", "admin", new DateTime(1994, 01, 01), "admin@admin.fr", "admin", null),
                    new("Jean", "Martin", "Jmart", new DateTime(2000, 04, 24), "jean.martin@free.fr", "marjean24", null),
                    new("Marie", "Dupont", "Marie37", new DateTime(2004, 10, 10), "marie.dup37@gmail.com", "Marie.37", null)
                };
                damso.AjouterOeuvre(lesMorceaux[7]);
                damso.AjouterOeuvre(lesMorceaux[8]);
                damso.AjouterOeuvre(lesMorceaux[9]);
                damso.AjouterOeuvre(lesAlbums[0]);
                damso.AjouterOeuvre(lesAlbums[1]);

                Dictionary<Oeuvre, List<Avis>> lesAvis = new();
                lesAvis.Add(QALFINFINITY, new List<Avis>() { new Avis("Super !", new("Jean", "Martin", "Jmart", new DateTime(2000, 04, 24), "jean.martin@free.fr", "marjean24", "/img"), Modele.Type.Like),
                                                           new Avis("génial.", new("Marie", "Dupont", "Marie37", new DateTime(2004, 10, 10), "marie.dup37@gmail.com", "Marie.37", "/img"), Modele.Type.Like)
                                                           });
                lesAvis.Add(DALTON, new List<Avis>() { new Avis("Le rap c'est pas mon truc", new("Marie", "Dupont", "Marie37", new DateTime(2004, 10, 10), "marie.dup37@gmail.com", "Marie.37", "/img"), Modele.Type.Indesirable) });


                return (lesArtistes, lesAlbums, lesMorceaux, lesUsers, lesUsers[0], lesAvis);
            }
        }

        public void SauvegardeDonnees(IEnumerable<Artiste> artistes, IEnumerable<Album> albums, IEnumerable<Morceau> morceaux, IEnumerable<Utilisateur> utilisateurs, Utilisateur currentUser, Dictionary<Oeuvre, List<Avis>> avis)
        {
            throw new NotImplementedException();
        }
    }
}
