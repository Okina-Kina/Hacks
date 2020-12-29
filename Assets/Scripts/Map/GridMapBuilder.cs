using UnityEngine;

public class GridMapBuilder : ObjectBuilderBase {
    [SerializeField] private Sprite[] _mapChips;
    public GridMap GridMap { private set; get; } = new GridMap ();

    //----------------------------------------------------------------------
    /// <summary>
    /// 指定したマップチップのオブジェクトを生成する
    /// </summary>
    private void CreateMapChipObject (Sprite mapChip, Vector2Int position) {
        var tileSize = GridMap.TileMagnification;
        var newObj = PlaceNewObject (position, new Vector2Int (tileSize, tileSize));
        newObj.GetComponent<SpriteRenderer> ().sprite = mapChip;
    }
    //----------------------------------------------------------------------
    /// <summary>
    /// マップの生成
    /// </summary>
    private void CreateMap () {
        for (var y = 0; y < GridMap.GridSize.y; y++)
            for (var x = GridMap.GridSize.x - 1; x >= 0; x--)
                for (var i = 0; i < _mapChips.Length; i++)
                    if (GridMap.Grid[y, x] == i) {
                        var position = QuarterView.GetQVCoord (x, y, GridMap);
                        CreateMapChipObject (_mapChips[i], position);
                    }
    }
    //----------------------------------------------------------------------
    protected override void AttachComponent (GameObject attachedObj) {
        attachedObj.AddComponent (typeof (SpriteRenderer));
    }
    //----------------------------------------------------------------------

    public override void Init () {
        CreateMap ();
    }
    //----------------------------------------------------------------------
    public override void Execute () { }

}