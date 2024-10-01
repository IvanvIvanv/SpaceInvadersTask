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
            if (targets == (targets | (1 << other.gameObject.layer)))
            {
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke();
        }

        private void CheckForOutOfBounds()
        {
            if (spriteRenderer.bounds.Intersects(GameState.Instance.CameraFitter.CurrentBounds)) return;

            Destroy(gameObject);
        }
    }
}
