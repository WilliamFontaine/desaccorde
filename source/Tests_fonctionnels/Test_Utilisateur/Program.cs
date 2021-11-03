using Modele;
using System;

namespace Test_Utilisateur
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager m = new(new Stub.Stub());
            m.AjouterUtilisateur("admin", "admin", "admin", new DateTime(2002, 06, 06), "admin@admin.fr", "admin", "/img");
            m.AjouterUtilisateur("Jean", "Jacques", "jiji", new DateTime(1987, 06, 06), "jean.jacques@gmail.com", "jiji42", "/img");
            m.SeConnecter("admin@admin.fr", "admin");
            Console.Write("IsConnecte ? ");
            Console.WriteLine(m.IsConnecte());
            Console.WriteLine(m.CurrentUser);
            try
            {
                m.SeConnecter("admin", "admin@admin.fr");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.ToString());
            }
            m.SeDeconnecter();
            Console.Write("IsConnecte ? ");
            Console.WriteLine(m.IsConnecte());

        }
    }
}
