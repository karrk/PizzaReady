using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed;

    public void Move(Vector3 m_dir)
    {
        transform.Translate(m_dir* Time.deltaTime * _moveSpeed,Space.World);
    }

    //public abstract void InterAct();
}
