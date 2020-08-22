using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour
{
    public Define.Scenes sceneType
    {
        get;

        protected set;
    } = Define.Scenes.Unknown;

    void Awake()
    {
        Managers manager = Managers.Manager;
        Init();
    }
    protected virtual void Init()
    {
        Object obj = GameObject.FindObjectOfType(typeof(EventSystem));


        if (obj == null)
        {
            Managers.Resource.Instantiate("Ui/EventSystem").name = "@EventSystem";
        }


    }

    public abstract void Clear();

}
