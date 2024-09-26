using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceInvadersTask.GameAssembly
{
    public class Player : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField]
        private float speedMetersPerSeconds = 1f;

        float moveDir;

        private void Update()
        {
            transform.position += new Vector3(moveDir, 0f, 0f) *
                speedMetersPerSeconds *
                Time.deltaTime;
        }

        public void OnMove(InputValue value)
        {
            moveDir = value.Get<float>();
        }
    }
}
