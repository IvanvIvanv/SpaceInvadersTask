using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    public class EnemyGridGenerator
    {
        private readonly Transform gridTransform;

        public EnemyGridGenerator(Transform gridTransform)
        {
            this.gridTransform = gridTransform;
        }

        public Enemy[,] GenerateGrid(GameObject[] enemyPrefabs, Vector2Int size, Vector2 enemyGap)
        {
            ClearEnemies(gridTransform);

            Enemy[,] enemyGrid = GenerateEnemyArray2D(enemyPrefabs, size);
            GridPlacer.PositionInGrid(enemyGrid, enemyGap);

            return enemyGrid;
        }

        private void ClearEnemies(Transform gridTransform)
        {
            for (int i = 0; i < gridTransform.childCount; i++)
            {
                Object.Destroy(gridTransform.GetChild(i).gameObject);
            }
        }

        private Enemy[,] GenerateEnemyArray2D(GameObject[] enemyPrefabs, Vector2Int gridSize)
        {
            Enemy[,] enemyGrid = new Enemy[gridSize.x, gridSize.y];

            for (int row = 0; row < gridSize.y; row++)
            {
                GameObject rowType = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

                for (int column = 0; column < gridSize.x; column++)
                {
                    GameObject enemy = Object.Instantiate(rowType);
                    enemyGrid[column, row] = enemy.GetComponent<Enemy>();
                    enemy.transform.SetParent(gridTransform, true);
                }
            }

            return enemyGrid;
        }
    }
}
