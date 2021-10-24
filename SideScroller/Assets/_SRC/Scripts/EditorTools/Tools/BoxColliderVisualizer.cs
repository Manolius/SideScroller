using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiloZitare
{
    [RequireComponent(typeof(BoxCollider))]
    public class BoxColliderVisualizer : MonoBehaviour
    {
        public bool drawGizmos = true;
        [SerializeField] Color gizmosColor = Color.green;


        private void OnDrawGizmos()
        {
            if (drawGizmos)
            {
             BoxCollider boxCollider = GetComponent<BoxCollider>();
                Gizmos.color = gizmosColor;
                Gizmos.DrawWireCube(this.transform.position + boxCollider.center, boxCollider.bounds.size);
            }
        }
    }
}