using System.IO;
using UnityEngine;

namespace FightParty.Save
{
    public abstract class BaseSaveConfig : ScriptableObject
    {
        protected const string TypeSaveFile = ".json";

        [SerializeField] protected string _fileName;

        public string FileName => _fileName + TypeSaveFile;
        public string SavePatch => Path.Combine(Application.persistentDataPath, _fileName);
    }
}

