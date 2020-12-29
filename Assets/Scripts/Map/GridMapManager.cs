using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMapManager : MonoBehaviour {
    private GridMapBuilder _gridMapBuilder;
    public GridMap OriginGridMap { private set; get; } = new GridMap ();
    public GridMap CurrentGridMap { private set; get; } = new GridMap ();

    //----------------------------------------------------------------------
    void Start () {
        _gridMapBuilder = GetComponent<GridMapBuilder> ();
        _gridMapBuilder.CreateMap (OriginGridMap);
    }

}