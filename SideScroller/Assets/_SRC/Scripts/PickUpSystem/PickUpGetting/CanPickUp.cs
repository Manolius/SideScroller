 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiloZitare
{
    public abstract class CanPickUp : ResetOnPlayerDeath
    {
        [HideInInspector]public bool canPickUp = true;
        public abstract PickUpController TakePickUp();
    }
}