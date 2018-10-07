using Unity.Entities;
using Unity.Mathematics;

namespace TastyCirclesHybrid
{
    // Makes an object move within world bounds.
    // Does not do anything by itself, just provides data to MoveSystem.
    [System.Serializable]
    public struct Move : IComponentData
    {
        public float velocity;
    }

    public class MoveComponent : ComponentDataWrapper<Move> { }
}
