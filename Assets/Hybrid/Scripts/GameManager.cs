using UnityEditor;
using UnityEngine;

namespace TastyCirclesHybrid
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public Vector2 playArea;

        public float foodSpeed = 1f;
        public float enemySpeed = 5f;

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogError("More than one GameManager in scene");
            }
            else
            {
                instance = this;
            }
        }

        public void Victory()
        {
            Debug.Log("Victory");
            EditorApplication.isPaused = true;
        }

        public void Defeat()
        {
            Debug.Log("Defeat");
            EditorApplication.isPaused = true;
        }


        //Food wander time in game manager
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
