using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

// 
public class ActorObjectBuilder : ObjectBuilderBase {
    [SerializeField] private Actor _actor;
    private ActorObserver _actorObserver;
    //----------------------------------------------------------------------
    public GridMapManager GridMapManager { private set; get; }
    //----------------------------------------------------------------------
    /// <summary>
    /// 指定マスにアクターを生成
    /// </summary>
    public GameObject PlaceActor (Vector2Int idx) {
        var newActor = Instantiate (_actor.gameObject) as GameObject;
        var currentGridMap = GridMapManager.CurrentGridMap;

        var offset = currentGridMap.ActorOffset;
        var qvPos = QuarterView.GetQVCoord (idx.x, idx.y, offset, currentGridMap);

        SetObjectPosition (newActor, qvPos);
        newActor.GetComponent<Actor> ()
            .Action (idx, currentGridMap);

        return newActor;
    }
    //----------------------------------------------------------------------
    void Start () {
        _actorObserver = FindObjectOfType<ActorObserver> ();
        GridMapManager = FindObjectOfType<GridMapManager> ();
    }

}