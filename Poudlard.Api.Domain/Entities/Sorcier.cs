using System;
using System.Collections.Generic;
using System.Text;

namespace Poudlard.Api.Domain.Entities
{
    public class Sorcier
    {
        internal Sorcier(int id, string nom, string prenom, Guid maisonId)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            MaisonId = maisonId;
        }

        public int Id { get; }
        public string Nom { get; }
        public string Prenom { get; }
        public Guid MaisonId { get; set; }
    }
}
