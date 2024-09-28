using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceInvadersTask.GameAssembly
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Player : MonoBehaviour, IHittable
    {
        [Header("Movement")]
        [SerializeField]
        private float speedMetersPerSeconds = 1f;

        [Header("Shooting")]
        [SerializeField]
        private ProjectileData projectileData;

        private SpriteRenderer spriteRenderer;

        private float moveDir;

        private Bounds borderBounds;

        public Renderer Renderer => spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            TargetRegistry.enemyTargets.Add(this);
        }

        private void Update()
        {
            transform.position += speedMetersPerSeconds * Time.deltaTime * new Vector3(moveDir, 0f, 0f);
        }

        public void OnMove(InputValue value)
        {
            moveDir = value.Get<float>();
        }

        public void OnShoot()
        {
            ProjectileCreator.Create(TargetRegistry.playerTargets, projectileData, transform);
        }

        public void Hit()
        {
            throw new System.NotImplementedException();
        }
    }
}