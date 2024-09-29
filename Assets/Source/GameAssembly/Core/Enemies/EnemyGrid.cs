using Codice.CM.Common;
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
        private float moveDownDistance = 3f;

        [SerializeField]
        private float moveDownOffset = 10f;

        [SerializeField]
        private float horisontalSpeed = 10f;

        private bool moveRightFlag;

        public void GenerateGrid()
        {
            GameObject[] enemies = EnemyGridGenerator.GenerateGrid(enemyPrefabs, size, enemyGap);

            foreach (var enemy in enemies)
            {
                enemy.transform.SetParent(transform);
            }
        }

        private void Update()
        {
            Vector3 newPos = transform.position;
            newPos.x += horisontalSpeed * Time.deltaTime * (moveRightFlag ? 1f : -1f);
            transform.position = newPos;

            if (Mathf.Abs(transform.localPosition.x) >= moveDownDistance)
            {
                moveRightFlag = !moveRightFlag;
                MoveDown();
            }
        }

        private void MoveDown()
        {
            var newPos = transform.position;
            newPos.y -= moveDownOffset;
            transform.position = newPos;
        }
    }
}
