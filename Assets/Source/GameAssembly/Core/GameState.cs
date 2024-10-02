using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Linq;

namespace SpaceInvadersTask.GameAssembly
{
    public class GameState : MonoBehaviour
    {
        public static GameState Instance { get; private set; }

        [Header("Gui")]
        [SerializeField]
        private GameObject resultsGui;

        [SerializeField]
        private TextMeshProUGUI scoreDisplay;

        [Header("Camera")]
        [SerializeField]
        private Vector2 cameraMargin = new(10f, 10f);

        //Component references
        private Player player;
        private PlayerInput playerInput;

        private PlayerBounds playerBounds;
        private EnemyGrid enemyGrid;
        private Stars stars;
        private LivesIcons livesIcons;

        //Misc
        private ResultsGuiDisplayer resultsGuiDisplayer;
        private int remainingEnemies;

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
            CameraFitter.FitCamera(cameraMargin);
            playerBounds.SetBounds(player.GetComponent<Renderer>());
            stars.FitInBounds();

            playerBounds.OnEnemyEnterBounds += OnEnemyEnterBoundsHandler;
            player.OnHit += OnPlayerHitHandler;
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
            Lose();
        }

        private void OnEnemyKilledHandler(int scoreValue)
        {
            SetScore(score + scoreValue);
            remainingEnemies--;
            if (remainingEnemies == 0) Win();
        }

        private void OnPlayerHitHandler(int newLives)
        {
            if (newLives == 0) Lose();
            livesIcons.SubtractLife();
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
            SetScore(0);
            livesIcons.SetLives(player.MaxLives);
            resultsGuiDisplayer.HideResultsScreen();

            player.Setup();
            playerInput.enabled = true;

            ProjectileCreatorDestroyer.DestroyAllProjectiles();

            enemyGrid.GenerateGrid();
            remainingEnemies = enemyGrid.InitialEnemyCount;
            enemyGrid.CurrentEnemyGrid.OfType<Enemy>().ToList().ForEach(enemy => enemy.OnEnemyKilled += OnEnemyKilledHandler);
        }

        private void GetMonoReferences()
        {
            ProjectileCreatorDestroyer = FindObjectOfType<ProjectileCreatorDestroyer>();
            CameraFitter = FindObjectOfType<ChildCameraFitter>();
            playerBounds = FindObjectOfType<PlayerBounds>();
            enemyGrid = FindObjectOfType<EnemyGrid>();
            stars = FindObjectOfType<Stars>();
            livesIcons = FindObjectOfType<LivesIcons>();

            player = FindObjectOfType<Player>();
            playerInput = player.GetComponent<PlayerInput>();
        }

        private void Lose()
        {
            GamePauser.SetPause(true);
            resultsGuiDisplayer.ShowResultsScreen();
            playerInput.enabled = false;
        }

        private void Win()
        {
            GamePauser.SetPause(true);
            resultsGuiDisplayer.ShowResultsScreen(true);
            playerInput.enabled = false;
        }
    }
}