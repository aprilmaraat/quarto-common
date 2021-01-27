﻿using System.ComponentModel;

namespace Quarto.Common.Package
{
    /// <summary>
    /// Possible reponse messages
    /// </summary>
    public enum ResponseMessage
    {
        /// <summary>
        /// Response message for success
        /// </summary>
        [Description("Success")]
        Success,
        /// <summary>
        /// Response message for failure
        /// </summary>
        [Description("Exception")]
        Exception,
        /// <summary>
        /// Response message for other erros
        /// </summary>
        MiscError,
    }
}
