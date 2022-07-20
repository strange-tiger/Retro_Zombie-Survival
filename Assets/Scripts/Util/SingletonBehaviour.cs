using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// template <typename T> 
// 지금 만드는 건 컴포넌트 싱글톤이기에, 컴포넌트만 제네릭에 들어오도록 제한한다.
public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance 
    { 
        get 
        { 
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        } 
    }

    protected void Awake()
    {
        if( _instance != null )
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }

            return;
        }

        _instance = GetComponent<T>();
        DontDestroyOnLoad(gameObject);
    }
}
