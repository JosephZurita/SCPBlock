using Exiled.API.Interfaces;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SCPBlock
{

    public sealed class Config : IConfig
    {

        private static List<RoleTypeId> defBlocked = new() { RoleTypeId.Scp079 };

        /// <inheritdoc/>
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;
        
        /// <inheritdoc/>
        [Description("Should debug messages be displayed?")]
        public bool Debug { get; set; }

        /// <summary>
        /// List of SCPs which should be respawned as another as defined in swapList
        /// </summary>
        [Description("List of blocked SCPs")]
        public List<RoleTypeId> blockList { get; private set; } = new(defBlocked);

        /// <summary>
        /// List of SCPs which to be respawned as a replacement
        /// </summary>
        [Description("List of SCPs to swap to")]
        public List<RoleTypeId> swapList { get; private set; } = new(Enum.GetValues(typeof(RoleTypeId)).Cast<RoleTypeId>().Where(rt => rt.GetTeam() == Team.SCPs && !defBlocked.Contains(rt)));

    }
}