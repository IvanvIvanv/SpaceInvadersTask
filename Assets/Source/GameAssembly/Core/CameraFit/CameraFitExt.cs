using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    public static class CameraFitExt
    {
        public static void FitInBounds(this Camera thisCamera, Bounds bounds)
        {
            thisCamera.transform.position = bounds.center - Vector3.forward * 10f;

            float newSize = bounds.extents.y;

            float widthRatio = (float)Screen.width / Screen.height;
            float widthSize = newSize * widthRatio;
            float widthExceed = bounds.extents.x / widthSize;

            if (widthExceed > 1f)
            {
                newSize *= widthExceed;
            }

            thisCamera.orthographicSize = newSize;
        }
    }
}
