using System.Collections.Generic;
using UnityEngine;
using TribeToSurvive.SaveSystems;

namespace TribeToSurvive.Model
{
    public class MapGenerator : MonoBehaviour
    {
        [SerializeField] private int _mapLength = 7;
        [SerializeField] [Range(0, 100)] private int _wallChance = 50;

        private const int CHUNK_SEPARATION_DEGREE = 20;

        public void GenerateMap()
        {
            Chunk[] chunks = new Chunk[_mapLength * _mapLength];
            bool[,] heightMap = GenerateHeightMap();

            for (int i = 0; i < _mapLength; i++)
            {
                for (int j = 0; j < _mapLength; j++)
                {
                    chunks[i * _mapLength + j] = GenerateChunk(i, j, heightMap);
                }
            }
            Unit firstUnit = new Unit(new Vector3(10, 0, 10));
            SaveSystem.SaveGame(new GameData(chunks, firstUnit));
        }

        private bool[,] GenerateHeightMap()
        {
            bool[,] heightMap = new bool[_mapLength * CHUNK_SEPARATION_DEGREE, _mapLength * CHUNK_SEPARATION_DEGREE];

            for (int i = 0; i < heightMap.GetLength(0); i++)
            {
                for (int j = 0; j < heightMap.GetLength(1); j++)
                {
                    if (i < 10 || j < 10 || i > heightMap.GetLength(0) - 10 || j > heightMap.GetLength(1) - 10)
                        heightMap[i, j] = true;
                    else if (Vector2.Distance(new Vector2(i, j), new Vector2(heightMap.GetLength(0) / 2, heightMap.GetLength(1) / 2)) < 5)
                        heightMap[i, j] = false;
                    else
                        heightMap[i, j] = Random.Range(0, 100) > _wallChance;
                }
            }

            UseCellAutomat(heightMap);

            return heightMap;
        }

        private void UseCellAutomat(bool[,] map)
        {
            int minimalNeighboursToSurvive = 4;

            for (int x = 1; x < map.GetLength(0) - 1; x++)
                for (int y = 1; y < map.GetLength(1) - 1; y++)
                {
                    int neighbourCount = ScoreNeighbours(map, x, y);

                    if (neighbourCount > minimalNeighboursToSurvive)
                        map[x, y] = false;
                    else if (neighbourCount < minimalNeighboursToSurvive)
                        map[x, y] = true;
                }
        }
        private int ScoreNeighbours(bool[,] map, int coordX, int coordY)
        {
            int neighbourCount = 0;

            for (int i = coordX - 1; i < coordX + 2; i++)
                for (int j = coordY - 1; j < coordY + 2; j++)
                    if ((i != coordX || j != coordY) && map[i, j] == false)
                        neighbourCount += 1;

            return neighbourCount;
        }

        private Chunk GenerateChunk(int chunkCoordX, int chunkCoordY, bool[,] heightMap)
        {
            int ñhunkFreeSquare = CHUNK_SEPARATION_DEGREE * CHUNK_SEPARATION_DEGREE;
            List<ISceneObject> chunkObjects = new List<ISceneObject>();
            bool[,] cellIsFree = new bool[CHUNK_SEPARATION_DEGREE, CHUNK_SEPARATION_DEGREE];

            for (int x = 0; x < CHUNK_SEPARATION_DEGREE; x++)
            {
                for (int y = 0; y < CHUNK_SEPARATION_DEGREE; y++)
                {
                    if (heightMap[x + CHUNK_SEPARATION_DEGREE * chunkCoordX, y + CHUNK_SEPARATION_DEGREE * chunkCoordY] == true)
                    {
                        chunkObjects.Add(new Rock(new Vector3((float)x / 2 - 5 + 10 * chunkCoordX, 0, (float)y / 2 - 5 + 10 * chunkCoordY)));
                        ñhunkFreeSquare -= 1;
                        cellIsFree[x, y] = false;
                    }
                    else
                    {
                        cellIsFree[x, y] = true;
                    }
                }
            }

            int treeCount = Random.Range(ñhunkFreeSquare / 10, ñhunkFreeSquare / 5);

            for (int i = 0; i < treeCount; i++)
            {
                Vector2 coord = GetRandomCoord(cellIsFree) + new Vector2(0.0025f * Random.Range(-10, 10), 0.0025f * Random.Range(-10, 10));
                chunkObjects.Add(new Tree(new Vector3(coord.x / 2 - 5 + 10 * chunkCoordX, 0, coord.y / 2 - 5 + 10 * chunkCoordY)));
            }

            return new Chunk(new Vector3(chunkCoordX * 10, 0, chunkCoordY * 10), chunkObjects);
        }

        private Vector2Int GetRandomCoord(bool[,] cellIsFree)
        {
            Vector2Int coord;
            int recursionChecker = 0;

            do
            {
                coord = new Vector2Int(Random.Range(0, CHUNK_SEPARATION_DEGREE), Random.Range(0, CHUNK_SEPARATION_DEGREE));
                recursionChecker++;

                if (recursionChecker > 5000)
                    throw new System.Exception("Unable to find a place on the chunk");
            }
            while (cellIsFree[coord.x, coord.y] == false);

            cellIsFree[coord.x, coord.y] = false;
            return coord;
        }
    }
}
