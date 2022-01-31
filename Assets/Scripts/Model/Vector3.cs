namespace TribeToSurvive.Model
{
    [System.Serializable]
    public struct Vector3
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }

        public Vector3(float x, float y, float z) => (X, Y, Z) = (x, y, z);
        public Vector3(UnityEngine.Vector3 vector) => (X, Y, Z) = (vector.x, vector.y, vector.z);
    }
}
