﻿using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cofoundry.Web
{
    /// <summary>
    /// Represents a task that runs in the Cofoundry startup and 
    /// initialization pipeline.
    /// </summary>
    public interface IStartupTask
    {
        /// <summary>
        /// An integer representing the ordering (lower values first). Can use custom 
        /// values but using the enum StartupTaskOrdering is recommended.
        /// </summary>
        int Ordering { get; }

        /// <summary>
        /// Executes the startup task
        /// </summary>
        void Run(IAppBuilder app);
    }
}