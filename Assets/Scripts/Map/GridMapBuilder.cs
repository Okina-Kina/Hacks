using UnityEngine;

// マップオブジェクトの生成
public class GridMapBuilder : ObjectBuilderBase {
    [SerializeField] private Sprite[] _mapChips;

    //----------------------------------------------------------------------
    /// <summary>
    /// マップの生成
    /// </summary>
    public void CreateMap (GridMap gridMap) {
        for (var y = 0; y < gridMap.GridSize.y; y++)
            for (var x = gridMap.GridSize.x - 1; x >= 0; x--)
                for (var i = 0; i < _mapChips.Length; i++)
                    if (gridMap.Grid[y, x] == i) {
                        var position = QuarterView.GetQVCoord (x, y, gridMap);
                        CreateMapChipObject (_mapChips[i], position, gridMap);
                    }
    }
    //----------------------------------------------------------------------
    protected override void AttachComponent (GameObject attachedObj) {
        attachedObj.AddComponent (typeof (SpriteRenderer));
    }
    //----------------------------------------------------------------------
    /// <summary>
    /// 指定したマップチップのオブジェクトを生成する
    /// </summary>
    private void CreateMapChipObject (Sprite mapChip, Vector2Int position, GridMap gridMap) {
        var tileSize = gridMap.TileMagnification;
        var newObj = PlaceNewObject (position, new Vector2Int (tileSize, tileSize));
        newObj.GetComponent<SpriteRenderer> ().sprite = mapChip;
    }
}