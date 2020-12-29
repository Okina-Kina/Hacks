using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// QV座標系の変換機構を持つ
public static class QuarterView {
    //----------------------------------------------------------------------
    /// <summary>
    /// QV座標を取得
    /// </summary>
    public static Vector2Int GetQVCoord (int x, int y, Vector2Int offset, GridMap gridMap) {
        var tileSize = gridMap.TileSize * gridMap.TileMagnification;

        var qx = Mathf.RoundToInt (tileSize / 2 * (x + y) + gridMap.Offset.x);
        var qy = Mathf.RoundToInt (tileSize / 4 * (x - y) + gridMap.Offset.y);

        return new Vector2Int (qx, qy) + offset;
    }
    //----------------------------------------------------------------------
    public static Vector2Int GetQVCoord (int x, int y, GridMap gridMap) {
        return GetQVCoord (x, y, Vector2Int.zero, gridMap);
    }
    //----------------------------------------------------------------------
    /// <summary>
    /// QV座標からインデックスを取得
    /// </summary>
    public static Vector2Int GetQVIdx (int qx, int qy, Vector2Int offset, GridMap gridMap) {
        var tileSize = gridMap.TileSize * gridMap.TileMagnification;
        qx -= (gridMap.Offset.x + offset.x);
        qy -= (gridMap.Offset.y + offset.y);

        var x = (qx + (2 * qy)) / tileSize;
        var y = (qx - (2 * qy)) / tileSize;

        return new Vector2Int ((int) x, (int) y);
    }
    //----------------------------------------------------------------------
    public static Vector2Int GetQVIdx (int qx, int qy, GridMap gridMap) {
        return GetQVIdx (qx, qy, Vector2Int.zero, gridMap);
    }
    //----------------------------------------------------------------------
    /// <summary>
    /// マウス座標からQVマス座標を取得
    /// </summary>
    public static Vector2Int GetMouseQVIdx (Vector2Int offset, GridMap gridMap) {
        var mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        return QuarterView.GetQVIdx ((int) mousePos.x, (int) mousePos.y, offset, gridMap);
    }
    //----------------------------------------------------------------------
    public static Vector2Int GetMouseQVIdx (GridMap gridMap) {
        return QuarterView.GetMouseQVIdx (Vector2Int.zero, gridMap);
    }
    //----------------------------------------------------------------------
    /// <summary>
    /// マウス座標からQV座標を取得
    /// </summary>
    public static Vector2Int GetMouseQVCoord (Vector2Int offset, GridMap gridMap) {
        var qvIdx = QuarterView.GetMouseQVIdx (offset, gridMap);
        return QuarterView.GetQVCoord (qvIdx.x, qvIdx.y, gridMap);
    }
    //----------------------------------------------------------------------
    public static Vector2Int GetMouseQVCoord (GridMap gridMap) {
        return QuarterView.GetMouseQVCoord (Vector2Int.zero, gridMap);
    }

}