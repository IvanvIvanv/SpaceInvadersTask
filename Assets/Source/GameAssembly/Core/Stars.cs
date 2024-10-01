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
            Vector2 viewportCenter = Camera.main.ViewportToWorldPoint(Vector2.one / 2f);
            Vector2 viewportTopRight = Camera.main.ViewportToWorldPoint(Vector2.one);

            Bounds viewportBounds = new(viewportCenter, viewportTopRight - viewportCenter);

            var shape = particles.shape;
            shape.radius = viewportBounds.extents.x * 2f;

            var main = particles.main;
            main.startLifetime = viewportBounds.extents.y * 4f / main.startSpeed.constant;

            particles.Simulate(main.startLifetime.constant);
            particles.Play();
        }
    }
}
