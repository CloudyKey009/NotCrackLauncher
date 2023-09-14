using CmlLib.Core;
using CmlLib.Core.Auth;
using System;//stüdyo using gerekmiyor diyor ama using(sistemi) kullanmazsak hataya sebep oluyor

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
            //var cmllibte bir class oyüzden pek kafaya takmayýn(karýþmasýn diye)
            foreach (var item in launcher.GetAllVersions())
            {
                comboBox1.Items.Add(item.Name);//yukarýda satýrda tüm versiyonlarý microsoft sunucularýndan alýyor ve comboboxa ekliyor(alpha beta ve rd dahil)
            }

        }

        private void Launch()
        {
            var path = new MinecraftPath();
            var launcher = new CMLauncher(path);//burada cml baþlatýcýsýný kullanýyor
            var launchOption = new MLaunchOption
            { //bu rami ayarlar
                MaximumRamMb = 2048,
                Session = MSession.GetOfflineSession(textBox1.Text),
                //tam bu satýra sunucunun(senin) ip girebilirsin "Serverip = [sunucuip]"
            };
            versiyon = comboBox1.SelectedItem.ToString();
            var process = launcher.CreateProcess(versiyon, launchOption);

            process.Start();
            Hide();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            path();//on saattir burayla uðraþtým boþ býrakýnca combobox itemleri gözükmüyordu null hatasý veriyordu internette araþtýrdým path yazmak gerekiyormuþ ön yükleme için
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Thread thread = new Thread(() => Launch());
            thread.IsBackground = true;
            thread.Start();//burada kontrol tamamen cmlib launch kullanýyor
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
//lütfen stüdyo 2022 ile açýnýz (bu uyarý nekadar faydalý oldu adsfdsgfdhxgfhgj)