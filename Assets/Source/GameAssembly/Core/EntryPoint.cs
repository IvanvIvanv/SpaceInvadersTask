using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    public class EntryPoint : MonoBehaviour
    {
        [Header("Enemy Generation")]
        [SerializeField]
        private EnemyData[] enemyTypes;

        [SerializeField]
        private Vector2Int gridSize;

        [SerializeField]
        private Vector2 enemyGap;

        private void Awake()
        {
            EnemyData[,] enemyGrid = EnemyPlacer.GenerateEnemyGrid(enemyTypes, gridSize);
            GameObject enemyCollectionGO = new("EnemyCollection");
            Transform enemyCollectionTransform = enemyCollectionGO.transform;
            enemyCollectionTransform.SetParent(transform, true);
            EnemyPlacer.PlaceEnemiesInGrid(enemyGrid, enemyCollectionTransform, enemyGap);
        }
    }
}