using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    public static class ProjectileCreator
    {
        public static void Create(List<IHittable> targets, ProjectileData data, Transform source)
        {
            GameObject projectileGO = new();

            Transform projectileTransform = projectileGO.transform;
            projectileTransform.position = source.position;
            projectileTransform.rotation = source.rotation;

            var projectile = projectileGO.AddComponent<Projectile>();
            projectile.SetTargets(targets);
            projectile.SetProjectileData(data);
        }
    }
}
