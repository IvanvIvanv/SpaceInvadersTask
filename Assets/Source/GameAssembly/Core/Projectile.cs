using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    public class Projectile : MonoBehaviour
    {
        private new SpriteRenderer renderer;

        private List<IHittable> hittables = new();
        private ProjectileData data;

        private void Awake()
        {
            renderer = gameObject.AddComponent<SpriteRenderer>();
        }

        private void Update()
        {
            transform.position += (Vector3)data.Direction * Time.deltaTime;

            for (int i = 0; i < hittables.Count; i++)
            {
                if (hittables[i].Renderer == null) continue;
                if (!hittables[i].Renderer.bounds.Intersects(renderer.bounds)) continue;
                hittables[i].Hit();
                hittables.Remove(hittables[i]);
                Destroy(gameObject);
                return;
            }
        }

        public void SetTargets(List<IHittable> hittables)
        {
            this.hittables = hittables;
        }

        public void SetProjectileData(ProjectileData data)
        {
            this.data = data;
            renderer.sprite = data.Sprite;
            renderer.color = data.Color;
        }
    }
}
