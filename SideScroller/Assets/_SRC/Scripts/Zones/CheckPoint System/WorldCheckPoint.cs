using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiloZitare
{
    public class WorldCheckPoint : MonoBehaviour
    {
        //[SerializeField] bool resetAllOnSpawn = true;
        //[SerializeField] ObjectRepositionPoint[] listToReset;

        PlayerController playerController;

        //GameObject[] listToNotReset = new GameObject[];
        // Start is called before the first frame update
        //void Start()
        //{
        //    if (resetAllOnSpawn)
        //    {
        //     listToReset = FindObjectsOfType<ObjectRepositionPoint>();
        //    }
        //    else
        //    {
        //    }
        //}

        private void OnTriggerEnter(Collider other)
        {
            GetPlayerController(other);
        }

        protected void GetPlayerController(Collider _collider)
        {
            if (_collider.CompareTag(TagConstants.PLAYER))
            {
                if (_collider.gameObject.TryGetComponent<PlayerController>(out PlayerController _playerController))
                {
                  SetUpPlayerController(_playerController);
                }
                else
                {
#if UNITY_EDITOR
                    Debug.LogError($"CheckPoint couldnt find {typeof(PlayerController).Name} in object {_collider.name}");
#endif
                }
            }
        }

        protected void SetUpPlayerController(PlayerController _playerController)
        {
            playerController = _playerController;
            // playerController = GetComponent<PlayerController>();
            //playerController = FindObjectOfType<PlayerController>(true);
            playerController.CheckPointReached();
            playerController.PlayerDeath += Respawn;
            playerController._CheckPointReached += DisableCheckpoint;
        }

        protected void Respawn()
        {
            //IResetOnPlayerDeath[] listToReset = FindObjectsOfType<IResetOnPlayerDeath>();
            ResetOnPlayerDeath[] listToReset = FindObjectsOfType<ResetOnPlayerDeath>();
            //IResetOnPlayerDeath[] listToReset = FindObjectsOfType<MonoBehaviour>().OfType<IResetOnPlayerDeath>();

            foreach (var _object in listToReset)
            {
                _object.ResetOnPlayerRespawn();
            }
            playerController.gameObject.SetActive(true);
            playerController.transform.position = this.transform.position;
        }

        protected void DisableCheckpoint()
        {
            playerController.PlayerDeath -= Respawn;
            playerController._CheckPointReached -= DisableCheckpoint;
           // playerController = null;
        }

        private void OnDisable()
        {
            if(playerController != null)
            {
            playerController.PlayerDeath -= Respawn;
            playerController._CheckPointReached -= DisableCheckpoint;
            }
        }

    }
}
