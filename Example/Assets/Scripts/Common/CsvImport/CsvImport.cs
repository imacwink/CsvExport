using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

#if UNITY_WSA && !UNITY_EDITOR
using System.Reflection;
#endif

public class CsvImport
{
	private static Dictionary<System.Type, System.Object> mGameResDataBase = new Dictionary<System.Type, object>();

	#region 外部调用;
	public static bool LoadData<T, U>(string strTableName)
	{
		Object assetObj = Resources.Load("CsvBin/" + strTableName);

		if (assetObj == null)
		{
			Debug.LogError(strTableName + " is not exist !!!");
			return false;
		}

		TextAsset txtAsset = assetObj as TextAsset;
		if (txtAsset != null)
		{
			byte[] dataArray = txtAsset.bytes;
			System.IO.MemoryStream stream = new System.IO.MemoryStream(dataArray);
			T saveObj = ProtoBuf.Serializer.Deserialize<T>(stream);
#if UNITY_WSA && !UNITY_EDITOR
            TypeInfo elementType = typeof(T).GetTypeInfo();
            var propInfo = elementType.GetDeclaredProperty("mSzDataList");
#else
			System.Reflection.PropertyInfo propInfo = typeof(T).GetProperty("mSzDataList");
#endif

#if UNITY_WSA && !UNITY_EDITOR
            System.Object resultObj = propInfo.GetValue(saveObj);
#else
			System.Object resultObj = propInfo.GetValue(saveObj, new object[] { });
#endif
			mGameResDataBase[typeof(U)] = resultObj;
			return true;
		}
		else
		{
			Debug.LogWarning("LoadData " + strTableName + " Error !!!  Please Check FileName!!!");
			return false;
		}
	}

	public static List<T> GetData<T>()
	{
		if (mGameResDataBase.ContainsKey(typeof(T)))
		{
			return mGameResDataBase[typeof(T)] as List<T>;
		}
		return null;
	}
	#endregion
}

