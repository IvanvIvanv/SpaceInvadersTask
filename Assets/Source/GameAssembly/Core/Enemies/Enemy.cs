using Codice.CM.Client.Differences.Graphic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    [RequireComponent(typeof(SpriteRendererCollider))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private Sprite sprite;

        [SerializeField]
        private GameObject projectilePrefab;

        private new SpriteRenderer renderer;
        private new SpriteRendererCollider collider;

        public Renderer Renderer => renderer;

        void Awake()
        {
            renderer = GetComponent<SpriteRenderer>();
            collider = GetComponent<SpriteRendererCollider>();

            renderer.sprite = sprite;
            collider.OnCollisionEnter += Hit;
        }

        public void Hit()
        {
            Destroy(gameObject);
        }
    }
}
