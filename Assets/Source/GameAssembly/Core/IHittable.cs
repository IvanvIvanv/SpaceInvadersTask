using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    public interface IHittable
    {
        Renderer Renderer { get; }

        void Hit();
    }
}
