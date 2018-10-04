using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject food;
    public int foodLimit = 1200;
    [HideInInspector]
    public int foodCount = 0;

    public Vector2 playArea;

    private void Start()
    {
        for (int foodCount = 0; foodCount < foodLimit; foodCount++)
        {
            GameObject foodClone = Instantiate(food, new Vector3(Random.Range(-playArea.x, playArea.x), Random.Range(-playArea.y, playArea.y), 0), Quaternion.identity);
            foodClone.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            foodCount++;
        }
    }

    private void Update()
    {
        for(int i = 0; i < 100; i++)
        {
            if (foodCount < foodLimit)
            {
                GameObject foodClone = Instantiate(food, new Vector3(Random.Range(-playArea.x, playArea.x), Random.Range(-playArea.y, playArea.y), 0), Quaternion.identity);
                foodClone.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                foodCount++;
            }
            else
                break;
        }
    }
}
