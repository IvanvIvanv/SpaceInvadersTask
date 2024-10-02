using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersTask.GameAssembly
{
    public class LivesIcons : MonoBehaviour
    {
        [SerializeField]
        private GameObject iconPrefab;

        public void SetLives(int lives)
        {
            for (int i = 0; i < lives; i++)
            {
                if (i >= transform.childCount)
                {
                    Instantiate(iconPrefab, transform);
                }
            }
        }

        public void SubtractLife()
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
