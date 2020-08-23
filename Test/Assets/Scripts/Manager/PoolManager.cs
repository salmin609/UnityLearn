using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    #region Pool
    class Pool
    {
        public GameObject Original
        {
            get;
            private set;
        }

        public Transform Root
        {
            get;
            set;
        }

        Stack<PoolAble> poolStack = new Stack<PoolAble>();

        public void Init(GameObject original, int count = 5)
        {
            Original = original;
            Root = new GameObject().transform;
            Root.name = $"{original.name}Root";

            for (int i = 0; i < count; ++i)
            {
                Push(Create());
            }
        }

        PoolAble Create()
        {
            GameObject obj = Object.Instantiate<GameObject>(Original);
            obj.name = Original.name;
            return obj.GetOrAddComponent<PoolAble>();
        }

        public void Push(PoolAble poolAble)
        {
            if (poolAble == null)
            {
                return;
            }

            poolAble.transform.parent = Root;
            poolAble.gameObject.SetActive(false);
            poolAble.isUsing = false;

            poolStack.Push(poolAble);
        }

        public PoolAble Pop(Transform parent)
        {
            PoolAble poolAble;

            if (poolStack.Count > 0)
            {
                poolAble = poolStack.Pop();
            }
            else
            {
                poolAble = Create();
            }
            poolAble.gameObject.SetActive(true);

            if (parent == null)
            {
                poolAble.transform.parent = Managers.Scene.CurrentScene.transform;
            }

            poolAble.transform.parent = parent;
            poolAble.isUsing = true;

            return poolAble;
        }
    }
#endregion

    Dictionary<string, Pool> pool = new Dictionary<string, Pool>();

    private Transform root;

    public void Init()
    {
        if (root == null)
        {
            root = new GameObject
            {
                name = "@PoolRoot"
            }.transform;

            Object.DontDestroyOnLoad(root);
        }
    }

    public void Push(PoolAble poolAble)
    {
        string name = poolAble.gameObject.name;

        if (pool.ContainsKey(name) == false)
        {
            Object.Destroy(poolAble.gameObject);
            return;
        }

        pool[name].Push(poolAble);
    }

    public void CreatePool(GameObject obj, int count = 5)
    {
        Pool newPool = new Pool();
        newPool.Init(obj, count);
        newPool.Root.parent = root.transform;

        pool.Add(obj.name, newPool);
    }

    public PoolAble Pop(GameObject original, Transform parent = null)
    {
        if (pool.ContainsKey(original.name) == false)
        {
            CreatePool(original);
        }
        return pool[original.name].Pop(parent);
    }

    public GameObject GetOriginal(string name)
    {
        if (pool.ContainsKey(name) == false)
        {
            return null;
        }

        return pool[name].Original;
    }

    public void Clear()
    {
        foreach (Transform child in root)
        {
            GameObject.Destroy(child.gameObject);
        }
        pool.Clear();
    }
}
