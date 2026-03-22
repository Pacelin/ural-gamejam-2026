using Plugins.Audio;

namespace Project.Core.Audio
{
    public static class MusicController
    {
        private static ISoundEventInstance _soundEventInstance;
        private static ISoundEventInstance _roomTone;

        private static ISoundEvent _currentMusic;
        
        public static void SetMusic(ISoundEvent soundEvent)
        {
            if (_currentMusic == soundEvent)
                return;
            Stop();
            _currentMusic = soundEvent;
            _soundEventInstance = soundEvent.CreateInstance();
            _soundEventInstance.Start();
        }

        public static void SetRoomTone(ISoundEvent soundEvent)
        {
            StopRoomTone();
            _roomTone = soundEvent.CreateInstance();
            _roomTone.Start();
        }

        public static void StopRoomTone()
        {
            if (_roomTone != null)
            {
                _roomTone.Stop(true);
                _roomTone.Release();
                _roomTone = null;
            }
        }

        public static void Stop()
        {
            if (_soundEventInstance != null)
            {
                _soundEventInstance.Stop(true);
                _soundEventInstance.Release();
                _soundEventInstance = null;
                _currentMusic = null;
            }
        }
    }
}