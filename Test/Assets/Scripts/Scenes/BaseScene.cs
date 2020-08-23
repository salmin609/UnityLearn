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
        Util.FindObjectTypeOrInstantiate(typeof(EventSystem), "Ui/EventSystem", "@EventSystem");
    }

    public abstract void Clear();

}
