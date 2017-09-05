using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Common.ApplicationManagement.OrientationSystem
{
    public class OrientationAnchor2D : MonoBehaviour
    {
        // EventHandlers

        // Events

        // Event Methods

        // Members
        [SerializeField()]
        public Vector3 _landscapeAnchoredPosition3D;

        [SerializeField()]
        public Vector2 _landscapeAnchorMin;

        [SerializeField()]
        public Vector2 _landscapeAnchorMax;

        [SerializeField()]
        public Vector2 _landscapePivot;

        [SerializeField()]
        public Vector3 _landscapeRotation;

        [SerializeField()]
        public Vector3 _landscapeScale;

        [SerializeField()]
        public Vector3 _portraitAnchoredPosition3D;

        [SerializeField()]
        public Vector2 _portraitAnchorMin;

        [SerializeField()]
        public Vector2 _portraitAnchorMax;

        [SerializeField()]
        public Vector2 _portraitPivot;

        [SerializeField()]
        public Vector3 _portraitRotation;

        [SerializeField()]
        public Vector3 _portraitScale;

        [SerializeField()]
        public float _time;

        private RectTransform _rectTransform;

        private IEnumerator _moveCoroutine;

        // Properties

        // Constructors
        public OrientationAnchor2D()
        {
            _landscapeAnchoredPosition3D = Vector3.zero;
            _landscapeAnchorMin = Vector2.zero;
            _landscapeAnchorMax = Vector2.zero;
            _landscapePivot = Vector2.zero;
            _landscapeRotation = Vector3.one;
            _landscapeScale = Vector3.one;
            _portraitAnchoredPosition3D = Vector3.zero;
            _portraitAnchorMin = Vector2.zero;
            _portraitAnchorMax = Vector2.zero;
            _portraitPivot = Vector2.zero;
            _portraitRotation = Vector3.one;
            _portraitScale = Vector3.one;
            _time = 0.25f;
            _rectTransform = null;
            _moveCoroutine = null;
        }

        // MonoBehaviour
        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

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
            _rectTransform.pivot = _landscapePivot;
            for (float t = 0; t <= 1 * _time; t += Time.deltaTime)
            {
                _rectTransform.anchorMax = Vector2.Lerp(_portraitAnchorMax, _landscapeAnchorMax, t / _time);
                _rectTransform.anchorMin = Vector2.Lerp(_portraitAnchorMin, _landscapeAnchorMin, t / _time);
                _rectTransform.anchoredPosition3D = Vector3.Lerp(_portraitAnchoredPosition3D, _landscapeAnchoredPosition3D, t / _time);
                _rectTransform.localRotation = Quaternion.Euler(Vector3.Lerp(_portraitRotation, _landscapeRotation, t / _time));
                _rectTransform.localScale = Vector3.Lerp(_portraitScale, _landscapeScale, t / _time);
                yield return 0;
            }
            _rectTransform.anchorMax = _landscapeAnchorMax;
            _rectTransform.anchorMin = _landscapeAnchorMin;
            _rectTransform.anchoredPosition3D = _landscapeAnchoredPosition3D;
            _rectTransform.localRotation = Quaternion.Euler(_landscapeRotation);
            _rectTransform.localScale = _landscapeScale;
        }

        public IEnumerator MoveToPortrait()
        {
            _rectTransform.pivot = _portraitPivot;
            for (float t = 0; t <= 1 * _time; t += Time.deltaTime)
            {
                _rectTransform.anchorMax = Vector2.Lerp(_landscapeAnchorMax, _portraitAnchorMax, t / _time);
                _rectTransform.anchorMin = Vector2.Lerp(_landscapeAnchorMin, _portraitAnchorMin, t / _time);
                _rectTransform.anchoredPosition3D = Vector3.Lerp(_landscapeAnchoredPosition3D, _portraitAnchoredPosition3D, t / _time);
                _rectTransform.localRotation = Quaternion.Euler(Vector3.Lerp(_landscapeRotation, _portraitRotation, t / _time));
                _rectTransform.localScale = Vector3.Lerp(_landscapeScale, _portraitScale, t / _time);
                yield return 0;
            }
            _rectTransform.anchorMax = _portraitAnchorMax;
            _rectTransform.anchorMin = _portraitAnchorMin;
            _rectTransform.anchoredPosition3D = _portraitAnchoredPosition3D;
            _rectTransform.localRotation = Quaternion.Euler(_portraitRotation);
            _rectTransform.localScale = _portraitScale;
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