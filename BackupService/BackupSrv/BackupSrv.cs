using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using BackupSrv.BL;

namespace BackupSrv
{
    public partial class BackupSrv : ServiceBase
    {
        public BackupSrv()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Logic.Start();
        }

        internal void TestStartupAndStop(string[] args)
        {
            this.OnStart(args);
        }

        protected override void OnStop()
        {
        }
    }
}
