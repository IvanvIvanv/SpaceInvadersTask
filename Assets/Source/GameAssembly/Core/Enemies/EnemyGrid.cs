using System;
using System.Collections;
using System.Collections.Generic;
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

        private float currentHorisontalDirection;

        public event Action<int> OnEnemyKilled;

        public Enemy[] GenerateGrid()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }

            Enemy[] enemies = EnemyGridGenerator.GenerateGrid(enemyPrefabs, size, enemyGap);

            foreach (var enemy in enemies)
            {
                enemy.transform.SetParent(transform);
                enemy.OnEnemyKilled += scoreValue => OnEnemyKilled?.Invoke(scoreValue);
            }

            currentHorisontalDirection = 1f;

            return enemies;
        }

        private void Update()
        {
            CheckChangeDirection();

            Vector3 newPos = transform.position;
            newPos.x += horisontalSpeed * Time.deltaTime * currentHorisontalDirection;
            transform.position = newPos;
        }

        private void CheckChangeDirection()
        {
            if (transform.localPosition.x * currentHorisontalDirection < changeDirDistance) return;

            currentHorisontalDirection = -currentHorisontalDirection;
            MoveDown();
        }

        private void MoveDown()
        {
            var newPos = transform.position;
            newPos.y -= moveDownOffset;
            transform.position = newPos;
        }
    }
}
