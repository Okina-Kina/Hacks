using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectBuilderBase : MonoBehaviour {
    //----------------------------------------------------------------------
    /// <summary>
    /// ゲームオブジェクトにコンポーネントをアタッチする
    /// </summary>
    virtual protected void AttachComponent (GameObject attachedObj) { }
    //----------------------------------------------------------------------
    /// <summary>
    /// オブジェクトの大きさを設定する
    /// </summary>
    protected void SetObjectScale (GameObject obj, Vector2Int scale) {
        obj.transform.localScale = new Vector3 (scale.x, scale.y);
    }
    //----------------------------------------------------------------------
    /// <summary>
    /// オブジェクトを指定のワールド座標に配置する
    /// </summary>
    protected void SetObjectPosition (GameObject obj, Vector2Int position) {
        obj.transform.position = new Vector3 (position.x, position.y);
    }
    //----------------------------------------------------------------------
    /// <summary>
    /// 空のオブジェクトを生成する
    /// </summary>
    protected GameObject CreateEmptyGameObject () { return new GameObject (); }
    //----------------------------------------------------------------------
    /// <summary>
    /// あるオブジェクトの子オブジェクトを生成する
    /// </summary>
    protected GameObject CreateEmptyGameObject (GameObject parentObject) {
        var newChildObj = new GameObject ();
        newChildObj.transform.SetParent (parentObject.transform);
        return newChildObj;
    }
    //----------------------------------------------------------------------
    /// <summary>
    /// 新しくオブジェクトを生成する
    /// </summary>
    protected GameObject PlaceNewObject (Vector2Int position, Vector2Int scale) {
        var newObj = CreateEmptyGameObject ();

        AttachComponent (newObj);
        SetObjectPosition (newObj, position);
        SetObjectScale (newObj, scale);

        return newObj;
    }
    //----------------------------------------------------------------------
    /// <summary>
    /// 新しい子オブジェクトを生成する
    /// </summary>
    protected GameObject PlaceNewObject (GameObject parentObj, Vector2Int position, Vector2Int scale) {
        var newObj = CreateEmptyGameObject (parentObj);

        AttachComponent (newObj);
        SetObjectPosition (newObj, position);
        SetObjectScale (newObj, scale);

        return newObj;
    }
}