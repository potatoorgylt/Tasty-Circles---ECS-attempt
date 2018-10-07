using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TastyCirclesHybrid
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public Vector2 playArea;

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
    }
}
