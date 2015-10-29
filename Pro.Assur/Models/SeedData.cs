using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pro.Assur.Models
{
    public static class SeedData
    {
        public static  List<Devis>  Seed(int nombre)
        {
            var listOfDevis = new List<Devis>();
            var rand = new Random();
            for (int i = 1; i <= nombre; i++)
            {
                listOfDevis.Add(new Devis
                {
                    DevisGuid = Guid.NewGuid(),
                    Prenom = "Prenom " + i,
                    Nom ="Nom " + i,
                    Email = "email" + 1 +"@gmail.com",
                    DateDemande = new DateTime(rand.Next(2010,2015), rand.Next(1, 12), rand.Next(1, 28)),
                    ModelVehicule = "model " +i,
                    CodePostal = "45451",
                    CompagnieActuelle = "Compagnie " + i,
                    DateCirculation = new DateTime(rand.Next(2010, 2015), rand.Next(1, 12), rand.Next(1, 28)),
                    DateNaissance = new DateTime(rand.Next(2010, 2015), rand.Next(1, 12), rand.Next(1, 28)),
                    PuissanceFiscale = "44554",
                    DatePermis = new DateTime(rand.Next(2010, 2015), rand.Next(1, 12), rand.Next(1, 28)),
                    MotifResiliation = MotifResiliation.Alcolémie,
                    Responsables = "2",
                    NonResponsables = "1",
                    Ville = "ville "+i,
                    Tel = "78787787878"
                });
            }

            

            return listOfDevis;
        }







    }
}