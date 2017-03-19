using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyPlace
{
    public enum HeroTypeEnum
    {
        Archer = 0,
        Barbarian,
        Casual,
        Wizard,
        Sorceress,
        Knight,
        //Normal
        Special,
        //Rare
        King,
        Gorgon,
        Spideress,
        Aqua,
        Fire,
        Naked,
        //End
        Max,
    }

    public static class CharaCreator
    {
        static Dictionary<string, HeroItem> _dictHeroConfs;
        static Dictionary<string, Material> _dictLoadedMats = new Dictionary<string, Material>();

        public static void CreateHero()
        {
            if (_dictHeroConfs == null)
            {
                var heroList = SerializationManager.LoadFromCSV<HeroItem>("Configs/HeroConfs");
                _dictHeroConfs = new Dictionary<string, HeroItem>();
                heroList.ForEach(p =>
                {
                    _dictHeroConfs.Add(p.strType, p);
                });
            }

            int perc = Random.Range(0, 100);
            HeroTypeEnum typeEnum = HeroTypeEnum.Archer;
            if (perc < 70)
                typeEnum = (HeroTypeEnum)Random.Range(0, (int)HeroTypeEnum.Special);
            else
                typeEnum = (HeroTypeEnum)Random.Range((int)HeroTypeEnum.Special + 1, (int)HeroTypeEnum.Max);

            var hero = (GameObject.Instantiate(Resources.Load(Consts.Prefab_HeroBase)) as GameObject).AddComponent<HeroCtrl>();
            hero.transform.position = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            var itemConf = _dictHeroConfs[typeEnum.ToString()];

            Material matPrefab = null;
            var matName = itemConf.GenRandomHeroMatName();
            if (_dictLoadedMats.ContainsKey(matName))
                matPrefab = _dictLoadedMats[matName];
            else
            {
                matPrefab = Resources.Load<Material>(Consts.Material_Heroes + matName);
                _dictLoadedMats.Add(matName, matPrefab);
            }
            if (matPrefab != null)
            {
                hero.ModelMngr.smrBody.material.CopyPropertiesFromMaterial(matPrefab);
                hero.ModelMngr.smrBody.material.shader = matPrefab.shader;
            }
        }
    }


    public class HeroItem : ICSVDeserializable
    {
       
        static string[] strRacials = { "Black", "Brown", "White" };

        public string strType;
        public int nSexual;
        public bool bRacial;
        public string[] strCounts;
        public string[] strColors;

        public void CSVDeserialize(Dictionary<string, string[]> data, int index)
        {
            strType = data["Type"][index];
            nSexual = int.Parse(data["Sexual"][index]);
            bRacial = !string.IsNullOrEmpty(data["Racial"][index]);
            strCounts = data["Count"][index].Split('|');
            string colors = data["Color"][index];
            strColors = string.IsNullOrEmpty(colors) ? null : colors.Split('|');
        }

        public string GenRandomHeroMatName() //sexual + racial + type + count + color
        {
            string finalLook = "";
            //sexual 1 male 0 female
            int sexId = nSexual == 2 ? Random.Range(0, 2) : nSexual;
            finalLook = sexId == 0 ? "Female " : "Male ";
            //choose one if have racail
            if (bRacial)
            {
                int ranRacial = Random.Range(0, strRacials.Length);
                finalLook += strRacials[ranRacial] + " ";
            }
            finalLook += strType;
            //naked have no count
            int count = strCounts.Length > 1 ? int.Parse(strCounts[sexId]) : int.Parse(strCounts[0]);
            if (count != 0)
                finalLook += " 0" + (Random.Range(0, count) + 1);
            //may no color
            if (strColors != null)
            {
                string color = " " + strColors[Random.Range(0, strColors.Length)];
                if (DataCenter.Instance.MatList.Contains(finalLook + color))
                    finalLook += color;
                else
                {
                    var availableLooks = DataCenter.Instance.MatList.FindAll(p => p.Contains(finalLook));
                    finalLook = availableLooks[Random.Range(0, availableLooks.Count)];
                }
            }
            return finalLook;
        }
    }
}
