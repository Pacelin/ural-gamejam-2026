using Project.Core.Misc;
using Project.Core.Pause;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Core
{
    public class RuntimeLifetimeScope : LifetimeScope
    {
        [Header("Scene Loading")] 
        [SerializeField] private SceneTransitionView _transitionPrefab;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<RuntimeEntryPoint>();
            builder.RegisterEntryPoint<EscapeController>().AsSelf();
            builder.RegisterEntryPoint<PauseController>().AsSelf();

            builder.RegisterComponentInNewPrefab(_transitionPrefab, Lifetime.Singleton)
                .UnderTransform(transform);
            builder.RegisterBuildCallback(o => 
                o.Resolve<SceneTransitionView>().gameObject.SetActive(false));
            builder.Register<SceneLoader>(Lifetime.Singleton);
            
            DontDestroyOnLoad(gameObject);
        }
    }
}