using Modele;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Mongo
{
    /// <summary>
    /// Classe regroupant toutes les opération de modification des données
    /// </summary>
    public class MongoCRUD
    {
        private readonly IMongoDatabase db;

        /// <summary>
        /// Méthode permettant d'initialiser et de donner accès à la base de données
        /// </summary>
        public MongoCRUD()
        {
            var client = new MongoClient("mongodb+srv://user:user@desaccordecluster.bxboq.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            db = client.GetDatabase("Collections");
        }

        /// <summary>
        /// Méthode pour ajouter un objet dans la base de données
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="record"></param>
        public void InsertOne<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }

        /// <summary>
        /// Méthode permettant de charger les listes de l'application
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public List<T> LoadRecords<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            if (!BsonClassMap.IsClassMapRegistered(typeof(Morceau)))
            {
                BsonClassMap.RegisterClassMap<Morceau>();
            }
            if (!BsonClassMap.IsClassMapRegistered(typeof(Album)))
            {
                BsonClassMap.RegisterClassMap<Album>();
            }
            if (!BsonClassMap.IsClassMapRegistered(typeof(Playlist)))
            {
                BsonClassMap.RegisterClassMap<Playlist>();
            }
            return collection.Find(new BsonDocument()).ToList();
        }

        /// <summary>
        /// Méthode permettant de charger le current user dans sa variable dans l'application
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public T LoadRecord<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            try
            {
                return collection.Find(new BsonDocument()).First();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Méthode pour ajouter une oeuvre à la liste d'oeuvre désignée de l'application et à un artiste
        /// </summary>
        /// <param name="a"></param>
        /// <param name="o"></param>
        public void UpdateOeuvresArtiste(Artiste a, Oeuvre o)
        {
            var artistes = db.GetCollection<Artiste>("Artistes");
            if (o is Album)
            {
                var oeuvres = db.GetCollection<Album>("Albums");
                oeuvres.InsertOne(o as Album);
            }
            else
            {
                var oeuvres = db.GetCollection<Morceau>("Morceaux");
                oeuvres.InsertOne(o as Morceau);
            }
            var filter = Builders<Artiste>.Filter.Eq("Nom", a.Nom);
            if (o is Album)
            {
                var update = Builders<Artiste>.Update.Push(x => x.ListAlbums, o);
                artistes.UpdateOne(filter, update);
            }
            else
            {
                var update = Builders<Artiste>.Update.Push(x => x.ListMorceaux, o);
                artistes.UpdateOne(filter, update);
            }
        }

        /// <summary>
        /// Méthode d'ajout d'une  playlists d'un utilisateur
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        public void AddPlaylistUser(Utilisateur u, Playlist p)
        {
            var user = db.GetCollection<Utilisateur>("Users");
            var currentuser = db.GetCollection<Utilisateur>("CurrentUser");
            var filter = Builders<Utilisateur>.Filter.Eq("Email", u.Email);
            var update = Builders<Utilisateur>.Update.Push(x => x.Playlists, p);
            user.UpdateOne(filter, update);
            currentuser.UpdateOne(filter, update);
        }

        /// <summary>
        /// Méthode de suppression d'une playlist d'un utilisateur
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        public void DeletePlaylistUser(Utilisateur u, Playlist p)
        {
            var user = db.GetCollection<Utilisateur>("Users");
            var currentuser = db.GetCollection<Utilisateur>("CurrentUser");
            var filter = Builders<Utilisateur>.Filter.Eq("Email", u.Email);
            var update = Builders<Utilisateur>.Update.Pull(x => x.Playlists, p);
            user.UpdateOne(filter, update);
            currentuser.UpdateOne(filter, update);
        }

        /// <summary>
        /// Méthode d'ajout d'un album en favoris
        /// </summary>
        public void AddAlbumUser(Utilisateur u, Album a)
        {
            var user = db.GetCollection<Utilisateur>("Users");
            var currentuser = db.GetCollection<Utilisateur>("CurrentUser");
            var filter = Builders<Utilisateur>.Filter.Eq("Email", u.Email);
            var update = Builders<Utilisateur>.Update.Push(x => x.Albums, a);
            user.UpdateOne(filter, update);
            currentuser.UpdateOne(filter, update);
        }

        /// <summary>
        /// Méthode de suppression d'un album des favoris
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        public void DeleteAlbumUser(Utilisateur u, Album a)
        {
            var user = db.GetCollection<Utilisateur>("Users");
            var currentuser = db.GetCollection<Utilisateur>("CurrentUser");
            var filter = Builders<Utilisateur>.Filter.Eq("Email", u.Email);
            var update = Builders<Utilisateur>.Update.Pull(x => x.Albums, a);
            user.UpdateOne(filter, update);
            currentuser.UpdateOne(filter, update);
        }

        /// <summary>
        /// Méthode d'ajout d'un morceau en favoris
        /// </summary>
        public void AddMorceauUser(Utilisateur u, Morceau m)
        {
            var user = db.GetCollection<Utilisateur>("Users");
            var currentuser = db.GetCollection<Utilisateur>("CurrentUser");
            var filter = Builders<Utilisateur>.Filter.Eq("Email", u.Email);
            var update = Builders<Utilisateur>.Update.Push(x => x.Morceaux, m);
            user.UpdateOne(filter, update);
            currentuser.UpdateOne(filter, update);
        }

        /// <summary>
        /// Méthode de suppression d'un morceau des favoris
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        public void DeleteMorceauUser(Utilisateur u, Morceau m)
        {
            var user = db.GetCollection<Utilisateur>("Users");
            var currentuser = db.GetCollection<Utilisateur>("CurrentUser");
            var filter = Builders<Utilisateur>.Filter.Eq("Email", u.Email);
            var update = Builders<Utilisateur>.Update.Pull(x => x.Morceaux, m);
            user.UpdateOne(filter, update);
            currentuser.UpdateOne(filter, update);
        }

        /// <summary>
        /// Méthode d'ajout d'un morceau en artiste
        /// </summary>
        public void AddArtisteUser(Utilisateur u, Artiste a)
        {
            var user = db.GetCollection<Utilisateur>("Users");
            var currentuser = db.GetCollection<Utilisateur>("CurrentUser");
            var filter = Builders<Utilisateur>.Filter.Eq("Email", u.Email);
            var update = Builders<Utilisateur>.Update.Push(x => x.Artistes, a);
            user.UpdateOne(filter, update);
            currentuser.UpdateOne(filter, update);
        }

        /// <summary>
        /// Méthode de suppression d'un artiste des favoris
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        public void DeleteArtisteUser(Utilisateur u, Artiste a)
        {
            var user = db.GetCollection<Utilisateur>("Users");
            var currentuser = db.GetCollection<Utilisateur>("CurrentUser");
            var filter = Builders<Utilisateur>.Filter.Eq("Email", u.Email);
            var update = Builders<Utilisateur>.Update.Pull(x => x.Artistes, a);
            user.UpdateOne(filter, update);
            currentuser.UpdateOne(filter, update);
        }

        /// <summary>
        /// Méthode pour supprimer un morceau d'une playlist
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public void AddMorceauPlaylist(Utilisateur u, Playlist p, Morceau m)
        {
            var user = db.GetCollection<Utilisateur>("Users");
            var currentuser = db.GetCollection<Utilisateur>("CurrentUser");
            var filter = Builders<Utilisateur>.Filter.Eq("Email", u.Email);
            var update = Builders<Utilisateur>.Update.Push(x => x.Playlists[u.Playlists.IndexOf(u.GetPlaylist(p.Titre))].Morceaux, m);
            user.UpdateOne(filter, update);
            currentuser.UpdateOne(filter, update);
        }

        /// <summary>
        /// Méthode pour supprimer un morceau d'une playlist
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public void DeleteMorceauPlaylist(Utilisateur u, Playlist p, Morceau m)
        {
            var user = db.GetCollection<Utilisateur>("Users");
            var currentuser = db.GetCollection<Utilisateur>("CurrentUser");
            var filter = Builders<Utilisateur>.Filter.Eq("Email", u.Email);
            var update = Builders<Utilisateur>.Update.Pull(x => x.Playlists[u.Playlists.IndexOf(u.GetPlaylist(p.Titre))].Morceaux, m);
            user.UpdateOne(filter, update);
            currentuser.UpdateOne(filter, update);
        }
        /// <summary>
        /// Méthode pour supprimer un objet de la base de données
        /// </summary>
        /// <param name="table"></param>
        /// <param name="o"></param>
        public void Delete(string table, object o)
        {
            if (o is Utilisateur)
            {
                var collection = db.GetCollection<Utilisateur>(table);
                var filter = Builders<Utilisateur>.Filter.Eq("Email", (o as Utilisateur).Email);
                collection.DeleteOne(filter);
            }
            else if (o is Playlist)
            {
                var collection = db.GetCollection<Playlist>(table);
                var filter = Builders<Playlist>.Filter.Eq("Titre", (o as Playlist).Titre);
                collection.DeleteOne(filter);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Méthode pour mettre à jour un utilisateur
        /// </summary>
        /// <param name="u"></param>
        public void UpdateUser(Utilisateur u)
        {
            var user = db.GetCollection<Utilisateur>("Users");
            var currentuser = db.GetCollection<Utilisateur>("CurrentUser");
            var filter = Builders<Utilisateur>.Filter.Eq("Email", u.Email);
            var update = Builders<Utilisateur>.Update.Combine(Builders<Utilisateur>.Update.Set(x => x.Pseudo, u.Pseudo),
                                                              Builders<Utilisateur>.Update.Set(x => x.MotDePasse, u.MotDePasse),
                                                              Builders<Utilisateur>.Update.Set(x => x.Image, u.Image));
            user.UpdateOne(filter, update);
            currentuser.UpdateOne(filter, update);
        }

        /// <summary>
        /// Méthode pour mettre à jour une playlist
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        public void UpdatePlaylist(Utilisateur u, Playlist p)
        {
            var user = db.GetCollection<Utilisateur>("Users");
            var currentuser = db.GetCollection<Utilisateur>("CurrentUser");
            var filter = Builders<Utilisateur>.Filter.Eq("Email", u.Email);
            var update = Builders<Utilisateur>.Update.Combine(Builders<Utilisateur>.Update.Set(x => x.Playlists[u.Playlists.IndexOf(u.GetPlaylist(p.Titre))].Titre, p.Titre),
                                                              Builders<Utilisateur>.Update.Set(x => x.Playlists[u.Playlists.IndexOf(u.GetPlaylist(p.Titre))].Description, p.Description),
                                                              Builders<Utilisateur>.Update.Set(x => x.Playlists[u.Playlists.IndexOf(u.GetPlaylist(p.Titre))].Image, p.Image));
            user.UpdateOne(filter, update);
            currentuser.UpdateOne(filter, update);
        }

        /// <summary>
        /// Méthode pour ajouter des avis
        /// </summary>
        /// <param name="a"></param>
        /// <param name="o"></param>
#pragma warning disable CA1822 // Marquer les membres comme étant static
        public void AddAvis(Avis a, Oeuvre o)
#pragma warning restore CA1822 // Marquer les membres comme étant static
        {
            MongoCRUD db = new();
            AvisDB av = new(a.Commentaire, a.User, a.Type, o);
            db.InsertOne("Avis", av);
        }

        /// <summary>
        /// Méthode pour supprimer des artistes
        /// </summary>
        /// <param name="a"></param>
        /// <param name="o"></param>
        public void DeleteAvis(Avis a, Oeuvre o)
        {
            var collection = db.GetCollection<AvisDB>("Avis");
            var builder = Builders<AvisDB>.Filter;
            var filter = Builders<AvisDB>.Filter.Eq(x => x.O, o);
            filter &= Builders<AvisDB>.Filter.Eq(x => x.User, a.User);
            collection.DeleteOne(filter);
        }

        /// <summary>
        /// Méthode pour modifier le connemtaire d'un avis
        /// </summary>
        /// <param name="a"></param>
        /// <param name="o"></param>
        public void UpdateAvisCommentaire(Avis a, Oeuvre o)
        {
            var collection = db.GetCollection<AvisDB>("Avis");
            var filter = Builders<AvisDB>.Filter.Eq(x => x.O, o);
            filter &= Builders<AvisDB>.Filter.Eq(x => x.User, a.User);
            var update = Builders<AvisDB>.Update.Set(x => x.Commentaire, a.Commentaire);
            collection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Méthode pour modifier le type d'un avis
        /// </summary>
        /// <param name="a"></param>
        /// <param name="o"></param>
        public void UpdateAvisType(Avis a, Oeuvre o)
        {
            var collection = db.GetCollection<AvisDB>("Avis");
            var filter = Builders<AvisDB>.Filter.Eq(x => x.O, o);
            filter &= Builders<AvisDB>.Filter.Eq(x => x.User, a.User);
            var update = Builders<AvisDB>.Update.Set(x => x.Type, a.Type);
            collection.UpdateOne(filter, update);
        }
    }
}