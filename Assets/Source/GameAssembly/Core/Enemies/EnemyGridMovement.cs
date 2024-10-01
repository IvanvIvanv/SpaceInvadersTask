using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    public class EnemyGridMovement
    {
        private readonly Transform gridTransform;

        private readonly float changeDirDistance = 3f;
        private readonly float moveDownOffset = 10f;
        private readonly float horisontalSpeed = 10f;

        private float currentHorisontalDirection = 1f;

        public EnemyGridMovement(
            Transform gridTransform, 
            float changeDirDistance = 3f, float moveDownOffset = 10f, float horisontalSpeed = 10f)
        {
            this.gridTransform = gridTransform;
            this.changeDirDistance = changeDirDistance;
            this.moveDownOffset = moveDownOffset;
            this.horisontalSpeed = horisontalSpeed;
        }

        public void FrameMove()
        {
            CheckChangeDirection();

            Vector3 newPos = gridTransform.position;
            newPos.x += horisontalSpeed * Time.deltaTime * currentHorisontalDirection;
            gridTransform.position = newPos;
        }

        public void ResetMovement()
        {
            gridTransform.localPosition = Vector3.zero;
            currentHorisontalDirection = 1f;
        }

        private void CheckChangeDirection()
        {
            if (gridTransform.localPosition.x * currentHorisontalDirection < changeDirDistance) return;

            currentHorisontalDirection = -currentHorisontalDirection;
            MoveDown();
        }

        private void MoveDown()
        {
            var newPos = gridTransform.position;
            newPos.y -= moveDownOffset;
            gridTransform.position = newPos;
        }
    }
}
