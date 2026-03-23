using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Core.Misc
{
    public class SceneLoader
    {
        private readonly SceneTransitionView _transitionView;
        
        public SceneLoader(SceneTransitionView transitionView)
        {
            _transitionView = transitionView;
        }

        public void Load(int buildIndex)
        {
            UniTask.Void(async cancellationToken =>
            {
                await _transitionView.FadeIn(cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();

                await SceneManager.LoadSceneAsync(buildIndex);
                cancellationToken.ThrowIfCancellationRequested();
                
                await _transitionView.FadeOut(cancellationToken);
            }, Application.exitCancellationToken);
        }
    }
}