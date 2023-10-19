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
            Stopwatch stopwatch = new Stopwatch();
            this.Hide();

            while (true)
            {

                Process[] processes = Process.GetProcessesByName(processName);
                if (processes.Length > 0)
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