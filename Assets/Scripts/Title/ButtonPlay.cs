using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Title
{
    public class ButtonPlay : MonoBehaviour
    {
        [SerializeField()]
        private Animator _animatorLoading;

        public ButtonPlay()
        {
            _animatorLoading = null;
        }

        private void Awake()
        {
            if (_animatorLoading == null)
            {
                _animatorLoading = GetComponent<Animator>();
            }
        }

        public void OnButtonClick()
        {
            _animatorLoading.SetBool("Visible", true);
            StartCoroutine(LoadLevelSelect());
        }

        private IEnumerator LoadLevelSelect()
        {
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadSceneAsync("SceneLevelSelect", LoadSceneMode.Additive);
        }
    }
}