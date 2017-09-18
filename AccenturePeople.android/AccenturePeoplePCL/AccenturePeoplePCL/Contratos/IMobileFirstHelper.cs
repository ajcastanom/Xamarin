using System;
using Worklight;

namespace AccenturePeoplePCL.Contratos
{
    public interface IMobileFirstHelper
    {
        IWorklightClient MobileFirstClient { get; }
    }
}
