using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static GameObject CashedPrefabInstantiate(string prefabName, Transform parent = null)
    {
        return Managers.Resource.Instantiate(Managers.Data.GetCashedPrefab(prefabName) , parent);
    }

    public static bool RandomInHundred(int percent)
    {
        if (Random.Range(0, 101) <= percent) return true;
        return false;
    }
    public static bool RandomInHundred(float percent)
    {
        if (Random.Range(0f, 100f) <= percent) return true;
        return false;
    }

    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
		if (component == null)
            component = go.AddComponent<T>();
        return component;
	}

    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(go, name, recursive);
        if (transform == null)
            return null;
        
        return transform.gameObject;
    }

    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null)
            return null;

        if (recursive == false)
        {
            for (int i = 0; i < go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                        return component;
                }
            }
		}
        else
        {
            foreach (T component in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }
        }

        return null;
    }


}
