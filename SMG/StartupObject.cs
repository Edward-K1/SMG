﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMG
{
    class StartupObject
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public bool IsCriticalApp { get; set; } = false;
        public bool IsDisabled { get; set; } = false;
        public StartupKind kind { get; set; }
        public string LaunchCommand { get; set; }

        public StartupObject(string name, string fpath, bool isCritical, bool isDisabled, StartupKind skind, string lcmd = "")
        {
            this.Name = name;
            this.FilePath = fpath;
            this.IsCriticalApp = isCritical;
            this.IsDisabled = isDisabled;
            this.kind = skind;
            this.LaunchCommand = lcmd;
        }



    }
    enum StartupKind { AllUsersPath, DefaultStartupPath, HKLMKey, HKCUKey }
}