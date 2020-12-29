using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectBuilderBase : ObjectBehaviourBase
{
    /// <summary>
    /// ゲームオブジェクトにコンポーネントをアタッチする
    /// </summary>
    /// <param name="attachedObj"></param>
    virtual protected void AttachComponent(GameObject attachedObj) { }

    /// <summary>
    /// 空のオブジェクトを生成する
    /// </summary>
    /// <returns></returns>
    protected GameObject CreateEmptyGameObject()
    {
        var newObj = new GameObject();

        return newObj;
    }

    /// <summary>
    /// あるオブジェクトの子オブジェクトを生成する
    /// </summary>
    /// <returns></returns>
    protected GameObject CreateEmptyGameObject(GameObject parentObject)
    {
        var newChildObj = new GameObject();
        newChildObj.transform.SetParent(parentObject.transform);

        return newChildObj;
    }

    /// <summary>
    /// オブジェクトの大きさを設定する
    /// </summary>
    /// <param name="obj">変更するオブジェクト</param>
    /// <param name="scale">サイズ</param>
    protected void SetObjectScale(GameObject obj, Vector2Int scale)
    {
        obj.transform.localScale = new Vector3(scale.x, scale.y);
    }

    /// <summary>
    /// オブジェクトを指定のワールド座標に配置する
    /// </summary>
    /// <param name="obj">オブジェクト</param>
    /// <param name="position">配置する座標</param>
    protected void SetObjectPosition(GameObject obj, Vector2Int position)
    {
        obj.transform.position = new Vector3(position.x, position.y);
    }

    /// <summary>
    /// 新しくオブジェクトを生成する
    /// </summary>
    /// <param name="position"></param>
    /// <param name="scale"></param>
    protected GameObject PlaceNewObject(Vector2Int position, Vector2Int scale)
    {
        var newObj = CreateEmptyGameObject();

        AttachComponent(newObj);
        SetObjectPosition(newObj, position);
        SetObjectScale(newObj, scale);

        return newObj;
    }

    /// <summary>
    /// 新しい子オブジェクトを生成する
    /// </summary>
    /// <param name="position"></param>
    /// <param name="scale"></param>
    protected GameObject PlaceNewObject(GameObject parentObj, Vector2Int position, Vector2Int scale)
    {
        var newObj = CreateEmptyGameObject(parentObj);

        AttachComponent(newObj);
        SetObjectPosition(newObj, position);
        SetObjectScale(newObj, scale);

        return newObj;
    }
}
