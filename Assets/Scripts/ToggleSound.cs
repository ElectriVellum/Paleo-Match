using Assets.Scripts.Common.ApplicationManagement.AudioSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ToggleSound : MonoBehaviour
    {
        [SerializeField()]
        private Toggle _toggle;

        public ToggleSound()
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
            _toggle.isOn = !AudioSystemManager.Instance.MuteSounds;
        }

        public void ToggleOnValueChanged(bool value)
        {
            AudioSystemManager.Instance.PlayButtonClickSound();
            AudioSystemManager.Instance.MuteSounds = !_toggle.isOn;
        }
    }
}