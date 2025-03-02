﻿// <auto-generated />
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace MediawikiTranslator.Models.Data.MHRS
{

	public partial class LightBowGun
	{
		[JsonProperty("snow.equip.LightBowgunBaseUserData", NullValueHandling = NullValueHandling.Ignore)]
		public SnowEquipLightBowgunBaseUserData SnowEquipLightBowgunBaseUserData { get; set; }

		public static Weapon[] Fetch()
		{
			return FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\player\weapon\lightbowgun\lightbowgunbasedata.user.2.json")).SnowEquipLightBowgunBaseUserData.Param;
		}
	}

	public partial class SnowEquipLightBowgunBaseUserData
	{
		[JsonProperty("_Param", NullValueHandling = NullValueHandling.Ignore)]
		public LightBowGunParam[] Param { get; set; }
	}

	public partial class LightBowGunParam : Weapon
	{
		[JsonProperty("_Fluctuation", NullValueHandling = NullValueHandling.Ignore)]
		public string Fluctuation { get; set; }

		[JsonProperty("_Reload", NullValueHandling = NullValueHandling.Ignore)]
		public string Reload { get; set; }

		[JsonProperty("_Recoil", NullValueHandling = NullValueHandling.Ignore)]
		public string Recoil { get; set; }

		[JsonProperty("_KakusanType", NullValueHandling = NullValueHandling.Ignore)]
		public string KakusanType { get; set; }

		[JsonProperty("_BulletEquipFlagList", NullValueHandling = NullValueHandling.Ignore)]
		public bool[] BulletEquipFlagList { get; set; }

		[JsonProperty("_BulletNumList", NullValueHandling = NullValueHandling.Ignore)]
		public long[] BulletNumList { get; set; }

		[JsonProperty("_BulletTypeList", NullValueHandling = NullValueHandling.Ignore)]
		public string[] BulletTypeList { get; set; }

		[JsonProperty("_RapidShotList", NullValueHandling = NullValueHandling.Ignore)]
		public string[] RapidShotList { get; set; }

		[JsonProperty("_UniqueBullet", NullValueHandling = NullValueHandling.Ignore)]
		public string UniqueBullet { get; set; }
	}

	public partial class LightBowGun
	{
		public static LightBowGun FromJson(string json) => JsonConvert.DeserializeObject<LightBowGun>(json, MediawikiTranslator.Models.Data.MHRS.LightBowGunConverter.Settings);
	}

	internal static class LightBowGunConverter
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
