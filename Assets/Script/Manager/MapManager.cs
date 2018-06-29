using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tile
{
    non = 0,
    black_left = 1,
    black_center = 2,
    black_right = 3
}

[System.Serializable]
public class MapManager : Singleton<MapManager> {
    public int map_size_x = 18;
    public int map_size_y = 10;

    Tile[,] map_data;


	// Use this for initialization
	void Awake () {
        map_data = new Tile[10, 18] // y, x임 주의
        {   
            {(Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0},
            {(Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0},
            {(Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0},
            {(Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)1, (Tile)2, (Tile)2, (Tile)2, (Tile)3, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0},
            {(Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0},
            {(Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)1, (Tile)2, (Tile)3, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0},
            {(Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0},
            {(Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)1, (Tile)2, (Tile)2, (Tile)2, (Tile)3, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0},
            {(Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0, (Tile)0},
            {(Tile)2, (Tile)2, (Tile)2, (Tile)2, (Tile)2, (Tile)2, (Tile)2, (Tile)2, (Tile)2, (Tile)2, (Tile)2, (Tile)2, (Tile)2, (Tile)2, (Tile)2, (Tile)2, (Tile)2, (Tile)2}
        };

        Map_Create();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Map_Create() {
        for (int i = 0; i < map_size_y; i++) {
            for (int j = 0; j < map_size_x; j++) {
                if (map_data[i, j] != Tile.non) {
                    GameObject map_object = ObjectPool.access.Pop(map_data[i, j].ToString(), transform);
                    map_object.transform.position = (new Vector2((j - 9) + 0.5f, (i - 5)*-1 - 0.5f));
                }
            }
        }
    }
}
