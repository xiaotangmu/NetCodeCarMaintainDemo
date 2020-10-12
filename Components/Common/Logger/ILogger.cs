﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logger.Log4Net;

namespace Common.Logger
{
    public interface ILogger
    {
        /// <summary>
        ///   Log debug message
        /// </summary>
        /// <param name="message"> The debug message </param>
        /// <param name="args"> the message argument values </param>
        void Debug(string message,LoggerType type = LoggerType.FileRollingLogger);

        /// <summary>
        ///   Log debug message
        /// </summary>
        /// <param name="message"> The message </param>
        /// <param name="exception"> Exception to write in debug message </param>
        /// <param name="args"></param>
        void Debug(string message, Exception exception, LoggerType type = LoggerType.FileRollingLogger);

        /// <summary>
        ///   Log debug message
        /// </summary>
        /// <param name="item"> The item with information to write in debug </param>
        void Debug(object item, LoggerType type = LoggerType.FileRollingLogger);

        /// <summary>
        ///   Log FATAL error
        /// </summary>
        /// <param name="message"> The message of fatal error </param>
        /// <param name="args"> The argument values of message </param>
        void Fatal(string message, LoggerType type = LoggerType.FileRollingLogger);

        /// <summary>
        ///   log FATAL error
        /// </summary>
        /// <param name="message"> The message of fatal error </param>
        /// <param name="exception"> The exception to write in this fatal message </param>
        void Fatal(string message, Exception exception, LoggerType type = LoggerType.FileRollingLogger);

        /// <summary>
        ///   Log message information
        /// </summary>
        /// <param name="message"> The information message to write </param>
        /// <param name="args"> The arguments values </param>
        void Info(string message, LoggerType type = LoggerType.FileRollingLogger);

        /// <summary>
        ///   Log warning message
        /// </summary>
        /// <param name="message"> The warning message to write </param>
        /// <param name="args"> The argument values </param>
        void Warning(string message, LoggerType type = LoggerType.FileRollingLogger);

        /// <summary>
        ///   Log error message
        /// </summary>
        /// <param name="message"> The error message to write </param>
        /// <param name="args"> The arguments values </param>
        void Error(string message, LoggerType type = LoggerType.FileRollingLogger);

        /// <summary>
        ///   Log error message
        /// </summary>
        /// <param name="message"> The error message to write </param>
        /// <param name="exception"> The exception associated with this error </param>
        /// <param name="args"> The arguments values </param>
        void Error(string message, Exception exception, LoggerType type = LoggerType.FileRollingLogger);
    }
}
