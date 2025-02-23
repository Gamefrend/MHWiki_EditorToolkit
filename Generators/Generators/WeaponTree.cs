using DocumentFormat.OpenXml.Math;
using MediawikiTranslator.Models.DamageTable.PartsData;
using MediawikiTranslator.Models.Data.MHWI;
using MediawikiTranslator.Models.WeaponTree;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System.Text;

namespace MediawikiTranslator.Generators
{
	public class WeaponTree
	{
		public static string ParseJson(string json, string sharpnessBase, int maxSharpnessCount, string pathName, string defaultIcon)
		{
			return Generate(WebToolkitData.FromJson(json), sharpnessBase, maxSharpnessCount, pathName, defaultIcon).Result;
		}

		public static string ParseCsv(string csvFile, bool duplicateSharpness, string delimiter = ",")
		{
			return Models.WeaponTree.Serialize.ToJson([new WebToolkitData() {
				Data = ParseWeaponsFromCsv(csvFile, duplicateSharpness, delimiter).ToArray()
			}]);
		}


		public static async Task<string> Generate(WebToolkitData[] srcData, string sharpnessBase, int maxSharpnessCount, string pathName, string defaultIcon)
		{
			return await Task.Run(() =>
			{
				if (srcData.Length == 0 || !srcData.Any(x => x.Data.Any(y => !string.IsNullOrEmpty(y.Name))))
				{
					return "";
				}
				StringBuilder ret = new();
				ret.AppendLine($@"{{{{#css:
  @media screen and (max-width:600px)
  {{ 
    .hide-on-mobile {{
      display:none;
    }}
    table.wikitable.mobile-sm tr td span.divot {{
      font-size:smaller!important;
    }}
    table.wikitable.mobile-sm td {{
      padding-left:0px!important;
      padding-right:0px!important;
    }}
  }}
}}}}");
				string tableGame = srcData.Length > 0 ? srcData[0].Game : "MHWI";
				string tableIconType = srcData.Length > 0 && srcData[0].Data.Length > 0 ? srcData[0].Data[0].IconType : "GS";
				if (string.IsNullOrEmpty(tableIconType))
				{
					tableIconType = defaultIcon;
				}
				if (new string[] { "MHG", "MH1", "MHF1" }.Contains(tableGame))
				{
					string fullName = GetWeaponTypeFullName(tableIconType);
					ret.AppendLine($"{{{{1stGenTreeLegend|{fullName}|{(tableGame == "MH1" ? "1": "2")}}}}}");
				}
				else
				{
					ret.AppendLine($@"{{{{WeaponTreeLegend|{srcData.FirstOrDefault()?.Game ?? "MHWI"}|{(WebToolkitData.GetWeaponName(string.IsNullOrEmpty(srcData.FirstOrDefault()?.Data?.FirstOrDefault()?.IconType) ? defaultIcon : srcData.FirstOrDefault()?.Data?.FirstOrDefault()?.IconType))}}}}}");
				}
				bool tableHasElderseal = srcData.Any(y => y.Data.Any(x => !string.IsNullOrEmpty(x.Elderseal)));
				bool tableHasRampageSlots = srcData.Any(y => y.Data.Any(x => !string.IsNullOrEmpty(x.RampageSlots) && x.RampageSlots != "0"));
				bool tableHasRampageDecos = srcData.Any(y => y.Data.Any(x => !string.IsNullOrEmpty(x.RampageDeco) && x.RampageDeco != "0"));
				bool tableHasArmorSkills = srcData.Any(y => y.Data.Any(x => !string.IsNullOrEmpty(x.ArmorSkill)));
				int totalCnt = 0;
				ret.AppendLine($@"<br>
{{| class=""wikitable center wide mw-collapsible mobile-sm"" style=""white-space:normal; overflow-x:auto;""
! colspan=12 | <h4 style=""margin:0px;"">{srcData[0].PathName} Tree</h4>
|-
!Name 
!class=""hide-on-mobile""|Rarity
!class=""hide-on-mobile""|{{{{UI|MHWI|Attack}}}}");
				if (!new string[] { "HBG", "LBG" }.Contains(tableIconType))
				{
					ret.AppendLine(@"!class=""hide-on-mobile""|{{UI|MHWI|Element}}");
				}
				if (!new string[] { "MHG", "MH1", "MHF1" }.Contains(tableGame))
				{
					ret.AppendLine(@"!class=""hide-on-mobile""|{{UI|MHWI|Affinity}}");
				}
				StringBuilder mobileHeaderBuilder = new();
				mobileHeaderBuilder.AppendLine(@"! R
! {{UI|MHWI|Attack}}");
				if (!new string[] { "HBG", "LBG" }.Contains(tableIconType))
				{
					mobileHeaderBuilder.AppendLine(@"! {{UI|MHWI|Element}}");
				}
				if (!new string[] { "MHG", "MH1", "MHF1" }.Contains(tableGame))
				{
					mobileHeaderBuilder.AppendLine(@"! {{UI|MHWI|Affinity}}");
				}
				switch (tableIconType)
				{
					case "Bo":
						ret.AppendLine("!class=\"hide-on-mobile\"|{{UI|MHWI|Bow Coatings}}");
						mobileHeaderBuilder.AppendLine("!{{UI|MHWI|Bow Coatings}}");
						break;
					case "CB":
						ret.AppendLine("!class=\"hide-on-mobile\"|{{UI|MHWI|CB Phial Type}}");
						mobileHeaderBuilder.AppendLine("!{{UI|MHWI|CB Phial Type}}");
						break;
					case "SA":
						ret.AppendLine("!class=\"hide-on-mobile\"|{{UI|MHWI|SA Phial Type}}");
						mobileHeaderBuilder.AppendLine("!{{UI|MHWI|SA Phial Type}}");
						break;
					case "GL":
						ret.AppendLine("!class=\"hide-on-mobile\"|{{UI|MHWI|GL Shelling Type}}");
						mobileHeaderBuilder.AppendLine("!{{UI|MHWI|GL Shelling Type}}");
						break;
					case "HH":
						ret.AppendLine("!class=\"hide-on-mobile\"|{{UI|MHWI|HH Menu Notes}}");
						mobileHeaderBuilder.AppendLine("!{{UI|MHWI|HH Menu Notes}}");
						break;
					case "IG":
						ret.AppendLine("!class=\"hide-on-mobile\"|{{UI|MHWI|IG Kinsect Bonus}}");
						mobileHeaderBuilder.AppendLine("!{{UI|MHWI|IG Kinsect Bonus}}");
						break;
					case "HBG":
						ret.AppendLine("!class=\"hide-on-mobile\"|{{UI|MHWI|HBG Special Ammo}}");
						mobileHeaderBuilder.AppendLine("!{{UI|MHWI|HBG Special Ammo}}");
						ret.AppendLine("!class=\"hide-on-mobile\"|{{UI|MHWI|HBG Deviation}}");
						mobileHeaderBuilder.AppendLine("!{{UI|MHWI|HBG Deviation}}");
						if (srcData[0].Game != "MHWI")
						{
							ret.AppendLine("!class=\"hide-on-mobile\"|Reload / Recoil");
							mobileHeaderBuilder.AppendLine("!Reload / Recoil");
						}
						break;
					case "LBG":
						ret.AppendLine("!{{UI|MHWI|LBG Special Ammo}}");
						mobileHeaderBuilder.AppendLine("!{{UI|MHWI|LBG Special Ammo}}");
						ret.AppendLine("!class=\"hide-on-mobile\"|{{UI|MHWI|LBG Deviation}}");
						mobileHeaderBuilder.AppendLine("!{{UI|MHWI|LBG Deviation}}");
						if (srcData[0].Game != "MHWI")
						{
							ret.AppendLine("!class=\"hide-on-mobile\"|Reload / Recoil");
							mobileHeaderBuilder.AppendLine("!Reload / Recoil");
						}
						break;
					default: break;
				}
				if (tableHasElderseal)
				{
					ret.AppendLine(@"!class=""hide-on-mobile""|{{UI|MHWI|Elderseal}}");
					mobileHeaderBuilder.AppendLine("!{{UI|MHWI|Elderseal}}");
				}
				if (tableHasRampageSlots)
				{
					ret.AppendLine(@"!class=""hide-on-mobile""|Rmpg. Slots");
					mobileHeaderBuilder.AppendLine("!Rmpg. Slots");
				}
				if (tableHasRampageDecos)
				{
					ret.AppendLine(@"!class=""hide-on-mobile""|[[File:UI-Rampage Decoration 3.png|20x20px|center|link=]]");
					mobileHeaderBuilder.AppendLine("![[File:UI-Rampage Decoration 3.png|20x20px|center|link=]]");
				}
				if (tableHasArmorSkills)
				{
					ret.AppendLine(@"!class=""hide-on-mobile""|[[File:MHWI-Armor Skill Icon Red.png|20x20px|link=]]");
					mobileHeaderBuilder.AppendLine("![[File:MHWI-Armor Skill Icon Red.png|20x20px|link=]]");
				}
				if (!new string[] { "Bo", "HBG", "LBG" }.Contains(tableIconType))
				{
					ret.AppendLine(@"!class=""hide-on-mobile""|[[File:2ndGen-Whetstone Icon Yellow.png|24x24px|link=]]");
					mobileHeaderBuilder.AppendLine("![[File:2ndGen-Whetstone Icon Yellow.png|24x24px|link=]]");
				}
				if (!new string[] { "MHG", "MH1", "MHF1" }.Contains(tableGame))
				{
					ret.AppendLine(@"!class=""hide-on-mobile""|[[File:2ndGen-Decoration Icon Blue.png|24x24px|link=]]");
					mobileHeaderBuilder.AppendLine(@"![[File:2ndGen-Decoration Icon Blue.png|24x24px|link=]]");
				}
				ret.AppendLine(@"!class=""hide-on-mobile""|{{UI|MHWI|Defense}}");
				mobileHeaderBuilder.AppendLine(@"!{{UI|MHWI|Defense}}");
				string mobileHeaders = mobileHeaderBuilder.ToString();
				List<string> namesSoFar = [];
				int arrayCnt = 0;
				foreach (Datum dataObj in srcData[0].Data.Where(x => !namesSoFar.Contains(x.Name.Trim())))
				{
					if (!namesSoFar.Contains(dataObj.Name.Trim()))
					{
						namesSoFar.Add(dataObj.Name.Trim());
						Tuple<int, int, List<string>> cnts = AddWeapon(ret, dataObj, defaultIcon, srcData, srcData[0], totalCnt, arrayCnt, sharpnessBase, maxSharpnessCount, mobileHeaders, tableHasElderseal, tableHasRampageSlots, tableHasRampageDecos, tableHasArmorSkills, namesSoFar);
						totalCnt = cnts.Item1;
						arrayCnt = cnts.Item2;
						namesSoFar.AddRange(cnts.Item3.Where(x => !namesSoFar.Contains(x)));
					}
				}
				ret.AppendLine("|}");
				return ret.ToString();
			});
		}

		private static Tuple<int, int, List<string>> AddWeapon(StringBuilder ret, Datum dataObj, string defaultIcon, WebToolkitData[] srcData, WebToolkitData dataArray, int totalCnt, int arrayCnt, string sharpnessBase, int maxSharpnessCount, string mobileHeaders, bool tableHasElderseal, bool tableHasRampageSlots, bool tableHasRampageDecos, bool tableHasArmorSkills, List<string> namesSoFar)
		{
			string iconType = dataObj.IconType;
			if (string.IsNullOrEmpty(iconType))
			{
				iconType = defaultIcon;
			}
			string sharpness = "";
			if (!string.IsNullOrEmpty(dataObj.Sharpness))
			{
				string[][] objSharpness = Newtonsoft.Json.JsonConvert.DeserializeObject<string[][]>(dataObj.Sharpness)!;
				for (var i2 = 0; i2 < objSharpness.Length; i2++)
				{
					var barObj = objSharpness[i2];
					sharpness += "{{" + sharpnessBase;
					var cnt = maxSharpnessCount > -1 ? maxSharpnessCount : barObj.Length;
					for (var i3 = 0; i3 < cnt; i3++)
					{
						sharpness += "|" + (barObj[i3] != "" ? barObj[i3] : 0);
					}
					sharpness += "}}";
					if (i2 != objSharpness.Length - 1)
					{
						sharpness += "\n";
					}
				}
			}
			string decos = "";
			if (!string.IsNullOrEmpty(dataObj.Decos))
			{
				Decoration[] objDecos = [.. Newtonsoft.Json.JsonConvert.DeserializeObject<Decoration[]>(dataObj.Decos)!.OrderBy(x => !x.IsRampage).ThenBy(x => x.Level)];
				if (new string[] { "MHWI", "MHW", "MHRS", "MHR", "MHWilds" }.Contains(dataArray.Game))
				{
					foreach (Decoration deco in objDecos)
					{
						for (int i = 0; i < deco.Qty; i++)
						{
							decos += $"{{{{{(deco.IsRampage ? "RampageDeco" : "5thDeco")}|{deco.Level}}}}}";
						}
					}
				}
				else if (objDecos.Length > 0)
				{
					for (int i = 0; i < objDecos[0].Qty; i++)
					{
						decos += "◯";
					}
				}
			}
			int trueRaw = Convert.ToInt32(Math.Round(Convert.ToInt32(dataObj.Attack) / Weapon.GetWeaponBloat(iconType, dataArray.Game)));
			Datum? iterAncestor = dataObj;
			List<int> ancestors = [];
			Datum ancestor = dataArray.Data[0];
			Datum[] allData = srcData.SelectMany(x => x.Data).ToArray();
			string[] dataNames = allData.Select(x => x.Name.Trim()).Distinct().ToArray();
			int testCnt = 0;
			while (iterAncestor != null && testCnt < 500)
			{
				iterAncestor = allData.FirstOrDefault(x => iterAncestor.Parent != null && x.Name.Trim() == iterAncestor.Parent.Trim());
				if (iterAncestor != null && iterAncestor.Name.Trim() != dataObj.Name.Trim())
				{
					int index = Array.IndexOf(dataNames, (iterAncestor ?? ancestor).Name.Trim());
					if (!ancestors.Contains(index))
					{
						ancestors.Add(Array.IndexOf(dataNames, (iterAncestor ?? ancestor).Name.Trim()));
					}
				}
				testCnt++;
			}
			if (testCnt >= 500)
			{
				throw new Exception("Ancestor overload at " + dataArray.Data[0].Name + " line somewhere near " + iterAncestor!.Name + ". This usually means that the weapons are referencing each other in the \"Upgraded From\" section in a never-ending loop.");
			}
			string prefix = "";
			ancestors.Reverse();
			List<string> prevPaths = [];
			List<Datum> ancs = [];
			Datum? anc = dataObj;
			while (anc != null)
			{
				if (!string.IsNullOrEmpty(anc.Parent))
				{
					string parent = anc.Parent;
					anc = allData.FirstOrDefault(x => x.Name == parent && !string.IsNullOrEmpty(x.PathLink));
					if (anc == null)
					{
						anc = allData.First(x => x.Name == parent);
					}
					ancs.Add(anc);
				}
				else
				{
					anc = null;
				}
			}
			ancs.Reverse();
			foreach (Datum a in ancs)
			{
				if (!string.IsNullOrEmpty(a.PathLink) && prevPaths.Count < 2)
				{
					prevPaths.Add(a.PathLink);
				}
			}
			int thisIndex = Array.IndexOf(dataNames, dataObj.Name);
			int ancestorCnt = 1;
			int spaceCnt = 0;
			if (totalCnt > 0 && !string.IsNullOrEmpty(dataObj.Parent))
			{
				bool futureSiblings = !string.IsNullOrEmpty(dataObj.Parent) && allData.Any(x => x.Name != dataObj.Name && x.Parent != null && x.Parent.Trim() == dataObj.Parent.Trim() && Array.IndexOf(dataNames, x.Name) > thisIndex);
				foreach (int ancestorIndex in ancestors)
				{
					string ancestorName = dataNames[ancestorIndex];
					Datum ancestorWeapon = allData.First(x => x.Name.Trim() == ancestorName.Trim());
					if (!string.IsNullOrEmpty(ancestorWeapon.Parent) && allData.Any(x => x.Name != ancestorName && x.Parent != null && x.Parent.Trim() == ancestorWeapon.Parent.Trim() && Array.IndexOf(dataNames, x.Name) > ancestorIndex))
					{
						prefix += "{{K|I}}";
					}
					else
					{
						if (prefix == "")
						{
							prefix += "{{K|S|W}}";
						}
						else if (spaceCnt > 0 || string.IsNullOrEmpty(dataObj.PathLink) || prevPaths.Count >= 2)
						{
							prefix += "{{K|S|W}}";
						}
						spaceCnt++;
					}
					ancestorCnt++;
				}
				prefix += futureSiblings ? "{{K|B}}" : "{{K|L}}";
			}
			string prevPathLink = prevPaths.Count > 1 ? prevPaths[1] : "";
			string thisPathLink = prevPaths.Count > 0 ? prevPaths[0] : "";
			string id = GetWeaponId($"{dataObj.Name.Replace(" ", "_")}_{dataArray.PathName.Replace(" ", "_")}");
			ret.AppendLine($@"{{{{GenericWeaponTreeRow
| ID = {id}{(!string.IsNullOrEmpty(dataObj.PathLink) && prevPaths.Count < 2 ? $@"
| IDC = {dataObj.PathLink.Replace(" ", "_")}" : "")}{(!string.IsNullOrEmpty(thisPathLink) ? $@"
| IDH = {thisPathLink.Replace(" ", "_")}" : "")}{(!string.IsNullOrEmpty(prevPathLink) ? $@"
| IDIH = {prevPathLink.Replace(" ", "_")}" : "")}{(!string.IsNullOrEmpty(prefix) ? $@"
| Spaces = {prefix}" : "")}
| Weapon = {{{{GenericWeaponLink|{dataArray.Game}|{dataObj.Name}|{iconType}|{dataObj.Rarity}{(dataObj.CanForge == true ? "|true" : "")}{(dataObj.CanRollback == true ? (dataObj.CanForge != true ? "||true" : "|true") : "")}}}}}
| Headers = 
{mobileHeaders}{(iconType == "Bo" ? @"
| 5 Style = white-space: normal;" : "")}
|{dataObj.Rarity}
|{dataObj.Attack + (trueRaw == Convert.ToInt32(dataObj.Attack) ? "" : $" ({trueRaw})")}");
			if (!new string[] { "HBG", "LBG" }.Contains(iconType))
			{
				ret.AppendLine($@"|{(string.IsNullOrEmpty(dataObj.Element) && dataObj.Element != "0" ? "-" : $"{{{{UI|UI|{dataObj.Element}|text={dataObj.ElementDamage}}}}}") + (string.IsNullOrEmpty(dataObj.Element2) && dataObj.Element2 != "0" ? "" : $" {{{{UI|UI|{dataObj.Element2}|text={dataObj.ElementDamage2}}}}}")} ");
			}
			if (!new string[] { "MHG", "MH1", "MHF1" }.Contains(dataArray.Game))
			{
				ret.AppendLine($@"|{ ((dataObj.Affinity == 0 || dataObj.Affinity == null) ? "0%" : dataObj.Affinity + "%")} ");
			}
			switch (iconType)
			{
				case "Bo":
					ret.AppendLine($"|{GetBowCoatings(dataArray.Game, dataObj.BoCoatings)}");
					break;
				case "CB":
					ret.AppendLine($"|{(!string.IsNullOrEmpty(dataObj.CBPhialType) ? dataObj.CBPhialType : " - ")}");
					break;
				case "SA":
					ret.AppendLine($"|{(!string.IsNullOrEmpty(dataObj.SAPhialType) ? dataObj.SAPhialType : " - ")}");
					break;
				case "GL":
					ret.AppendLine($"|{(!string.IsNullOrEmpty(dataObj.GLShellingType) ? dataObj.GLShellingType : " - ")}");
					break;
				case "HH":
					ret.AppendLine($"|{{{{UI|MHWI|HH Note|1 {dataObj.HHNote1}}}}}{{{{UI|MHWI|HH Note|2 {dataObj.HHNote2}}}}}{{{{UI|MHWI|HH Note|3 {dataObj.HHNote3}}}}}");
					break;
				case "IG":
					ret.AppendLine($"|{(!string.IsNullOrEmpty(dataObj.IGKinsectBonus) ? dataObj.IGKinsectBonus : " - ")}");
					break;
				case "HBG":
					ret.AppendLine($"|{(!string.IsNullOrEmpty(dataObj.HBGSpecialAmmoType) ? dataObj.HBGSpecialAmmoType : " - ")}");
					ret.AppendLine($"|{(!string.IsNullOrEmpty(dataObj.HBGDeviation) ? dataObj.HBGDeviation : " - ")}");
					if (dataArray.Game != "MHWI")
					{
						ret.AppendLine($"|{(!string.IsNullOrEmpty(dataObj.HBGReloadRecoil) ? dataObj.HBGReloadRecoil : " - ")}");
					}
					break;
				case "LBG":
					ret.AppendLine($"|{(!string.IsNullOrEmpty(dataObj.LBGSpecialAmmoType) ? dataObj.LBGSpecialAmmoType : " - ")}");
					ret.AppendLine($"|{(!string.IsNullOrEmpty(dataObj.LBGDeviation) ? dataObj.LBGDeviation : " - ")}");
					if (dataArray.Game != "MHWI")
					{
						ret.AppendLine($"|{(!string.IsNullOrEmpty(dataObj.LBGReloadRecoil) ? dataObj.LBGReloadRecoil : " - ")}");
					}
					break;
				default: break;
			}
			if (!string.IsNullOrEmpty(dataObj.Elderseal))
			{
				ret.AppendLine($@"| {dataObj.Elderseal}");
			}
			else if (tableHasElderseal)
			{
				ret.AppendLine("| -");
			}
			if (!string.IsNullOrEmpty(dataObj.RampageSlots) && dataObj.RampageSlots != "0")
			{
				ret.AppendLine($@"| {dataObj.RampageSlots}");
			}
			else if (tableHasRampageSlots)
			{
				ret.AppendLine("| -");
			}
			if (!string.IsNullOrEmpty(dataObj.RampageDeco) && dataObj.RampageDeco != "0")
			{
				ret.AppendLine($@"| [[File:UI-Rampage Decoration {dataObj.RampageDeco}.png|20x20px|center]]");
			}
			else if (tableHasRampageDecos)
			{
				ret.AppendLine("| -");
			}
			if (!string.IsNullOrEmpty(dataObj.ArmorSkill))
			{
				ret.AppendLine($@"| {dataObj.ArmorSkill}{(!string.IsNullOrEmpty(dataObj.ArmorSkill2) ? ", " + dataObj.ArmorSkill2 : "")}");
			}
			else if (tableHasArmorSkills)
			{
				ret.AppendLine("| -");
			}
			if (!new string[] { "Bo", "HBG", "LBG" }.Contains(iconType))
			{
				ret.AppendLine($@"| {(string.IsNullOrEmpty(sharpness) ? "-" : sharpness)}");
			}
			ret.AppendLine($@"| {(string.IsNullOrEmpty(decos) ? "-" : decos)}
| {(string.IsNullOrEmpty(dataObj.Defense) || dataObj.Defense == "0" ? "-" : dataObj.Defense)}
}}}}");
			if (!string.IsNullOrEmpty(dataObj.PathLink))
			{
				WebToolkitData? dataArrayThis = srcData.FirstOrDefault(x => x.PathName == dataObj.PathLink);
				if (dataArrayThis != null)
				{
					foreach (Datum obj in dataArrayThis.Data.Where(x => !namesSoFar.Contains(x.Name.Trim())))
					{
						if (!namesSoFar.Contains(obj.Name.Trim()))
						{
							namesSoFar.Add(obj.Name.Trim());
							Tuple<int, int, List<string>> cnts = AddWeapon(ret, obj, defaultIcon, srcData, dataArrayThis, totalCnt, arrayCnt, sharpnessBase, maxSharpnessCount, mobileHeaders, tableHasElderseal, tableHasRampageSlots, tableHasRampageDecos, tableHasArmorSkills, namesSoFar);
							totalCnt = cnts.Item1;
							arrayCnt = cnts.Item2;
							namesSoFar.AddRange(cnts.Item3.Where(x => !namesSoFar.Contains(x)));
						}
					}
				}
			}
			totalCnt++;
			arrayCnt++;
			return new Tuple<int, int, List<string>>(totalCnt, arrayCnt, namesSoFar);
		}

		private static string GetWeaponId(string idStart)
		{
			char[] replace = ['!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '+', '=', '{', '}', '[', ']', '|', '\\', ':', ';', '"', '\'', '<', '>', ',', '/', '?'];
			string[] replaceWith = ["exclam", "ampat", "pound", "dollar", "perc", "carat", "amp", "asterisk", "parenthopen", "parenthclose", "plus", "equals", "braceopen", "braceclose", "bracketopen", "bracketclose", "pipe", "backslash", "colon", "semicolon", "quote", "apost", "quote", "less", "greater", "comma", "slash", "question"];
			for (int i = 0; i < replace.Length; i++)
			{
				idStart = idStart.Replace(replace[i].ToString(), replaceWith[i]);
			}
			return idStart;
		}

		public static string GetWeaponTypeFullName(string weaponType)
		{
			return new Dictionary<string, string>()
			{
				{ "CB", "Charge Blade"},
				{ "DB", "Dual Blades"},
				{ "GS", "Great Sword"},
				{ "GL", "Gunlance"},
				{ "Hm", "Hammer"},
				{ "HH", "Hunting Horn"},
				{ "IG", "Insect Glaive"},
				{ "Ln", "Lance"},
				{ "LS", "Long Sword"},
				{ "SA", "Switch Axe"},
				{ "SnS", "Sword and Shield"},
				{ "Bo", "Bow"},
				{ "HBG", "Heavy Bowgun"},
				{ "LBG", "Light Bowgun"}
			}[weaponType];
		}

		private static string GetBowCoatings(string game, string coatingString)
		{
			string[] coatingArr = coatingString?.Split(',')?.Select(x => x.Trim())?.ToArray() ?? [];
			string coatings = "";
			foreach (string coating in coatingArr)
			{
				if (coatings != "")
				{
					coatings += " ";
				}
				bool hasPlus = coating.EndsWith("+");
				switch (coating[..^(hasPlus ? 1 : 0)])
				{
					case "Close-Range":
					case "Closerange":
					case "CloseRange":
					case "Close-range":
					{
						coatings += $"[[File:{game}-Coating Icon White{(hasPlus ? " Plus" : "")}.png|24x24px|Close-range Coating|link=Close-range Coating ({game})]]";
						break;
					}
					case "Power":
					{
						coatings += $"[[File:{game}-Coating Icon Red{(hasPlus ? " Plus" : "")}.png|24x24px|Power Coating|link=Power Coating ({game})]]";
						break;
					}
					case "Poison":
					{
						coatings += $"[[File:{game}-Coating Icon Purple{(hasPlus ? " Plus" : "")}.png|24x24px|Poison Coating|link=Poison Coating ({game})]]";
						break;
					}
					case "Para":
					{
						coatings += $"[[File:{game}-Coating Icon {(game == "MHRS" ? "Orange" : "Lemon")}{(hasPlus ? " Plus" : "")}.png|24x24px|Para Coating|link=Para Coating ({game})]]";
						break;
					}
					case "Sleep":
					{
						coatings += $"[[File:{game}-Coating Icon Light Blue{(hasPlus ? " Plus" : "")}.png|24x24px|Sleep Coating|link=Sleep Coating ({game})]]";
						break;
					}
					case "Blast":
					{
						coatings += $"[[File:{game}-Coating Icon {(game == "MHRS" ? "Vermilion" : "Light Green")}{(hasPlus ? " Plus" : "")}.png|24x24px|Blast Coating|link=Blast Coating ({game})]]";
						break;
					}
					case "Exhaust":
					{
						coatings += $"[[File:{game}-Coating Icon Dark Blue{(hasPlus ? " Plus" : "")}.png|24x24px|Exhaust Coating|link=Exhaust Coating ({game})]]";
						break;
					}
				}
			}
			return coatings;
		}

		private static List<Datum> ParseWeaponsFromCsv(string csvFile, bool duplicateSharpness, string delimiter = ",")
		{
			var weapons = new List<Datum>();
			using (var parser = new TextFieldParser(GenerateStreamFromString(csvFile)))
			{
				string[]? lines = csvFile.Split('\n');
				foreach (String line in lines)
				{
					if (line.Split(delimiter).Length > 10)
					{

						//Reformating field that have "," in them so they can be parsed into weapons
						String cleanedLine = line;

						if (!cleanedLine.Split(delimiter)[16].Contains("n/a"))
						{
							String temp = cleanedLine.Split(delimiter)[16];
                            String sharpnessCleanedLine = sharpnessReformater(line);
							cleanedLine = sharpnessCleanedLine;
						}
						if (!cleanedLine.Split(delimiter)[18].Contains("n/a"))
						{
                            String coatingCleanedLine = coatingReformater(cleanedLine, delimiter);
							cleanedLine = coatingCleanedLine;
						}

						//Processing row
						string[]? fields = cleanedLine.Split(delimiter);
						Datum weapon = ParseWeaponFromLine(fields);
						weapon.Decos = ParseDecosFromLine(fields);
						List<string[]> sharpnessFinal = [];

						if (!fields[16].Contains("n/a"))
						{
							SharpnessData sharp1 = ParseSharpness1FromLine(fields[16]);
							sharpnessFinal.Add([sharp1.Red!.Value.ToString(), sharp1.Orange!.Value.ToString(), sharp1.Yellow!.Value.ToString(), sharp1.Green!.Value.ToString(), sharp1.Blue!.Value.ToString(), sharp1.White!.Value.ToString(), sharp1.Purple!.Value.ToString()]);
							SharpnessData? sharp2 = null;
							if (fields.Length == 29)
							{
								sharp2 = ParseSharpness2FromLine(fields[17]);
							}
							else if (duplicateSharpness)
							{
								sharp2 = sharp1;
							}
							if (sharp2 != null)
							{
								sharpnessFinal.Add([sharp2.Red!.Value.ToString(), sharp2.Orange!.Value.ToString(), sharp2.Yellow!.Value.ToString(), sharp2.Green!.Value.ToString(), sharp2.Blue!.Value.ToString(), sharp2.White!.Value.ToString(), sharp2.Purple!.Value.ToString()]);
							}
						}
						weapon.Sharpness = JsonConvert.SerializeObject(sharpnessFinal.ToArray());
						weapons.Add(weapon);
					}
				}
			}

			return weapons;
		}

		private static String sharpnessReformater(String line){
			int startIndexSharpness = line.IndexOf("[");
			int endIndexSharpness = line.IndexOf("]");
			String substringSharpness = "";
			String substringSharpnessTwo = "";
			String SharpnessCleanedline = "";

			if (startIndexSharpness != -1 && endIndexSharpness != -1){

				String subStringBeginningAfterSharpness = line.Substring(endIndexSharpness + 1, line.Length - endIndexSharpness - 1);
				int startIndexSharpnessTwo = subStringBeginningAfterSharpness.IndexOf("[");
				int endIndexSharpnessTwo = subStringBeginningAfterSharpness.IndexOf("]");

				substringSharpness = line.Substring(startIndexSharpness, endIndexSharpness - startIndexSharpness + 1);
				substringSharpnessTwo = line.Substring(endIndexSharpness + 4, endIndexSharpnessTwo - startIndexSharpnessTwo + 1);

				String beginningOfLine = line.Substring(0, startIndexSharpness).Replace("\"","");
				String endOfLine = line.Substring(startIndexSharpnessTwo + endIndexSharpness + endIndexSharpnessTwo, line.Length - (startIndexSharpnessTwo + endIndexSharpness + endIndexSharpnessTwo));
				String newLine = substringSharpness.Replace(",", "") + "," + substringSharpnessTwo.Replace(",", "");

				SharpnessCleanedline = beginningOfLine + newLine + endOfLine;

				substringSharpness.Replace(",", "");
				substringSharpnessTwo.Replace(",", "");

				return SharpnessCleanedline;
			}
			return line;
		}

		private static String coatingReformater(String line, String delimiter)
		{
			Console.WriteLine(line);
            String coatingCleanedLine = "";
			int coatingStartIndex;
            if (line.IndexOf(",Close Range,") > 0)
			{
                return line.Replace("Close Range", "Close-Range");

            }
            if (line.IndexOf("\"\"\"") != -1)
			{
				int firstTrippleQuoteIndex = line.IndexOf("\"\"\"");
				int secondTrippleQuoteIndex = line.Substring(firstTrippleQuoteIndex + 4).IndexOf("\"\"\"") + firstTrippleQuoteIndex + 4;

				if(secondTrippleQuoteIndex < firstTrippleQuoteIndex)
				{
                    coatingStartIndex = line.Substring(firstTrippleQuoteIndex + 4).IndexOf("\"") + firstTrippleQuoteIndex + 4;
				}
				else
				{
                    coatingStartIndex = line.Substring(secondTrippleQuoteIndex + 4).IndexOf("\"") + secondTrippleQuoteIndex + 4;
                }
                Console.WriteLine(firstTrippleQuoteIndex + "  " + secondTrippleQuoteIndex + "  " + coatingStartIndex);
			}
			else
			{
                coatingStartIndex = line.IndexOf(",\"") + 1;
				
            }
            String coatingSubstring = line.Substring(coatingStartIndex + 1);
            Console.WriteLine(coatingStartIndex);
            int coatingSubstringLength = coatingSubstring.IndexOf("\"");
			coatingSubstring = coatingSubstring.Substring(0, coatingSubstringLength);
            coatingCleanedLine = line.Replace(coatingSubstring, coatingSubstring.Replace(", ", " ").Replace("Close Range","Close-Range"));
            return coatingCleanedLine;
		}

        // Very straightforward but also sensible
        private static Datum ParseWeaponFromLine(string[] lineFields)
		{
			bool? elementHidden = lineFields[9].Contains("(");
			return new Datum()
			{
				CanForge = lineFields[0] != "" ? true : null,
				CanRollback = lineFields[1] != "" ? true : null,
				Name = lineFields[2].IndexOf("\"\"") > 0 ? lineFields[2].Substring(1, lineFields[2].Length - 2).Replace("\"\"","\"") : lineFields[2],
				Parent = lineFields[3].IndexOf("\"\"") > 0 ? lineFields[2].Substring(1, lineFields[3].Length - 2) : lineFields[3],
                IconType = lineFields[4],
				Rarity = GetIntFieldOrEmpty(lineFields[5]),
				Attack = GetIntFieldOrEmpty(lineFields[6]).ToString(),
				Defense = lineFields[7].Contains("-") ? null : GetIntFieldOrEmpty(lineFields[7]).ToString(),
				Element = lineFields[8],
				ElementDamage = (elementHidden == true ? "(" : "") + GetIntFieldOrEmpty(lineFields[9].Replace("(", "").Replace(")", "").ToString()) + (elementHidden == true ? ")" : ""),
				Affinity = GetIntFieldOrEmpty(lineFields[10]),
				Elderseal = lineFields[11],
				//12-15 is Decoration, 16-17 is Sharpness
				BoCoatings = lineFields[18].Replace("\"", "").Replace(" ", ","),
				CBPhialType = lineFields[19],
				Element2 = lineFields[20],
				ElementDamage2 = GetIntFieldOrEmpty(lineFields[21]).ToString(),
				GLShellingType = lineFields[22] + " " + lineFields[23],
				HBGSpecialAmmoType = lineFields[24],
				HBGDeviation = lineFields[25],
				HHNote1 = lineFields[26].Replace("Light ", ""),
				HHNote2 = lineFields[27].Replace("Light ", ""),
				HHNote3 = lineFields[28].Replace("Light ", ""),
				IGKinsectBonus = lineFields[29],
				LBGSpecialAmmoType = lineFields[30],
				LBGDeviation = lineFields[31],
				SAPhialType = lineFields[32]
			};
		}

		private static string ParseDecosFromLine(string[] fields)
		{
			string decoArray = "[";
			int[] decos = [GetIntFieldOrEmpty(fields[12]), GetIntFieldOrEmpty(fields[13]), GetIntFieldOrEmpty(fields[14])];
			for (int decoLvl = 1; decoLvl < 5; decoLvl++)
			{
				int cnt = decos.Count(x => x == decoLvl);
				if (cnt > 0)
				{
					if (decoArray != "[")
					{
						decoArray += ", ";
					}
					decoArray += $"{{\"Level\":\"{decoLvl}\",\"Qty\":\"{cnt}\",\"IsRampage\":false}}";
				}
			}
			return decoArray + "]";
		}

		private static SharpnessData ParseSharpness1FromLine(String field)
		{
			String[] sharpness = field.Replace("[","").Replace("]","").Replace("\"","").Split(" ");
			return new SharpnessData()
			{
				Red = GetIntFieldOrEmpty(sharpness[0]),
				Orange = GetIntFieldOrEmpty(sharpness[1]),
				Yellow = GetIntFieldOrEmpty(sharpness[2]),
				Green = GetIntFieldOrEmpty(sharpness[3]),
				Blue = GetIntFieldOrEmpty(sharpness[4]),
				White = GetIntFieldOrEmpty(sharpness[5]),
				Purple = GetIntFieldOrEmpty(sharpness[6]),
			};
		}

        private static SharpnessData ParseSharpness2FromLine(string field)
        {
            String[] sharpness = field.Replace("[", "").Replace("]", "").Replace("\"", "").Split(" ");
            return new SharpnessData()
            {
                Red = GetIntFieldOrEmpty(sharpness[0]),
                Orange = GetIntFieldOrEmpty(sharpness[1]),
                Yellow = GetIntFieldOrEmpty(sharpness[2]),
                Green = GetIntFieldOrEmpty(sharpness[3]),
                Blue = GetIntFieldOrEmpty(sharpness[4]),
                White = GetIntFieldOrEmpty(sharpness[5]),
                Purple = GetIntFieldOrEmpty(sharpness[6]),
            };
        }

        private static int GetIntFieldOrEmpty(string field)
		{
			return !string.IsNullOrWhiteSpace(field) ? int.Parse(field) : 0;
		}

		private static bool? GetBoolFieldOrEmpty(string field)
		{
			return !string.IsNullOrWhiteSpace(field) ? bool.Parse(field) : null;
		}

		private static MemoryStream GenerateStreamFromString(string value)
		{
			return new MemoryStream(Encoding.UTF8.GetBytes(value ?? ""));
		}
    }
}
