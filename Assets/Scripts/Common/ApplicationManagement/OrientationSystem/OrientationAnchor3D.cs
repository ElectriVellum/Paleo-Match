using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Common.ApplicationManagement.OrientationSystem
{
    public class OrientationAnchor3D : MonoBehaviour
    {
        // EventHandlers

        // Events

        // Event Methods

        // Members
        [SerializeField()]
        public Vector3 _landscapePosition;

        [SerializeField()]
        public Vector3 _landscapeRotation;

        [SerializeField()]
        public Vector3 _landscapeScale;

        [SerializeField()]
        public Vector3 _portraitPosition;

        [SerializeField()]
        public Vector3 _portraitRotation;

        [SerializeField()]
        public Vector3 _portraitScale;

        [SerializeField()]
        public float _time;

        private IEnumerator _moveCoroutine;

        // Properties

        // Constructors
        public OrientationAnchor3D()
        {
            _landscapePosition = Vector3.zero;
            _landscapeRotation = Vector3.one;
            _landscapeScale = Vector3.one;
            _portraitPosition = Vector3.zero;
            _portraitRotation = Vector3.one;
            _portraitScale = Vector3.one;
            _time = 0.25f;
            _moveCoroutine = null;
        }

        // MonoBehaviour
        private void OnEnable()
        {
            if (OrientationSystemManager.Instance != null)
            {
                OrientationSystemManager.Instance.OrientationChanged += OrientationSystemManager_OrientationChanged;
            }

        }

        private void OnDisable()
        {
            if (OrientationSystemManager.Instance != null)
            {
                OrientationSystemManager.Instance.OrientationChanged -= OrientationSystemManager_OrientationChanged;
            }
        }

        // Methods
        public IEnumerator MoveToLandscape()
        {
            for (float t = 0; t <= 1 * _time; t += Time.deltaTime)
            {
                transform.localPosition = Vector3.Lerp(_portraitPosition, _landscapePosition, t / _time);
                transform.localRotation = Quaternion.Euler(Vector3.Lerp(_portraitRotation, _landscapeRotation, t / _time));
                transform.localScale = Vector3.Lerp(_portraitScale, _landscapeScale, t / _time);
                yield return 0;
            }
            transform.localPosition = _landscapePosition;
            transform.localRotation = Quaternion.Euler(_landscapeRotation);
            transform.localScale = _landscapeScale;
        }

        public IEnumerator MoveToPortrait()
        {
            for (float t = 0; t <= 1 * _time; t += Time.deltaTime)
            {
                transform.localPosition = Vector3.Lerp(_landscapePosition, _portraitPosition, t / _time);
                transform.localRotation = Quaternion.Euler(Vector3.Lerp(_landscapeRotation, _portraitRotation, t / _time));
                transform.localScale = Vector3.Lerp(_landscapeScale, _portraitScale, t / _time);
                yield return 0;
            }
            transform.localPosition = _portraitPosition;
            transform.localRotation = Quaternion.Euler(_portraitRotation);
            transform.localScale = _portraitScale;
        }

        // Animation Events

        // UI Events
        private void OrientationSystemManager_OrientationChanged(OrientationSystemManager sender, OrientationChangedEventArgs e)
        {
            switch (e.NewOrientation)
            {
                case Orientation.Unknown:
                    break;
                case Orientation.Portrait:
                    if (_moveCoroutine != null)
                    {
                        StopCoroutine(_moveCoroutine);
                    }
                    _moveCoroutine = MoveToPortrait();
                    StartCoroutine(_moveCoroutine);
                    break;
                case Orientation.Landscape:
                    if (_moveCoroutine != null)
                    {
                        StopCoroutine(_moveCoroutine);
                    }
                    _moveCoroutine = MoveToLandscape();
                    StartCoroutine(_moveCoroutine);
                    break;
                default:
                    break;
            }
        }
    }
}
