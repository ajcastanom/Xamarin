using System;
using Worklight;

namespace PruebaMobileFirst.Contratos
{
    public interface IMobileFirstHelper
    {
        IWorklightClient MobileFirstClient { get; }
    }
}
