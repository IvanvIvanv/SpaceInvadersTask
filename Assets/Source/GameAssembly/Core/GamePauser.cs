using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    public static class GamePauser
    {
        public static void SetPause(bool pause)
        {
            Time.timeScale = pause ? 0f : 1f;
        }
    }
}
