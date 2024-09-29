using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    public class EnemyGridGenerator : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] enemyPrefabs;

        [SerializeField]
        private Vector2Int size;

        [SerializeField]
        private Vector2 enemyGap;

        private void Awake()
        {
            GameObject[,] enemyGrid = CreateEnemyGrid(enemyPrefabs, size);
            GridPlacer.PositionInGrid(enemyGrid, enemyGap);
        }

        private GameObject[,] CreateEnemyGrid(GameObject[] enemyPrefabs, Vector2Int gridSize)
        {
            GameObject[,] enemyGrid = new GameObject[gridSize.x, gridSize.y];

            for (int row = 0; row < gridSize.y; row++)
            {
                GameObject rowType = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

                for (int column = 0; column < gridSize.x; column++)
                {
                    GameObject enemy = Instantiate(rowType, transform);
                    enemyGrid[column, row] = enemy;
                }
            }

            return enemyGrid;
        }
    }
}
