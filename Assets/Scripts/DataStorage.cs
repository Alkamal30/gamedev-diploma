using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public static class DataStorage
    {
        private readonly static string _directoryPath = "/Saves";
        private readonly static string _slotNameTemplate = "CharacterSlot_{0}.save";

        public static bool IsSlotDataExists(int index)
        {
            string slotName = string.Format(_slotNameTemplate, index);
            string slotPath = Path.Combine(Application.persistentDataPath, _directoryPath, slotName);

            return File.Exists(slotPath);
        }

        public static async Task<SlotData> LoadSlotDataAsync(int index)
        {
            string slotName = string.Format(_slotNameTemplate, index);
            string slotPath = Path.Combine(Application.persistentDataPath, _directoryPath, slotName);

            if(!File.Exists(slotPath))
            {
                return null;
            }

            string fileContent = await File.ReadAllTextAsync(slotPath);
            SlotData slotData = JsonUtility.FromJson<SlotData>(fileContent);

            return slotData;
        }

        public static async Task SaveSlotDataAsync(SlotData slotData)
        {
            string slotName = string.Format(_slotNameTemplate, slotData.SlotId);
            string directoryPath = Path.Combine(Application.persistentDataPath, _directoryPath);
            string slotPath = Path.Combine(directoryPath, slotName);

            string fileContent = JsonUtility.ToJson(slotData);
            
            Directory.CreateDirectory(directoryPath);
            await File.WriteAllTextAsync(slotPath, fileContent);
        }
    }
}
