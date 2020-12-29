using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientClickObserver : MonoBehaviour {
    private SpriteRenderer _sprite;
    private ActorObjectBuilder _actorBuilder;

    //----------------------------------------------------------------------
    /// <summary>
    /// カーソルを追従
    /// </summary>
    private void FollowCursor () {
        var currentGridMap = _actorBuilder.GridMapManager.CurrentGridMap;
        var offset = new Vector2Int (0, 0);
        var qvPos = QuarterView.GetMouseQVCoord (offset, currentGridMap);
        this.transform.position = new Vector3 (qvPos.x, qvPos.y + offset.y);
    }
    private void OnClickGrid () {
        var currentGridMap = _actorBuilder.GridMapManager.CurrentGridMap;
        var qvIdx = QuarterView.GetMouseQVIdx (currentGridMap);
        Debug.Log (qvIdx);
        if (Input.GetMouseButtonDown (0)) _actorBuilder.PlaceActor (qvIdx);
    }
    //----------------------------------------------------------------------
    void Start () {
        _actorBuilder = GetComponent<ActorObjectBuilder> ();
    }
    //----------------------------------------------------------------------
    void Update () {
        FollowCursor ();
        OnClickGrid ();
    }
}