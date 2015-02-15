using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Logger
    {
        private StreamWriter file;
        private String dateStarted;
        private String root = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                                    ".bookLibrary");
        private String logFolder; 
        private String instancePath;
        private bool wrote;

        public Logger()
        {
            wrote = false;
        }

        public void startService()
        {
            logFolder = Path.Combine(root, "logs");
            dateStarted = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
            instancePath = Path.Combine(logFolder, dateStarted + ".log");

            try
            {
                Directory.CreateDirectory(root);
                Directory.CreateDirectory(logFolder);

                if (File.Exists(Path.Combine(logFolder, dateStarted)) == false)
                    using (File.CreateText(instancePath)) { };

                file = new StreamWriter(instancePath);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void writeLine(String caller, String method, Exception exception)
        {
            String dateOfLog = DateTime.Now.ToString("HH-mm-ss.fff");
            file.WriteLine("[" + dateOfLog + " | " + caller + " | " + method + "]" + Environment.NewLine +exception.Message);
            wrote = true;
        }
        
        public void stopService()
        {
            if(file != null)
                file.Close();

            if(wrote == false && File.Exists(instancePath))
                File.Delete(instancePath);
        }
    }
}
