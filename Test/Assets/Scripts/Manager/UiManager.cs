using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager
{
    private int sortOrder;

    private Stack<UIPopup> popupStack = new Stack<UIPopup>();
    private UiScene sceneUi = null;

    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UiRoot");

            if (root == null)
            {
                root = new GameObject
                {
                    name = "@UiRoot"
                };
            }

            return root;
        }
    }

    public void SetCanvas(GameObject obj, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(obj);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        if (sort)
        {
            canvas.sortingOrder = sortOrder;
            sortOrder++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }

    public T ShowPopupUi<T>(string name = null) where T : UIPopup
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }

        GameObject obj = Managers.Resource.Instantiate($"Ui/Popup/{name}");
        T popUp = Util.GetOrAddComponent<T>(obj);
        popupStack.Push(popUp);

        obj.transform.SetParent(Root.transform);
        return popUp;
    }

    public T ShowSceneUi<T>(string name = null) where T : UiScene
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }

        GameObject obj = Managers.Resource.Instantiate($"Ui/Scene/{name}");
        T scene = Util.GetOrAddComponent<T>(obj);
        sceneUi = scene;

        obj.transform.SetParent(Root.transform);
        return scene;
    }

    public void ClosePopupUi()
    {
        if (popupStack.Count == 0)
        {
            return;
        }

        UIPopup popUp = popupStack.Pop();
        Managers.Resource.Destroy(popUp.gameObject);
        popUp = null;
        sortOrder--;
    }

    public void ClosePopupUi(UIPopup index)
    {
        if (popupStack.Count == 0)
        {
            return;
        }
        if (popupStack.Peek() != index)
        {
            Debug.Log("Close popup failed mtf");
            return;
        }
        ClosePopupUi();
    }

    public void CloseAllPopupUi()
    {
        while (popupStack.Count > 0)
        {
            ClosePopupUi();
        }
    }
}
