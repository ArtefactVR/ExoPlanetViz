using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
[CustomEditor(typeof(Exoplanet_Data_Planets))]
public class Exoplanet_Data_PlanetsEditor : BaseExcelEditor<Exoplanet_Data_Planets>
{	    
    public override bool Load()
    {
        Exoplanet_Data_Planets targetData = target as Exoplanet_Data_Planets;

        string path = targetData.SheetName;
        if (!File.Exists(path))
            return false;

        string sheet = targetData.WorksheetName;

        ExcelQuery query = new ExcelQuery(path, sheet);
        if (query != null && query.IsValid())
        {
            targetData.dataArray = query.Deserialize<Exoplanet_Data_PlanetsData>().ToArray();
            EditorUtility.SetDirty(targetData);
            AssetDatabase.SaveAssets();
            return true;
        }
        else
            return false;
    }
}
