using Unity.Entities;
using UnityEngine;

namespace TastyCirclesHybrid
{
    // Makes an object move within world bounds.
    // Does not do anything by itself, just provides data to MoveSystem.
    [System.Serializable]
    public struct Faction : IComponentData
    {
        public int faction;
    }

    public class FactionComponent : ComponentDataWrapper<Faction> { }
}