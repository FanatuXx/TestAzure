using System;
using System.Collections.Generic;
using System.Text;
using Tools.CommandQuerySeparation;

namespace Poudlard.Api.Domain.Commands
{
    public class ChangeMaisonSorcierCommand : ICommandDefinition
    {
        public ChangeMaisonSorcierCommand(int sorcierId, Guid maisonId)
        {
            SorcierId = sorcierId;
            MaisonId = maisonId;
        }

        public int SorcierId { get; }
        public Guid MaisonId { get; }
    }
}
