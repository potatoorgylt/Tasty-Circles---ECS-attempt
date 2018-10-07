using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TastyCirclesHybrid
{
    public class EatObject : MonoBehaviour
    {
        PlayerManager playerManager;

        float areaSize;
        float changeScale;

        SpawnAI spawnFood;

        private void Start()
        {
            playerManager = GetComponent<PlayerManager>();
            areaSize = playerManager.getScale();
            spawnFood = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SpawnAI>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.transform.localScale.x < gameObject.transform.localScale.x)
            {
                Grow(collision);
                spawnFood.foodCount--;
                Destroy(collision.gameObject);
            }
            else
            {
                areaSize = areaSize / 2;
                changeScale = Mathf.Sqrt(areaSize / Mathf.PI);

                playerManager.setScale(changeScale);
            }

        }

        public void Grow(Collider2D collision)
        {
            AIManager objFoodManager = collision.gameObject.GetComponent<AIManager>();

            areaSize = areaSize + objFoodManager.getArea();
            changeScale = Mathf.Sqrt(areaSize / Mathf.PI);

            playerManager.setScale(changeScale);
        }
    }
}
