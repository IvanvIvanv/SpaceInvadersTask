using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceInvadersTask.GameAssembly
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Player : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField]
        private float speed = 1f;

        [Header("Shooting")]
        [SerializeField]
        private GameObject projectilePrefab;

        private float moveDir;

        public event Action OnResetted;

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
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.transform.position = transform.position;
        }

        public void OnReset()
        {
            OnResetted?.Invoke();
        }

        public void Setup()
        {
            Vector3 newPos = transform.position;
            newPos.x = 0;
            transform.position = newPos;
        }
    }
}