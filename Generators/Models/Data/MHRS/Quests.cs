﻿// <auto-generated />
	using System.Globalization;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Converters;
namespace MediawikiTranslator.Models.Data.MHRS
{

	public partial class Quests
	{
		[JsonProperty("snow.data.QuestDataForRewardUserData", NullValueHandling = NullValueHandling.Ignore)]
		public SnowDataQuestDataForRewardUserData SnowDataQuestDataForRewardUserData { get; set; }
#nullable enable
		private static QuestsRewardLotTablesParam[]? _LootTables { get; set; }
#nullable disable

		public static QuestsParam[] GetAllQuests()
		{
            if (_LootTables == null)
            {
				_LootTables = QuestsRewardLotTables.GetAllLootTables();
			}
            QuestsParam[] lrhr = FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\quest\system\questrewardsystem\questdataforrewarddata.user.2.json")).SnowDataQuestDataForRewardUserData.Param;
			QuestsParam[] mr = FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\quest\system\questrewardsystem\questdataforrewarddata_mr.user.2.json")).SnowDataQuestDataForRewardUserData.Param;
			QuestsParam[] ret = new QuestsParam[lrhr.Length + mr.Length];
			lrhr.CopyTo(ret, 0);
			mr.CopyTo(ret, lrhr.Length); 
			foreach (QuestsParam param in ret)
			{
				int cntr = 1;
				List<string> paramDesc = [];
				string detail = CommonMsgs.GetMsg($"QN{param.QuestNumber:D6}_{cntr:D2}");
				while (!string.IsNullOrEmpty(detail))
				{
					paramDesc.Add(detail);
					detail = CommonMsgs.GetMsg($"QN{param.QuestNumber:D6}_{cntr:D2}");
					cntr++;
				}
				param.DescFields = [..paramDesc];
				if (param.CommonMaterialRewardTableIndex != null)
				{
					QuestsRewardLotTablesParam lootTable = _LootTables.FirstOrDefault(x => x.Id == param.CommonMaterialRewardTableIndex);
					if (lootTable != null)
					{
						param.LootTable = lootTable;
					}
				}
			}
			return ret;
		}
	}

	public partial class SnowDataQuestDataForRewardUserData
	{
		[JsonProperty("_Param", NullValueHandling = NullValueHandling.Ignore)]
		public QuestsParam[] Param { get; set; }
	}

	public partial class QuestsParam
	{
		[JsonProperty("_QuestNumber", NullValueHandling = NullValueHandling.Ignore)]
		public long? QuestNumber { get; set; }

		[JsonProperty("_TargetRewardAddNum", NullValueHandling = NullValueHandling.Ignore)]
		public long? TargetRewardAddNum { get; set; }

		[JsonProperty("_AdditionalTargetRewardTableIndex", NullValueHandling = NullValueHandling.Ignore)]
		public long? AdditionalTargetRewardTableIndex { get; set; }

		[JsonProperty("_CommonMaterialAddNum", NullValueHandling = NullValueHandling.Ignore)]
		public long? CommonMaterialAddNum { get; set; }

		[JsonProperty("_CommonMaterialRewardTableIndex", NullValueHandling = NullValueHandling.Ignore)]
		public long? CommonMaterialRewardTableIndex { get; set; }

		[JsonProperty("_AdditionalQuestRewardTableIndex", NullValueHandling = NullValueHandling.Ignore)]
		public long[] AdditionalQuestRewardTableIndex { get; set; }

		[JsonProperty("_ClothTicketIndex", NullValueHandling = NullValueHandling.Ignore)]
		public long? ClothTicketIndex { get; set; }
		[JsonIgnore]
		public string[] DescFields { get; set; }
		[JsonIgnore]
		public QuestsRewardLotTablesParam LootTable { get; set; }
	}

	public partial class Quests
	{
		public static Quests FromJson(string json) => JsonConvert.DeserializeObject<Quests>(json, MediawikiTranslator.Models.Data.MHRS.QuestsConverter.Settings);
	}

	internal static class QuestsConverter
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
