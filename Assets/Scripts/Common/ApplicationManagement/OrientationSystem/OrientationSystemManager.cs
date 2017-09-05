using UnityEngine;

namespace Assets.Scripts.Common.ApplicationManagement.OrientationSystem
{
    public class OrientationSystemManager : MonoBehaviour
    {
        private static OrientationSystemManager _instance;

        public static OrientationSystemManager Instance
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

        public delegate void OrientationChangedEventHandler(OrientationSystemManager sender, OrientationChangedEventArgs e);

        public event OrientationChangedEventHandler OrientationChanged;

        protected virtual void OnOrientationChanged(Orientation newOrientation)
        {
            if (OrientationChanged != null)
            {
                OrientationChanged.Invoke(this, new OrientationChangedEventArgs(newOrientation));
            }
        }

        private Orientation _orientation;

        private Vector2 _lastResolution;

        public Orientation Orientation
        {
            get
            {
                return _orientation;
            }
            private set
            {
                if (_orientation != value)
                {
                    _orientation = value;
                    OnOrientationChanged(_orientation);
                }
            }
        }

        public OrientationSystemManager()
        {
            Instance = this;
            _orientation = Orientation.Unknown;
            _lastResolution = Vector2.zero;
        }

        private void Update()
        {
            if (_lastResolution.x != Screen.width || _lastResolution.y != Screen.height)
            {
                _lastResolution = new Vector2(Screen.width, Screen.height);
                if (_orientation != (_lastResolution.x >= _lastResolution.y ? Orientation.Landscape : Orientation.Portrait))
                {
                    Orientation = _lastResolution.x >= _lastResolution.y ? Orientation.Landscape : Orientation.Portrait;

                }
            }
        }
    }
}