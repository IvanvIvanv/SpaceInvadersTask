using Codice.CM.Client.Differences.Graphic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private GameObject projectilePrefab;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("PlayerProjectile")) return;
            Destroy(gameObject);
        }
    }
}
