namespace WindowsServiceDemo
{
    partial class FileMonitorService
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            #region 初始化PerformanceCounter

            this.fileChangeCounter = new System.Diagnostics.PerformanceCounter();

            this.fileDeleteCounter = new System.Diagnostics.PerformanceCounter();

            this.fileRenameCounter = new System.Diagnostics.PerformanceCounter();

            this.fileCreateCounter = new System.Diagnostics.PerformanceCounter();


            fileChangeCounter.CategoryName = "File Monitor Service";

            fileDeleteCounter.CategoryName = "File Monitor Service";

            fileRenameCounter.CategoryName = "File Monitor Service";

            fileCreateCounter.CategoryName = "File Monitor Service";


            fileChangeCounter.CounterName = "Files Changed";

            fileDeleteCounter.CounterName = "Files Deleted";

            fileRenameCounter.CounterName = "Files Renamed";

            fileCreateCounter.CounterName = "Files Created";

            this.ServiceName = "FileMonitorService";

            this.CanPauseAndContinue = true;

            this.CanStop = true;

            servicePaused = false;


            #endregion

        }

        #endregion
    }
}
