using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMap {
    [SerializeField] private Vector2Int _gridSize = new Vector2Int (30, 30);
    [SerializeField] private Vector2Int _offset = new Vector2Int (-320, 0);

    public int[, ] Grid { private set; get; }
    public Vector2Int GridSize { get { return _gridSize; } }
    public Vector2Int Offset { get { return _offset; } }
    public int TileSize { private set; get; } = 32;
    public int TileMagnification { private set; get; } = 4;

    //----------------------------------------------------------------------
    public GridMap () {
        Grid = new int[_gridSize.y, _gridSize.x];

        for (int y = 0; y < GridSize.y; y++)
            for (int x = 0; x < GridSize.x; x++)
                Grid[y, x] = 1;
    }
    //----------------------------------------------------------------------

}