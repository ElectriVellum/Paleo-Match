namespace Assets.Scripts.Common.ApplicationManagement.OrientationSystem
{
    public class OrientationChangedEventArgs
    {
        private Orientation _newOrientation;

        public Orientation NewOrientation
        {
            get
            {
                return _newOrientation;
            }
        }

        public OrientationChangedEventArgs()
        {
            _newOrientation = Orientation.Unknown;
        }

        public OrientationChangedEventArgs(Orientation newOrientation)
        {
            _newOrientation = newOrientation;
        }
    }
}