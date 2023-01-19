using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{

    public T Load<T>(string path) where T : Object
    {
        if(typeof(T) == typeof(GameObject))
        {
            string name = path;
            int index = name.LastIndexOf('/');
            if (index >= 0) name = name.Substring(index + 1);

            GameObject go = Managers.Pool.GetOriginal(name);
            if (go != null) return go as T;
        }

        return Resources.Load<T>(path);
    }

    public T[] LoadAll<T>(string path) where T : Object
    {
        return Resources.LoadAll<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null , bool worldStay = false)
    {
        GameObject original = Load<GameObject>($"Prefabs/{path}");
        if (original == null)
        {
            Debug.Log($"Failed to load prefab : {path} ");
            return null;
        }

        if (original.GetComponent<Poolable>() != null) return Managers.Pool.Pop(original, parent).gameObject;
        GameObject go = Object.Instantiate(original, parent, worldStay);
        go.name = original.name;
        return go;
    }

    public GameObject Instantiate(GameObject original, Transform parent = null , bool worldStay = false)
    {
        if (original == null)
        {
            return null;
        }

        if (original.GetComponent<Poolable>() != null) return Managers.Pool.Pop(original, parent).gameObject;
        GameObject go = Object.Instantiate(original, parent, worldStay);
        go.name = original.name;
        return go;
    }

    public void Destroy(GameObject go , float time = 0f)
    {
        if (go == null) return;

        Poolable poolable = go.GetComponent<Poolable>();
        if (poolable != null)
        {
            Managers.Pool.Push(poolable);
            return;
        }

        Object.Destroy(go,time);
    }
}
