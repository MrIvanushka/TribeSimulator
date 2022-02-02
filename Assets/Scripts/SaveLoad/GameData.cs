using System.Collections;
using System.Collections.Generic;
using TribeToSurvive.Model;

namespace TribeToSurvive.SaveSystems
{
    [System.Serializable]
    public class GameData
    {
        public List<ISceneObject> Objects;
        public Vector3 CameraPosition;

        public GameData(Chunk[] chunks, Unit unit)
        {
            Objects = new List<ISceneObject>(chunks);
            Objects.Add(unit);

            CameraPosition = new Vector3(unit.Position.x, 3, unit.Position.z);
        }
    }
}
