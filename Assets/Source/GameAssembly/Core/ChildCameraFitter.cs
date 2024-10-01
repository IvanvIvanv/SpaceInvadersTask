using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    public class ChildCameraFitter : MonoBehaviour
    {
        public Bounds CurrentBounds { get; private set; }

        public void FitCamera(Vector2 margin)
        {
            Bounds childBounds = transform.GetCombinedBoundsOfChildren();
            childBounds.Expand(margin);
            Camera.main.FitInBounds(childBounds);

            CurrentBounds = childBounds;
        }
    }
}
