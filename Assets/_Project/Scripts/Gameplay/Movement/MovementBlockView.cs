using UnityEngine;

namespace Project.Gameplay.Movement
{
    public class MovementBlockView : MonoBehaviour
    {
        public void Block() => gameObject.SetActive(true);
        public void Unblock() => gameObject.SetActive(false);
    }
}