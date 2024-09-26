using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    public static class BoundsEncapsulatedExt
    {
        public static bool AreEncapsulatedIn(this Bounds thisBounds, Bounds thatBounds)
        {
            return 
                thisBounds.Contains(thatBounds.min) && 
                thisBounds.Contains(thatBounds.max);
        }

        //public static Vector3 GetOffsetToKeepInside(this Bounds thisBounds, Bounds thatBounds)
        //{
        //    Vector3 maxOffset = Vector3.Abs(thatBounds.max - thisBounds.max);
        //    Vector3 minOffset = thatBounds.min - thisBounds.min;

        //    return
        //}
    }
}
