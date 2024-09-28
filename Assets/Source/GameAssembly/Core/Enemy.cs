using Codice.CM.Client.Differences.Graphic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    public class Enemy : MonoBehaviour, IHittable
    {
        private new SpriteRenderer renderer;

        public Renderer Renderer => renderer;

        void Awake()
        {
            renderer = gameObject.AddComponent<SpriteRenderer>();
            TargetRegistry.playerTargets.Add(this);
        }

        public void Hit()
        {
            if (this == null) return;
            Destroy(gameObject);
        }

        public void SetData(EnemyData data)
        {
            renderer.sprite = data.Sprite;
        }
    }
}
