using System;
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
        public StartupKind Type { get; set; }
        public string LaunchCommand { get; set; }

        public StartupObject(string name, string fpath, StartupKind skind,
            string lcommand = "", bool isCritical = false, bool isDisabled = false)
        {
            this.Name = name;
            this.FilePath = fpath;
            this.Type = skind;
            this.LaunchCommand = lcommand;
            this.IsCriticalApp = isCritical;
            this.IsDisabled = isDisabled;
            

        }

    }
    enum StartupKind { AllUsersPath, UserStartupPath, HKLMKey, HKCUKey }
}
