﻿/*
 *  Dover Framework - OpenSource Development framework for SAP Business One
 *  Copyright (C) 2014  Eduardo Piva
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *  
 *  Contact me at <efpiva@gmail.com>
 * 
 */
using System.Xml.Serialization;
using SAPbobsCOM;
using System;
using Dover.Framework.Monad;

namespace Dover.Framework.Model.SAP
{

    // 
    // This source code was auto-generated by xsd, Version=2.0.50727.42.
    // 


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(ElementName="BOM", Namespace = "", IsNullable = false)]
    public partial class UserTableBOM : IBOM
    {

        private IBO[] boField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BO", Type=typeof(UserTableBOMBO))]
        public IBO[] BO
        {
            get
            {
                return this.boField;
            }
            set
            {
                this.boField = value;
            }
        }

    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class UserTableBOMBO : IBO, IComparable<UserTableBOMBO>
    {

        private BOMBOAdmInfo admInfoField;

        private BOMBOQueryParams queryParamsField;

        private UserTable[] userTablesMDField;

        internal override string[] GetKey()
        {
            return new string[] { "TableName" };
        }

        internal override BoObjectTypes GetBOType()
        {
            return BoObjectTypes.oUserTables;
        }

        internal override Type GetBOClassType()
        {
            return typeof(IUserTablesMD);
        }

        internal override string GetName()
        {
            return Messages.UDT;
        }

        internal override string GetFormattedKey()
        {
            return "[" + UserTablesMD
                .With(x => x[0])
                .Return(x => x.TableName, string.Empty) + "]";
        }

        internal override string GetFormattedDescription()
        {
            return UserTablesMD
                .With(x => x[0])
                .Return(x => x.TableDescription, string.Empty);
        }

        /// <remarks/>
        public BOMBOAdmInfo AdmInfo
        {
            get
            {
                return this.admInfoField;
            }
            set
            {
                this.admInfoField = value;
            }
        }

        /// <remarks/>
        public BOMBOQueryParams QueryParams
        {
            get
            {
                return this.queryParamsField;
            }
            set
            {
                this.queryParamsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("row", IsNullable = false)]
        public UserTable[] UserTablesMD
        {
            get
            {
                return this.userTablesMDField;
            }
            set
            {
                this.userTablesMDField = value;
            }
        }

        public int CompareTo(UserTableBOMBO other)
        {
            if (userTablesMDField != null && userTablesMDField.Length == 1 &&
                other.userTablesMDField != null && other.userTablesMDField.Length == 1)
                return this.userTablesMDField[0].TableName.CompareTo(other.UserTablesMD[0].TableName);
            return -1;
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class UserTable
    {

        private string tableNameField;

        private string tableDescriptionField;

        private BoUTBTableType tableTypeField;

        private string archivableField;

        private string archiveDateFieldField;

        /// <remarks/>
        public string TableName
        {
            get
            {
                return this.tableNameField;
            }
            set
            {
                this.tableNameField = value;
            }
        }

        /// <remarks/>
        public string TableDescription
        {
            get
            {
                return this.tableDescriptionField;
            }
            set
            {
                this.tableDescriptionField = value;
            }
        }

        /// <remarks/>
        public BoUTBTableType TableType
        {
            get
            {
                return this.tableTypeField;
            }
            set
            {
                this.tableTypeField = value;
            }
        }

        /// <remarks/>
        public string Archivable
        {
            get
            {
                return this.archivableField;
            }
            set
            {
                this.archivableField = value;
            }
        }

        /// <remarks/>
        public string ArchiveDateField
        {
            get
            {
                return this.archiveDateFieldField;
            }
            set
            {
                this.archiveDateFieldField = value;
            }
        }
    }
}