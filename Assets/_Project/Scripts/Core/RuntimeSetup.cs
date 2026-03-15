using JetBrains.Annotations;
using Project.Achievements;
using Project.Core.Misc;
using UnityEngine;

namespace Project.Core
{
    [UsedImplicitly]
    public class RuntimeSetup
    {
        private readonly GameModel _gameModel;
        private readonly PurposesModel _purposesModel;
        private readonly SaveBool _firstLaunch;
        
        public RuntimeSetup(GameModel gameModel, PurposesModel purposesModel)
        {
            _gameModel = gameModel;
            _purposesModel = purposesModel;
            _firstLaunch = new SaveBool("firstLaunch", false);
        }
        
        public void Setup()
        {
            if (!_firstLaunch.Value)
            {
                _firstLaunch.Value = true;
                
                var setup = Resources.Load<RuntimeSetupConfig>("SO_RuntimeSetup");
                _purposesModel.ApplyPurposeProgress(EPurpose.GameLaunch, 1);
            }
        }
    }
}