using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int[,] bricksArray = new int[,] {
        {0,0,0,0,2,0,0,0,0},
        {0,0,0,1,2,1,0,0,0},
        {0,0,2,2,2,2,2,0,0},
        {0,1,1,1,2,1,1,1,0},
        {0,0,0,0,2,0,0,0,0},
    };

    public int[,] bricksArray3 = new int[,] {
        {0,0,3,0,0},
        {0,0,3,0,0},
        {0,2,3,2,2},
        {1,1,3,1,1},
        {0,2,3,2,0}
    };

    public float yOffset;
    public Vector2 brickSize = new Vector2(1, 0.5f);

    List<Klocek> klocki = new List<Klocek>();
    public Klocek prefab;

    private void Start()
    {
        Generate(bricksArray3);
    }

    public void Generate(int[,] level)
    {
        Vector2 startPos = Vector2.zero;
        startPos.x = -level.GetLength(1) * 0.5f * brickSize.x + brickSize.x * 0.5f;
        startPos.y = -level.GetLength(0)* 0.5f * brickSize.y + yOffset;

        for(int x=0; x < level.GetLength(1); x++)
        {
            for(int y=0; y < level.GetLength(0); y++)
            {
                if (level[y, x] == 0) continue;
                SpawnujKlocka(
                    x * brickSize.x + startPos.x, 
                    y * brickSize.y + startPos.y, 
                    level[y, x]
                    );
            }
        }
    }

    void SpawnujKlocka( float x, float y, int zycia)
    {
        Vector3 pos = new Vector3(x, y, 0);
        Klocek instancja = Instantiate(prefab, pos, Quaternion.identity, transform);
        instancja.SetKlocek(zycia);

        klocki.Add(instancja);
    }
}
