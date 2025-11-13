using System;
using System.Collections;
using System.Collections.Generic;
using GameAnalyticsSDK;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Enemy : MonoBehaviour, IHittable
    {
        [SerializeField]
        private GameObject projectilePrefab;

        [SerializeField]
        private int scoreValue = 1;

        [SerializeField]
        private int maxHealth = 3;

        [SerializeField]
        private string enemyID;

        private SpriteRenderer spriteRenderer;

        private int remainingHealth;

        public event Action<string, int> OnEnemyKilled;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            remainingHealth = maxHealth;
        }

        public void Shoot()
        {
            GameState.Instance.ProjectileCreatorDestroyer.CreateProjectile(
                projectilePrefab, transform);
        }

        private void ReceiveDamage()
        {
            remainingHealth -= 1;
            spriteRenderer.color = Color.Lerp(Color.red, Color.white, (float)remainingHealth / maxHealth);
            GameAnalytics.NewDesignEvent("EnemyDamaged");

            if (remainingHealth > 0) return;
            Destroy(gameObject);
            OnEnemyKilled?.Invoke(enemyID, scoreValue);
        }

        public void Hit()
        {
            ReceiveDamage();
        }
    }
}
