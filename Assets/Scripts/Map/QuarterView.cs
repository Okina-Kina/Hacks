using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// QV座標系の変換機構を持つ
public static class QuarterView {
    //----------------------------------------------------------------------
    /// <summary>
    /// QV座標を取得
    /// </summary>
    public static Vector2Int GetQVCoord (int x, int y, GridMap gridMap) {
        var tileSize = gridMap.TileSize * gridMap.TileMagnification;
        var qx = (int) (tileSize / 2 * (x + y) + gridMap.Offset.x);
        var qy = (int) (tileSize / 4 * (x - y) + gridMap.Offset.y);

        return new Vector2Int (qx, qy) + gridMap.Offset;
    }
    //----------------------------------------------------------------------
    /// <summary>
    /// QV座標からインデックスを取得
    /// </summary>
    public static Vector2Int GetQVIdx (int qx, int qy, GridMap gridMap) {
        var tileSize = gridMap.TileSize * gridMap.TileMagnification;
        qx -= gridMap.Offset.x;
        qy -= gridMap.Offset.y;

        var x = (qx + (2 * qy)) / tileSize;
        var y = (qx - (2 * qy)) / tileSize;

        return new Vector2Int ((int) x, (int) y);
    }
}