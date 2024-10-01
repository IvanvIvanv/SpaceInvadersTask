using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    public class EnemyGrid : MonoBehaviour
    {
        [Header("EnemyGeneration")]
        [SerializeField]
        private GameObject[] enemyPrefabs;

        [SerializeField]
        private Vector2Int size;

        [SerializeField]
        private Vector2 enemyGap;

        [Header("GridMovement")]
        [SerializeField]
        private float changeDirDistance = 3f;

        [SerializeField]
        private float moveDownOffset = 10f;

        [SerializeField]
        private float horisontalSpeed = 10f;

        //Composition
        private EnemyGridMovement movement;
        private EnemyGridGenerator enemyGridGenerator;

        //Properties
        public Enemy[,] CurrentEnemyGrid { get; private set; }

        private void Awake()
        {
            movement = new EnemyGridMovement(transform, changeDirDistance, moveDownOffset, horisontalSpeed);
            enemyGridGenerator = new EnemyGridGenerator(transform);
        }

        private void Update()
        {
            movement.FrameMove();
        }

        public void GenerateGrid()
        {
            CurrentEnemyGrid = enemyGridGenerator.GenerateGrid(enemyPrefabs, size, enemyGap);
        }
    }
}
