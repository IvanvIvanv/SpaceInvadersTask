using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    public class ChildCameraFitter : MonoBehaviour
    {
        [SerializeField]
        private new Camera camera;

        private void Start()
        {
            Bounds childBounds = transform.GetCombinedBoundsOfChildren();
            camera.FitInBounds(childBounds);
        }
    }
}
