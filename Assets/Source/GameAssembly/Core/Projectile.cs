using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        private LayerMask targets;

        [SerializeField]
        private Vector2 direction;

        private SpriteRenderer spriteRenderer;

        private bool hitFlag;

        public event Action OnDestroyed;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            transform.position += (Vector3)direction * Time.deltaTime;
            CheckForOutOfBounds();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (hitFlag) return;
            if (targets != (targets | (1 << other.gameObject.layer))) return;
            if (!other.gameObject.TryGetComponent<IHittable>(out var hittable)) return;
            hittable.Hit();
            Destroy(gameObject);
            hitFlag = true;
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke();
        }

        private void CheckForOutOfBounds()
        {
            Vector2 viewportCenter = Camera.main.ViewportToWorldPoint(new(0.5f, 0.5f));
            Vector2 viewportTopRight = Camera.main.ViewportToWorldPoint(Vector2.one);

            if (spriteRenderer.bounds.Intersects(new(viewportCenter, (viewportTopRight - viewportCenter) * 2f))) return;

            Destroy(gameObject);
        }
    }
}
