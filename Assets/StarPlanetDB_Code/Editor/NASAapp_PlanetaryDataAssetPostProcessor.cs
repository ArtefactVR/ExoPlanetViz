using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
public class NASAapp_PlanetaryDataAssetPostprocessor : AssetPostprocessor 
{
    private static readonly string filePath = "Assets/StarPlanetData/NASAapp_Trappist1_PLANET_DATA.xls";
    private static readonly string assetFilePath = "Assets/StarPlanetData/NASAapp_PlanetaryData.asset";
    private static readonly string sheetName = "NASAapp_PlanetaryData";
    
    static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        foreach (string asset in importedAssets) 
        {
            if (!filePath.Equals (asset))
                continue;
                
            NASAapp_PlanetaryData data = (NASAapp_PlanetaryData)AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(NASAapp_PlanetaryData));
            if (data == null) {
                data = ScriptableObject.CreateInstance<NASAapp_PlanetaryData> ();
                data.SheetName = filePath;
                data.WorksheetName = sheetName;
                AssetDatabase.CreateAsset ((ScriptableObject)data, assetFilePath);
                //data.hideFlags = HideFlags.NotEditable;
            }
            
            //data.dataArray = new ExcelQuery(filePath, sheetName).Deserialize<NASAapp_PlanetaryDataData>().ToArray();		

            //ScriptableObject obj = AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(ScriptableObject)) as ScriptableObject;
            //EditorUtility.SetDirty (obj);

            ExcelQuery query = new ExcelQuery(filePath, sheetName);
            if (query != null && query.IsValid())
            {
                data.dataArray = query.Deserialize<NASAapp_PlanetaryDataData>().ToArray();
                ScriptableObject obj = AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(ScriptableObject)) as ScriptableObject;
                EditorUtility.SetDirty (obj);
            }
        }
    }
}
