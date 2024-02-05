namespace InternetTvProviderWinApp
{
    public partial class PocetnaStrana : Form
    {
        public PocetnaStrana()
        {
            InitializeComponent();

            usernameBox.Enter += new EventHandler(usernameBox_Enter);
            usernameBox.Leave += new EventHandler(usernameBox_Leave);
        }
    }
}
