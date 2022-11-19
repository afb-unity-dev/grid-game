using Com.Afb.GridGame.Data.Dto;
using UnityEditor;
using UnityEngine;

namespace Com.Afb.GridGame.Editor {
    [CustomEditor(typeof(GridSettings))]
    public class GridSettingsEditor : UnityEditor.Editor {
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            if (GUI.changed) {
                var gridSize = serializedObject.FindProperty("gridSize").intValue;
                Debug.Log("GridSize: " + gridSize);
            }
        }
    }
}

