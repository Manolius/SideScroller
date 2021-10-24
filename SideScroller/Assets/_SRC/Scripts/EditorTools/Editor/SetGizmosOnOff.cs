using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MiloZitare
{

    public class SetGizmosOnOff : EditorWindow
    {
        private bool colliderGizmos = true;
        private bool prevcolliderGizmos = true;
        
        private bool enableMeshes = true;
        private bool prevEnableMeshes = true;



        [MenuItem("Personalized Tools/Tools")]
        protected static void ShowWindow()
        {
            GetWindow<SetGizmosOnOff>("Toggle Gizmos");
        }

        void OnGUI()
        {
            colliderGizmos = EditorGUILayout.Toggle("Draw colliders Gizmos", colliderGizmos);
            if (prevcolliderGizmos != colliderGizmos)
            {
                prevcolliderGizmos = colliderGizmos;
                BoxColliderVisualizer[] _boxColliderVisualizerList = FindObjectsOfType<BoxColliderVisualizer>();
                foreach (var _boxColliderVisualizer in _boxColliderVisualizerList)
                {
                    _boxColliderVisualizer.drawGizmos = colliderGizmos;
                }

            }

            enableMeshes = EditorGUILayout.Toggle("Enable Meshes On/Off", enableMeshes);
            if (prevEnableMeshes != enableMeshes)
            {
                prevEnableMeshes = enableMeshes;
                MeshToggle[] _meshToggleList = FindObjectsOfType<MeshToggle>();
                foreach (var _meshToggle in _meshToggleList)
                {
                    _meshToggle.toggleableMeshes = enableMeshes;
                }
            }
        }
    }
}