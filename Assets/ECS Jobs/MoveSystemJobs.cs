using Unity.Collections;
using Unity.Entities;
using Unity.Burst;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TastyCirclesHybrid
{
    // Moves objects within world bounds.
    /*public class MoveSystemJobs : JobComponentSystem
    {
        [BurstCompile]
        struct MovementJob : IJobProcessComponentData<Position, Move>
        {
            public float moveSpeed;
            public float deltaTime;
            public Vector2 playArea;
            public float wanderTime;

            private Vector2 nextPos;

            public void Execute(ref Position position, [ReadOnly] ref Move speed)
            {
                float3 pos = position.Value;
                if (wanderTime > 0f)
                {
                    //pos = Vector3.MoveTowards(pos, nextPos, moveSpeed * deltaTime);
                    pos.x += deltaTime * speed.velocity;
                    pos.y += deltaTime * speed.velocity;
                }
                else
                {
                    //This causes Unity crash, my guess is that it's caused by Random.Range since it's called from the main thread.
                    //nextPos = new Vector2(Random.Range(-playArea.x, playArea.x), Random.Range(-playArea.y, playArea.y));
                    //Let's try to think of something else
                    //nextPos += deltaTime * speed.velocity;
                }

                position.Value = pos;
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            MovementJob moveJob = new MovementJob
            {
                wanderTime = GameManager.instance.WanderTime(),
                playArea = GameManager.instance.playArea,
                deltaTime = Time.deltaTime,
            };

            JobHandle moveHandle = moveJob.Schedule(this, inputDeps);

            return moveHandle;
        }

        /*struct Group
        {
            public ComponentDataArray<Position> positions;
            public ComponentDataArray<Move> moves;
            public readonly ComponentDataArray<Faction> factions;
            public readonly int Length;
        }

        [Inject] Group m_Group;

        

        Vector2 playArea;

        private List<Vector2> nextPos = new List<Vector2>();
        private FoodWanderTime foodWanderTime;

        SpawnAI spawnAI;

        private float foodSpeed;
        private float enemySpeed;

        protected override void OnStartRunning()
        {
            base.OnStartRunning();
            foodWanderTime = GameManager.instance.GetComponent<FoodWanderTime>();

            playArea = GameManager.instance.playArea;

            foodSpeed = GameManager.instance.foodSpeed;
            enemySpeed = GameManager.instance.enemySpeed;
        }

        protected override void OnUpdate()
        {
            float dt = Time.deltaTime;

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
                    if(m_Group.factions[i].faction == 0)
                        pos = Vector2.MoveTowards(pos, nextPos[i], foodSpeed * Time.deltaTime);
                    else
                        pos = Vector2.MoveTowards(pos, nextPos[i], enemySpeed * Time.deltaTime);
                }
                else
                {
                    nextPos[i] = new Vector2(Random.Range(-playArea.x, playArea.x), Random.Range(-playArea.y, playArea.y));
                }

                // assign the position back
                m_Group.positions[i] = new Position { Value = pos };
            }
        }
    }*/
}
