using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TastyCirclesClassic
{
    public class SpawnAI : MonoBehaviour
    {
        public GameObject food;
        public GameObject enemy;

        public int enemyLimit = 30;
        public int foodLimit = 1200;
        [HideInInspector]
        public int foodCount = 0;
        [HideInInspector]
        public int enemyCount = 0;

        Vector2 playArea;

        public bool canRespawn = true;

        private void Start()
        {
            playArea = GameManager.instance.playArea;

            for (int i = 0; i < foodLimit; i++)
            {
                Spawn(food);
                foodCount++;
                food.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            }

            for (int enemyCount = 0; enemyCount < enemyLimit; enemyCount++)
            {
                Spawn(enemy);
            }
        }

        private void Update()
        {
            if (canRespawn == true)
            {
                for (int i = 0; i < 100; i++)
                {
                    if (foodCount < foodLimit)
                    {
                        Spawn(food);
                        foodCount++;
                        food.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                    }
                    else
                        break;
                }
            }
        }
        void Spawn(GameObject obj)
        {
            GameObject objClone = Instantiate(obj, new Vector3(
                Random.Range(-playArea.x, playArea.x),
                Random.Range(-playArea.y, playArea.y), 0),
                Quaternion.identity);
        }
    }
}