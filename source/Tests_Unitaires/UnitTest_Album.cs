using Modele;
using System;
using Xunit;

namespace Tests_Unitaires
{
    public class UnitTest_Album
    {
        [Fact]
        public void Titre_Test()
        {
            Artiste a1 = new("Artiste 1", "desc 1", new DateTime(2001, 03, 16), "/img");
            Oeuvre al1 = new Album("test1", "desc album 1", a1, "/img", new DateTime(2021, 05, 11));

            Assert.Equal("test1", al1.Titre);
        }

        [Fact]
        public void AjouterOeuvre_Test()
        {
            Artiste a1 = new("Artiste 1", "desc 1", new DateTime(2001, 03, 16), "/img");
            Album al1 = new("test1", "desc album 1", a1, "/img", new DateTime(2021, 05, 11));

            al1.AjouterOeuvre(new Morceau("Morceau 2", a1, "3:24", new DateTime(2006, 07, 13), "/img", Genre.Country, ""));
            Assert.Equal(new Morceau("Morceau 2", a1, "3:24", new DateTime(2006, 07, 13), "/img", Genre.Country, ""), al1.Tracklist[0]);
        }

        [Fact]
        public void SupprimerOeuvre_Test()
        {
            Artiste a1 = new("Artiste 1", "desc 1", new DateTime(2001, 03, 16), "/img");
            Album al1 = new("test1", "desc album 1", a1, "/img", new DateTime(2021, 05, 11));

            al1.AjouterOeuvre(new Morceau("Morceau 2", a1, "3:24", new DateTime(2006, 07, 13), "/img", Genre.Country, ""));
            al1.SupprimerOeuvre(new Morceau("Morceau 2", a1, "3:24", new DateTime(2006, 07, 13), "/img", Genre.Country, ""));
            Assert.Empty(al1.Tracklist);
        }


    }
}
