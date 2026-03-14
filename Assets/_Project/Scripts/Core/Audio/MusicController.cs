using Plugins.Audio;

namespace Project.Core.Audio
{
    public static class MusicController
    {
        private static ISoundEventInstance _soundEventInstance;
        
        public static void SetMusic(ISoundEvent soundEvent)
        {
            Stop();
            _soundEventInstance = soundEvent.CreateInstance();
            _soundEventInstance.Start();
        }

        public static void Stop()
        {
            if (_soundEventInstance != null)
            {
                _soundEventInstance.Stop(true);
                _soundEventInstance.Release();
                _soundEventInstance = null;
            }
        }
    }
}