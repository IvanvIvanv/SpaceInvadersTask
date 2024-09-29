using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class PlayerBounds : MonoBehaviour
    {
        private new BoxCollider2D collider;

        public event Action OnEnemyEnterBounds;

        private void Awake()
        {
            collider = GetComponent<BoxCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer != LayerMask.NameToLayer("Enemy")) return;
            OnEnemyEnterBounds?.Invoke();
        }

        public void SetBounds(Renderer playerRenderer)
        {
            Vector2 boundsSize = new(
                Camera.main.orthographicSize / Screen.height * Screen.width * 2,
                playerRenderer.bounds.extents.y * 2
                );

            collider.size = boundsSize;

            transform.position = playerRenderer.bounds.center;
        }
    }
}
