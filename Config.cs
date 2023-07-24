using Exiled.API.Features.Roles;
using Exiled.API.Interfaces;
using PlayerRoles;
using PluginAPI.Roles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SCPBlock
{

    /// <inheritdoc cref="IConfig"/>
    public sealed class Config : IConfig
    {

        private static List<RoleTypeId> defBlocked = new() { RoleTypeId.Scp079 };

        /// <inheritdoc/>
        public bool IsEnabled { get; set; } = true;

        /// <inheritdoc />
        public bool Debug { get; set; }

        /// <summary>
        /// Gets the list of ints config.
        /// </summary>
        [Description("List of blocked SCPs")]
        public List<RoleTypeId> blockList { get; private set; } = new(defBlocked);

        /// <summary>
        /// Gets the list of ints config.
        /// </summary>
        [Description("List of blocked SCPs")]
        public List<RoleTypeId> swapList { get; private set; } = new(Enum.GetValues(typeof(RoleTypeId)).Cast<RoleTypeId>().Where(rt => rt.GetTeam() == Team.SCPs && !defBlocked.Contains(rt)));

    }
}