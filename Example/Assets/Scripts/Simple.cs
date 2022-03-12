using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Simple : MonoBehaviour
{
    public Text mText = null;

    void Start()
    {
        CsvImport.LoadData<STCsv.Entity, STCsv.EntityItem>("Entity");
        string strContent = null;
        List<STCsv.EntityItem> entityItemList = CsvImport.GetData<STCsv.EntityItem>();
        if (entityItemList != null)
        {
            for (int i = 0; i < entityItemList.Count; i++)
            {
                Debug.Log("ID: " + entityItemList[i].mID + " Name: " + entityItemList[i].mName + " Desc: " + entityItemList[i].mDesc + " Speed: " + entityItemList[i].mSpeed);
                strContent += "ID: " + entityItemList[i].mID + " Name: " + entityItemList[i].mName + " Desc: " + entityItemList[i].mDesc + " Speed: " + entityItemList[i].mSpeed;
                strContent += " \n ";
            } 
        }

        mText.text = strContent;
    }
}
