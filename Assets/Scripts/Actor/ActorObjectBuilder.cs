using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

// 
public class ActorObjectBuilder : ObjectBuilderBase {
    [SerializeField] Actor _actor;
    private ActorObserver _actorObserver;
    private GridMapManager _gridMapManager;
    //----------------------------------------------------------------------
    /// <summary>
    /// 指定マスにアクターを生成
    /// </summary>
    private GameObject PlaceActor (int x, int y) {
        var newActor = Instantiate (_actor.gameObject) as GameObject;
        var currentGridMap = _gridMapManager.CurrentGridMap;

        var offset = newActor.GetComponent<Actor> ().Offset;
        var qvPos = QuarterView.GetQVCoord (x, y, offset, currentGridMap);

        SetObjectPosition (newActor, qvPos);
        newActor.GetComponent<Actor> ()
            .Action (new Vector2Int (x, y), currentGridMap);

        return newActor;
    }
    //----------------------------------------------------------------------
    void Start () {
        _actorObserver = FindObjectOfType<ActorObserver> ();
        _gridMapManager = FindObjectOfType<GridMapManager> ();

        PlaceActor (0, 0);
        PlaceActor (4, 4);
    }

}