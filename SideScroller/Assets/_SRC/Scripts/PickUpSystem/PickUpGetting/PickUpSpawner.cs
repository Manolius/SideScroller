using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiloZitare
{
    public class PickUpSpawner : CanPickUp
    {
        [SerializeField] public float respawnCD = 0.1f;

        PickUpController spawnedPickUp;

        public Func<IEnumerator> Respawncoroutine { get; private set; }

        private void Start()
        {
            TakePickUp();
        }

        public override PickUpController TakePickUp()
        {
            if (this.transform.childCount > 0)
            {
                spawnedPickUp = this.transform.GetChild(0).gameObject.GetComponent<PickUpController>();
                spawnedPickUp.OnUseFinished += RespawnPickUp;
                //spawnedPickUp.onFullReset += InstantRespawn;

                return spawnedPickUp;
            }
            return null;
        }

        //private void InstantRespawn()
        //{
        //  StopCoroutine(ReSpawnPickUp());
        //  Respawn();
        //}

        private void RespawnPickUp()
        {
            if (this.gameObject == null || (bool)this.gameObject?.activeSelf) StartCoroutine(ReSpawnPickUp());
        }
        IEnumerator ReSpawnPickUp()
        {
            Respawncoroutine = ReSpawnPickUp;
            yield return Wait.Seconds(respawnCD);
            Respawn();
        }

        protected void Respawn()
        {
            spawnedPickUp.transform.position = this.transform.position;
            spawnedPickUp.transform.parent = this.transform;
            spawnedPickUp.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            if (spawnedPickUp != null)
            {
                spawnedPickUp.OnUseFinished -= RespawnPickUp;
                //spawnedPickUp.onFullReset -= InstantRespawn;
                // spawnedPickUp.OnUseFinished -= RespawnPickUp;
            }
            StopAllCoroutines();
        }

        public override void ResetOnPlayerRespawn()
        {
            spawnedPickUp.FullReset();
            Respawn();
        }
    }

}