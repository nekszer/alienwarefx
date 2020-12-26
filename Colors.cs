using ColorHelper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlienColors
{
    public class ColorPallete
    {
        private static Dictionary<string, Dictionary<string, string>> Colors
        {
            get
            {
                return new Dictionary<string, Dictionary<string, string>>
                {
                    { "Red", new Dictionary<string, string>
                        {
                            { "accent-4", "#d50000" }, { "accent-3", "#ff1744" }, { "accent-2", "#ff5252" }, { "accent-1", "#ff8a80" },
                            { "darken-4", "#b71c1c" }, { "darken-3", "#c62828" }, { "darken-2", "#d32f2f" }, { "darken-1", "#e53935" },
                            { "neutral", "#f44336" },
                            { "lighten-1", "#ef5350" }, { "lighten-2", "#e57373" }, { "lighten-3", "#ef9a9a" }, { "lighten-4", "#ffcdd2" }, { "lighten-5", "#ffebee" }
                        }
                    },
                    { "Pink", new Dictionary<string, string>
                        {
                            { "accent-4", "#c51162" }, { "accent-3", "#f50057" }, { "accent-2", "#ff4081" }, { "accent-1", "#ff80ab" }, { "darken-4", "#880e4f" }, { "darken-3", "#ad1457" }, { "darken-2", "#c2185b" }, { "darken-1", "#d81b60" }, { "neutral","#e91e63" }, { "lighten-1", "#ec407a" }, { "lighten-2", "#f06292" }, { "lighten-3", "#f48fb1" }, { "lighten-4", "#f8bbd0" }, { "lighten-5", "#fce4ec" }
                        }
                    },
                    { "Purple", new Dictionary<string, string>
                        {
                            { "accent-4", "#aa00ff" }, { "accent-3", "#d500f9" }, { "accent-2", "#e040fb" }, { "accent-1", "#ea80fc" }, { "darken-4", "#4a148c" }, { "darken-3", "#6a1b9a" }, { "darken-2", "#7b1fa2" }, { "darken-1", "#8e24aa" }, { "neutral","#9c27b0" }, { "lighten-1", "#ab47bc" }, { "lighten-2", "#ba68c8" }, { "lighten-3", "#ce93d8" }, { "lighten-4", "#e1bee7" }, { "lighten-5", "#f3e5f5" }
                        }
                    },
                    { "Indigo ", new Dictionary<string, string>
                        {
                            { "accent-4", "#304ffe" }, { "accent-3", "#3d5afe" }, { "accent-2", "#536dfe" }, { "accent-1", "#8c9eff" }, { "darken-4", "#1a237e" }, { "darken-3", "#283593" }, { "darken-2", "#303f9f" }, { "darken-1", "#3949ab" }, { "neutral","#3f51b5" }, { "lighten-1", "#5c6bc0" }, { "lighten-2", "#7986cb" }, { "lighten-3", "#9fa8da" }, { "lighten-4", "#c5cae9" }, { "lighten-5", "#e8eaf6" }
                        }
                    },
                    { "Blue", new Dictionary<string, string>
                        {
                            { "accent-4", "#2962ff" }, { "accent-3", "#2979ff" }, { "accent-2", "#448aff" }, { "accent-1", "#82b1ff" }, { "darken-4", "#0d47a1" }, { "darken-3", "#1565c0" }, { "darken-2", "#1976d2" }, { "darken-1", "#1e88e5" }, { "neutral","#2196f3" }, { "lighten-1", "#42a5f5" }, { "lighten-2", "#64b5f6" }, { "lighten-3", "#90caf9" }, { "lighten-4", "#bbdefb" }, { "lighten-5", "#e3f2fd" }
                        }
                    },
                    { "Cyan", new Dictionary<string, string>
                        {
                            { "accent-4", "#00b8d4" }, { "accent-3", "#00e5ff" }, { "accent-2", "#18ffff" }, { "accent-1", "#84ffff" }, { "darken-4", "#006064" }, { "darken-3", "#00838f" }, { "darken-2", "#0097a7" }, { "darken-1", "#00acc1" }, { "neutral","#00bcd4" }, { "lighten-1", "#26c6da" }, { "lighten-2", "#4dd0e1" }, { "lighten-3", "#80deea" }, { "lighten-4", "#b2ebf2" }, { "lighten-5", "#e0f7fa" }
                        }
                    },
                    { "Teal", new Dictionary<string, string>
                        {
                            { "accent-4", "#00bfa5" }, { "accent-3", "#1de9b6" }, { "accent-2", "#64ffda" }, { "accent-1", "#a7ffeb" }, { "darken-4", "#004d40" }, { "darken-3", "#00695c" }, { "darken-2", "#00796b" }, { "darken-1", "#00897b" }, { "neutral","#009688" }, { "lighten-1", "#26a69a" }, { "lighten-2", "#4db6ac" }, { "lighten-3", "#80cbc4" }, { "lighten-4", "#b2dfdb" }, { "lighten-5", "#e0f2f1" }
                        }
                    },
                    { "Green", new Dictionary<string, string>
                        {
                            { "accent-4", "#00c853" }, { "accent-3", "#00e676" }, { "accent-2", "#69f0ae" }, { "accent-1", "#b9f6ca" }, { "darken-4", "#1b5e20" }, { "darken-3", "#2e7d32" }, { "darken-2", "#388e3c" }, { "darken-1", "#43a047" }, { "neutral","#4caf50" }, { "lighten-1", "#66bb6a" }, { "lighten-2", "#81c784" }, { "lighten-3", "#a5d6a7" }, { "lighten-4", "#c8e6c9" }, { "lighten-5", "#e8f5e9" }
                        }
                    },
                    { "Lime", new Dictionary<string, string>
                        {
                            { "accent-4", "#aeea00" }, { "accent-3", "#c6ff00" }, { "accent-2", "#eeff41" }, { "accent-1", "#f4ff81" }, { "darken-4", "#827717" }, { "darken-3", "#9e9d24" }, { "darken-2", "#afb42b" }, { "darken-1", "#c0ca33" }, { "neutral","#cddc39" }, { "lighten-1", "#d4e157" }, { "lighten-2", "#dce775" }, { "lighten-3", "#e6ee9c" }, { "lighten-4", "#f0f4c3" }, { "lighten-5", "#f9fbe7" }
                        }
                    },
                    { "Yellow", new Dictionary<string, string>
                        {
                            { "accent-4", "#ffd600" }, { "accent-3", "#ffea00" }, { "accent-2", "#ffff00" }, { "accent-1", "#ffff8d" }, { "darken-4", "#f57f17" }, { "darken-3", "#f9a825" }, { "darken-2", "#fbc02d" }, { "darken-1", "#fdd835" }, { "neutral","#ffeb3b" }, { "lighten-1", "#ffee58" }, { "lighten-2", "#fff176" }, { "lighten-3", "#fff59d" }, { "lighten-4", "#fff9c4" }, { "lighten-5", "#fffde7" }
                        }
                    },
                    { "Amber", new Dictionary<string, string>
                        {
                            { "accent-4", "#ffab00" }, { "accent-3", "#ffc400" }, { "accent-2", "#ffd740" }, { "accent-1", "#ffe57f" }, { "darken-4", "#ff6f00" }, { "darken-3", "#ff8f00" }, { "darken-2", "#ffa000" }, { "darken-1", "#ffb300" }, { "neutral","#ffc107" }, { "lighten-1", "#ffca28" }, { "lighten-2", "#ffd54f" }, { "lighten-3", "#ffe082" }, { "lighten-4", "#ffecb3" }, { "lighten-5", "#fff8e1" }

                        }
                    },
                    { "Orange", new Dictionary<string, string>
                        {
                            { "accent-4", "#ff6d00" }, { "accent-3", "#ff9100" }, { "accent-2", "#ffab40" }, { "accent-1", "#ffd180" }, { "darken-4", "#e65100" }, { "darken-3", "#ef6c00" }, { "darken-2", "#f57c00" }, { "darken-1", "#fb8c00" }, { "neutral","#ff9800" }, { "lighten-1", "#ffa726" }, { "lighten-2", "#ffb74d" }, { "lighten-3", "#ffcc80" }, { "lighten-4", "#ffe0b2" }, { "lighten-5", "#fff3e0" }
                        }
                    },
                    { "Brown", new Dictionary<string, string>
                        {
                            { "darken-4", "#3e2723" }, { "darken-3", "#4e342e" }, { "darken-2", "#5d4037" }, { "darken-1", "#6d4c41" }, { "neutral","#795548" }, { "lighten-1", "#8d6e63" }, { "lighten-2", "#a1887f" }, { "lighten-3", "#bcaaa4" }, { "lighten-4", "#d7ccc8" }, { "lighten-5", "#efebe9" }
                        }
                    },
                    { "Grey", new Dictionary<string, string>
                        {
                            { "darken-4", "#212121" }, { "darken-3", "#424242" }, { "darken-2", "#616161" }, { "darken-1", "#757575" }, { "neutral","#9e9e9e" }, { "lighten-1", "#bdbdbd" }, { "lighten-2", "#e0e0e0" }, { "lighten-3", "#eeeeee" }, { "lighten-4", "#f5f5f5" }, { "lighten-5", "#fafafa" }
                        }
                    }
                };
            }
        }

        private static Random rand = new Random();

        /// <summary>
        /// Genera un color aleatorio
        /// </summary>
        /// <returns>HEX Color</returns>
        public static RGB RandomColor()
        {
            var color = Colors.OrderBy(i => rand.Next()).FirstOrDefault();
            var values = color.Value.Where(c => c.Key.Contains("darken") || c.Key.Contains("neutral"));
            var random = RandomColor(values);
            var rgb = ColorConverter.HexToRgb(new HEX(random.Value));
            return rgb;
        }

        private static KeyValuePair<string, string> RandomColor(IEnumerable<KeyValuePair<string, string>> colors)
        {
            var randomlyOrdered = colors.OrderBy(i => rand.Next());
            var randomitemm = randomlyOrdered.First();
            return randomitemm;
        }

        public static RGB GetColor(ColorName color, ColorTone type)
        {
            if (Colors.ContainsKey(color.ToString()))
                if (Colors[color.ToString()].ContainsKey(type.ToString())) return ColorConverter.HexToRgb( new HEX(Colors[color.ToString()][type.ToString()]));
            throw new Exception("Color and type not found");
        }

    }

    public enum ColorName
    {
        Red,
        Pink,
        Purple,
        Indigo,
        Blue,
        Cyan,
        Teal,
        Green,
        Lime,
        Yellow,
        Amber,
        Orange,
        Brown,
        Grey
    }

    public enum ColorTone
    {
        Accent4,
        Accent3,
        Accent2,
        Accent1,
        Darkne4,
        Darkne3,
        Darkne2,
        Darkne1,
        Neutral,
        Lighten1,
        Lighten2,
        Lighten3,
        Lighten4,
        Lighten5
    }
}
