﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptLinkStandard.Helpers;
using ScriptLinkStandard.Objects;

namespace ScriptLinkStandard.Tests.HelpersTests
{
    [TestClass]
    public class TransformToRowObjectTests
    {
        [TestMethod]
        [TestCategory("RowObject")]
        [ExpectedException(typeof(ArgumentException))]
        public void RowObjectFromJson_NullString()
        {
            string json = null;
            RowObject expected = new RowObject();
            Assert.AreEqual(expected, ScriptLinkHelpers.TransformToFieldObject(json));
        }

        [TestMethod]
        [TestCategory("RowObject")]
        public void RowObjectFromJson_Success()
        {
            string json = "{\"Fields\":[],\"ParentRowId\":null,\"RowAction\":null,\"RowId\":\"1||1\"}";
            RowObject expected = new RowObject
            {
                RowId = "1||1"
            };
            RowObject actual = (RowObject)ScriptLinkHelpers.TransformToRowObject(json);
            Assert.IsNotNull(actual.RowId);
            Assert.AreEqual(expected.RowId, actual.RowId);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("RowObject")]
        public void RowObjectFromJson_Failure()
        {
            string json = "{\"Fields\":[],\"ParentRowId\":null,\"RowAction\":null,\"RowId\":\"1||2\"}";
            RowObject expected = new RowObject
            {
                RowId = "1||1"
            };
            RowObject actual = (RowObject)ScriptLinkHelpers.TransformToRowObject(json);
            Assert.IsNotNull(actual.RowId);
            Assert.AreNotEqual(expected.RowId, actual.RowId);
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("RowObject")]
        public void RowObjectFromXml_Success()
        {
            string xml = "<?xml version=\"1.0\" encoding=\"utf-16\"?>" + Environment.NewLine
                       + "<RowObject xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">" + Environment.NewLine
                       + "  <RowId>1||1</RowId>" + Environment.NewLine
                       + "  <Fields />" + Environment.NewLine
                       + "</RowObject>";
            RowObject expected = new RowObject
            {
                RowId = "1||1"
            };
            RowObject actual = (RowObject)ScriptLinkHelpers.TransformToRowObject(xml);
            Assert.IsNotNull(actual.RowId);
            Assert.AreEqual(expected.RowId, actual.RowId);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("RowObject")]
        public void RowObjectFromXml_Failure()
        {
            string xml = "<?xml version=\"1.0\" encoding=\"utf-16\"?>" + Environment.NewLine
                       + "<RowObject xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">" + Environment.NewLine
                       + "  <RowId>1||2</RowId>" + Environment.NewLine
                       + "  <Fields />" + Environment.NewLine
                       + "</RowObject>";
            RowObject expected = new RowObject
            {
                RowId = "1||1"
            };
            RowObject actual = (RowObject)ScriptLinkHelpers.TransformToRowObject(xml);
            Assert.IsNotNull(actual.RowId);
            Assert.AreNotEqual(expected.RowId, actual.RowId);
            Assert.AreNotEqual(expected, actual);
        }
    }
}