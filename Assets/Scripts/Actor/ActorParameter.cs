using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorParameter {
    [SerializeField] private float _maxHp = 1;
    private float _leftHp, _power = 1, _defence = 0;
    private float _moveCoolTime = 1f, _attackCoolTime = 1;
    //----------------------------------------------------------------------
    public float Hp {
        set { _leftHp = Mathf.Clamp (value, min : 0, max : 10); }
        get { return _leftHp; }
    }
    //----------------------------------------------------------------------
    public float Power {
        set { _power = Mathf.Clamp (value, min : 0, max : 5); }
        get { return _power; }
    }
    //----------------------------------------------------------------------
    public float Defence {
        set { _defence = Mathf.Clamp (value, min : 0, max : 5); }
        get { return _defence; }
    }
    //----------------------------------------------------------------------
    public float AttackCoolTime {
        set { _attackCoolTime = Mathf.Clamp (value, min : 0.1f, max : 3); }
        get { return _attackCoolTime; }
    }
    //----------------------------------------------------------------------
    public float MoveCoolTime {
        set { _moveCoolTime = Mathf.Clamp (value, min : 0.1f, max : 3); }
        get { return _moveCoolTime; }
    }
    //----------------------------------------------------------------------
    public ActorParameter () { _leftHp = _maxHp; }
}