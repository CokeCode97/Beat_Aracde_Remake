using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
    
    private static T singleton_object;

    public static T access {
        get {
            if (singleton_object == null) {
                singleton_object = FindObjectOfType(typeof(T)) as T;

                if (singleton_object == null) {
                    Debug.LogError("이 씬에" + typeof(T) + "이거 없는데?");
                }
            }

            return singleton_object;
        }
    }
}
