
namespace IndigoBunting.FrameworkUI.Example1
{
    public class UIExample1Manager : UIBaseManager
    {
        private UIBaseCanvas menuCanvas;
        private UIBaseCanvas settingsCanvas;

        private void Start()
        {
            menuCanvas = GetCanvasByName("MainMenu");
            settingsCanvas = GetCanvasByName("Settings");
            
            menuCanvas.Show();
        }

        public void ShowSettings()
        {
            settingsCanvas.Show();
        }

        public void HideSettings()
        {
            settingsCanvas.Hide();
        }
    }
}
