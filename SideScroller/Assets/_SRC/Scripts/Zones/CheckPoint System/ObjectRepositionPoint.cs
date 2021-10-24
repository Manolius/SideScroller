using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiloZitare
{
    public class ObjectRepositionPoint : ResetOnPlayerDeath
    {
        Transform char2Spawn;

        void Start()
        {
            if (this.transform.childCount == 1)
            {
                char2Spawn = this.transform.GetChild(0);
                char2Spawn.parent = null;
            }
            else
            {
                Debug.LogError($"{typeof(ObjectRepositionPoint).Name} has {this.transform.childCount} children when it has to be 1");
            }
        }
    
        public override void ResetOnPlayerRespawn()
        {
            char2Spawn.gameObject.SetActive(false);
            char2Spawn.transform.position = this.transform.position;
            char2Spawn.gameObject.SetActive(true);
        }
       
    }
}
