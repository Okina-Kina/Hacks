using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Hierarchy上で実行されるスクリプトの基底クラス
public abstract class ObjectBehaviourBase : MonoBehaviour
{
    /// <summary>
    /// オブジェクトの生成時の処理
    /// </summary>
    abstract public void Init();

    /// <summary>
    /// オブジェクトの実行処理
    /// </summary>
    abstract public void Execute();

    /// <summary>
    /// 外部からの命令によって呼ばれる処理
    /// (常には実行されない)
    /// </summary>
    virtual public void OrderdExecution() { }

    /// <summary>
    /// コンポーネントの取得処理
    /// </summary>
    virtual protected void DefineCompornent() { }

    /// <summary>
    /// 変数の初期化処理
    /// </summary>
    virtual protected void DefineVarriable() { }

    /// <summary>
    /// オブジェクト生成時処理の本体
    /// </summary>
    void Start()
    {
        DefineCompornent();
        DefineVarriable();
        Init();
    }

    /// <summary>
    /// 実行処理の本体
    /// </summary>
    void Update()
    {
        Execute();
    }
}
