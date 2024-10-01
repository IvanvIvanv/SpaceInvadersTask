using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    public class ProjectileCreatorDestroyer : MonoBehaviour
    {
        public GameObject CreateProjectile(GameObject projectilePrefab, Transform source)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform);
            projectile.transform.position = source.position;

            return projectile;
        }

        public void DestroyAllProjectiles()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}
