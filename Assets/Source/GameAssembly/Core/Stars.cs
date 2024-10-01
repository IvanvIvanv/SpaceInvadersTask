using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    [RequireComponent(typeof(ParticleSystem))]
    public class Stars : MonoBehaviour
    {
        private ParticleSystem particles;

        private void Awake()
        {
            particles = GetComponent<ParticleSystem>();
        }

        public void FitInBounds()
        {
            var shape = particles.shape;
            shape.radius = (
                Camera.main.ViewportToWorldPoint(Vector2.one) -
                Camera.main.ViewportToWorldPoint(Vector2.zero)).x / 2f;
        }
    }
}
