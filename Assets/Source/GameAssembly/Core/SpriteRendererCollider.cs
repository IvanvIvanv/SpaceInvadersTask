using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SpaceInvadersTask.GameAssembly
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteRendererCollider : MonoBehaviour
    {
        private static readonly List<SpriteRendererCollider> colliderRegistry = new();

        [SerializeField]
        private LayerMask collidesWith;

        private new SpriteRenderer renderer;

        public event Action OnCollisionEnter;

        public LayerMask CollidesWith => collidesWith;

        public SpriteRenderer Renderer => renderer;

        private void Awake()
        {
            renderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            colliderRegistry.Add(this);
        }

        private void OnDisable()
        {
            colliderRegistry.Remove(this);
        }

        private void Update()
        {
            for (int i = 0; i < colliderRegistry.Count; i++)
            {
                var collider = colliderRegistry[i];
                if (collider == this) continue;
                if ((collidesWith.value & (1 << collider.gameObject.layer)) == 0) continue;
                if (!renderer.bounds.Intersects(collider.Renderer.bounds)) continue;

                Collide();

                if ((collider.CollidesWith.value & (1 << gameObject.layer)) != 0)
                    collider.Collide();
            }
        }

        public void Collide()
        {
            OnCollisionEnter?.Invoke();
        }
    }
}