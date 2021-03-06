﻿using CadeOErro.Domain.Models;

namespace CadeOErro.Server.Util.Extensions
{
    public static class LogExtensions
    {
        public static Log FixFields(this Log log)
        {
            if (!string.IsNullOrEmpty(log.stackTrace))
            {
                log.stackTrace = log.stackTrace.Trim();
            }
            

            return log;
        }
    }
}
