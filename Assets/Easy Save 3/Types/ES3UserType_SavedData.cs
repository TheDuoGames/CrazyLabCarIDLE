using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("gameLevel", "currentEarningLevel", "currentSpeedLevel", "currentSellLevel")]
	public class ES3UserType_SavedData : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3UserType_SavedData() : base(typeof(SavedData)){ Instance = this; priority = 1; }


		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (SavedData)obj;
			
			writer.WriteProperty("gameLevel", instance.gameLevel, ES3Type_int.Instance);
			writer.WriteProperty("currentEarningLevel", instance.currentEarningLevel, ES3Type_int.Instance);
			writer.WriteProperty("currentSpeedLevel", instance.currentSpeedLevel, ES3Type_int.Instance);
			writer.WriteProperty("currentSellLevel", instance.currentSellLevel, ES3Type_int.Instance);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (SavedData)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "gameLevel":
						instance.gameLevel = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "currentEarningLevel":
						instance.currentEarningLevel = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "currentSpeedLevel":
						instance.currentSpeedLevel = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "currentSellLevel":
						instance.currentSellLevel = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			var instance = new SavedData();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}


	public class ES3UserType_SavedDataArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_SavedDataArray() : base(typeof(SavedData[]), ES3UserType_SavedData.Instance)
		{
			Instance = this;
		}
	}
}