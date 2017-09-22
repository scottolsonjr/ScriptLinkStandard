﻿namespace ScriptLinkStandard.Helpers
{
    public partial class ScriptLinkHelpers
    {
        /// <summary>
        /// Returns whether a given ErrorCode is valid
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public static bool IsValidErrorCode(string errorCode)
        {
            int convertedErrorCode;
            if (int.TryParse(errorCode, out convertedErrorCode))
            {
                return IsValidErrorCode(convertedErrorCode);
            }
            return false;
        }
        /// <summary>
        /// Returns whether a given ErrorCode is valid
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public static bool IsValidErrorCode(int errorCode)
        {
            if (errorCode >= 0 && errorCode <= 5)
            {
                return true;
            }
            return false;
        }
    }
}