using Assets.Scripts.Common.ApplicationManagement.AudioSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Title
{
    public class TogglePanelInformation : MonoBehaviour
    {
        [SerializeField()]
        private Toggle _toggle;

        [SerializeField()]
        private Animator _animator;

        public TogglePanelInformation()
        {
            _toggle = null;
            _animator = null;
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
            _toggle.isOn = _animator.GetBool("Visible");
        }

        public void ToggleOnValueChanged(bool value)
        {
            AudioSystemManager.Instance.PlayButtonClickSound();
            AudioSystemManager.Instance.PlayWindowShowSound();
            _animator.SetBool("Visible", _toggle.isOn);
        }
    }
}