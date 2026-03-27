using DG.Tweening;
using Plugins.Audio;
using Project.Gameplay.Inventory;
using TMPro;
using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class BasementConsoleScreens : MonoBehaviour
    {
        [Header("Sounds")]
        [SerializeField] private Transform _soundPoint;
        [SerializeField] private SoundEvent _analyzeSound;
        [SerializeField] private SoundEvent _acceptSound;
        [SerializeField] private SoundEvent _declineSound;
        [SerializeField] private Transform _screenSoundPoint;
        [SerializeField] private SoundEvent _screenChangeSound;
        [Header("Screen Text")]
        [SerializeField] private TMP_Text _screenText;
        [SerializeField] private string _defaultText = "WAIT COMMAND";
        [SerializeField] private string _declineText = "COMMAND ERROR";
        [SerializeField] private string _acceptText = "COMMAND ACCEPTED";
        [SerializeField] private float _analyzeStrokeDuration = 0.4f;
        [SerializeField] private float _resetDuration = 0.5f;
        [SerializeField] private string[] _analyzeCommands = new[]
        {
            "ANALYZE COMMAND",
            "ANALYZE COMMAND.",
            "ANALYZE COMMAND..",
            "ANALYZE COMMAND..."
        };
        [Header("Screen Images")]
        [SerializeField] private MeshRenderer _screenMeshRenderer;
        [SerializeField] private float _loadingDuration = 0.4f;
        [Space]
        [SerializeField] private Material _loadingScreenMaterial;
        [SerializeField] private Material _defaultScreenMaterial;
        [SerializeField] private InventoryItemConfig[] _disksItems;
        [SerializeField] private Material[] _disksMaterials;

        private void Awake()
        {
            _screenText.text = _defaultText;
            _screenMeshRenderer.sharedMaterial = _defaultScreenMaterial;
        }

        private void OnDestroy()
        {
            DOTween.Kill(this);
        }

        public void InsertDisk(InventoryItemConfig disk)
        {
            var diskIndex = System.Array.IndexOf(_disksItems, disk);
            var diskMaterial = _disksMaterials[diskIndex];
            LoadDisk(diskMaterial);
        }

        public void ClearDisk()
        {
            LoadDisk(_defaultScreenMaterial);
        }
        
        public void SetupCommand(bool correct)
        {
            var seq = DOTween.Sequence(this);
            for (int i = 0; i < _analyzeCommands.Length; i++)
            {
                var index = i;
                seq.AppendCallback(() =>
                {
                    _analyzeSound.PlayOneShotInPoint(_soundPoint.position);
                    _screenText.text = _analyzeCommands[index];
                }).AppendInterval(_analyzeStrokeDuration);
            }

            if (correct)
            {
                seq.AppendCallback(() =>
                {
                    _acceptSound.PlayOneShotInPoint(_soundPoint.position);
                    _screenText.text = _acceptText;
                });
            }
            else
            {
                seq.AppendCallback(() =>
                {
                    _declineSound.PlayOneShotInPoint(_soundPoint.position);
                    _screenText.text = _declineText;
                });
            }

            seq.AppendInterval(_resetDuration)
                .AppendCallback(() => _screenText.text = _defaultText);
        }

        private void LoadDisk(Material targetMaterial)
        {
            DOTween.Sequence(this)
                .AppendCallback(() =>
                {
                    _screenChangeSound.PlayOneShotInPoint(_screenSoundPoint.position);
                    _screenMeshRenderer.sharedMaterial = _loadingScreenMaterial;
                })
                .AppendInterval(_loadingDuration)
                .AppendCallback(() =>
                {
                    _screenMeshRenderer.sharedMaterial = targetMaterial;
                });
        }
    }
}