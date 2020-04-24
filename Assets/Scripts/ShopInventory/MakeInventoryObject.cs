using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MakeInventoryObject {

    [MenuItem("Assets/Create/InventoryObject")]
    public static void Create()
    {

        InventoryObject asset = ScriptableObject.CreateInstance<InventoryObject>();
        AssetDatabase.CreateAsset(asset,"Assets/NewInventoryObject.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;

    }

}
