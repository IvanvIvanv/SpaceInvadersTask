using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    public class EnemyGrid : MonoBehaviour
    {
        [Header("Enemy Generation")]
        [SerializeField]
        private GameObject[] enemyPrefabs;

        [SerializeField]
        private Vector2Int size;

        [SerializeField]
        private Vector2 enemyGap;

        [Header("Grid Movement")]
        [SerializeField]
        private float changeDirDistance = 3f;

        [SerializeField]
        private float moveDownOffset = 10f;

        [SerializeField]
        private float horisontalSpeed = 10f;

        [Header("Grid Shooting")]
        [SerializeField]
        private float minShootDelay = 3f;

        [SerializeField]
        private float maxShootDelay = 8f;

        //Composition
        private EnemyGridMovement movement;
        private EnemyGridGenerator generator;
        private EnemyGridShooting shooting;

        //Coroutines
        private Coroutine enemyShootingCoroutine;

        //Properties
        public Enemy[,] CurrentEnemyGrid { get; private set; }

        private void Awake()
        {
            movement = new EnemyGridMovement(transform, changeDirDistance, moveDownOffset, horisontalSpeed);
            generator = new EnemyGridGenerator(transform);
        }

        private void Update()
        {
            movement.FrameMove();
        }

        public void GenerateGrid()
        {
            StopEnemyShooting();
            movement.ResetMovement();
            CurrentEnemyGrid = generator.GenerateGrid(enemyPrefabs, size, enemyGap);
            shooting = new EnemyGridShooting(CurrentEnemyGrid, minShootDelay, maxShootDelay);
            enemyShootingCoroutine = StartCoroutine(shooting.ShootingRoutine());
        }

        private void StopEnemyShooting()
        {
            if (enemyShootingCoroutine == null) return;
            StopCoroutine(enemyShootingCoroutine);
        }
    }
}
