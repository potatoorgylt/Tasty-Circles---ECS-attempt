using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TastyCirclesClassic
{
    public class AIManager : MonoBehaviour
    {
        float area;

        SpriteRenderer spriteRenderer;

        private void Start()
        {
            area = Mathf.PI * Mathf.Pow(gameObject.transform.localScale.x / 2, 2);
        }

        public float getArea()
        {
            return area;
        }
    }
}

