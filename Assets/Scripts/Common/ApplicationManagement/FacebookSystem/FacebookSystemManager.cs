using UnityEngine;

namespace Assets.GhostcheeseGames.PaleoMatch.Scripts.Common.ApplicationManagement.FacebookSystem
{
    public class FacebookSystemManager : MonoBehaviour
    {
        private static FacebookSystemManager _instance;

        public static FacebookSystemManager Instance
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

        //private bool _autoLogin;

        public FacebookSystemManager()
        {
            Instance = this;
            //_autoLogin = true;
        }

        //private void Awake()
        //{
        //    if (!FB.IsInitialized)
        //    {
        //        FB.Init(InitCallback, OnHideUnity);
        //    }
        //    if (_autoLogin)
        //    {
        //        FB.ActivateApp();
        //    }
        //}

        //private void InitCallback()
        //{
        //    if (FB.IsInitialized)
        //    {
        //        FB.ActivateApp();
        //    }
        //    else
        //    {
        //        Debug.Log("Failed to Initialize the Facebook SDK.");
        //    }
        //}

        //private void OnHideUnity(bool isUnityShown)
        //{
        //    if (!isUnityShown)
        //    {
        //        Time.timeScale = 0f;
        //    }
        //    else
        //    {
        //        Time.timeScale = 1f;
        //    }
        //}

        //public void Login()
        //{

        //}

        //public void Logout()
        //{

        //}
    }
}