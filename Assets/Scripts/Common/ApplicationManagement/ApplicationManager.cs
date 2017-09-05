using UnityEngine;

namespace Assets.Scripts.Common.ApplicationManagement
{
    public class ApplicationManager : MonoBehaviour
    {
        private static ApplicationManager _instance;

        public static ApplicationManager Instance
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

        public ApplicationManager()
        {
            Instance = this;
        }
    }
}