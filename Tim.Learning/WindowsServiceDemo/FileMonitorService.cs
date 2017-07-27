using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceDemo
{
    public partial class FileMonitorService : ServiceBase
    {
        private System.Diagnostics.PerformanceCounter fileCreateCounter;  
 
        private System.Diagnostics.PerformanceCounter fileDeleteCounter;  
  
        private System.Diagnostics.PerformanceCounter fileRenameCounter;  
  
        private System.Diagnostics.PerformanceCounter fileChangeCounter;

        private bool servicePaused;

        public FileMonitorService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            #region 文件监视器
            FileSystemWatcher curWatcher = new FileSystemWatcher();


            curWatcher.BeginInit();

            curWatcher.IncludeSubdirectories = true;

            curWatcher.Path = System.Configuration.ConfigurationSettings.AppSettings["FileMonitorDirectory"];

            curWatcher.Changed += new FileSystemEventHandler(OnFileChanged);

            curWatcher.Created += new FileSystemEventHandler(OnFileCreated);

            curWatcher.Deleted += new FileSystemEventHandler(OnFileDeleted);

            curWatcher.Renamed += new RenamedEventHandler(OnFileRenamed);

            curWatcher.EnableRaisingEvents = true;

            curWatcher.EndInit();


            #endregion

        }


        private void OnFileChanged(Object source, FileSystemEventArgs e)
        {
            if (servicePaused == false)
            {

                fileChangeCounter.IncrementBy(1);

            }
        }

        private void OnFileRenamed(Object source, RenamedEventArgs e)

        {

            if (servicePaused == false)

            {

                fileRenameCounter.IncrementBy(1);

            }

        }

        private void OnFileCreated(Object source, FileSystemEventArgs e)

        {

            if (servicePaused == false)

            {

                fileCreateCounter.IncrementBy(1);

            }

        }

        private void OnFileDeleted(Object source, FileSystemEventArgs e)

        {

            if (servicePaused == false)

            {

                fileDeleteCounter.IncrementBy(1);

            }

        }


        protected override void OnStop()
        {
            #region 清零计数器
            if (fileChangeCounter.RawValue != 0)

            {

                fileChangeCounter.IncrementBy(-fileChangeCounter.RawValue);

            }

            if (fileDeleteCounter.RawValue != 0)

            {

                fileDeleteCounter.IncrementBy(-fileDeleteCounter.RawValue);

            }

            if (fileRenameCounter.RawValue != 0)

            {

                fileRenameCounter.IncrementBy(-fileRenameCounter.RawValue);

            }

            if (fileCreateCounter.RawValue != 0)

            {

                fileCreateCounter.IncrementBy(-fileCreateCounter.RawValue);

            }

            #endregion

        }


        protected override void OnPause()
        {
            servicePaused = true;
        }



        protected override void OnContinue()
        {
            servicePaused = false;
        }

    }
}
