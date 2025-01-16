﻿// <auto-generated />
using System.Globalization;
using MediawikiTranslator.Generators;
using MediawikiTranslator.Models.ArmorSets;
using MediawikiTranslator.Models.Data.MHRS;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace MediawikiTranslator.Models.Data.MHWI
{

	public partial class Armor
	{
		[JsonProperty("Name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }

		[JsonProperty("Index", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(ArmorParseStringConverter))]
		public long? Index { get; set; }

		[JsonProperty("Order", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(ArmorParseStringConverter))]
		public long? Order { get; set; }

		[JsonProperty("Variant", NullValueHandling = NullValueHandling.Ignore)]
		public string Variant { get; set; }

		[JsonProperty("SetLayeredId", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(ArmorParseStringConverter))]
		public long? SetLayeredId { get; set; }

		[JsonProperty("Type", NullValueHandling = NullValueHandling.Ignore)]
		public string Type { get; set; }

		[JsonProperty("EquipSlot", NullValueHandling = NullValueHandling.Ignore)]
		public string EquipSlot { get; set; }

		[JsonProperty("Defense", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(ArmorParseStringConverter))]
		public long? Defense { get; set; }

		[JsonProperty("ModelId1", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(ArmorParseStringConverter))]
		public long? ModelId1 { get; set; }

		[JsonProperty("ModelId2", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(ArmorParseStringConverter))]
		public long? ModelId2 { get; set; }

		[JsonProperty("IconColor", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(ArmorParseStringConverter))]
		public long? IconColor { get; set; }

		[JsonProperty("IconEffect", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(ArmorParseStringConverter))]
		public long? IconEffect { get; set; }

		[JsonProperty("Rarity", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(ArmorParseStringConverter))]
		public long? Rarity { get; set; }

		[JsonProperty("Cost", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(ArmorParseStringConverter))]
		public long? Cost { get; set; }

		[JsonProperty("FireRes", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(ArmorParseStringConverter))]
		public long? FireRes { get; set; }

		[JsonProperty("WaterRes", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(ArmorParseStringConverter))]
		public long? WaterRes { get; set; }

		[JsonProperty("IceRes", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(ArmorParseStringConverter))]
		public long? IceRes { get; set; }

		[JsonProperty("ThunderRes", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(ArmorParseStringConverter))]
		public long? ThunderRes { get; set; }

		[JsonProperty("DragonRes", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(ArmorParseStringConverter))]
		public long? DragonRes { get; set; }

		[JsonProperty("SlotCount", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(ArmorParseStringConverter))]
		public long? SlotCount { get; set; }

		[JsonProperty("Slot1Size", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(ArmorParseStringConverter))]
		public long? Slot1Size { get; set; }

		[JsonProperty("Slot2Size", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(ArmorParseStringConverter))]
		public long? Slot2Size { get; set; }

		[JsonProperty("Slot3Size", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(ArmorParseStringConverter))]
		public long? Slot3Size { get; set; }

		[JsonProperty("SetSkill1", NullValueHandling = NullValueHandling.Ignore)]
		public string SetSkill1 { get; set; }

		[JsonProperty("SetSkill1Level", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(ArmorParseStringConverter))]
		public long? SetSkill1Level { get; set; }

		[JsonProperty("HiddenSkill", NullValueHandling = NullValueHandling.Ignore)]
		public string HiddenSkill { get; set; }

		[JsonProperty("HiddenSkillLevel", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(ArmorParseStringConverter))]
		public long? HiddenSkillLevel { get; set; }

		[JsonProperty("Skill1", NullValueHandling = NullValueHandling.Ignore)]
		public string Skill1 { get; set; }

		[JsonProperty("Skill1Level", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(ArmorParseStringConverter))]
		public long? Skill1Level { get; set; }

		[JsonProperty("Skill2", NullValueHandling = NullValueHandling.Ignore)]
		public string Skill2 { get; set; }

		[JsonProperty("Skill2Level", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(ArmorParseStringConverter))]
		public long? Skill2Level { get; set; }

		[JsonProperty("Skill3", NullValueHandling = NullValueHandling.Ignore)]
		public string Skill3 { get; set; }

		[JsonProperty("Skill3Level", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(ArmorParseStringConverter))]
		public long? Skill3Level { get; set; }

		[JsonProperty("Gender", NullValueHandling = NullValueHandling.Ignore)]
		public string Gender { get; set; }

		[JsonProperty("SetGroup", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(ArmorParseStringConverter))]
		public long? SetGroup { get; set; }

		[JsonProperty("IsPermanent", NullValueHandling = NullValueHandling.Ignore)]
		public string IsPermanent { get; set; }

		[JsonProperty("Description", NullValueHandling = NullValueHandling.Ignore)]
		public string Description { get; set; }

		[JsonIgnore]
		public List<SkillDescriptions> Skills { get; set; } = [];

		[JsonIgnore]
		public SetSkills SetSkill { get; set; }

		[JsonIgnore]
		public ArmorCraftingData CraftingData { get; set; }

		[JsonIgnore]
		public string SetName { get; set; }

		public static WebToolkitData[] GetWebToolkitData()
		{
			Armor[] allArmor = GetArmors();
			List<WebToolkitData> ret = [];
			Dictionary<int, string> colors = MediawikiTranslator.Generators.Items.GetMHWIWikiColors();
			//21 is layered armor, anything higher is a placeholder
			foreach (Armor armor in allArmor.OrderBy(x => x.SetName).Where(x => x.SetName != "HARDUMMY" && x.EquipSlot != "Charm" && x.Type == "Regular" && (x.CraftingData == null || x.CraftingData.Unk4 < 153)))
			{
				WebToolkitData newArmor = new WebToolkitData()
				{
					MaleFrontImg = $"MHWI-{armor.SetName} Set Male Front Render.png",
					MaleBackImg = $"MHWI-{armor.SetName} Set Male Back Render.png",
					FemaleFrontImg = $"MHWI-{armor.SetName} Set Female Front Render.png",
					FemaleBackImg = $"MHWI-{armor.SetName} Set Female Back Render.png",
					Game = "MHWI",
					SetName = armor.SetName,
					Rarity = armor.Rarity,
					Rank = armor.Variant.Replace("_", ""),
					OnlyForGender = (armor.Gender != "Unisex" ? armor.Gender : null)
				};
				if (ret.Any(x => x.SetName == newArmor.SetName && x.OnlyForGender == newArmor.OnlyForGender))
				{
					newArmor = ret.First(x => x.SetName == newArmor.SetName && x.OnlyForGender == newArmor.OnlyForGender);
				}
				if (armor.SetSkill != null)
				{
					newArmor.SetSkill1Name = armor.SetSkill.SetBonusName;
				}
				List<Piece> pieces = [];
				if (newArmor.Pieces != null)
				{
					pieces = [..newArmor.Pieces];
				}
				int maxLevel = GetMaxArmorLevel(armor.Rarity!.Value);
				Piece newPiece = new Piece()
				{
					Name = armor.Name,
					MaxLevel = maxLevel,
					Defense = armor.Defense, 
					MaxDefense = armor.CraftingData == null ? null : armor.Defense + ((maxLevel - 1) * 2),
					Description = armor.Description,
					DragonRes = armor.DragonRes,
					FireRes = armor.FireRes,
					WaterRes = armor.WaterRes,
					IceRes = armor.IceRes,
					ThunderRes = armor.ThunderRes,
					ForgingCost = armor.Cost,
					Rarity = armor.Rarity,
					IconType = TranslateArmorTypeToIcon(armor.EquipSlot),
					FemaleImage = "MHWI-" + armor.Name + " Female Render.png",
					MaleImage = "MHWI-" + armor.Name + " Male Render.png"
				};
				List<Material> mats = [];
				if (armor.CraftingData != null && armor.CraftingData.Mat1 != null)
				{
					mats.Add(new Material()
					{
						Color = Generators.Weapon.GetColorString(armor.CraftingData.Mat1.WikiIconColor!.ToString()),
						Icon = armor.CraftingData.Mat1.WikiIconName,
						Name = armor.CraftingData.Mat1.Name,
						Quantity = armor.CraftingData.Mat1Count
					});
				}
				if (armor.CraftingData != null && armor.CraftingData.Mat2 != null)
				{
					mats.Add(new Material()
					{
						Color = Generators.Weapon.GetColorString(armor.CraftingData.Mat2.WikiIconColor!.ToString()),
						Icon = armor.CraftingData.Mat2.WikiIconName,
						Name = armor.CraftingData.Mat2.Name,
						Quantity = armor.CraftingData.Mat2Count
					});
				}
				if (armor.CraftingData != null && armor.CraftingData.Mat3 != null)
				{
					mats.Add(new Material()
					{
						Color = Generators.Weapon.GetColorString(armor.CraftingData.Mat3.WikiIconColor!.ToString()),
						Icon = armor.CraftingData.Mat3.WikiIconName,
						Name = armor.CraftingData.Mat3.Name,
						Quantity = armor.CraftingData.Mat3Count
					});
				}
				if (armor.CraftingData != null && armor.CraftingData.Mat4 != null)
				{
					mats.Add(new Material()
					{
						Color = Generators.Weapon.GetColorString(armor.CraftingData.Mat4.WikiIconColor!.ToString()),
						Icon = armor.CraftingData.Mat4.WikiIconName,
						Name = armor.CraftingData.Mat4.Name,
						Quantity = armor.CraftingData.Mat4Count
					});
				}
				newPiece.Materials = [.. mats];
				newPiece.Skills = [..armor.Skills.Select(x => new Skill()
				{
					Level = x.Level,
					Name = x.SkillName,
					WikiIconColor = colors[(int)x.WikiIconColor!.Value]
				})];
				newPiece.Decos1 = (armor.Slot1Size == 1 ? 1 : 0) + (armor.Slot2Size == 1 ? 1 : 0) + (armor.Slot3Size == 1 ? 1 : 0);
				newPiece.Decos2 = (armor.Slot1Size == 2 ? 1 : 0) + (armor.Slot2Size == 2 ? 1 : 0) + (armor.Slot3Size == 2 ? 1 : 0);
				newPiece.Decos3 = (armor.Slot1Size == 3 ? 1 : 0) + (armor.Slot2Size == 3 ? 1 : 0) + (armor.Slot3Size == 3 ? 1 : 0);
				newPiece.Decos4 = (armor.Slot1Size == 4 ? 1 : 0) + (armor.Slot2Size == 4 ? 1 : 0) + (armor.Slot3Size == 4 ? 1 : 0);
				pieces.Add(newPiece);
				newArmor.Pieces = [.. pieces];
				if (!ret.Any(x => x.SetName == newArmor.SetName && x.OnlyForGender == newArmor.OnlyForGender))
				{
					ret.Add(newArmor);
				}
			}
			return [.. ret];
		}

		private static int GetMaxArmorLevel(long rarity)
		{
			return new Dictionary<long, int>()
			{
				{ 1, 19 },
				{ 2, 17 },
				{ 3, 15 },
				{ 4, 13 },
				{ 5, 12 },
				{ 6, 11 },
				{ 7, 7 },
				{ 8, 7 },
				{ 9, 20 },
				{ 10, 17 },
				{ 11, 13 },
				{ 12, 10 }
			}[rarity];
		}

		public static Armor[] GetArmors()
		{
			Armor[] allArmor = FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHWI\chunk\common\equip\armor.json"));
			SkillDescriptions[] skillDescriptions = SkillDescriptions.GetSkillDescriptions();
			SetSkills[] setSkills = MHWI.SetSkills.GetSetBonusDescriptions();
			ArmorCraftingData[] craftingData = MHWI.ArmorCraftingData.GetArmorCraftingData();
			foreach (Armor armor in allArmor)
			{
				if (armor.Skill1 != "0: --------")
				{
					armor.Skills.Add(skillDescriptions.First(x => x.SkillId == Convert.ToInt32(armor.Skill1.Substring(0, armor.Skill1.IndexOf(":"))) && x.Level == armor.Skill1Level));
				}
				if (armor.Skill2 != "0: --------")
				{
					armor.Skills.Add(skillDescriptions.First(x => x.SkillId == Convert.ToInt32(armor.Skill2.Substring(0, armor.Skill2.IndexOf(":"))) && x.Level == armor.Skill2Level));
				}
				if (armor.Skill3 != "0: --------")
				{
					armor.Skills.Add(skillDescriptions.First(x => x.SkillId == Convert.ToInt32(armor.Skill3.Substring(0, armor.Skill3.IndexOf(":"))) && x.Level == armor.Skill3Level));
				}
				if (armor.SetSkill1 != "0: --------")
				{
					armor.SetSkill = setSkills.First(x => x.SetBonusId == Convert.ToInt32(armor.SetSkill1.Substring(0, armor.SetSkill1.IndexOf(":"))));
				}
				armor.SetName = armor.SetLayeredId!.Value > 0 ? GetSetName(armor.SetLayeredId!.Value) : "";
				armor.CraftingData = craftingData.FirstOrDefault(x => x.EquipmentIndex!.Value == armor.Index!.Value);
				armor.Rarity++;
			}
			return allArmor;
		}

		public static string TranslateArmorTypeToIcon(string type)
		{
			return new Dictionary<string, string>()
			{
				{ "Head", "Helmet" },
				{ "Chest", "Chestplate" },
				{ "Arms", "Armguards" },
				{ "Waist", "Waist" },
				{ "Legs", "Leggings" },
			}[type];
		}

		public static void GetSimplifiedArmorData()
		{
			SimplifiedSkill[] skills = SkillDescriptions.GetSimplifiedSkills();
			Armor[] armorData = GetArmors();
			Skills[] allSkills = MHWI.Skills.GetSkills();
			List<SimplifiedArmor> allSimpleArmor = [];
			foreach (Armor armor in armorData.Where(x => x.Name != "HARDUMMY" && x.Name != "Invalid Message"))
			{
				SimplifiedArmor simpleArmor = new SimplifiedArmor()
				{
					ArmorPieceName = armor.Name,
					ArmorType = armor.EquipSlot,
					Rarity = (int)armor.Rarity!.Value,
					SetName = armor.SetLayeredId!.Value > 0 ? GetSetName(armor.SetLayeredId!.Value) : "",
					SetBonus = armor.SetSkill != null ? armor.SetSkill.SetBonusName : ""
				};
				List<SimplifiedSkill> armorSkills = new List<SimplifiedSkill>();
				foreach (SkillDescriptions skill in armor.Skills)
				{
					SimplifiedSkill simpleSkill = skills.First(x => x.Id == skill.SkillId!.Value);
					armorSkills.Add(new SimplifiedSkill()
					{
						Description = simpleSkill.Description,
						Id = simpleSkill.Id,
						Level = (int)skill.Level!.Value,
						MaxLevel = simpleSkill.MaxLevel,
						LevelDetails = simpleSkill.LevelDetails,
						Name = simpleSkill.Name,
						WikiIconColor = simpleSkill.WikiIconColor
					});
				}
				simpleArmor.Skills = [.. armorSkills];
				allSimpleArmor.Add(simpleArmor);
			}
			File.WriteAllText(@"D:\MH_Data Repo\MH_Data\Parsed Files\MHWI\mhwi simple armor data.json", JsonConvert.SerializeObject(allSimpleArmor, Formatting.Indented));
		}

		private static string GetSetName(long key)
		{
			return new Dictionary<long, string>()
		{
			{ 1, "Leather" },
			{ 2, "Hunter's" },
			{ 3, "Anja" },
			{ 4, "Jagras" },
			{ 5, "Bone" },
			{ 6, "Alloy" },
			{ 7, "Kestodon" },
			{ 8, "Gajau" },
			{ 9, "Vespoid" },
			{ 10, "Kulu" },
			{ 11, "Pukei" },
			{ 12, "Jyura" },
			{ 13, "Barroth" },
			{ 14, "Kadachi" },
			{ 15, "Chainmail" },
			{ 16, "Unavailable" },
			{ 17, "Hornetaur" },
			{ 18, "Unavailable" },
			{ 19, "King Beetle" },
			{ 20, "Rathian" },
			{ 21, "Girros" },
			{ 22, "Tzitzi" },
			{ 23, "Lumu" },
			{ 24, "High Metal" },
			{ 25, "Death Stench" },
			{ 26, "Legiana" },
			{ 27, "Baan" },
			{ 28, "Odogaron" },
			{ 29, "Unavailable" },
			{ 30, "Ingot" },
			{ 31, "Unavailable" },
			{ 32, "Rathalos" },
			{ 33, "Diablos" },
			{ 34, "Kirin" },
			{ 35, "Brigade" },
			{ 36, "Unavailable" },
			{ 37, "Leather α" },
			{ 38, "Leather β" },
			{ 39, "Chainmail α" },
			{ 40, "Chainmail β" },
			{ 41, "Hunter's α" },
			{ 42, "Hunter's β" },
			{ 43, "Bone α" },
			{ 44, "Bone β" },
			{ 45, "Alloy α" },
			{ 46, "Alloy β" },
			{ 47, "Gajau α" },
			{ 48, "Gajau β" },
			{ 49, "Kestodon α" },
			{ 50, "Kestodon β" },
			{ 51, "Vespoid α" },
			{ 52, "Vespoid β" },
			{ 53, "Gastodon α" },
			{ 54, "Gastodon β" },
			{ 55, "Barnos α" },
			{ 56, "Barnos β" },
			{ 57, "Hornetaur α" },
			{ 58, "Hornetaur β" },
			{ 59, "Unavailable" },
			{ 60, "Unavailable" },
			{ 61, "Jagras α" },
			{ 62, "Jagras β" },
			{ 63, "Kulu α" },
			{ 64, "Kulu β" },
			{ 65, "Pukei α" },
			{ 66, "Pukei β" },
			{ 67, "Jyura α" },
			{ 68, "Jyura β" },
			{ 69, "Barroth α" },
			{ 70, "Barroth β" },
			{ 71, "Kadachi α" },
			{ 72, "Kadachi β" },
			{ 73, "Rathian α" },
			{ 74, "Rathian β" },
			{ 75, "Girros α" },
			{ 76, "Girros β" },
			{ 77, "Tzitzi α" },
			{ 78, "Tzitzi β" },
			{ 79, "Lumu α" },
			{ 80, "Lumu β" },
			{ 81, "Odogaron α" },
			{ 82, "Odogaron β" },
			{ 83, "Dodogama α" },
			{ 84, "Dodogama β" },
			{ 85, "Lavasioth α" },
			{ 86, "Lavasioth β" },
			{ 87, "Rath Heart α" },
			{ 88, "Rath Heart β" },
			{ 89, "High Metal α" },
			{ 90, "High Metal β" },
			{ 91, "Ingot α" },
			{ 92, "Ingot β" },
			{ 93, "Anja α" },
			{ 94, "Anja β" },
			{ 95, "Legiana α" },
			{ 96, "Legiana β" },
			{ 97, "Baan α" },
			{ 98, "Baan β" },
			{ 99, "Vaal Hazak α" },
			{ 100, "Vaal Hazak β" },
			{ 101, "Rathalos α" },
			{ 102, "Rathalos β" },
			{ 103, "Diablos α" },
			{ 104, "Diablos β" },
			{ 105, "Kirin α" },
			{ 106, "Kirin β" },
			{ 107, "Nergigante α" },
			{ 108, "Nergigante β" },
			{ 109, "Uragaan α" },
			{ 110, "Uragaan β" },
			{ 111, "Rath Soul α" },
			{ 112, "Rath Soul β" },
			{ 113, "Diablos Nero α" },
			{ 114, "Diablos Nero β" },
			{ 115, "Bazel α" },
			{ 116, "Bazel β" },
			{ 117, "King Beetle α" },
			{ 118, "King Beetle β" },
			{ 119, "Brigade α" },
			{ 120, "Brigade β" },
			{ 121, "Damascus α" },
			{ 122, "Damascus β" },
			{ 123, "Dober α" },
			{ 124, "Dober β" },
			{ 125, "Xeno'jiiva α" },
			{ 126, "Xeno'jiiva β" },
			{ 127, "Teostra α" },
			{ 128, "Teostra β" },
			{ 129, "Kushala α" },
			{ 130, "Kushala β" },
			{ 131, "Skull α" },
			{ 132, "Skull β" },
			{ 133, "Death Stench α" },
			{ 134, "Death Stench β" },
			{ 135, "Guild Cross α" },
			{ 136, "Guild Cross β" },
			{ 137, "Unavailable" },
			{ 138, "Unavailable" },
			{ 139, "Zorah α" },
			{ 140, "Zorah β" },
			{ 141, "Commission α" },
			{ 142, "Commission β" },
			{ 143, "Unavailable" },
			{ 144, "Unavailable" },
			{ 145, "Brigade" },
			{ 146, "Guild Cross" },
			{ 147, "Blossom" },
			{ 148, "Diver" },
			{ 149, "Harvest" },
			{ 150, "Orion" },
			{ 151, "Faux Felyne α" },
			{ 152, "Mosswine Mask α" },
			{ 153, "Gala Suit" },
			{ 154, "HARDUMMY" },
			{ 155, "Ryu" },
			{ 156, "Sakura" },
			{ 157, "Bushi \"Sabi\"" },
			{ 158, "Bushi \"Sabi\"" },
			{ 159, "Bayek" },
			{ 160, "Bushi \"Sabi\"" },
			{ 161, "Shamos" },
			{ 162, "Shamos α" },
			{ 163, "Shamos β" },
			{ 164, "Butterfly" },
			{ 165, "Butterfly α" },
			{ 166, "Butterfly β" },
			{ 167, "Bushi \"Sabi\"" },
			{ 168, "Bushi \"Sabi\"" },
			{ 169, "Origin" },
			{ 170, "Bushi \"Homare\"" },
			{ 171, "Bushi \"Homare\"" },
			{ 172, "Bushi \"Homare\"" },
			{ 173, "Bushi \"Homare\"" },
			{ 174, "Bushi \"Homare\"" },
			{ 175, "Unavailable" },
			{ 176, "Strategist α" },
			{ 177, "Unavailable" },
			{ 178, "Dragonking α" },
			{ 179, "Unavailable" },
			{ 180, "Unavailable" },
			{ 181, "Unavailable" },
			{ 182, "Unavailable" },
			{ 183, "Kulve Taroth α" },
			{ 184, "Kulve Taroth β" },
			{ 185, "Blossom" },
			{ 186, "Diver" },
			{ 187, "Harvest" },
			{ 188, "Orion" },
			{ 189, "Gala Suit" },
			{ 190, "Samurai" },
			{ 191, "Deviljho α" },
			{ 192, "Deviljho β" },
			{ 193, "Unavailable" },
			{ 194, "Bushi \"Sabi\"" },
			{ 195, "Bushi \"Homare\"" },
			{ 196, "Drachen α" },
			{ 197, "Blossom α" },
			{ 198, "Diver α" },
			{ 199, "Harvest α" },
			{ 200, "Orion α" },
			{ 201, "Gala Suit α" },
			{ 202, "Butterfly" },
			{ 203, "Butterfly α" },
			{ 204, "Butterfly β" },
			{ 205, "Queen Beetle" },
			{ 206, "Queen Beetle α" },
			{ 207, "Queen Beetle β" },
			{ 208, "Vaal Hazak γ" },
			{ 209, "Kirin γ" },
			{ 210, "Teostra γ" },
			{ 211, "Kushala γ" },
			{ 212, "Nergigante γ" },
			{ 213, "Zorah γ" },
			{ 214, "Xeno'jiiva γ" },
			{ 215, "HARDUMMY" },
			{ 216, "Ryu" },
			{ 217, "Ryu α" },
			{ 218, "Sakura α" },
			{ 219, "Azure Starlord α" },
			{ 220, "Dante α" },
			{ 221, "Lunastra α" },
			{ 222, "Lunastra β" },
			{ 223, "Sealed Eyepatch α" },
			{ 224, "Shadow Shades α" },
			{ 225, "Kulu-Ya-Ku Head α" },
			{ 226, "Wiggler Head α" },
			{ 227, "Butterfly" },
			{ 228, "Death Stench" },
			{ 229, "Shadow Shades" },
			{ 230, "Dante" },
			{ 231, "Drachen" },
			{ 232, "Mosswine Mask" },
			{ 233, "Faux Felyne" },
			{ 234, "Commission" },
			{ 235, "Sealed Eyepatch" },
			{ 236, "Wiggler Head" },
			{ 237, "Origin" },
			{ 238, "Beetle" },
			{ 239, "Unavailable" },
			{ 240, "Skull Mask" },
			{ 241, "Kulu-Ya-Ku Head" },
			{ 242, "HARDUMMY" },
			{ 243, "Lunastra γ" },
			{ 244, "Geralt α" },
			{ 245, "Ciri α" },
			{ 246, "Geralt of Rivia" },
			{ 247, "Ciri" },
			{ 248, "Kulve Taroth γ" },
			{ 249, "Defender α" },
			{ 250, "Direwolf+" },
			{ 251, "Unavailable" },
			{ 252, "Bone α+" },
			{ 253, "Bone β+" },
			{ 254, "Alloy α+" },
			{ 255, "Alloy β+" },
			{ 256, "Vespoid α+" },
			{ 257, "Vespoid β+" },
			{ 258, "Hornetaur α+" },
			{ 259, "Hornetaur β+" },
			{ 260, "Kestodon α+" },
			{ 261, "Kestodon β+" },
			{ 262, "Gajau α+" },
			{ 263, "Gajau β+" },
			{ 264, "Shamos α+" },
			{ 265, "Shamos β+" },
			{ 266, "Gastodon α+" },
			{ 267, "Gastodon β+" },
			{ 268, "Barnos α+" },
			{ 269, "Barnos β+" },
			{ 270, "Wulg α+" },
			{ 271, "Wulg β+" },
			{ 272, "Cortos α+" },
			{ 273, "Cortos β+" },
			{ 274, "Jagras α+" },
			{ 275, "Jagras β+" },
			{ 276, "Tzitzi α+" },
			{ 277, "Tzitzi β+" },
			{ 278, "Girros α+" },
			{ 279, "Girros β+" },
			{ 280, "Dodogama α+" },
			{ 281, "Dodogama β+" },
			{ 282, "Kulu α+" },
			{ 283, "Kulu β+" },
			{ 284, "Pukei α+" },
			{ 285, "Pukei β+" },
			{ 286, "Barroth α+" },
			{ 287, "Barroth β+" },
			{ 288, "Jyura α+" },
			{ 289, "Jyura β+" },
			{ 290, "Beo α+" },
			{ 291, "Beo β+" },
			{ 292, "Kadachi α+" },
			{ 293, "Kadachi β+" },
			{ 294, "High Metal α+" },
			{ 295, "High Metal β+" },
			{ 296, "Banbaro α+" },
			{ 297, "Banbaro β+" },
			{ 298, "Anja α+" },
			{ 299, "Anja β+" },
			{ 300, "Rathian α+" },
			{ 301, "Rathian β+" },
			{ 302, "Rath Heart α+" },
			{ 303, "Rath Heart β+" },
			{ 304, "Lumu α+" },
			{ 305, "Lumu β+" },
			{ 306, "Lumu Phantasm α+" },
			{ 307, "Lumu Phantasm β+" },
			{ 308, "Coral Pukei α+" },
			{ 309, "Coral Pukei β+" },
			{ 310, "Viper Kadachi α+" },
			{ 311, "Viper Kadachi β+" },
			{ 312, "Baan α+" },
			{ 313, "Baan β+" },
			{ 314, "Leather" },
			{ 315, "Chain" },
			{ 316, "Hunter α" },
			{ 317, "Hunter β" },
			{ 318, "Bone" },
			{ 319, "Alloy" },
			{ 320, "Vespoid" },
			{ 321, "Hornetaur" },
			{ 322, "Kestodon" },
			{ 323, "Gajau" },
			{ 324, "Unavailable" },
			{ 325, "Goldspring Macaque" },
			{ 326, "Shamos" },
			{ 327, "Faux Kelbi" },
			{ 328, "Ingot α+" },
			{ 329, "Ingot β+" },
			{ 330, "Barioth α+" },
			{ 331, "Barioth β+" },
			{ 332, "Rathalos α+" },
			{ 333, "Rathalos β+" },
			{ 334, "Diablos α+" },
			{ 335, "Diablos β+" },
			{ 336, "Legiana α+" },
			{ 337, "Legiana β+" },
			{ 338, "Odogaron α+" },
			{ 339, "Odogaron β+" },
			{ 340, "Lavasioth α+" },
			{ 341, "Lavasioth β+" },
			{ 342, "Uragaan α+" },
			{ 343, "Uragaan β+" },
			{ 344, "Nargacuga α+" },
			{ 345, "Nargacuga β+" },
			{ 346, "Glavenus α+" },
			{ 347, "Glavenus β+" },
			{ 348, "Brachydios α+" },
			{ 349, "Brachydios β+" },
			{ 350, "Tigrex α+" },
			{ 351, "Tigrex β+" },
			{ 352, "Fulgur Anja α+" },
			{ 353, "Fulgur Anja β+" },
			{ 354, "Jagras" },
			{ 355, "Kulu-Ya-Ku" },
			{ 356, "Black Belt α+" },
			{ 357, "Black Belt β+" },
			{ 358, "Dragonking Eyepatch" },
			{ 359, "Strategist Spectacles" },
			{ 360, "Pulverizing Feather" },
			{ 361, "Tzitzi-Ya-Ku" },
			{ 362, "Great Girros" },
			{ 363, "Shrieking Legia α+" },
			{ 364, "Shrieking Legia β+" },
			{ 365, "Rath Soul α+" },
			{ 366, "Rath Soul β+" },
			{ 367, "Diablos Nero α+" },
			{ 368, "Diablos Nero β+" },
			{ 369, "Death Garon α+" },
			{ 370, "Death Garon β+" },
			{ 371, "Acidic Glavenus α+" },
			{ 372, "Acidic Glavenus β+" },
			{ 373, "Artian α+" },
			{ 374, "Artian β+" },
			{ 375, "Skull Scarf" },
			{ 376, "Pukei-Pukei α" },
			{ 377, "Pukei-Pukei β" },
			{ 378, "Dober α+" },
			{ 379, "Dober β+" },
			{ 380, "Damascus α+" },
			{ 381, "Damascus β+" },
			{ 382, "Velkhana α+" },
			{ 383, "Velkhana β+" },
			{ 384, "Seething Bazel α+" },
			{ 385, "Seething Bazel β+" },
			{ 386, "Blackveil Hazak α+" },
			{ 387, "Blackveil Hazak β+" },
			{ 388, "Teostra α+" },
			{ 389, "Teostra β+" },
			{ 390, "Kushala α+" },
			{ 391, "Kushala β+" },
			{ 392, "Kirin α+" },
			{ 393, "Kirin β+" },
			{ 394, "Namielle α+" },
			{ 395, "Namielle β+" },
			{ 396, "Clockwork α+" },
			{ 397, "Barroth" },
			{ 398, "Guild Palace α+" },
			{ 399, "Guild Palace β+" },
			{ 400, "Clockwork α+" },
			{ 401, "Clockwork β+" },
			{ 402, "Crystal Earring" },
			{ 403, "Ruiner Nergi α+" },
			{ 404, "Ruiner Nergi β+" },
			{ 405, "Shara Ishvalda α+" },
			{ 406, "Shara Ishvalda β+" },
			{ 407, "Savage Jho α+" },
			{ 408, "Savage Jho β+" },
			{ 409, "Anjanath α" },
			{ 410, "Anjanath β" },
			{ 411, "Guildwork α+" },
			{ 412, "Guildwork β+" },
			{ 413, "Unavailable" },
			{ 414, "Golden Lune α+" },
			{ 415, "Golden Lune β+" },
			{ 416, "Silver Sol α+" },
			{ 417, "Silver Sol β+" },
			{ 418, "Jyuratodus" },
			{ 419, "Tobi-Kadachi" },
			{ 420, "Zinogre α+" },
			{ 421, "Zinogre β+" },
			{ 422, "Stygian Zin α+" },
			{ 423, "Stygian Zin β+" },
			{ 424, "Yian Garuga α+" },
			{ 425, "Yian Garuga β+" },
			{ 426, "Zorah α+" },
			{ 427, "Zorah β+" },
			{ 428, "Rajang α+" },
			{ 429, "Rajang β+" },
			{ 430, "Furious Rajang α+" },
			{ 431, "Furious Rajang β+" },
			{ 432, "Raging Brachy α+" },
			{ 433, "Raging Brachy β+" },
			{ 434, "Safi'jiiva α+" },
			{ 435, "Safi'jiiva β+" },
			{ 436, "Alatreon α+" },
			{ 437, "Alatreon β+" },
			{ 438, "Sealed Dragon Cloth α+" },
			{ 439, "Wyverian Ears α+" },
			{ 440, "Faux Aptonoth" },
			{ 441, "Duffel Penguin Mask α+" },
			{ 442, "Lunastra α+" },
			{ 443, "Lunastra β+" },
			{ 444, "Kulve Taroth α+" },
			{ 445, "Kulve Taroth β+" },
			{ 446, "Rose α+" },
			{ 447, "Paolumu" },
			{ 448, "Passion α+" },
			{ 449, "Rathian α" },
			{ 450, "Demonlord α+" },
			{ 451, "Rathian β" },
			{ 452, "Oolong α+" },
			{ 453, "Radobaan α" },
			{ 454, "Astral α+" },
			{ 455, "Radobaan β" },
			{ 456, "Rose" },
			{ 457, "Passion" },
			{ 458, "Demonlord" },
			{ 459, "Oolong" },
			{ 460, "Astral" },
			{ 461, "High Metal" },
			{ 462, "Thermae" },
			{ 463, "Hare Band" },
			{ 464, "Downy Crake" },
			{ 465, "Pearlspring α+" },
			{ 466, "Kadachi Scarf" },
			{ 467, "Buff Body α+" },
			{ 468, "Brute Tigrex α+" },
			{ 469, "Brute Tigrex β+" },
			{ 470, "Guardian α+" },
			{ 471, "Yukumo" },
			{ 472, "Silver Knight" },
			{ 473, "HARDUMMY" },
			{ 474, "Namielle γ+" },
			{ 475, "Azure Starlord" },
			{ 476, "Azure Age α+" },
			{ 477, "Velkhana γ+" },
			{ 478, "Frostfang Barioth α+" },
			{ 479, "Frostfang Barioth β+" },
			{ 480, "Fatalis α+" },
			{ 481, "Fatalis β+" },
			{ 482, "HARDUMMY" },
			{ 483, "Unavailable" },
			{ 484, "Leon α+" },
			{ 485, "Claire α+" },
			{ 486, "Leon+" },
			{ 487, "Claire+" },
			{ 488, "Gastodon" },
			{ 489, "Barnos" },
			{ 490, "Dodogama" },
			{ 491, "Ingot" },
			{ 492, "Rath Heart α" },
			{ 493, "Rath Heart β" },
			{ 494, "Lavasioth α" },
			{ 495, "Lavasioth β" },
			{ 496, "Legiana α" },
			{ 497, "Legiana β" },
			{ 498, "Odogaron α" },
			{ 499, "Odogaron β" },
			{ 500, "Rathalos α" },
			{ 501, "Rathalos β" },
			{ 502, "Rath Soul α" },
			{ 503, "Rath Soul β" },
			{ 504, "Diablos α" },
			{ 505, "Diablos β" },
			{ 506, "Diablos Nero α" },
			{ 507, "Diablos Nero β" },
			{ 508, "Uragaan α" },
			{ 509, "Uragaan β" },
			{ 510, "Bazelgeuse α" },
			{ 511, "Bazelgeuse β" },
			{ 512, "Deviljho α" },
			{ 513, "Deviljho β" },
			{ 514, "Dober α" },
			{ 515, "Dober β" },
			{ 516, "Damascus α" },
			{ 517, "Damascus β" },
			{ 518, "Zorah α" },
			{ 519, "Zorah β" },
			{ 520, "Zorah γ" },
			{ 521, "Nergigante α" },
			{ 522, "Nergigante β" },
			{ 523, "Nergigante γ" },
			{ 524, "Teostra α" },
			{ 525, "Teostra β" },
			{ 526, "Teostra γ" },
			{ 527, "Kushala α" },
			{ 528, "Kushala β" },
			{ 529, "Kushala γ" },
			{ 530, "Vaal Hazak α" },
			{ 531, "Vaal Hazak β" },
			{ 532, "Vaal Hazak γ" },
			{ 533, "Kirin α" },
			{ 534, "Kirin β" },
			{ 535, "Kirin γ" },
			{ 536, "Xeno α" },
			{ 537, "Xeno β" },
			{ 538, "Xeno γ" },
			{ 539, "Lunastra α" },
			{ 540, "Lunastra β" },
			{ 541, "Lunastra γ" },
			{ 542, "Kulve α" },
			{ 543, "Kulve β" },
			{ 544, "Kulve γ" },
			{ 545, "Guardian" },
			{ 546, "Vespoid+" },
			{ 547, "Hornetaur+" },
			{ 548, "Wulg+" },
			{ 549, "Cortos+" },
			{ 550, "Jagras+" },
			{ 551, "Tzitzi-Ya-Ku+" },
			{ 552, "Great Girros+" },
			{ 553, "Dodogama+" },
			{ 554, "Kulu-Ya-Ku+" },
			{ 555, "Pukei-Pukei+" },
			{ 556, "Coral Pukei+" },
			{ 557, "Barroth+" },
			{ 558, "Jyuratodus+" },
			{ 559, "Beotodus+" },
			{ 560, "Tobi-Kadachi+" },
			{ 561, "Viper Kadachi+" },
			{ 562, "Banbaro α+" },
			{ 563, "Banbaro β+" },
			{ 564, "Anjanath α+" },
			{ 565, "Anjanath β+" },
			{ 566, "Fulgur Anja α+" },
			{ 567, "Fulgur Anja β+" },
			{ 568, "Rathian α+" },
			{ 569, "Rathian β+" },
			{ 570, "Rath Heart α+" },
			{ 571, "Rath Heart β+" },
			{ 572, "Paolumu+" },
			{ 573, "Lumu Phantasm+" },
			{ 574, "Radobaan+" },
			{ 575, "Artian" },
			{ 576, "Barioth α+" },
			{ 577, "Barioth β+" },
			{ 578, "Rathalos α+" },
			{ 579, "Rathalos β+" },
			{ 580, "Rath Soul α+" },
			{ 581, "Rath Soul β+" },
			{ 582, "Diablos α+" },
			{ 583, "Diablos β+" },
			{ 584, "Diablos Nero α+" },
			{ 585, "Diablos Nero β+" },
			{ 586, "Legiana α+" },
			{ 587, "Legiana β+" },
			{ 588, "Shrieking Legia α+" },
			{ 589, "Shrieking Legia β+" },
			{ 590, "Odogaron α+" },
			{ 591, "Odogaron β+" },
			{ 592, "Death Garon α+" },
			{ 593, "Death Garon β+" },
			{ 594, "Lavasioth+" },
			{ 595, "Uragaan+" },
			{ 596, "Nargacuga α+" },
			{ 597, "Nargacuga β+" },
			{ 598, "Glavenus α+" },
			{ 599, "Glavenus β+" },
			{ 600, "Acidic Glavenus α+" },
			{ 601, "Acidic Glavenus β+" },
			{ 602, "Brachydios α+" },
			{ 603, "Brachydios β+" },
			{ 604, "Tigrex α+" },
			{ 605, "Tigrex β+" },
			{ 606, "Brute Tigrex α+" },
			{ 607, "Brute Tigrex β+" },
			{ 608, "Black Belt" },
			{ 609, "Seething Bazel α+" },
			{ 610, "Seething Bazel β+" },
			{ 611, "Savage Jho α+" },
			{ 612, "Savage Jho β+" },
			{ 613, "Velkhana α+" },
			{ 614, "Velkhana β+" },
			{ 615, "Blackveil Hazak α+" },
			{ 616, "Blackveil Hazak β+" },
			{ 617, "Teostra α+" },
			{ 618, "Teostra β+" },
			{ 619, "Kushala α+" },
			{ 620, "Kushala β+" },
			{ 621, "Kirin α+" },
			{ 622, "Kirin β+" },
			{ 623, "Namielle α+" },
			{ 624, "Namielle β+" },
			{ 625, "Guild Palace+" },
			{ 626, "Acrobat" },
			{ 627, "Showman" },
			{ 628, "Shara Ishvalda α+" },
			{ 629, "Shara Ishvalda β+" },
			{ 630, "Yian Garuga α+" },
			{ 631, "Yian Garuga β+" },
			{ 632, "Zinogre α+" },
			{ 633, "Zinogre β+" },
			{ 634, "Golden Lune α+" },
			{ 635, "Golden Lune β+" },
			{ 636, "Silver Sol α+" },
			{ 637, "Silver Sol β+" },
			{ 638, "Lunastra α+" },
			{ 639, "Lunastra β+" },
			{ 640, "Ruiner Nergi α+" },
			{ 641, "Ruiner Nergi β+" },
			{ 642, "Guildwork+" },
			{ 643, "Rajang α+" },
			{ 644, "Rajang β+" },
			{ 645, "Stygian Zin α+" },
			{ 646, "Stygian Zin β+" },
			{ 647, "Safi'jiiva α+" },
			{ 648, "Safi'jiiva β+" },
			{ 649, "Furious Rajang α+" },
			{ 650, "Furious Rajang β+" },
			{ 651, "Raging Brachy α+" },
			{ 652, "Raging Brachy β+" },
			{ 653, "Frostfang Barioth α+" },
			{ 654, "Frostfang Barioth β+" },
			{ 655, "Alatreon α+" },
			{ 656, "Alatreon β+" },
			{ 657, "Fatalis α+" },
			{ 658, "Fatalis β+" },
			{ 659, "Kulve Taroth α+" },
			{ 660, "Kulve Taroth β+" },
			{ 661, "Sealed Dragon Cloth" },
			{ 662, "Wyverian Ears" },
			{ 663, "Duffel Penguin+" },
			{ 664, "Pearlspring+" },
			{ 665, "Buff Body α+" },
			{ 666, "Azure Age" },
			{ 667, "Unavailable" },
			{ 668, "HARDUMMY" },
			{ 669, "Velkhana γ+" },
			{ 670, "Namielle γ+" },
			{ 671, "Unavailable" },
			{ 672, "Buff Body γ+" },
			{ 673, "Innerwear α" },
			{ 674, "Clockwork β+" },
			{ 675, "Innerwear β" },
			{ 676, "Artemis α+" },
			{ 677, "Artemis" },
			{ 678, "Artemis α+" }
		}[key];
		}
	}

	public partial class Armor
	{
		public static Armor[] FromJson(string json) => JsonConvert.DeserializeObject<Armor[]>(json, MediawikiTranslator.Models.Data.MHWI.ArmorConverter.Settings);
	}

	internal static class ArmorConverter
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

	internal class ArmorParseStringConverter : JsonConverter
	{
		public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

		public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null) return null;
			var value = serializer.Deserialize<string>(reader);
			long l;
			if (Int64.TryParse(value, out l))
			{
				return l;
			}
			throw new Exception("Cannot unmarshal type long");
		}

		public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
		{
			if (untypedValue == null)
			{
				serializer.Serialize(writer, null);
				return;
			}
			var value = (long)untypedValue;
			serializer.Serialize(writer, value.ToString());
			return;
		}

		public static readonly ArmorParseStringConverter Singleton = new ArmorParseStringConverter();
	}
}
