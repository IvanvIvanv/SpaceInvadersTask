using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    public class ChildCameraFitter : MonoBehaviour
    {
        public Bounds CurrentBounds { get; private set; }

        public void FitCamera()
        {
            Bounds childBounds = transform.GetCombinedBoundsOfChildren();
            Camera.main.FitInBounds(childBounds);

            CurrentBounds = childBounds;
        }
    }
}
