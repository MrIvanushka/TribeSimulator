namespace TribeToSurvive.Model
{
    public interface ISceneObject
    {
        UnityEngine.Vector3 Position { get; }

        void Destroy();
    }
}
