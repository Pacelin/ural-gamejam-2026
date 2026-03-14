using Project.Achievements;
using Project.Core.Misc;
using Project.Core.Pause;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Core
{
    public class RuntimeLifetimeScope : LifetimeScope
    {
        [Header("Achievements")]
        [SerializeField] private AchievementConfig[] _allAchievements;
        [SerializeField] private PurposeConfig[] _allPurposes;
        [SerializeField] private AchievementsWindowView _achievementsWindowPrefab;
        [SerializeField] private AchievementsNotificationWindowView _achievementsNotificationWindowPrefab;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameModel>(Lifetime.Singleton);
            builder.Register<RuntimeSetup>(Lifetime.Singleton);
            builder.RegisterEntryPoint<RuntimeEntryPoint>();
            builder.RegisterEntryPoint<EscapeController>().AsSelf();
            builder.RegisterEntryPoint<PauseController>().AsSelf();
            
            ConfigureAchievements(builder);
            
            DontDestroyOnLoad(gameObject);
        }

        private void ConfigureAchievements(IContainerBuilder builder)
        {
            builder.RegisterInstance(_allAchievements);
            builder.RegisterInstance(_allPurposes);
            builder.Register<PurposesModel>(Lifetime.Singleton);
            builder.RegisterEntryPoint<AchievementsModel>().AsSelf();

            builder.RegisterComponentInNewPrefab(_achievementsWindowPrefab, Lifetime.Singleton)
                .UnderTransform(transform);
            builder.RegisterComponentInNewPrefab(_achievementsNotificationWindowPrefab, Lifetime.Singleton)
                .UnderTransform(transform);
            
            builder.RegisterEntryPoint<AchievementsWindowController>().AsSelf();
            builder.RegisterEntryPoint<AchievementsNotificationsWindowController>().AsSelf();
            builder.RegisterEntryPoint<AchievementsClaimer>();
            
            builder.RegisterBuildCallback(o =>
            {
                o.Resolve<AchievementsWindowView>().gameObject.SetActive(false);
                o.Resolve<AchievementsNotificationWindowView>().gameObject.SetActive(false);
            });
        }
    }
}