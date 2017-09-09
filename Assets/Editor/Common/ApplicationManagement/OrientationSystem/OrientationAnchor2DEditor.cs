using Assets.Scripts.Common.ApplicationManagement.OrientationSystem;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor.Common.ApplicationManagement.OrientationSystem
{
    [CustomEditor(typeof(OrientationAnchor2D))]
    public class OrientationAnchor2DEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var orientationAnchor = target as OrientationAnchor2D;
            var rectTransform = orientationAnchor.gameObject.GetComponent<RectTransform>();

            if (GUILayout.Button("Set Portrait Anchor"))
            {
                orientationAnchor._portraitAnchoredPosition3D = rectTransform.anchoredPosition3D;
                orientationAnchor._portraitAnchorMax = rectTransform.anchorMax;
                orientationAnchor._portraitAnchorMin = rectTransform.anchorMin;
                orientationAnchor._portraitPivot = rectTransform.pivot;
                orientationAnchor._portraitRotation = rectTransform.localRotation.eulerAngles;
                orientationAnchor._portraitScale = rectTransform.localScale;
            }
            if (GUILayout.Button("Set Landscape Anchor"))
            {
                orientationAnchor._landscapeAnchoredPosition3D = rectTransform.anchoredPosition3D;
                orientationAnchor._landscapeAnchorMax = rectTransform.anchorMax;
                orientationAnchor._landscapeAnchorMin = rectTransform.anchorMin;
                orientationAnchor._landscapePivot = rectTransform.pivot;
                orientationAnchor._landscapeRotation = rectTransform.localRotation.eulerAngles;
                orientationAnchor._landscapeScale = rectTransform.localScale;
            }

            if (GUILayout.Button("Move To Portrait Anchor"))
            {
                rectTransform.anchoredPosition3D = orientationAnchor._portraitAnchoredPosition3D;
                rectTransform.anchorMax = orientationAnchor._portraitAnchorMax;
                rectTransform.anchorMin = orientationAnchor._portraitAnchorMin;
                rectTransform.pivot = orientationAnchor._portraitPivot;
                rectTransform.localRotation = Quaternion.Euler(orientationAnchor._portraitRotation);
                rectTransform.localScale = orientationAnchor._portraitScale;
            }
            if (GUILayout.Button("Move To Landscape Anchor"))
            {
                rectTransform.anchoredPosition3D = orientationAnchor._landscapeAnchoredPosition3D;
                rectTransform.anchorMax = orientationAnchor._landscapeAnchorMax;
                rectTransform.anchorMin = orientationAnchor._landscapeAnchorMin;
                rectTransform.pivot = orientationAnchor._landscapePivot;
                rectTransform.localRotation = Quaternion.Euler(orientationAnchor._landscapeRotation);
                rectTransform.localScale = orientationAnchor._landscapeScale;
            }
        }
    }
}