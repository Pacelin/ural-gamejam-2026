namespace Project.Gameplay.Misc
{
    public class SubtitlesService
    {
        private readonly SubtitlesView _view;

        public SubtitlesService(SubtitlesView view)
        {
            _view = view;
        } 

        public SubtitleSequence Sequence() => new SubtitleSequence(this);
        
        public void Show(SubtitleData[] datas) => _view.Show(datas);
        public void Show(SubtitleData data) => _view.Show(new[] { data });

        public void Show(string text, float duration) => Show(new SubtitleData()
        {
            Text = text,
            Duration = duration
        });

        public void Show(string text) => Show(new SubtitleData()
        {
            Text = text,
            Duration = -1
        });
    }
}