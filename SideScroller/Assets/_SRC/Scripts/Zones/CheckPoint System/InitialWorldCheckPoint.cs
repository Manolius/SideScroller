using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiloZitare
{
    public class InitialWorldCheckPoint : WorldCheckPoint
    {
        private void Start()
        {
            PlayerController _playerController = GetComponentInChildren<PlayerController>();
            SetUpPlayerController(_playerController);
        }
    }
}