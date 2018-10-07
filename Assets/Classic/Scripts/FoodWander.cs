using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TastyCirclesClassic
{
    public class FoodWander : MonoBehaviour
    {
        public float speed = 5f;

        private Vector2 nextPos;

        private GameObject gameManagerObj;
        private FoodWanderTime foodWanderTime;

        Vector2 playArea;

        private void Start()
        {
            playArea = GameManager.instance.playArea;

            gameManagerObj = GameObject.FindWithTag("GameManager");
            foodWanderTime = gameManagerObj.GetComponent<FoodWanderTime>();
        }

        void Update()
        {
            if (foodWanderTime.WanderTime() > 0f)
            {
                transform.position = Vector2.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
            }
            else
            {
                nextPos = new Vector2(Random.Range(-playArea.x, playArea.x), Random.Range(-playArea.y, playArea.y));
            }
        }
    }
}