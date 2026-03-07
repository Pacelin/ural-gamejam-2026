using System;

namespace Plugins.Extras
{
    [Flags]
    public enum EPauseState
    {
        None = 0,
        PausedByApplication = 1,
        PausedByUser = 2,
    }
}