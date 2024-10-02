using System;
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
        private float speed = 1f;

        [Header("Shooting")]
        [SerializeField]
        private GameObject projectilePrefab;

        [Header("Lives")]
        [SerializeField]
        private int maxLives = 3;

        private float moveDir;

        private GameObject createdProjectile;

        private int remainingLives;

        public event Action<int> OnHit;

        public int MaxLives => maxLives;

        private void Update()
        {
            Vector3 newPos = transform.position;
            newPos.x += speed * Time.deltaTime * moveDir;
            
            Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
            Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

            newPos.x = Mathf.Clamp(newPos.x, leftEdge.x, rightEdge.x);
            transform.position = newPos;
        }

        public void OnMove(InputValue value)
        {
            moveDir = value.Get<float>();
        }

        public void OnShoot()
        {
            if (createdProjectile != null) return;
            createdProjectile = 
                GameState.Instance.ProjectileCreatorDestroyer.CreateProjectile(
                projectilePrefab,
                transform);
        }

        public void Setup()
        {
            Vector3 newPos = transform.position;
            newPos.x = 0;
            transform.position = newPos;
            remainingLives = maxLives;
        }

        public void Hit()
        {
            remainingLives -= 1;
            OnHit?.Invoke(remainingLives);
        }
    }
}