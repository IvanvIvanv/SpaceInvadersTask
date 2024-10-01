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

        [SerializeField]
        private TextMeshProUGUI scoreDisplay;

        //Component references
        private Player player;
        private PlayerInput playerInput;

        private PlayerBounds playerBounds;
        private EnemyGrid enemyGrid;
        private Stars stars;

        //Misc
        private ResultsGuiDisplayer resultsGuiDisplayer;

        //Player values
        private int score;

        //Public component references
        public ProjectileCreatorDestroyer ProjectileCreatorDestroyer { get; private set; }
        public ChildCameraFitter CameraFitter { get; private set; }

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
            CameraFitter.FitCamera();
            playerBounds.SetBounds(player.GetComponent<Renderer>());
            stars.FitInBounds();

            playerBounds.OnEnemyEnterBounds += OnEnemyEnterBoundsHandler;
            enemyGrid.OnEnemyKilled += OnEnemyKilledHandler;
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

        private void OnEnemyKilledHandler(int scoreValue)
        {
            SetScore(score + scoreValue);
        }

        public void OnReset()
        {
            NewGame();
        }

        private void SetScore(int newScore)
        {
            score = newScore;
            scoreDisplay.text = score.ToString();
        }

        private void NewGame()
        {
            GamePauser.SetPause(false);
            resultsGuiDisplayer.HideResultsScreen();
            playerInput.enabled = true;
            enemyGrid.GenerateGrid();
            player.Setup();
            ProjectileCreatorDestroyer.DestroyAllProjectiles();
            SetScore(0);
        }

        private void GetMonoReferences()
        {
            ProjectileCreatorDestroyer = FindObjectOfType<ProjectileCreatorDestroyer>();
            CameraFitter = FindObjectOfType<ChildCameraFitter>();
            playerBounds = FindObjectOfType<PlayerBounds>();
            enemyGrid = FindObjectOfType<EnemyGrid>();
            stars = FindObjectOfType<Stars>();

            player = FindObjectOfType<Player>();
            playerInput = player.GetComponent<PlayerInput>();
        }
    }
}