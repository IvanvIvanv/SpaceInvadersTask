using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    public static class TargetRegistry
    {
        public static List<IHittable> playerTargets = new();
        public static List<IHittable> enemyTargets = new();
    }
}