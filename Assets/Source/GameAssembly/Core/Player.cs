using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceInvadersTask.GameAssembly
{
    [RequireComponent(typeof(SpriteRendererCollider))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Player : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField]
        private float speedMetersPerSeconds = 1f;

        [Header("Shooting")]
        [SerializeField]
        private GameObject projectilePrefab;

        private SpriteRenderer spriteRenderer;
        private new SpriteRendererCollider collider;

        private float moveDir;

        public Renderer Renderer => spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            collider = GetComponent<SpriteRendererCollider>();
            collider.OnCollisionEnter += Hit;
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
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.transform.position = transform.position;
        }

        public void Hit()
        {
            Destroy(gameObject);
        }
    }
}