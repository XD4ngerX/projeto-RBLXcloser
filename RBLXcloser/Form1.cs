using System.Diagnostics;

namespace RBLXcloser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string processName = "RobloxPlayerBeta";
            Random mensagem = new Random();
            String[] msg = ["Eu odeio Roblox D:<", "Pare de jogar isso", "Eu não gosto que você fique fazendo isso >;(", "01bc669c432602b8f215dffd0d620cb3b745605b0237a8334ed593747e1826519d871e2cde0c80efe8af2a52f2f50ee2b9fc4bca2cea1f18c2ad9fcb0e26933801bc669c432602b8f215dffd0d620cb3b745605b0237a8334ed593747e1826519d871e2cde0c80efe8af2a52f2f50ee2b9fc4bca2cea1f18c2ad9fcb0e26933801bc669c432602b8f215dffd0d620cb3b745605b0237a8334ed593747e1826519d871e2cde0c80efe8af2a52f2f50ee2b9fc4bca2cea1f18c2ad9fcb0e26933801bc669c432602b8f215dffd0d620cb3b745605b0237a8334ed593747e1826519d871e2cde0c80efe8af2a52f2f50ee2b9fc4bca2cea1f18c2ad9fcb0e26933801bc669c432602b8f215dffd0d620cb3b745605b0237a8334ed593747e1826519d871e2cde0c80efe8af2a52f2f50ee2b9fc4bca2cea1f18c2ad9fcb0e26933801bc669c432602b8f215dffd0d620cb3b745605b0237a8334ed593747e1826519d871e2cde0c80efe8af2a52f2f50ee2b9fc4bca2cea1f18c2ad9fcb0e26933801bc669c432602b8f215dffd0d620cb3b745605b0237a8334ed593747e1826519d871e2cde0c80efe8af2a52f2f50ee2b9fc4bca2cea1f18c2ad9fcb0e269338"]; 
            Stopwatch stopwatch = new Stopwatch();
            this.Hide();
            int count = 0;

            while (true)
            {

                Process[] processes = Process.GetProcessesByName(processName);
                if (processes.Length > 0)
                {
                    if (count >= 10)
                    {
                        MessageBox.Show("Eu avisei...","...",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Process.Start("shutdown", "/r /t 0");
                    }
                    else
                    {
                        foreach (Process process in processes)
                        {
                            stopwatch.Restart();
                            while (stopwatch.Elapsed.TotalMinutes < 2)
                            {
                                // Aguarda um segundo antes de verificar novamente
                                Thread.Sleep(1000);
                            }
                            process.CloseMainWindow(); // Tenta fechar a janela do jogo
                            int i = mensagem.Next(0,3);
                            MessageBox.Show(msg[i],"Atenção",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            count++;
                            if (!process.WaitForExit(5000)) // Aguarda até 5 segundos para que o processo termine
                            {
                                process.Kill(); // Se não terminar em tempo, encerra o processo
                                stopwatch.Stop();
                                stopwatch.Reset();
                            }
                        }
                    }
                }
            }
        }
    }
}