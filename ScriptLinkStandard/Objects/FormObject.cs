﻿using ScriptLinkStandard.Helpers;
using ScriptLinkStandard.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptLinkStandard.Objects
{
    /// <summary>
    /// Represents a ScriptLink FormObject within an <see cref="OptionObject"/>.
    /// </summary>
    public class FormObject : IEquatable<FormObject>, IFormObject
    {
        //
        // Public Properties (DO NOT MODIFY)
        //

        /// <summary>
        /// Gets or sets the CurrentRow property of the <see cref="FormObject"/>.
        /// </summary>
        /// <value>The value is a <see cref="RowObject"/> containing the current row.</value>
        public RowObject CurrentRow { get; set; }
        /// <summary>
        /// Gets or sets the FormId propery of the <see cref="FormObject"/>.
        /// </summary>
        /// <value>The value is a <see cref="string"/>.</value>
        public string FormId { get; set; }
        /// <summary>
        /// Gets or sets the MultipleIteration property of the <see cref="FormObject"/>.
        /// </summary>
        /// <value>The value is a <see cref="bool"/> indicating whether the Option includes a multiple iteration table.</value>
        public bool MultipleIteration { get; set; }
        /// <summary>
        /// Gets or sets the OtherRows property of the <see cref="FormObject"/>.
        /// </summary>
        /// <value>The value is a <see cref="List{T}"/> of <see cref="RowObject"/> containing all of the rows of a multiple iteration table.</value>
        public List<RowObject> OtherRows { get; set; }

        //
        // Begin Customizations (only methods and private properties)
        //

        //
        // Constructor
        //

        /// <summary>
        /// Creates a new ScriptLink <see cref="FormObject"/>.
        /// </summary>
        public FormObject()
        {
            this.OtherRows = new List<RowObject>();
        }

        //
        // Private Properties
        //

        //
        // IEquatable<FormObject> Methods
        //

        /// <summary>
        /// Used to compare two <see cref="FormObject"/> and determine if they are equal. Returns <see cref="bool"/>.
        /// </summary>
        /// <param name="other">The <see cref="CustomFormObject"/> to compare.</param>
        /// <returns>Returns a <see cref="bool"/> indicating whether the two <see cref="FormObject"/> are equal.</returns>
        public bool Equals(FormObject other)
        {
            if (other == null)
                return false;
            return this.FormId == other.FormId &&
                   this.MultipleIteration == other.MultipleIteration &&
                   ((this.CurrentRow == null && other.CurrentRow == null) ||
                   this.CurrentRow.Equals(other.CurrentRow)) &&
                   AreRowsEqual(this.OtherRows, other.OtherRows);
        }
        private bool AreRowsEqual(List<RowObject> list1, List<RowObject> list2)
        {
            if (!AreBothNull(list1, list2) && AreBothEmpty(list1, list2))
                return true;
            if (list1.Count != list2.Count)
                return false;
            for (int i = 0; i < list1.Count; i++)
            {
                if (!list1[i].Equals(list2[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private bool AreBothEmpty(List<RowObject> list1, List<RowObject> list2)
        {
            return (!list1.Any() && !list2.Any());
        }

        private bool AreBothNull(List<RowObject> list1, List<RowObject> list2)
        {
            return (list1 == null && list2 == null);
        }

        /// <summary>
        /// Used to compare <see cref="FormObject"/> to an <see cref="object"/> to determine if they are equal. Returns <see cref="bool"/>.
        /// </summary>
        /// <param name="other">The <see cref="object"/> to compare.</param>
        /// <returns>Returns a <see cref="bool"/> indicating whether <see cref="FormObject"/> is equal to an <see cref="object"/>.</returns>
        public override bool Equals(object obj)
        {
            FormObject formObject = obj as FormObject;
            if (formObject == null)
                return false;
            return this.Equals(formObject);
        }

        /// <summary>
        /// Overrides the <see cref="GetHashCode"/> method for a <see cref="FormObject"/>.
        /// </summary>
        /// <returns>Returns an <see cref="int"/> representing the unique hash code for the <see cref="FormObject"/>.</returns>
        public override int GetHashCode()
        {
            string delimiter = "||";
            string hash = this.FormId
                + delimiter + this.MultipleIteration.ToString()
                + delimiter + this.CurrentRow.GetHashCode().ToString();
            foreach (RowObject rowObject in this.OtherRows)
            {
                hash += delimiter + rowObject.GetHashCode();
            }
            return hash.GetHashCode();
        }

        public static bool operator ==(FormObject formObject1, FormObject formObject2)
        {
            if (((object)formObject1) == null || ((object)formObject2) == null)
                return Object.Equals(formObject1, formObject2);

            return formObject1.Equals(formObject2);
        }

        public static bool operator !=(FormObject formObject1, FormObject formObject2)
        {
            if (((object)formObject1) == null || ((object)formObject2) == null)
                return !Object.Equals(formObject1, formObject2);

            return !(formObject1.Equals(formObject2));
        }

        //
        // IFormObject Methods
        //

        /// <summary>
        /// Returns the RowId of the <see cref="CurrentRow"/>.
        /// </summary>
        /// <returns></returns>
        public string GetCurrentRowId()
        {
            return ScriptLinkHelpers.GetCurrentRowId(this);
        }
        /// <summary>
        /// Returns the value of the <see cref="FieldObject"/> in the CurrentRow of the <see cref="FormObject"/> by FieldNumber.
        /// </summary>
        /// <param name="fieldNumber"></param>
        /// <returns></returns>
        public string GetFieldValue(string fieldNumber)
        {
            return ScriptLinkHelpers.GetFieldValue(this, fieldNumber);
        }
        /// <summary>
        /// Returns the value of the <see cref="FieldObject"/> in the <see cref="RowObject"/> of the <see cref="FormObject"/> by RowId and FieldNumber.
        /// </summary>
        /// <param name="rowId"></param>
        /// <param name="fieldNumber"></param>
        /// <returns></returns>
        public string GetFieldValue(string rowId, string fieldNumber)
        {
            return ScriptLinkHelpers.GetFieldValue(this, rowId, fieldNumber);
        }
        /// <summary>
        /// Returns a <see cref="List{T}"/> of FieldValues in a <see cref="FormObject"/>.
        /// </summary>
        /// <param name="fieldNumber"></param>
        /// <returns></returns>
        public List<string> GetFieldValues(string fieldNumber)
        {
            return ScriptLinkHelpers.GetFieldValues(this, fieldNumber);
        }
        /// <summary>
        /// Returns the ParentRowId of the <see cref="CurrentRow"/>.
        /// </summary>
        /// <returns></returns>
        public string GetParentRowId()
        {
            return ScriptLinkHelpers.GetParentRowId(this);
        }
        /// <summary>
        /// Determines whether the <see cref="FieldObject"/> is enabled in the <see cref="FormObject"/> by FieldNumber.
        /// </summary>
        /// <param name="fieldNumber"></param>
        /// <returns></returns>
        public bool IsFieldEnabled(string fieldNumber)
        {
            return ScriptLinkHelpers.IsFieldEnabled(this, fieldNumber);
        }
        /// <summary>
        /// Determines whether the <see cref="FieldObject"/> is locked in the <see cref="FormObject"/> by FieldNumber.
        /// </summary>
        /// <param name="fieldNumber"></param>
        /// <returns></returns>
        public bool IsFieldLocked(string fieldNumber)
        {
            return ScriptLinkHelpers.IsFieldLocked(this, fieldNumber);
        }
        /// <summary>
        /// Determines whether the <see cref="FieldObject"/> is present in the <see cref="FormObject"/> by FieldNumber.
        /// </summary>
        /// <param name="fieldNumber"></param>
        /// <returns></returns>
        public bool IsFieldPresent(string fieldNumber)
        {
            return ScriptLinkHelpers.IsFieldPresent(this, fieldNumber);
        }
        /// <summary>
        /// Determines whether the <see cref="FieldObject"/> is required in the <see cref="FormObject"/> by FieldNumber.
        /// </summary>
        /// <param name="fieldNumber"></param>
        /// <returns></returns>
        public bool IsFieldRequired(string fieldNumber)
        {
            return ScriptLinkHelpers.IsFieldRequired(this, fieldNumber);
        }
        /// <summary>
        /// Sets the value of a <see cref="FieldObject"/> in a <see cref="FormObject"/>.
        /// </summary>
        /// <param name="rowId"></param>
        /// <param name="fieldNumber"></param>
        /// <param name="fieldValue"></param>
        /// <returns></returns>
        public void SetFieldValue(string rowId, string fieldNumber, string fieldValue)
        {
            FormObject tempFormObject = ScriptLinkHelpers.SetFieldValue(this, rowId, fieldNumber, fieldValue);
            this.CurrentRow = tempFormObject.CurrentRow;
            this.OtherRows = tempFormObject.OtherRows;
        }
        /// <summary>
        /// Returns a <see cref="string"/> with all of the contents of the <see cref="FormObject"/> formatted in HTML.
        /// </summary>
        /// <param name="includeHtmlHeaders">Determines whether to include the HTML headers in return. False allows for the embedding of the HTML in another HTML document.</param>
        /// <returns><see cref="string"/> of all of the contents of the <see cref="FormObject"/> formatted in HTML.</returns>
        public string ToHtmlString(bool includeHtmlHeaders)
        {
            return ScriptLinkHelpers.TransformToHtmlString(this, includeHtmlHeaders);
        }
    }
}