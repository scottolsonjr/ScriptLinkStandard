﻿namespace ScriptLinkStandard.Helpers
{
    public partial class ScriptLinkHelpers
    {
        /// <summary>
        /// Safely converts a string to an integer.
        /// </summary>
        /// <param name="fieldValue"></param>
        /// <returns></returns>
        public static int SafeGetInt(string fieldValue)
        {
            int integerTest, tempValue = 0;
            if (int.TryParse(fieldValue, out integerTest))
            {
                tempValue = int.Parse(fieldValue);
            }
            return tempValue;
        }
    }
}