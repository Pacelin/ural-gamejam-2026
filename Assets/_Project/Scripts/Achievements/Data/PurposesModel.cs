using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Project.Core.Misc;
using UnityEngine.Assertions;

namespace Project.Achievements
{
    [UsedImplicitly]
    public class PurposesModel
    {
        public event System.Action<EPurpose, int> OnPurposeUpdate;
        
        private readonly Dictionary<EPurpose, PurposeConfig> _allPurposes;
        private readonly Dictionary<EPurpose, PurposeData> _dataDictionary;
        private readonly SavePoint<PurposeData[]> _savePoint;

        public PurposesModel(PurposeConfig[] allPurposes)
        {
            _allPurposes = allPurposes.ToDictionary(c => c.Id);
            _dataDictionary = allPurposes.ToDictionary(c => c.Id, c => new PurposeData()
            {
                Id = c.Id,
                Current = 0
            });
            
            _savePoint = new SavePoint<PurposeData[]>("purposes");
            
            if (_savePoint.HasSave())
            {
                var data = _savePoint.Load();
                foreach (var purposeData in data)
                    if (_dataDictionary.ContainsKey(purposeData.Id))
                        _dataDictionary[purposeData.Id] = purposeData;
            }
        }

        public int GetPurposeProgress(EPurpose id) => _dataDictionary[id].Current;
        
        public PurposeConfig GetPurposeConfig(EPurpose id)
        {
            Assert.IsTrue(_allPurposes.ContainsKey(id));
            
            return _allPurposes[id];
        } 
        
        public void ApplyPurposeProgress(EPurpose id, int count)
        {
            _dataDictionary[id].Current += count;
            SaveData();
            OnPurposeUpdate?.Invoke(id, count);
        }

        private void SaveData() => _savePoint.Save(_dataDictionary.Values.ToArray());
    }
}