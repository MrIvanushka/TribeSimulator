namespace TribeToSurvive.Model
{
    interface IVector3
    {
        float X { get; }
        float Y { get; }
        float Z { get; }
    }

    [System.Serializable]
    public struct Vector3 : IVector3
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }

        public Vector3(float x, float y, float z) => (X, Y, Z) = (x, y, z);
        public Vector3(UnityEngine.Vector3 vector) => (X, Y, Z) = (vector.x, vector.y, vector.z);

        public static Vector3 operator * (Vector3 vector, float a)
        {
            return new Vector3(vector.X * a, vector.Y * a, vector.Z * a);
        }
        public static Vector3 operator + (Vector3 a, Vector3 b)
        {
            return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

    }
}
