using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

namespace SpaceInvadersTask.GameAssembly
{
    public class GameState : MonoBehaviour
    {
        public static GameState Instance { get; private set; }

        [SerializeField]
        private GameObject resultsGui; 

        //Component references
        private Player player;
        private PlayerInput playerInput;

        private ChildCameraFitter cameraFitter;
        private PlayerBounds playerBounds;
        private EnemyGrid enemyGrid;

        //Misc
        private ResultsGuiDisplayer resultsGuiDisplayer;

        //Player values
        private int score;

        //Public component references
        public ProjectileCreatorDestroyer ProjectileCreatorDestroyer { get; private set; }

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

            resultsGuiDisplayer = new(resultsGui);
            GetMonoReferences();
        }

        private void Start()
        {
            NewGame();
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
            GamePauser.SetPause(true);
            resultsGuiDisplayer.ShowResultsScreen();
            playerInput.enabled = false;
        }

        public void OnReset()
        {
            NewGame();
        }

        private void NewGame()
        {
            GamePauser.SetPause(false);
            resultsGuiDisplayer.HideResultsScreen();
            playerInput.enabled = true;
            enemyGrid.GenerateGrid();
            player.Setup();
            ProjectileCreatorDestroyer.DestroyAllProjectiles();
        }

        private void GetMonoReferences()
        {
            ProjectileCreatorDestroyer = FindObjectOfType<ProjectileCreatorDestroyer>();
            cameraFitter = FindObjectOfType<ChildCameraFitter>();
            playerBounds = FindObjectOfType<PlayerBounds>();
            enemyGrid = FindObjectOfType<EnemyGrid>();
            player = FindObjectOfType<Player>();
            playerInput = player.GetComponent<PlayerInput>();
        }
    }
}