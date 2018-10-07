using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TastyCirclesHybrid
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

        public float speed = 1f;

        Vector2 playArea;

        public bool canRespawn = true;

        Entity entity;
        EntityManager manager;

        private void Start()
        {
            playArea = GameManager.instance.playArea;

            manager = World.Active.GetExistingManager<EntityManager>();

            for (int i = 0; i < foodLimit; i++)
            {
                Spawn(ref food);
                //set velocity
                manager.SetComponentData(entity, new Move { velocity = speed });
                SetColor(ref food);
                foodCount++;
            }

            for (int enemyCount = 0; enemyCount < enemyLimit; enemyCount++)
            {
                Spawn(ref enemy);
                //set velocity
                manager.SetComponentData(entity, new Move { velocity = speed });
            }
        }

        private void Update()
        {
            if (canRespawn == true)
            {
                if (foodCount < foodLimit)
                {
                    Spawn(ref food);
                    foodCount++;
                    //set velocity
                    manager.SetComponentData(entity, new Move { velocity = speed });
                    SetColor(ref food);
                }
            }
        }

        void Spawn(ref GameObject obj)
        {
            GameObject objClone = Instantiate(obj);

            //Set position
            Vector3 pos = new Vector3(
                Random.Range(-playArea.x, playArea.x),
                Random.Range(-playArea.y, playArea.y), 0);

            entity = objClone.GetComponent<GameObjectEntity>().Entity;
            manager.SetComponentData(entity, new Position { Value = pos});
        }

        void SetColor(ref GameObject obj)
        {
            Color col = obj.GetComponent<SpriteRenderer>().color;
            col = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            manager.AddComponentData(entity, new SpriteColor { color = col });
        }
    }
}