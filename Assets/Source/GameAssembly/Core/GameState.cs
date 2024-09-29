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

        private Player player;
        private PlayerInput playerInput;

        private ChildCameraFitter cameraFitter;
        private PlayerBounds playerBounds;
        private EnemyGrid enemyGrid;
        private TextMeshProUGUI resultsText;

        private int score;

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
            playerInput = player.GetComponent<PlayerInput>();

            resultsText = resultsGui.GetComponentInChildren<TextMeshProUGUI>();

            player.OnResetted += OnResettedHandler;
        }

        private void Start()
        {
            SetupGame();
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
            ShowResultsScreen();
        }

        private void OnResettedHandler()
        {
            SetupGame();
        }

        private void SetupGame()
        {
            SetPaused(false);
            playerInput.SwitchCurrentActionMap("Player");

            enemyGrid.GenerateGrid();

            resultsGui.SetActive(false);

            player.Setup();
        }

        private void ShowResultsScreen(bool win = false)
        {
            StringBuilder resultsBuilder = new();
            resultsBuilder.AppendLine(win ? "You won" : "You lost");
            resultsBuilder.AppendLine("Press R to restart");

            resultsBuilder.Append("Score: ");
            resultsBuilder.AppendLine(score.ToString());

            resultsText.text = resultsBuilder.ToString();
            resultsGui.SetActive(true);

            SetPaused(true);
            playerInput.SwitchCurrentActionMap("Gui");
        }

        private void SetPaused(bool paused)
        {
            Time.timeScale = paused ? 0f : 1f;
        }
    }
}