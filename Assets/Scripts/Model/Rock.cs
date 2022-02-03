using System;

namespace TribeToSurvive.Model
{
    [Serializable]
    public class Rock : BreakableObject
    {
        public override int BreakingTime { get; } = 5000;

        public Rock(Vector3 position) : base(position)
        { }
    }
}
