using Codice.CM.Client.Differences.Graphic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private GameObject projectilePrefab;

        [SerializeField]
        private int scoreValue = 1;

        [SerializeField]
        private int maxHealth = 3;

        private SpriteRenderer spriteRenderer;

        private int remainingHealth;

        public event Action<int> OnEnemyKilled;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            remainingHealth = maxHealth;
        }

        private void Start()
        {
            Shoot();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("PlayerProjectile")) return;
            ReceiveDamage();
        }

        private void ReceiveDamage()
        {
            remainingHealth -= 1;
            spriteRenderer.color = Color.Lerp(Color.red, Color.white, (float)remainingHealth / maxHealth);

            if (remainingHealth > 0) return;
            Destroy(gameObject);
            OnEnemyKilled?.Invoke(scoreValue);
        }

        private void Shoot()
        {
            if (transform == null) return;

            GameObject projectileGO = GameState.Instance.ProjectileCreatorDestroyer.CreateProjectile(
                projectilePrefab, transform);

            var projectile = projectileGO.GetComponent<Projectile>();
            projectile.OnDestroyed += Shoot;
        }
    }
}
