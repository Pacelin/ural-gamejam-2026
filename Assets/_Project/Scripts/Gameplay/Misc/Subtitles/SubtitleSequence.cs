using System.Collections.Generic;

namespace Project.Gameplay.Misc
{
    public class SubtitleSequence
    {
        private readonly SubtitlesService _service;
        private readonly List<SubtitleData> _datas;
        
        public SubtitleSequence(SubtitlesService service)
        {
            _service = service;
            _datas = new List<SubtitleData>();
        }

        public void Show() => _service.Show(_datas.ToArray());
        
        public void Add(string text) => 
            _datas.Add(new SubtitleData() { Text = text, Duration = -1 });
        public void Add(string text, float duration) =>
            _datas.Add(new SubtitleData() { Text = text, Duration = duration });
    }
}