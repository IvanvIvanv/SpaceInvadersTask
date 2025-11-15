using System.Collections;
using System.Collections.Generic;
using GamePush;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    public class GamePushInitializer : MonoBehaviour
    {
        [SerializeField] private GameState gameState;

        private void Awake()
        {
            GP_Init.OnReady += OnInit;
        }

        private void OnInit()
        {
            GP_Player.Login();
            Debug.Log($"Player ID: {GP_Player.GetID()}");
            gameState.NewGame();
        }
    }
}
