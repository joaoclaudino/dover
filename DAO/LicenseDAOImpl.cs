﻿/*
 *  Dover Framework - OpenSource Development framework for SAP Business One
 *  Copyright (C) 2015  Eduardo Piva
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;

namespace Dover.Framework.DAO
{
    internal class LicenseDAOImpl : LicenseDAO
    {
        private BusinessOneDAO b1DAO;

        public LicenseDAOImpl(BusinessOneDAO b1DAO)
        {
            this.b1DAO = b1DAO;
        }

        public void SaveLicense(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
            {
                throw new ArgumentNullException();
            }

            byte[] xmlBytes = convertToByteArray(xml);
            SoapHexBinary shb = new SoapHexBinary(Compression.Compress(xmlBytes));
            string xmlHex = null;
            xmlHex = shb.ToString();

            b1DAO.ExecuteStatement(this.GetSQL("DeleteLicense.sql"));

            InsertAsmBin(xmlHex);
        }
        
        public string GetLicense()
        {
            List<String> hexFile = b1DAO.ExecuteSqlForList<String>(this.GetSQL("GetLicense.sql"));
            if (hexFile.Count == 0)
                return null;
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (var hex in hexFile)
                {
                    sb.Append(hex);
                }
                SoapHexBinary shb = SoapHexBinary.Parse(sb.ToString());
                byte[] buffer = Compression.Uncompress(shb.Value);
                return convertoToString(buffer);
            }
            catch (ZipException)
            {
                return null;
            }
        }


        public DateTime GetDate()
        {
            return b1DAO.ExecuteSqlForObject<DateTime>(this.GetSQL("GetDate.sql"));
        }

        private void InsertAsmBin(string xmlHex)
        {
            string sql;
            int maxtext = 256000;
            int insertedText = 0;

            string insertSQL = this.GetSQL("InsertLicense.sql");

            for (int i = 0; i < xmlHex.Length / maxtext; i++)
            {
                string code = b1DAO.GetNextCode("DOVER_LICENSE_BIN");
                sql = String.Format(insertSQL,
                    code, code, xmlHex.Substring(i * maxtext, maxtext));
                b1DAO.ExecuteStatement(sql);
                insertedText += maxtext;
            }

            if (insertedText < xmlHex.Length)
            {
                string code = b1DAO.GetNextCode("DOVER_LICENSE_BIN");
                sql = String.Format(insertSQL,
                    code, code, xmlHex.Substring(insertedText));
                b1DAO.ExecuteStatement(sql);
            }
        }

        private byte[] convertToByteArray(string xml)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            using (StreamWriter writer = new StreamWriter(memoryStream))
            {
                writer.Write(xml);
                writer.Flush();
                return memoryStream.ToArray();
            }
        }

        private string convertoToString(byte[] input)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                memoryStream.Write(input, 0, input.Length);
                memoryStream.Seek(0, SeekOrigin.Begin);
                using (StreamReader reader = new StreamReader(memoryStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
