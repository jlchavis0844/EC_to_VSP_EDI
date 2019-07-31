﻿using System;
using System.Text;
using System.Text.RegularExpressions;

namespace EC_to_VSP_EDI {

    public class EnrollmentEntry {
        public const char SegmentTerminator = '~';

        //INS
        public const string SegmentID_INS = "INS";
        public char         SubscriberIndicator_INS01;
        public string       IndividualRelationshipCode_INS02;
        public const string MaintenanceTypeCode_INS03 = "030";
        public       string MaintenanceReasonCode_INS04;
        public char         BenefitStatusCode_INS05;
        //public       char   HandicapIndicator_INS06;

        //REF
        public const string SegmentID_REF = "REF";
        public const string ReferenceNumberQualifier_REF01 = "0F"; //SSN
        public string       ReferenceNumber_REF02;
        public string       ReferenceNumberQualifier2_REF01;
        public string       ReferenceNumber2_REF02;
        public string ReferenceNumberQualifier3_REF01;
        public string ReferenceNumber3_REF02;
        public const string ReferenceNumberQualifierVSP_REF01 = "DX"; //VSP division
        public string ReferenceNumberVSP_REF02;

        //NM1
        public const string SegmentID_NM1 = "NM1";
        public const string EntityIdentifierCode_NM101 = "IL";
        public const char EntityTypeQualifier_NM102 = '1';
        public string NameLast_NM103;
        public string NameFirst_NM104;
        public char NameInitial_NM105;
        public const string IdentificationCodeQualifier_NM108 = "34";
        public string IdentificationCode_NM109;//SSN

        //PER
        public const string SegmentID_PER = "PER";
        public const string ContactFunctionCode_PER01 = "IP";
        public const string ContactName_PER02 = "";
        public string CommunicationNumberQualifier_PER03;
        public string CommunicationNumber_PER04;
        public const string CommunicationNumberQualifier_PER05 = "EM";
        public string CommunicationNumber_PER06;
        //public const string CommunicationNumberQualifier_PER06 = "EM";
        //public string CommunicationNumber_PER08;

        //N3
        public const string SegmentID_N3 = "N3";
        public string ResidenceAddressLine1_N301;
        public string ResidenceAddressLine2_N302;

        //N4
        public const string SegmentID_N4 = "N4";
        public string ResidenceCity_N401;
        public string ResidenceState_N402;
        public string ResidenceZip_N403;
        //public string      CountryCode_N404;

        //DMG
        public const string SegmentID_DMG = "DMG";
        public const string DateTimeFormatQualifier_DMG01 = "D8";
        public string DatetimePeriod_DMG02;
        public char GenderCode_DMG03;
        public char MaritalStatusCode_DMG04;
        public char RaceCode_DMG05;
        public char CitizenshipStatusCode__DMG06;

        //HD
        public const string SegmentID_HD = "HD";
        public const string MaintenanceTypeCode_HD01 = "030";
        public const string Blank_HD02 = "";
        public const string InsuranceLineCode_HD03 = "VIS";
        public const string Blank_HD04 = "";
        public string CoverageLevelCode_HD05;

        //DTP
        public const string SegmentID_DTP = "DTP";
        public const string BenefitStartDate_DTP01 = "348";
        public const string BenefitEndDate_DTP01 = "349";
        public const string CoverageLevelChange_DTP01 = "303";
        public const string DateTimeFormat_DTP02 = "D8";
        public string DateTimePeriod_Start_DTP03;
        public string DateTimePeriod_End_DTP03;
        
        //Constructor
        public EnrollmentEntry(CensusRow row) {
            if (row.RelationshipCode == "0") {
                SubscriberIndicator_INS01 = 'Y';
            } else {
                SubscriberIndicator_INS01 = 'N';
            }
            
            IndividualRelationshipCode_INS02 = RelationshipTranslation(row.RelationshipCode);
            BenefitStatusCode_INS05 = 'A';

            if (row.SSN != null && row.SSN != "") {
                ReferenceNumber_REF02 = row.SSN.Replace("-", "");
            } else {
                
                Form1.log.Error("ERR: " + (++Form1.errorCounter) + "\tMissing SSN for the following:\n" + row.ToString());
            }
            ReferenceNumberVSP_REF02 = row.Division;
            NameLast_NM103 = row.LastName;
            NameFirst_NM104 = row.FirstName;
            if(row.MiddleName.Length > 0)
                NameInitial_NM105 = row.MiddleName[0];
            IdentificationCode_NM109 = row.SSN.Replace("-","");
            CommunicationNumberQualifier_PER03 = "HP";

            if(row.PersonalPhone != null && row.PersonalPhone != "")
                CommunicationNumber_PER04 = Regex.Replace(row.PersonalPhone, "[^0-9]", "");

            CommunicationNumber_PER06 = row.Email;
            ResidenceAddressLine1_N301 = row.Address1;
            ResidenceAddressLine2_N302 = row.Address2;
            ResidenceCity_N401 = row.City;
            ResidenceState_N402 = "CA";
            ResidenceZip_N403 = row.Zip;

            if (row.BirthDate != null && row.BirthDate != "") {
                DatetimePeriod_DMG02 = DateTime.Parse(row.BirthDate).ToString("yyyyMMdd");
            }

            if (row.Gender == "Male") {
                GenderCode_DMG03 = GenderCodes.Male;
            } else if (row.Gender == "Female") {
                GenderCode_DMG03 = GenderCodes.Female;
            } else {
                GenderCode_DMG03 = GenderCodes.Unknown;
            }

            MaritalStatusCode_DMG04 = MaritalTranslation(row.MaritalStatus);
            CoverageLevelCode_HD05 = CoverageTranslation(row.CoverageDetails);
            if(row.PlanEffectiveStartDate != null && row.PlanEffectiveStartDate != "") {
                DateTimePeriod_Start_DTP03 = DateTime.Parse(row.PlanEffectiveStartDate).ToString("yyyyMMdd");
            }

            if (row.PlanEffectiveEndDate != null && row.PlanEffectiveEndDate != "") {
                DateTimePeriod_Start_DTP03 = DateTime.Parse(row.PlanEffectiveEndDate).ToString("yyyyMMdd");
            }
        }

