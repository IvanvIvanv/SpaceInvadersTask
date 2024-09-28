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
        private float speedMetersPerSeconds = 1f;

        private SpriteRenderer spriteRenderer;

        private float moveDir;

        private Bounds borderBounds;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            transform.position += speedMetersPerSeconds * Time.deltaTime * new Vector3(moveDir, 0f, 0f);
        }

        public void OnMove(InputValue value)
        {
            moveDir = value.Get<float>();
        }
    }
}