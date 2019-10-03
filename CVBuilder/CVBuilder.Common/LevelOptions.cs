using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Common
{
    public static class LevelOptions
    {
        public const string None = "none";
        public const string Beginner = "beginner";
        public const string Intermediate = "intermediate";
        public const string Advanced = "advanced";

        public static Dictionary<string, string> LevelComboBox = new Dictionary<string, string>()
        {
            { Beginner, "Principiante" },
            { Intermediate, "Intermedio" },
            { Advanced, "Avanzado" }
        };
    }
}
