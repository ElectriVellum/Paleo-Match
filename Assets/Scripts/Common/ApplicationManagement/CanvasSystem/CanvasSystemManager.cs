using Assets.Scripts.Common.ApplicationManagement.OrientationSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Common.ApplicationManagement.CanvasSystem
{
    public class CanvasSystemManager : MonoBehaviour
    {
        private static CanvasSystemManager _instance;

        public static CanvasSystemManager Instance
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
        private Canvas _canvas;

        [SerializeField()]
        private Vector2 _nativeResolution;

        [SerializeField()]
        private float _nativePixelsToUnits;

        [SerializeField()]
        private ScaleMatchType _nativeScaleMatch;

        public Canvas Canvas
        {
            get
            {
                return _canvas;
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

        public CanvasSystemManager()
        {
            Instance = this;
            _canvas = null;
            _nativeResolution = new Vector2(1920f, 1920f);
            _nativePixelsToUnits = 1f;
            _nativeScaleMatch = ScaleMatchType.Largest;
        }

        private void Awake()
        {
            if (_canvas == null)
            {
                _canvas = GetComponent<Canvas>();
            }
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

        private void OrientationSystemManager_OrientationChanged(OrientationSystemManager sender, OrientationChangedEventArgs e)
        {
            Recalculate();
        }

        public void Recalculate()
        {
            var canvasScaler = _canvas.GetComponent<CanvasScaler>();
            if (canvasScaler != null)
            {
                canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
                canvasScaler.referenceResolution = _nativeResolution;
                canvasScaler.referencePixelsPerUnit = _nativePixelsToUnits;
                switch (_nativeScaleMatch)
                {
                    case ScaleMatchType.Height:
                        canvasScaler.matchWidthOrHeight = 1f;
                        break;
                    case ScaleMatchType.Width:
                        canvasScaler.matchWidthOrHeight = 0f;
                        break;
                    case ScaleMatchType.Largest:
                        if (Screen.width >= Screen.height)
                        {
                            canvasScaler.matchWidthOrHeight = 0f;
                        }
                        else
                        {
                            canvasScaler.matchWidthOrHeight = 1f;
                        }
                        break;
                    case ScaleMatchType.Smallest:
                        if (Screen.width <= Screen.height)
                        {
                            canvasScaler.matchWidthOrHeight = 0f;
                        }
                        else
                        {
                            canvasScaler.matchWidthOrHeight = 1f;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}