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
    public bool FPS { set; get; } = true;

    public bool Debug { set; get; } = true;

    public int GraphicsWidth { set; get; } = 1280;

    public int GraphicsHeight { set; get; } = 720;

    public bool FullScreen { set; get; } = false;
}