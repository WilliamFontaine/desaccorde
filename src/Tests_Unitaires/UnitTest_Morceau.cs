using Modele;
using System;
using Xunit;

namespace Tests_Unitaires
{
    public class UnitTest_Morceau
    {
        [Fact]
        public void Titre_Test()
        {
            Artiste a1 = new("Artiste 1", "desc 1", new DateTime(2001, 03, 16), "/img");
            Oeuvre al1 = new Morceau("test1", a1, "3:00", new DateTime(2021, 05, 11), "/img", Genre.Rap, "");

            Assert.Equal("test1", al1.Titre);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        public void DureeException_Test(string s)
        {
            Morceau m;
            Assert.Throws<ArgumentException>(() => m = new("test1", new("Artiste 1", "desc 1", new DateTime(2001, 03, 16), "/img"), s, new DateTime(2021, 05, 11), "/img", Genre.Rap, ""));
        }
    }
}