        public new string ToString() {
            StringBuilder sb = new StringBuilder();
            //INS
            sb.AppendLine(SegmentID_INS + '*' + SubscriberIndicator_INS01 + '*' + IndividualRelationshipCode_INS02 + '*' + MaintenanceTypeCode_INS03 + '*' +
                MaintenanceReasonCode_INS04 + '*' + BenefitStatusCode_INS05 + SegmentTerminator);
            //REFA
            sb.AppendLine(SegmentID_REF + '*' + ReferenceNumberQualifier_REF01 + '*' + ReferenceNumber_REF02 + SegmentTerminator);
            //REFB
            sb.AppendLine(SegmentID_REF + '*' + ReferenceNumberQualifierVSP_REF01 + '*' +  ReferenceNumberVSP_REF02 + SegmentTerminator);
            //NM1
            sb.AppendLine(SegmentID_NM1 + '*' +EntityIdentifierCode_NM101 + '*' + EntityTypeQualifier_NM102 + '*' + NameLast_NM103 + '*' 
                + NameFirst_NM104 + '*' + NameInitial_NM105 + '*' + IdentificationCodeQualifier_NM108 + '*' + IdentificationCode_NM109 + SegmentTerminator);
            //PER
            sb.AppendLine(SegmentID_PER + '*' + ContactFunctionCode_PER01 + '*' + ContactName_PER02 + '*' + CommunicationNumberQualifier_PER03 + '*' + 
                CommunicationNumber_PER04 + SegmentTerminator);
            //N3
            sb.AppendLine(SegmentID_N3 + '*' + ResidenceAddressLine1_N301 + '*' + ResidenceAddressLine2_N302 + SegmentTerminator);
            //N4
            sb.AppendLine(SegmentID_N4 + '*' + ResidenceCity_N401 + '*' + ResidenceState_N402 + '*' + ResidenceZip_N403 + SegmentTerminator);
            //DMG
            sb.AppendLine(SegmentID_DMG + '*' + DateTimeFormatQualifier_DMG01 + '*' + DatetimePeriod_DMG02 + '*' + GenderCode_DMG03 + SegmentTerminator);
            //HD
            sb.AppendLine(SegmentID_HD + '*' + MaintenanceTypeCode_HD01 + '*' + Blank_HD02 + '*' + InsuranceLineCode_HD03 + '*' + Blank_HD04 + '*' + 
                CoverageLevelCode_HD05 + SegmentTerminator);
            //DTP start
            sb.AppendLine(SegmentID_DTP + '*' + BenefitStartDate_DTP01 + '*' + DateTimeFormat_DTP02 + '*' + DateTimePeriod_Start_DTP03 + SegmentTerminator);
            //DTP end
            if(DateTimePeriod_End_DTP03 != null && DateTimePeriod_End_DTP03 !="") {
                sb.AppendLine(SegmentID_DTP + '*' + BenefitEndDate_DTP01 + '*' + DateTimeFormat_DTP02 + '*' + DateTimePeriod_End_DTP03 + SegmentTerminator);
            }

            return sb.ToString();
        }

        private string CoverageTranslation(string coverageIn) {
            if (coverageIn.Contains("Employee") && (coverageIn.Contains("Spouse") || coverageIn.Contains("partner")) && coverageIn.Contains("Child")) {
                return CoverageLevels.Family;
            } else if (coverageIn.Contains("Employee") && (coverageIn.Contains("Spouse") || coverageIn.Contains("partner"))) {
                return CoverageLevels.EmployeeSpouse;
            } else if (coverageIn.Contains("Employee") && coverageIn.Contains("Child")) {
                return CoverageLevels.EmployeeCHD;
            } else if (coverageIn.Contains("Employee")) {
                return CoverageLevels.Individual;
            } else return null;
        }

        private string RelationshipTranslation(string relIn) {
            switch (relIn) {
                case "0":
                    return "18";

                case "1":
                    if (relIn.Contains("Part")) {
                        return "53";
                    } else {
                        return "01";
                    }

                default:
                    return "19";
            }
        }

        private char MaritalTranslation(string statusIn) {
            switch (statusIn) {
                case "Married":
                    return MaritalStatusCodes.Married;

                case "Single":
                    return MaritalStatusCodes.Single;

                case "Divorced":
                    return MaritalStatusCodes.Divorced;

                case "Widowed":
                    return MaritalStatusCodes.Widowed;

                case "Domestic Partner":
                    return MaritalStatusCodes.RegisteredDomesticPartner;

                case "Legally Separated":
                    return MaritalStatusCodes.LegallySeparated;

                default:
                    return MaritalStatusCodes.Unreported;
            }
        }
    }
}
