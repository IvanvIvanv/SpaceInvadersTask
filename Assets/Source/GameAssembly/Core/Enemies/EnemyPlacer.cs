using GluonGui.WorkspaceWindow.Views.WorkspaceExplorer.Explorer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceInvadersTask.GameAssembly
{
    public static class EnemyPlacer
    {
        public static EnemyData[,] GenerateEnemyGrid(EnemyData[] enemyTypes, Vector2Int gridSize)
        {
            EnemyData[,] enemyGrid = new EnemyData[gridSize.x, gridSize.y];

            for (int row = 0; row < gridSize.y; row++)
            {
                EnemyData rowType = enemyTypes[Random.Range(0, enemyTypes.Length)];

                for (int column = 0; column < gridSize.x; column++)
                {
                    enemyGrid[column, row] = rowType;
                }
            }

            return enemyGrid;
        }

        public static void PlaceEnemiesInGrid(
            EnemyData[,] enemyDatas, Transform parent, Vector2 enemyGap)
        {
            float gridHorisontalExtent = (enemyDatas.GetLength(0) * enemyGap.x - enemyGap.x) / 2;

            for (int row = 0; row < enemyDatas.GetLength(1); row++)
            {
                for (int column = 0; column < enemyDatas.GetLength(0); column++)
                {
                    GameObject enemyGO = CreateEnemy(enemyDatas[column, row], parent);
                    Transform enemyTransform = enemyGO.transform;

                    Vector2 initPos = parent.transform.position;
                    initPos.x -= gridHorisontalExtent;
                    enemyTransform.localPosition = initPos;

                    Vector2 enemyOffset = new(
                        column * enemyGap.x,
                        row * -enemyGap.y);

                    enemyTransform.localPosition += (Vector3)enemyOffset;
                }
            }
        }

        private static GameObject CreateEnemy(EnemyData enemyData, Transform parent)
        {
            GameObject enemyGO = new("Enemy");
            enemyGO.transform.SetParent(parent, true);

            var enemyRenderer = enemyGO.AddComponent<SpriteRenderer>();
            enemyRenderer.sprite = enemyData.Sprite;

            return enemyGO;
        }
    }
}
