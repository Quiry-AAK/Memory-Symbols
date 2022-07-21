using System.IO;

namespace _Main.Scripts.SymbolSave
{
    public static class PathGetter
    {
        public static string AnswersFolderPath = "Assets/Resources/Answers/";

        public static string GetPath()
        {
            return PathGetterRecursive(1);
        }

        private static string PathGetterRecursive(int fileNumber)
        {
            var _path = AnswersFolderPath + fileNumber + ".asset";
            if (File.Exists(_path)) {
                return PathGetterRecursive(fileNumber + 1);
            }
            return _path;
        }
    }
}
