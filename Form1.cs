using CmlLib.Core;
using CmlLib.Core.Auth;
using System;//st�dyo using gerekmiyor diyor ama using(sistemi) kullanmazsak hataya sebep oluyor

namespace notcracklauncher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        public static string versiyon;//versiyon yazmazsak comboboxa itemler gelmiyor
        private void path()
        {
            var path = new MinecraftPath();
            var launcher = new CMLauncher(path);
            //var cmllibte bir class oy�zden pek kafaya takmay�n(kar��mas�n diye)
            foreach (var item in launcher.GetAllVersions())
            {
                comboBox1.Items.Add(item.Name);//yukar�da sat�rda t�m versiyonlar� microsoft sunucular�ndan al�yor ve comboboxa ekliyor(alpha beta ve rd dahil)
            }

        }

        private void Launch()
        {
            var path = new MinecraftPath();
            var launcher = new CMLauncher(path);//burada cml ba�lat�c�s�n� kullan�yor
            var launchOption = new MLaunchOption
            { //bu rami ayarlar
                MaximumRamMb = 2048,
                Session = MSession.GetOfflineSession(textBox1.Text),
                //tam bu sat�ra sunucunun(senin) ip girebilirsin "Serverip = [sunucuip]"
            };
            versiyon = comboBox1.SelectedItem.ToString();
            var process = launcher.CreateProcess(versiyon, launchOption);

            process.Start();
            Hide();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            path();//on saattir burayla u�ra�t�m bo� b�rak�nca combobox itemleri g�z�km�yordu null hatas� veriyordu internette ara�t�rd�m path yazmak gerekiyormu� �n y�kleme i�in
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Thread thread = new Thread(() => Launch());
            thread.IsBackground = true;
            thread.Start();//burada kontrol tamamen cmlib launch kullan�yor
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
//l�tfen st�dyo 2022 ile a��n�z (bu uyar� nekadar faydal� oldu adsfdsgfdhxgfhgj)