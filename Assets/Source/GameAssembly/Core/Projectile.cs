using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    [RequireComponent(typeof(SpriteRendererCollider))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        private Vector2 direction;

        private new SpriteRendererCollider collider;

        private void Awake()
        {
            collider = GetComponent<SpriteRendererCollider>();
        }

        private void OnEnable()
        {
            collider.OnCollisionEnter += Hit;
        }

        private void OnDisable()
        {
            collider.OnCollisionEnter -= Hit;
        }

        private void Update()
        {
            transform.position += (Vector3)direction * Time.deltaTime;
        }

        private void Hit()
        {
            Destroy(gameObject);
        }
    }
}
