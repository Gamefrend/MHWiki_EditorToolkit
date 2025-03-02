﻿// <auto-generated />
	using System.Globalization;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Converters;
namespace MediawikiTranslator.Models.Data.MHRS
{

	public partial class ArmorCraftingData
	{
		[JsonProperty("snow.data.ArmorProductUserData", NullValueHandling = NullValueHandling.Ignore)]
		public SnowDataArmorBaseUserCraftingData SnowDataArmorBaseUserCraftingData { get; set; }

		public static ArmorCraftingDataParam[] GetCraftingData()
		{
			Items[] allItems = Items.Fetch();
			ArmorCraftingDataParam[] allArmor = FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\player\armor\armorproductdata.user.2.json")).SnowDataArmorBaseUserCraftingData.Param;
			foreach (ArmorCraftingDataParam armor in allArmor)
			{
				for (int i = 0; i < armor.Item.Length; i++)
				{
					if (armor.Item[i] != "I_Unclassified_None")
					{
						if (armor.Materials == null)
						{
							armor.Materials = [];
						}
						armor.Materials.Add(new Tuple<Items, int>(allItems.First(x => x.Id == armor.Item[i]), (int)armor.ItemNum[i]));
					}
				}
			}
			return allArmor;
		}
	}

	public partial class SnowDataArmorBaseUserCraftingData
	{
		[JsonProperty("_Param", NullValueHandling = NullValueHandling.Ignore)]
		public ArmorCraftingDataParam[] Param { get; set; }
	}

	public partial class ArmorCraftingDataParam
	{
		[JsonProperty("_Id", NullValueHandling = NullValueHandling.Ignore)]
		public string Id { get; set; }

		[JsonProperty("_ItemFlag", NullValueHandling = NullValueHandling.Ignore)]
		public string ItemFlag { get; set; }

		[JsonProperty("_EnemyFlag", NullValueHandling = NullValueHandling.Ignore)]
		public string EnemyFlag { get; set; }

		[JsonProperty("_ProgressFlag", NullValueHandling = NullValueHandling.Ignore)]
		public string ProgressFlag { get; set; }

		[JsonProperty("_Item", NullValueHandling = NullValueHandling.Ignore)]
		public string[] Item { get; set; }

		[JsonProperty("_ItemNum", NullValueHandling = NullValueHandling.Ignore)]
		public long[] ItemNum { get; set; }

		[JsonProperty("_MaterialCategory", NullValueHandling = NullValueHandling.Ignore)]
		public string MaterialCategory { get; set; }

		[JsonProperty("_MaterialCategoryNum", NullValueHandling = NullValueHandling.Ignore)]
		public long? MaterialCategoryNum { get; set; }

		[JsonProperty("_OutputItem", NullValueHandling = NullValueHandling.Ignore)]
		public string[] OutputItem { get; set; }

		[JsonProperty("_OutputItemNum", NullValueHandling = NullValueHandling.Ignore)]
		public long[] OutputItemNum { get; set; }

		[JsonIgnore]
#pragma warning disable CS8669 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context. Auto-generated code requires an explicit '#nullable' directive in source.
		public List<Tuple<Items, int>>? Materials { get; set; }
#pragma warning restore CS8669 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context. Auto-generated code requires an explicit '#nullable' directive in source.
	}

	public partial class ArmorCraftingData
	{
		public static ArmorCraftingData FromJson(string json) => JsonConvert.DeserializeObject<ArmorCraftingData>(json, MediawikiTranslator.Models.Data.MHRS.ArmorCraftingDataConverter.Settings);
	}

	internal static class ArmorCraftingDataConverter
	{
		public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
		{
			MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
			DateParseHandling = DateParseHandling.None,
			Converters =
			{
				new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
			},
		};
	}
}
