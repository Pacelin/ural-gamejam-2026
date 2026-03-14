using Cysharp.Threading.Tasks;
using Plugins.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Project.Core
{
    public class RuntimeEntryPoint : IInitializable
    {
        private readonly RuntimeSetup setup;
        
        public RuntimeEntryPoint(RuntimeSetup setup)
        {
            this.setup = setup;
        }
        
        public void Initialize()
        {
            UniTask.Void(async () =>
            {
                await AudioSystem.Initialize(Application.exitCancellationToken);
                
                await SceneManager.LoadSceneAsync(sceneBuildIndex: 1, LoadSceneMode.Single);
                
                setup.Setup();
            });
        }
    }
}