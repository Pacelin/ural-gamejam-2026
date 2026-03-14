using UnityEngine;

namespace Project.Achievements
{
    public class AchievementsListView : MonoBehaviour
    {
        [SerializeField] private RectTransform _itemsContainer;
        [SerializeField] private AchievementsListItemView _itemPrefab;

        public AchievementsListItemView CreateItem() => Instantiate(_itemPrefab, _itemsContainer);
    }
}