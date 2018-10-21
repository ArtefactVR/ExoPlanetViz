using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
public class Exoplanet_Data_PlanetsAssetPostprocessor : AssetPostprocessor 
{
    private static readonly string filePath = "Assets/StarPlanetDB/Exoplanet_Data_PLANETS.xls";
    private static readonly string assetFilePath = "Assets/StarPlanetDB/Exoplanet_Data_Planets.asset";
    private static readonly string sheetName = "Exoplanet_Data_Planets";
    
    static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        foreach (string asset in importedAssets) 
        {
            if (!filePath.Equals (asset))
                continue;
                
            Exoplanet_Data_Planets data = (Exoplanet_Data_Planets)AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(Exoplanet_Data_Planets));
            if (data == null) {
                data = ScriptableObject.CreateInstance<Exoplanet_Data_Planets> ();
                data.SheetName = filePath;
                data.WorksheetName = sheetName;
                AssetDatabase.CreateAsset ((ScriptableObject)data, assetFilePath);
                //data.hideFlags = HideFlags.NotEditable;
            }
            
            //data.dataArray = new ExcelQuery(filePath, sheetName).Deserialize<Exoplanet_Data_PlanetsData>().ToArray();		

            //ScriptableObject obj = AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(ScriptableObject)) as ScriptableObject;
            //EditorUtility.SetDirty (obj);

            ExcelQuery query = new ExcelQuery(filePath, sheetName);
            if (query != null && query.IsValid())
            {
                data.dataArray = query.Deserialize<Exoplanet_Data_PlanetsData>().ToArray();
                ScriptableObject obj = AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(ScriptableObject)) as ScriptableObject;
                EditorUtility.SetDirty (obj);
            }
        }
    }
}
