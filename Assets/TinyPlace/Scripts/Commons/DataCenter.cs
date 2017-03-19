using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyPlace
{
    public class DataCenter
    {
        private static DataCenter _instance;
        public static DataCenter Instance
        {
            get {
                if (_instance == null)
                    _instance = new DataCenter();
                return _instance;
            }
        }

        public DataCenter()
        {
            LoadHeroMats();
        }

        List<string> _lstMats = new List<string>();
        public List<string> MatList
        {
            get { return _lstMats; }
        }
        void LoadHeroMats()
        {
            TextAsset ta = Resources.Load(Consts.Confs + "MatList") as TextAsset;
            if (ta != null)
            {
                var mats = ta.text.Split('|');
                _lstMats.Clear();

                for (int i = 0; i < mats.Length; i++)
                    _lstMats.Add(mats[i]);
            }
        }
    }
}
