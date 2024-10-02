using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    public class EnemyGridShooting
    {
        private readonly Enemy[,] enemyGrid;

        private readonly float minShootDelay = 3f;
        private readonly float maxShootDelay = 8f;

        public EnemyGridShooting(Enemy[,] enemyGrid, float minShootDelay = 3f, float maxShootDelay = 8f)
        {
            this.enemyGrid = enemyGrid;
            this.maxShootDelay = maxShootDelay;
            this.minShootDelay = minShootDelay;
        }

        public IEnumerator ShootingRoutine()
        {
            while(true)
            {
                yield return new WaitForSeconds(Random.Range(minShootDelay, maxShootDelay));
                ShootRandom();
            }
        }

        private void ShootRandom()
        {
            List<Enemy[]> ableToShootColumns = GetAbleToShootColumns();
            if (ableToShootColumns.Count == 0) return;
            Enemy[] selectedColumnToShoot = ableToShootColumns[Random.Range(0, ableToShootColumns.Count)];
            selectedColumnToShoot.Last(enemy => enemy != null).Shoot();
        }

        private List<Enemy[]> GetAbleToShootColumns()
        {
            List<Enemy[]> ableToShootColumns = new();

            for (int column = 0; column < enemyGrid.GetLength(0); column++)
            {
                bool isColumnAbleToShoot = false;
                Enemy[] columnEnemies = new Enemy[enemyGrid.GetLength(1)];
                for (int row = 0; row < enemyGrid.GetLength(1); row++)
                {
                    var enemy = enemyGrid[column, row];
                    columnEnemies[row] = enemy;
                    if (enemy != null)
                    {
                        isColumnAbleToShoot = true;
                    }
                }
                if (isColumnAbleToShoot)
                {
                    ableToShootColumns.Add(columnEnemies);
                }
            }

            return ableToShootColumns;
        }
    }
}
