using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace SpaceInvadersTask.GameAssembly
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        private LayerMask targets;

        [SerializeField]
        private Vector2 direction;

        private void Update()
        {
            transform.position += (Vector3)direction * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (targets == (targets | (1 << other.gameObject.layer)))
                Destroy(gameObject);
        }
    }
}
