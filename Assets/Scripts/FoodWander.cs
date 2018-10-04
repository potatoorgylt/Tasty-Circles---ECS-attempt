using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class FoodWander : MonoBehaviour
{
    public float timeUntilNextPos = 2f;
    [HideInInspector]
    public float curTime = 0f;

    public float speed = 5f;

    [HideInInspector]
    public Vector2 nextPos;

    [HideInInspector]
    public SpawnFood spawnFood;

    private void Start()
    {
        spawnFood = GameObject.FindWithTag("GameManager").GetComponent<SpawnFood>();
    }

    /*void Update()
    {
        Debug.Log(curTime);
        curTime = curTime + Time.deltaTime;

        if (curTime < timeUntilNextPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }
        else
        {
            nextPos = new Vector2(Random.Range(-spawnFood.playArea.x, spawnFood.playArea.x), Random.Range(-spawnFood.playArea.y, spawnFood.playArea.y));
            curTime = 0f;
        }
    }*/
}

class FoodWanderSystem : ComponentSystem
{
    struct Componenents
    {
        public FoodWander foodWander;
        public Transform transform;
    }

    protected override void OnUpdate()
    {
        foreach (var e in GetEntities<Componenents>())
        {
            e.foodWander.curTime = e.foodWander.curTime + Time.deltaTime;

            if (e.foodWander.curTime < e.foodWander.timeUntilNextPos)
            {
                e.transform.position = Vector2.MoveTowards(e.transform.position, e.foodWander.nextPos, e.foodWander.speed * Time.deltaTime);
            }
            else
            {
                e.foodWander.nextPos = new Vector2(Random.Range(-e.foodWander.spawnFood.playArea.x, e.foodWander.spawnFood.playArea.x), Random.Range(-e.foodWander.spawnFood.playArea.y, e.foodWander.spawnFood.playArea.y));
                e.foodWander.curTime = 0f;
            }
        }
    }
}
