using UnityEngine;

/// <summary>
/// マップ生成
/// </summary>
public class MapBuilder : ObjectBuilderBase
{
    [SerializeField] Sprite[] _mapChips;
    [SerializeField] Vector2Int _offset;
    [SerializeField] int _width = 8;
    [SerializeField] int _height = 6;
    [SerializeField] private int _mapChipSize = 3;

    private int[,] _mapData;
    private const int c_tileSize = 32;

    #region マップ生成メソッド
    /// <summary>
    /// テスト用のマップデータ作成
    /// </summary>
    private void TestMapDataFormat()
    {
        _mapData = new int[_width, _height];

        // 端点を全て通行不可にする
        for (var x = 0; x < _mapData.GetLength(0); x++) for (var y = 0; y < _mapData.GetLength(1); y++)
                if (x == 0 || x == _mapData.GetLength(0) - 1) _mapData[x, y] = 0;
                else if (y == 0 || y == _mapData.GetLength(1) - 1) _mapData[x, y] = 0;
                else _mapData[x, y] = 1;
    }

    /// <summary>
    /// 指定したマップチップのオブジェクトを生成する
    /// </summary>
    /// <param name="mapChip"></param>
    /// <param name="position"></param>
    private void CreateMapChipObject(Sprite mapChip, Vector2Int position)
    {
        var newObj = PlaceNewObject(position, new Vector2Int(_mapChipSize, _mapChipSize));
        newObj.GetComponent<SpriteRenderer>().sprite = mapChip;
    }

    /// <summary>
    /// マップの生成
    /// </summary>
    /// <param name="mapData"></param>
    private void CreateMap(int[,] mapData)
    {
        for (var x = 0; x < _mapData.GetLength(0); x++) for (var y = 0; y < _mapData.GetLength(1); y++)
                for (var i = 0; i < _mapChips.Length; i++)
                    if (_mapData[x, y] == i)
                    {
                        var position = new Vector2Int(x * c_tileSize * _mapChipSize, y * c_tileSize * _mapChipSize);
                        CreateMapChipObject(_mapChips[i], position + _offset);
                    }

    }
    #endregion

    #region Override

    protected override void AttachComponent(GameObject attachedObj)
    {
        attachedObj.AddComponent(typeof(SpriteRenderer));
    }

    protected override void DefineVarriable()
    {
        TestMapDataFormat();
    }

    public override void Init()
    {
        CreateMap(_mapData);
    }

    public override void Execute()
    {
    }

    #endregion Override
}