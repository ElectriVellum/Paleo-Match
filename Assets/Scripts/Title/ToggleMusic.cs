using Assets.Scripts.Common.ApplicationManagement.AudioSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Title
{
    public class ToggleMusic : MonoBehaviour
    {
        [SerializeField()]
        private Toggle _toggle;

        public ToggleMusic()
        {
            _toggle = null;
        }

        private void Awake()
        {
            if (_toggle == null)
            {
                _toggle = GetComponent<Toggle>();
            }
        }

        private void Start()
        {
            _toggle.isOn = !AudioSystemManager.Instance.MuteMusic;
        }

        public void ToggleOnValueChanged(bool value)
        {
            AudioSystemManager.Instance.PlayButtonClickSound();
            AudioSystemManager.Instance.MuteMusic = !_toggle.isOn;
        }
    }
}