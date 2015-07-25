using Microsoft.Xna.Framework;

namespace Game_DX
{
    public class ConfigManager
    {
        #region Singleton

        private static volatile ConfigManager configManager;
        private static object lockObj = new object();

        private ConfigManager() { }

        public static ConfigManager Instance
        {
            get
            {
                if (configManager == null)
                {
                    lock (lockObj)
                    {
                        configManager = new ConfigManager();
                    }
                }
                return configManager;
            }
        }

        #endregion

        // Properties
        public bool FPS { get { return true; } }

        public bool Debug { get { return true; } }

        public GameWindow GameWindow { set; get; }

    }
}
