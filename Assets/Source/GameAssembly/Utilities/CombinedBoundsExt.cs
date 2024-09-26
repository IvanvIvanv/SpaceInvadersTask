using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    public static class CombinedBoundsExt
    {
        public static Bounds GetCombinedBoundsOfChildren(this Transform transform)
        {
            Bounds combinedBounds = new();
            bool initBoundsFlag = false;

            Renderer[] renderers = transform.GetComponentsInChildren<Renderer>();

            for (int i = 0; i < renderers.Length; i++)
            {
                if (!initBoundsFlag)
                {
                    combinedBounds = renderers[i].bounds;
                    initBoundsFlag = true;
                    continue;
                }

                combinedBounds.Encapsulate(renderers[i].bounds);
            }

            return combinedBounds;
        }
    }
}
