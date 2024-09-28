using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    [CreateAssetMenu(fileName = "New EnemyData", menuName = "EnemyData", order = 51)]
    public class EnemyData : ScriptableObject
    {
        [field: SerializeField]
        public Sprite Sprite { get; private set; }
    }
}
