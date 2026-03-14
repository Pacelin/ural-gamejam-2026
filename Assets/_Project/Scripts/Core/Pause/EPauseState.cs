using System;

namespace Project.Core.Pause
{
    [Flags]
    public enum EPauseState
    {
        None = 0,
        PausedByApplication = 1,
        PausedByUser = 2,
        PausedByCutscene = 4,
        PausedByAchievements = 8,
    }
}