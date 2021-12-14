using Modele;
using System;
using Xunit;

namespace Tests_Unitaires
{
    public class UnitTest_Artiste
    {
        [Fact]
        public void Nom_Test()
        {
            Artiste a1 = new("Artiste 1", "desc 1", new DateTime(2001, 03, 16), "/img");
            Assert.Equal("Artiste 1", a1.Nom);
        }

        [Fact]
        public void AjouterOeuvre_Test()
        {
            Artiste a1 = new("Artiste 1", "desc 1", new DateTime(2001, 03, 16), "/img");
            a1.AjouterOeuvre(new Morceau("Morceau 2", a1, "3:24", new DateTime(2006, 07, 13), "/img", Genre.Country, ""));
            Assert.Equal(new Morceau("Morceau 2", a1, "3:24", new DateTime(2006, 07, 13), "/img", Genre.Country, ""), a1.ListMorceaux[0]);
        }

        [Fact]
        public void SupprimerOeuvre_Test()
        {
            Artiste a1 = new("Artiste 1", "desc 1", new DateTime(2001, 03, 16), "/img");
            a1.AjouterOeuvre(new Morceau("Morceau 2", a1, "3:24", new DateTime(2006, 07, 13), "/img", Genre.Country, ""));
            a1.SupprimerOeuvre(new Morceau("Morceau 2", a1, "3:24", new DateTime(2006, 07, 13), "/img", Genre.Country, ""));
            Assert.Empty(a1.ListMorceaux);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(0)]
        [InlineData(11)]
        public void ListOeuvre_Test(int nb)
        {
            Artiste a1 = new("Artiste 1", "desc 1", new DateTime(2001, 03, 16), "/img");
            for (int i = 0; i < nb; i++)
            {
                a1.AjouterOeuvre(new Morceau($"Morceau {i}", a1, "3:24", new DateTime(2006, 07, 13), "/img", Genre.Country, ""));
            }
            Assert.Equal(nb, a1.ListMorceaux.Count);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        public void NameException_Test(string s)
        {
            Artiste a;
            Assert.Throws<ArgumentException>(() => a = new(s, "desc 1", new DateTime(2001, 03, 16), "/img"));
        }
    }
}
