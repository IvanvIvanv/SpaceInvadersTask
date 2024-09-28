using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField]
        private EnemyGridData gridData;

        private void Awake()
        {
            EnemyPlacer.GridDataToEnemyGrid(gridData, transform);

            Bounds combinedBounds = transform.GetCombinedBoundsOfChildren();
            Camera.main.FitInBounds(combinedBounds);
        }
    }
}