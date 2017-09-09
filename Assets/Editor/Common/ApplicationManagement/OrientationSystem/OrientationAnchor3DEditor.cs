using Assets.Scripts.Common.ApplicationManagement.OrientationSystem;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor.Common.ApplicationManagement.OrientationSystem
{
    [CustomEditor(typeof(OrientationAnchor3D))]
    public class OrientationAnchor3DEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var orientationAnchor = target as OrientationAnchor3D;
            var rectTransform = orientationAnchor.gameObject.transform;

            if (GUILayout.Button("Set Portrait Anchor"))
            {
                orientationAnchor._portraitPosition = rectTransform.localPosition;
                orientationAnchor._portraitRotation = rectTransform.localRotation.eulerAngles;
                orientationAnchor._portraitScale = rectTransform.localScale;
            }
            if (GUILayout.Button("Set Landscape Anchor"))
            {
                orientationAnchor._landscapePosition = rectTransform.localPosition;
                orientationAnchor._landscapeRotation = rectTransform.localRotation.eulerAngles;
                orientationAnchor._landscapeScale = rectTransform.localScale;
            }

            if (GUILayout.Button("Move To Portrait Anchor"))
            {
                rectTransform.localPosition = orientationAnchor._portraitPosition;
                rectTransform.localRotation = Quaternion.Euler(orientationAnchor._portraitRotation);
                rectTransform.localScale = orientationAnchor._portraitScale;
            }
            if (GUILayout.Button("Move To Landscape Anchor"))
            {
                rectTransform.localPosition = orientationAnchor._landscapePosition;
                rectTransform.localRotation = Quaternion.Euler(orientationAnchor._landscapeRotation);
                rectTransform.localScale = orientationAnchor._landscapeScale;
            }
        }
    }
}
