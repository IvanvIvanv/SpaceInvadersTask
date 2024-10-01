using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    public static class EnemyGridGenerator
    {
        public static Enemy[] GenerateGrid(GameObject[] enemyPrefabs, Vector2Int size, Vector2 enemyGap)
        {
            GameObject[,] enemyGrid = GenerateEnemyArray2D(enemyPrefabs, size);
            GridPlacer.PositionInGrid(enemyGrid, enemyGap);
            return enemyGrid.Cast<GameObject>().Select(c => c.GetComponent<Enemy>()).ToArray();
        }

        private static GameObject[,] GenerateEnemyArray2D(GameObject[] enemyPrefabs, Vector2Int gridSize)
        {
            GameObject[,] enemyGrid = new GameObject[gridSize.x, gridSize.y];

            for (int row = 0; row < gridSize.y; row++)
            {
                GameObject rowType = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

                for (int column = 0; column < gridSize.x; column++)
                {
                    GameObject enemy = Object.Instantiate(rowType);
                    enemyGrid[column, row] = enemy;
                }
            }

            return enemyGrid;
        }
    }
}
