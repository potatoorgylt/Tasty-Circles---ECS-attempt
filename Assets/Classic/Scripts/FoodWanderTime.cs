using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TastyCirclesClassic
{
    public class FoodWanderTime : MonoBehaviour
    {
        public float timeUntilNextWander = 2f;
        private float curTime = 0f;

        private void Update()
        {
            CountWanderTime();
        }

        private void CountWanderTime()
        {
            if (curTime < timeUntilNextWander)
            {
                curTime = curTime + Time.deltaTime;
            }
            else
            {
                curTime = 0f;
            }
        }

        public float WanderTime()
        {
            return curTime;
        }
    }
}