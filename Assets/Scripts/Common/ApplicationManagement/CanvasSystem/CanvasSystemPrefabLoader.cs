using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Common.ApplicationManagement.CanvasSystem
{
    public class CanvasSystemPrefabLoader : MonoBehaviour
    {
        [SerializeField()]
        private bool _clearCanvasSystem;

        [SerializeField()]
        private GameObject _loadCanvasSystemPrefab;

        public CanvasSystemPrefabLoader()
        {
            _clearCanvasSystem = true;
            _loadCanvasSystemPrefab = null;
        }

        private void Awake()
        {
            if (_clearCanvasSystem == true && CanvasSystemManager.Instance != null && CanvasSystemManager.Instance.Canvas != null && CanvasSystemManager.Instance.Canvas.transform != null)
            {
                var children = new List<GameObject>();
                foreach (Transform child in CanvasSystemManager.Instance.Canvas.transform) children.Add(child.gameObject);
                children.ForEach(child => Destroy(child));
            }
        }

        private void Start()
        {
            if (_loadCanvasSystemPrefab != null && CanvasSystemManager.Instance != null && CanvasSystemManager.Instance.Canvas != null && CanvasSystemManager.Instance.Canvas.transform != null)
            {
                Instantiate(_loadCanvasSystemPrefab, CanvasSystemManager.Instance.Canvas.transform, false);
            }
        }
    }
}