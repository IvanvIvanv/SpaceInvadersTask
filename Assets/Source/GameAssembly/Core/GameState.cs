using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    public class GameState : MonoBehaviour
    {
        public static GameState Instance { get; private set; }

        private Player player;
        private ChildCameraFitter cameraFitter;
        private PlayerBounds playerBounds;
        private EnemyGrid enemyGrid;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }

            enemyGrid = FindObjectOfType<EnemyGrid>();
            cameraFitter = FindObjectOfType<ChildCameraFitter>();
            playerBounds = FindObjectOfType<PlayerBounds>();
            player = FindObjectOfType<Player>();
        }

        private void Start()
        {
            enemyGrid.GenerateGrid();
            cameraFitter.FitCamera();
            playerBounds.SetBounds(player.GetComponent<Renderer>());
            playerBounds.OnEnemyEnterBounds += OnEnemyEnterBoundsHandler;
        }

        private void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }

        private void OnEnemyEnterBoundsHandler()
        {
            Debug.Log("Lose");
        }
    }
}