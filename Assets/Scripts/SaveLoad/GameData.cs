using System.Collections;
using System.Collections.Generic;
using TribeToSurvive.Model;

namespace TribeToSurvive.SaveSystems
{
    [System.Serializable]
    public class GameData
    {
        public List<Chunk> Chunks;
        public List<Unit> Units;
        public Vector3 CameraPosition;

        public GameData(Chunk[] chunks, Unit unit)
        {
            Chunks = new List<Chunk>(chunks);
            Units = new List<Unit>() { unit };
            CameraPosition = new Vector3(unit.Position.x, 10, unit.Position.z);
        }
    }
}
