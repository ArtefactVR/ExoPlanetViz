using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
public class Exoplanet_StarsUnique2AssetPostprocessor : AssetPostprocessor 
{
    private static readonly string filePath = "Assets/StarPlanetDB/Exoplanet_StarsUnique2.xls";
    private static readonly string assetFilePath = "Assets/StarPlanetDB/Exoplanet_StarsUnique2.asset";
    private static readonly string sheetName = "Exoplanet_StarsUnique2";
    
    static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        foreach (string asset in importedAssets) 
        {
            if (!filePath.Equals (asset))
                continue;
                
            Exoplanet_StarsUnique2 data = (Exoplanet_StarsUnique2)AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(Exoplanet_StarsUnique2));
            if (data == null) {
                data = ScriptableObject.CreateInstance<Exoplanet_StarsUnique2> ();
                data.SheetName = filePath;
                data.WorksheetName = sheetName;
                AssetDatabase.CreateAsset ((ScriptableObject)data, assetFilePath);
                //data.hideFlags = HideFlags.NotEditable;
            }
            
            //data.dataArray = new ExcelQuery(filePath, sheetName).Deserialize<Exoplanet_StarsUnique2Data>().ToArray();		

            //ScriptableObject obj = AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(ScriptableObject)) as ScriptableObject;
            //EditorUtility.SetDirty (obj);

            ExcelQuery query = new ExcelQuery(filePath, sheetName);
            if (query != null && query.IsValid())
            {
                data.dataArray = query.Deserialize<Exoplanet_StarsUnique2Data>().ToArray();
                ScriptableObject obj = AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(ScriptableObject)) as ScriptableObject;
                EditorUtility.SetDirty (obj);
            }
        }
    }
}
