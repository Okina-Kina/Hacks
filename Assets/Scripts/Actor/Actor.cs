using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Actor : MonoBehaviour {
    private Vector2Int _velocity = new Vector2Int (1, 0);
    public Vector2Int Offset { private set; get; } = new Vector2Int (0, 48);
    public Vector2Int GridIdx { private set; get; }
    public ActorParameter Parameter { set; get; } = new ActorParameter ();
    //----------------------------------------------------------------------
    public void Action (Vector2Int gridIdx, GridMap gridMap) {
        MoveStream (gridIdx, gridMap);
        AttackStream (gridMap);
    }
    //----------------------------------------------------------------------
    /// <summary>
    /// 一定間隔で移動する
    /// </summary>
    private void MoveStream (Vector2Int gridIdx, GridMap gridMap) {
        GridIdx = gridIdx;

        Observable.Interval (System.TimeSpan.FromSeconds (Parameter.MoveCoolTime))
            .Subscribe (_ => {
                GridIdx += _velocity;
                var qvPos = QuarterView
                    .GetQVCoord (GridIdx.x, GridIdx.y, Offset, gridMap);
                Moving (qvPos);
            }).AddTo (gameObject);
    }
    //----------------------------------------------------------------------    
    /// <summary>
    /// 移動演出
    /// </summary>
    private void Moving (Vector2Int qvPosition) {
        this.transform.DOLocalMove (
                endValue: new Vector3 (qvPosition.x, qvPosition.y),
                duration : 0.5f, true)
            .SetEase (Ease.Linear);
    }
    //----------------------------------------------------------------------
    /// <summary>
    /// 一定間隔で攻撃する
    /// </summary>
    private void AttackStream (GridMap gridMap) {
        Observable.Interval (System.TimeSpan.FromSeconds (Parameter.AttackCoolTime))
            .Subscribe (_ => {
                Debug.Log (gameObject.name + "was Attacked");
            }).AddTo (gameObject);
    }
    //----------------------------------------------------------------------
}