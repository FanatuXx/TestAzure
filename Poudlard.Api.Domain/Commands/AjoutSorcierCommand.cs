using System;
using System.Collections.Generic;
using System.Text;
using Tools.CommandQuerySeparation;

namespace Poudlard.Api.Domain.Commands
{
    public class AjoutSorcierCommand : ICommandDefinition<int>
    {
        public string Nom { get; }
        public string Prenom { get; }
        public Guid MaisonId { get; }
        public AjoutSorcierCommand(string nom, string prenom, Guid maisonId)
        {
            Nom = nom;
            Prenom = prenom;
            MaisonId = maisonId;
        }
    }
}
