using UnityEngine;
using UnityEngine.SceneManagement;

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
            _titleScene = string.Empty;
        }

        [SerializeField()]
        private string _titleScene;

        private void Start()
        {
            if (_titleScene != null)
            {
                SceneManager.LoadSceneAsync(_titleScene, LoadSceneMode.Additive);
            }
        }
    }
}