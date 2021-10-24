using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiloZitare
{
    [RequireComponent(typeof(BoxCollider))]
    public class MeshToggle : MonoBehaviour
    {
        public bool toggleableMeshes = true;
        protected bool prevSeting = true;

        private void Start()
        {
            bool _setMeshes = false;

#if UNITY_EDITOR
            _setMeshes = toggleableMeshes;
#endif

            SetMeshes(_setMeshes);
        }

        private void Update()
        {
#if UNITY_EDITOR
            UpdateMeshes();
#endif
        }


        private void OnDrawGizmos()
        {
            UpdateMeshes();
        }

        private void UpdateMeshes()
        {
            if (toggleableMeshes != prevSeting)
            {
                prevSeting = toggleableMeshes;
                SetMeshes(toggleableMeshes);
            }
        }

        private void SetMeshes(bool _bool)
        {
            MeshRenderer _meshRenderer = GetComponent<MeshRenderer>();
            _meshRenderer.enabled = _bool;
        }
    }
}