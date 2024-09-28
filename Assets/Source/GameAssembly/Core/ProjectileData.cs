using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    [CreateAssetMenu(fileName = "New ProjectileData", menuName = "ProjectileData", order = 51)]
    public class ProjectileData : ScriptableObject
    {
        [field: SerializeField]
        public Sprite Sprite { get; private set; }

        [field: SerializeField]
        public Color Color { get; private set; } = Color.white;

        [field: SerializeField]
        public Vector2 Direction { get; private set; }
    }
}
