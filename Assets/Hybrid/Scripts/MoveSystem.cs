using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using System.Collections.Generic;

namespace TastyCirclesHybrid
{
    // Moves objects within world bounds.
    public class MoveSystem : ComponentSystem
    {
        struct Group
        {
            public ComponentDataArray<Position> positions;
            public ComponentDataArray<Move> moves;
            public readonly int Length;
        }

        [Inject] Group m_Group;

        Vector2 playArea;

        private List<Vector2> nextPos = new List<Vector2>();
        private FoodWanderTime foodWanderTime;

        protected override void OnStartRunning()
        {
            base.OnStartRunning();
            foodWanderTime = GameManager.instance.GetComponent<FoodWanderTime>();
        }

        protected override void OnUpdate()
        {
            float dt = Time.deltaTime;
            playArea = GameManager.instance.playArea;

            for(int i = 0; i < m_Group.Length; i++)
            {
                if (nextPos.Count < m_Group.Length)
                {
                    nextPos.Add(new Vector2(0, 0));
                }
                else if(nextPos.Count > m_Group.Length)
                {
                    nextPos.RemoveAt(nextPos.Count-1);
                }

                Vector3 pos = m_Group.positions[i].Value;
                Move move = m_Group.moves[i];

                if(foodWanderTime.WanderTime() > 0f)
                {
                    pos = Vector2.MoveTowards(pos, nextPos[i], 1f * Time.deltaTime);
                }
                else
                {
                    nextPos[i] = new Vector2(Random.Range(-playArea.x, playArea.x), Random.Range(-playArea.y, playArea.y));
                }

                // assign the position back
                m_Group.positions[i] = new Position { Value = pos };
            }
        }
    }
}
