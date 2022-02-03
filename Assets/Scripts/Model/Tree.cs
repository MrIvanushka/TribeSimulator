using System;

namespace TribeToSurvive.Model
{
    [Serializable]
    public class Tree : BreakableObject
    {
        public override int BreakingTime { get; } = 5000;

        public Tree(Vector3 position) : base(position)
        { }
    }
}
