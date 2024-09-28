using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    [CreateAssetMenu(fileName = "New EnemyGridData", menuName = "EnemyGridData", order = 51)]
    public class EnemyGridData : ScriptableObject
    {
        [field: SerializeField]
        public EnemyData[] EnemyTypes { get; private set; }

        [field: SerializeField]
        public Vector2Int Size { get; private set; }

        [field: SerializeField]
        public Vector2 EnemyGap { get; private set; }
    }
}