using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceInvadersTask.GameAssembly
{
    public static class GridPlacer
    {
        public static void PositionInGrid(
            GameObject[,] gameOjbects, Vector2 gap)
        {
            float gridHorisontalExtent = (gameOjbects.GetLength(0) * gap.x - gap.x) / 2;

            for (int row = 0; row < gameOjbects.GetLength(1); row++)
            {
                for (int column = 0; column < gameOjbects.GetLength(0); column++)
                {
                    GameObject go = gameOjbects[column, row];
                    Transform transform = go.transform;

                    Vector2 initPos = new();
                    initPos.x -= gridHorisontalExtent;
                    transform.localPosition = initPos;

                    Vector2 gridOffset = new(
                        column * gap.x,
                        row * -gap.y);

                    transform.localPosition += (Vector3)gridOffset;
                }
            }
        }
    }
}
