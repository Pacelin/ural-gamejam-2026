using JetBrains.Annotations;
using Plugins.Audio;
using Project.Core.Audio;
using VContainer.Unity;

namespace Project.Editor.Gameplay
{
    [UsedImplicitly]
    public class GameplayMusicController : IInitializable
    {
        public void Initialize()
        {
            MusicController.SetMusic(AudioSystem.Music_Menu);
            MusicController.SetRoomTone(AudioSystem.Game_Misc_RoomTone);
        }
    }
}