using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Interfaces;
using Exiled.API.Enums;

namespace Custom_Door_Lockdown
{
    public sealed class Config : IConfig
    {
        [Description("Does nothing")]
        public bool Debug { get; set; } = false;
        public bool IsEnabled { get; set; } = true;

        [Description("Doors that will be locked and opened on events")]

        public List<DoorType> DoorTypes { get; set; } = new List<DoorType>();

        [Description("if true, all doors will unlock on Warhead Start")]
        public bool UnlockOnWarheadStart { get; set; } = true;

        [Description("if true, all doors will unlock when all generators are activated")]
        public bool UnlockOnAllGenerators { get; set; } = true;

    }
}
