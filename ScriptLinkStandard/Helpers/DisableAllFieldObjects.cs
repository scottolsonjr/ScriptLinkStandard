﻿using ScriptLinkStandard.Interfaces;

namespace ScriptLinkStandard.Helpers
{
    public partial class ScriptLinkHelpers
    {
        public static IOptionObject DisableAllFieldObjects(IOptionObject optionObject)
        {
            return DisableAllFieldObjects(optionObject.ToOptionObject2()).ToOptionObject();
        }

        public static IOptionObject2 DisableAllFieldObjects(IOptionObject2 optionObject)
        {
            if (optionObject == null || optionObject.Forms.Count == 0)
                return optionObject;
            for (int i = 0; i < optionObject.Forms.Count; i++)
            {
                if (optionObject.Forms[i].CurrentRow != null)
                {
                    for (int j = 0; j < optionObject.Forms[i].CurrentRow.Fields.Count; j++)
                    {
                        optionObject.Forms[i].CurrentRow.Fields[j].SetAsDisabled();
                    }
                    optionObject.Forms[i].CurrentRow.RowAction = "EDIT";
                }
                for (int k = 0; k < optionObject.Forms[i].OtherRows.Count; k++)
                {
                    for (int l = 0; l < optionObject.Forms[i].OtherRows[k].Fields.Count; l++)
                    {
                        optionObject.Forms[i].OtherRows[k].Fields[l].SetAsDisabled();
                    }
                    optionObject.Forms[i].OtherRows[k].RowAction = "EDIT";
                }
            }
            return optionObject;
        }
    }
}