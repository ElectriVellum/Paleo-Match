using Assets.Scripts.Common.ApplicationManagement.OrientationSystem;
using UnityEngine;

namespace Assets.Scripts.Common.ApplicationManagement.CameraSystem
{
    public class CameraSystemManager : MonoBehaviour
    {
        private static CameraSystemManager _instance;

        public static CameraSystemManager Instance
        {
            get
            {
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }

        [SerializeField()]
        private Camera _camera;

        [SerializeField()]
        private Vector2 _nativeResolution;

        [SerializeField()]
        private float _nativePixelsToUnits;

        [SerializeField()]
        private ScaleMatchType _nativeScaleMatch;

        private float _scale;

        private float _scaledPixelsToUnits;

        public Camera Camera
        {
            get
            {
                return _camera;
            }
        }

        public Vector2 NativeResolution
        {
            get
            {
                return _nativeResolution;
            }
        }

        public float NativePixelsToUnits
        {
            get
            {
                return _nativePixelsToUnits;
            }
        }

        public ScaleMatchType NativeScaleMatch
        {
            get
            {
                return _nativeScaleMatch;
            }
        }

        public float Scale
        {
            get
            {
                return _scale;
            }
        }

        public float ScaledPixelsToUnits
        {
            get
            {
                return _scaledPixelsToUnits;
            }
        }

        public CameraSystemManager()
        {
            Instance = this;
            _camera = null;
            _nativeResolution = new Vector2(1920f, 1920f);
            _nativePixelsToUnits = 1f;
            _nativeScaleMatch = ScaleMatchType.Largest;
            _scale = 1f;
            _scaledPixelsToUnits = 1f;
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

        public void Recalculate()
        {
            if (_camera != null)
            {
                _camera.orthographic = true;
                switch (_nativeScaleMatch)
                {
                    case ScaleMatchType.Height:
                        _scale = Screen.height / _nativeResolution.y;
                        break;
                    case ScaleMatchType.Width:
                        _scale = Screen.width / _nativeResolution.x;
                        break;
                    case ScaleMatchType.Largest:
                        if (Screen.width >= Screen.height)
                        {
                            _scale = Screen.width / _nativeResolution.x;
                        }
                        else
                        {
                            _scale = Screen.height / _nativeResolution.y;
                        }
                        break;
                    case ScaleMatchType.Smallest:
                        if (Screen.width <= Screen.height)
                        {
                            _scale = Screen.width / _nativeResolution.x;
                        }
                        else
                        {
                            _scale = Screen.height / _nativeResolution.y;
                        }
                        break;
                    default:
                        break;
                }
                _scaledPixelsToUnits = _nativePixelsToUnits * _scale;
                _camera.orthographicSize = (Screen.height / 2f) / _scaledPixelsToUnits;
            }
        }

        private void OrientationSystemManager_OrientationChanged(OrientationSystemManager sender, OrientationChangedEventArgs e)
        {
            Recalculate();
        }
    }
}