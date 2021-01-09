namespace EC_to_BCBS_EDI {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public class EnrollmentEntry {
        public const char SegmentTerminator = '~';
        public readonly int SortOrder = 0;
        public bool SecondLine = false;
        public bool HasDental = false;
        public bool HasVision = false;

        // INS
        public const string SegmentID_INS = "INS";
        public char SubscriberIndicator_INS01;
        public string IndividualRelationshipCode_INS02;
        public const string MaintenanceTypeCode_INS03 = "030";
        public string MaintenanceReasonCode_INS04 = "XN"; //hard coded for full file
        public char BenefitStatusCode_INS05 = 'A';
        public readonly string MedicarePlanCode_INS06 = string.Empty;
        public readonly string Empty_INS07 = string.Empty;
        public readonly string EmploymentStatusCode_INS08 = string.Empty;//active or emps
        public readonly string Student_INS09 = string.Empty;
        public readonly string Disability_INS10;
        // public       char   HandicapIndicator_INS06;

        // REF
        public const string SegmentID_REF = "REF";
        public const string ReferenceNumberQualifier_REF01 = "0F"; // SSN
        public string ReferenceNumber_REF02;
        public const string ReferenceNumberQualifier2_REF01 = "1L";
        public string ReferenceNumber2_REF02;
        public string ReferenceNumberQualifier3_REF01;
        public string ReferenceNumber3_REF02;
        public const string ReferenceNumberQualifierBCBS_REF01 = ""; // BCBS Plan Value
        public string ReferenceNumberBCBS_REF02;

        public static List<string> DivList0001 = new List<string> { "CLASS-MGMT" };

        // NM1
        public const string SegmentID_NM1 = "NM1";
        public const string EntityIdentifierCode_NM101 = "IL";
        public const char EntityTypeQualifier_NM102 = '1';
        public string NameLast_NM103;
        public string NameFirst_NM104;
        public string NameInitial_NM105;
        public string NamePrefix_NM106 = string.Empty;
        public string NameSuffix_NM107 = string.Empty;
        public const string IdentificationCodeQualifier_NM108 = "34";
        public string IdentificationCode_NM109;// SSN

        // PER
        public const string SegmentID_PER = "PER";
        public const string ContactFunctionCode_PER01 = "IP";
        public const string ContactName_PER02 = "";
        public string CommunicationNumberQualifier_PER03;
        public string CommunicationNumber_PER04;
        public const string CommunicationNumberQualifier_PER05 = "EM";
        public string CommunicationNumber_PER06;

        // public const string CommunicationNumberQualifier_PER06 = "EM";
        // public string CommunicationNumber_PER08;

        // N3
        public const string SegmentID_N3 = "N3";
        public string ResidenceAddressLine1_N301;
        public string ResidenceAddressLine2_N302;

        // N4
        public const string SegmentID_N4 = "N4";
        public string ResidenceCity_N401;
        public string ResidenceState_N402;
        public string ResidenceZip_N403;

        // public string      CountryCode_N404;

        // DMG
        public const string SegmentID_DMG = "DMG";
        public const string DateTimeFormatQualifier_DMG01 = "D8";
        public string DatetimePeriod_DMG02;
        public string SexCode_DMG03;
        public char MaritalStatusCode_DMG04;
        public char RaceCode_DMG05;
        public char CitizenshipStatusCode__DMG06;

        // HD
        public const string SegmentID_HD = "HD";
        public readonly string MaintenanceTypeCode_HD01 = "030";
        public const string Blank_HD02 = "";
        public string InsuranceLineCode_HD03 = "HLT";
        public const string Blank_HD04 = "";
        public string CoverageLevelCode_HD05;

        // DTP
        public const string SegmentID_DTP = "DTP";
        public const string BenefitStartDate_DTP01 = "348";
        public const string HireDate_DTP01 = "336";

        // TODO: Implement coverage end logic
        public const string BenefitEndDate_DTP01 = "349";
        public const string CoverageLevelChange_DTP01 = "303";
        public const string DateTimeFormat_DTP02 = "D8";
        public string DateTimePeriod_Start_DTP03;
        public string DateTimePeriod_End_DTP03;
        public string DateTimePeriod_FamChange;
        public string DateTimePeriod_Hire_DTP03;

        private CensusRow MyRow;

        // Constructor
        public EnrollmentEntry(CensusRow row) {
            MyRow = row;
            if (row.RelationshipCode == "0") {
                this.SubscriberIndicator_INS01 = 'Y';
                EmploymentStatusCode_INS08 = "AC";
                SortOrder = 0;
            } else {
                this.SubscriberIndicator_INS01 = 'N';
                SortOrder = 1;
                if(row.Disabled == "Yes"){
                    Disability_INS10 = "Y";
                } else {
                    Disability_INS10 = "N";
                }
            }

            //if (Form1.INPUTFILE.Contains("Vis")) {
            // InsuranceLineCode_HD03 = "VIS";
            //} else InsuranceLineCode_HD03 = "DEN";

            //if(row.PlanType.Contains("Vis")){
            //    InsuranceLineCode_HD03 = "VIS";
            //    ReferenceNumber2_REF02 = "78910060AL6V0089002";
            //} else {
            //    InsuranceLineCode_HD03 = "DEN";
            //    ReferenceNumber2_REF02 = "78910003AL3V0181001";
            //}

            if (row.LastName == "Baugh")
                Console.WriteLine("Baugh");

            if (row.PlanAdminName.Contains("MVP")) {
                ReferenceNumber2_REF02 = "30642002";
            } else {
                ReferenceNumber2_REF02 = "30642000";
            }

            if (row.Dental == "TRUE") {
                this.HasDental = true;
            }

            if(row.Vision == "TRUE") {
                this.HasVision = true;
            }

            this.IndividualRelationshipCode_INS02 = this.RelationshipTranslation(row.RelationshipCode);
            this.BenefitStatusCode_INS05 = 'A';

            var memberSSN = (from record in Form1.Records
                             where record.EID == row.EID && record.RelationshipCode == "0"
                             select record.SSN).First().ToString().Replace("-", string.Empty);

            if (memberSSN != null && memberSSN != string.Empty) {
                // ReferenceNumber_REF02 = row.SSN.Replace("-", "");
                this.ReferenceNumber_REF02 = memberSSN;
            } else {
                // ReferenceNumber_REF02 = "         ";
                Form1.Log.Error("ERR: " + (++Form1.ErrorCounter) + "\tMissing SSN for the following:\n" + row.ToString());
            }

            //string memberDiv = (from record in Form1.Records
            //                    where record.EID == row.EID && record.RelationshipCode == "0"
            //                    select record.JobClass).First().ToString();

            //if (DivList0001.Contains(memberDiv)) {
            //    this.ReferenceNumberBCBS_REF02 = "0001";
            //    Form1.Log.Info(row.FirstName + " " + row.LastName + "\t" + memberDiv + "\t" + row.JobClass);
            //} else {
            //    this.ReferenceNumberBCBS_REF02 = "0002";
            //    Form1.Log.Info(row.FirstName + " " + row.LastName + "\t" + memberDiv + "\t" + row.JobClass);
            //}
            ReferenceNumberBCBS_REF02 = row.JobClass;

            this.NameLast_NM103 = row.LastName;
            this.NameFirst_NM104 = row.FirstName;

            if (row.MiddleName.Length > 0) {
                this.NameInitial_NM105 = row.MiddleName.Substring(0,1);
            } else {
                this.NameInitial_NM105 = string.Empty;
            }

            this.IdentificationCode_NM109 = row.SSN.Replace("-", string.Empty);
            this.CommunicationNumberQualifier_PER03 = "HP";

            if (row.PersonalPhone != null && row.PersonalPhone != string.Empty) {
                this.CommunicationNumber_PER04 = Regex.Replace(row.PersonalPhone, "[^0-9]", string.Empty);
            }

            this.CommunicationNumber_PER06 = row.Email;
            this.ResidenceAddressLine1_N301 = row.Address1;
            this.ResidenceAddressLine2_N302 = row.Address2;
            this.ResidenceCity_N401 = row.City;
            this.ResidenceState_N402 = this.GetStateByName(row.State);
            this.ResidenceZip_N403 = row.Zip.Substring(0, 5);

            if (row.BirthDate != null && row.BirthDate != string.Empty) {
                this.DatetimePeriod_DMG02 = DateTime.Parse(row.BirthDate).ToString("yyyyMMdd");
            }

            if (row.Sex == "Male") {
                this.SexCode_DMG03 = SexCodes.Male;
            } else if (row.Sex == "Female") {
                this.SexCode_DMG03 = SexCodes.Female;
            } else {
                this.SexCode_DMG03 = SexCodes.Unknown;
            }

            this.MaritalStatusCode_DMG04 = this.MaritalTranslation(row.MaritalStatus);
            this.CoverageLevelCode_HD05 = this.CoverageTranslation(row.CoverageDetails);

            if (row.EffectiveDate != null && row.EffectiveDate != string.Empty) {
                this.DateTimePeriod_Start_DTP03 = DateTime.Parse(row.EffectiveDate).ToString("yyyyMMdd");
            }

            if(SubscriberIndicator_INS01 == 'Y') {
                DateTimePeriod_Hire_DTP03 = DateTime.Parse(row.HireDate).ToString("yyyyMMdd");
            }

            if (row.ElectionStatus.ToUpper() == "ADD") {
                MaintenanceTypeCode_HD01 = "021";
            } else if(row.ElectionStatus.ToUpper() == "DROP") {
                MaintenanceTypeCode_HD01 = "024";
            } else if (row.ElectionStatus.ToUpper() == "UPDATE") {
                MaintenanceTypeCode_HD01 = "030";
            }

            if(MaintenanceTypeCode_HD01 == "024") {
                this.DateTimePeriod_Start_DTP03 = DateTime.Parse(row.EffectiveDate).AddDays(-1).ToString("yyyyMMdd");
            }

        }

        public new string ToString() {
            StringBuilder sb = new StringBuilder();

            // INS
            sb.AppendLine(SegmentID_INS + '*' + this.SubscriberIndicator_INS01 + '*' + this.IndividualRelationshipCode_INS02 + '*' + MaintenanceTypeCode_INS03 + '*' +
                this.MaintenanceReasonCode_INS04 + '*' + this.BenefitStatusCode_INS05 + '*' + MedicarePlanCode_INS06 + '*' + Empty_INS07 + '*' +
                EmploymentStatusCode_INS08+ '*' + Student_INS09 + '*' + Disability_INS10 + SegmentTerminator);

            // REFA
            sb.AppendLine(SegmentID_REF + '*' + ReferenceNumberQualifier_REF01 + '*' + this.ReferenceNumber_REF02 + SegmentTerminator);

            //2000 DTP - Hire Date
            if(this.DateTimePeriod_Hire_DTP03 != null) {
                sb.AppendLine(SegmentID_DTP + '*' + HireDate_DTP01 + '*' + DateTimeFormat_DTP02 + '*' + this.DateTimePeriod_Hire_DTP03 + SegmentTerminator);
            }

            // NM1
            if (IdentificationCode_NM109 != null && IdentificationCode_NM109 != string.Empty) {
                sb.AppendLine(SegmentID_NM1 + '*' + EntityIdentifierCode_NM101 + '*' + EntityTypeQualifier_NM102 + '*' + this.NameLast_NM103 + '*'
                    + this.NameFirst_NM104 + '*' + this.NameInitial_NM105 + '*' + this.NamePrefix_NM106 + '*' + this.NameSuffix_NM107 + '*' + IdentificationCodeQualifier_NM108 +
                    '*' + this.IdentificationCode_NM109 + SegmentTerminator);
            } else {
                sb.AppendLine(SegmentID_NM1 + '*' + EntityIdentifierCode_NM101 + '*' + EntityTypeQualifier_NM102 + '*' + this.NameLast_NM103 + '*'
                    + this.NameFirst_NM104 + '*' + this.NameInitial_NM105 + SegmentTerminator);
            }

            if (this.SubscriberIndicator_INS01 == 'Y') {
                // PER
                if (CommunicationNumber_PER04 != "" && CommunicationNumber_PER04 != null) {
                    sb.AppendLine(SegmentID_PER + '*' + ContactFunctionCode_PER01 + '*' + ContactName_PER02 + '*' + this.CommunicationNumberQualifier_PER03 + '*' +
                        this.CommunicationNumber_PER04 + SegmentTerminator);
                }

                // N3
                sb.AppendLine(SegmentID_N3 + '*' + this.ResidenceAddressLine1_N301 + '*' + this.ResidenceAddressLine2_N302 + SegmentTerminator);

                // N4
                sb.AppendLine(SegmentID_N4 + '*' + this.ResidenceCity_N401 + '*' + this.ResidenceState_N402 + '*' + this.ResidenceZip_N403 + SegmentTerminator);
            }

            // DMG
            sb.AppendLine(SegmentID_DMG + '*' + DateTimeFormatQualifier_DMG01 + '*' + this.DatetimePeriod_DMG02 + '*' + this.SexCode_DMG03 + '*' + MaritalStatusCode_DMG04 + SegmentTerminator);
            
            if (this.SubscriberIndicator_INS01 == 'Y') {
                sb.AppendLine(SegmentID_HD + '*' + MaintenanceTypeCode_HD01 + '*' + Blank_HD02 + '*' + InsuranceLineCode_HD03 +
                    '*' + Blank_HD04 + '*' + this.CoverageLevelCode_HD05 + SegmentTerminator);
            } else {
                sb.AppendLine(SegmentID_HD + '*' + MaintenanceTypeCode_HD01 + '*' + Blank_HD02 + '*' + InsuranceLineCode_HD03 + SegmentTerminator);
            }
            
            //start or end date
            if (this.MaintenanceTypeCode_HD01 != "024") {
                sb.AppendLine(SegmentID_DTP + '*' + BenefitStartDate_DTP01 + '*' + DateTimeFormat_DTP02 + '*' + this.DateTimePeriod_Start_DTP03 + SegmentTerminator);
            } else {
                sb.AppendLine(SegmentID_DTP + '*' + BenefitStartDate_DTP01 + '*' + DateTimeFormat_DTP02 + '*' + DateTime.Parse(this.MyRow.PlanEffectiveStartDate).ToString("yyyyMMdd") + SegmentTerminator);
                sb.AppendLine(SegmentID_DTP + '*' + BenefitEndDate_DTP01 + '*' + DateTimeFormat_DTP02 + '*' + this.DateTimePeriod_Start_DTP03 + SegmentTerminator);
            }
            
            sb.AppendLine(SegmentID_REF + '*' + ReferenceNumberQualifier2_REF01 + '*' + ReferenceNumber2_REF02 + SegmentTerminator);

            return sb.ToString();
        }

        private string CoverageTranslation(string coverageIn) {
            if (coverageIn.Contains("Employee") && (coverageIn.Contains("Spouse") || coverageIn.Contains("partner")) && coverageIn.Contains("Child")) {
                return CoverageLevels.Family;
            } else if (coverageIn.Contains("Employee") && (coverageIn.Contains("Spouse") || coverageIn.Contains("partner"))) {
                return CoverageLevels.EmployeeSpouse;
            } else if (coverageIn.Contains("Employee") && coverageIn.Contains("1 Child")) {
                return CoverageLevels.EmployeeChild;
            } else if (coverageIn.Contains("Employee") && coverageIn.Contains("Child")) {
                return CoverageLevels.Family;
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

        public string GetStateByName(string name) {
            switch (name.ToUpper()) {
                case "ALABAMA":
                    return "AL";

                case "ALASKA":
                    return "AK";

                case "AMERICAN SAMOA":
                    return "AS";

                case "ARIZONA":
                    return "AZ";

                case "ARKANSAS":
                    return "AR";

                case "CALIFORNIA":
                    return "CA";

                case "COLORADO":
                    return "CO";

                case "CONNECTICUT":
                    return "CT";

                case "DELAWARE":
                    return "DE";

                case "DISTRICT OF COLUMBIA":
                    return "DC";

                case "FEDERATED STATES OF MICRONESIA":
                    return "FM";

                case "FLORIDA":
                    return "FL";

                case "GEORGIA":
                    return "GA";

                case "GUAM":
                    return "GU";

                case "HAWAII":
                    return "HI";

                case "IDAHO":
                    return "ID";

                case "ILLINOIS":
                    return "IL";

                case "INDIANA":
                    return "IN";

                case "IOWA":
                    return "IA";

                case "KANSAS":
                    return "KS";

                case "KENTUCKY":
                    return "KY";

                case "LOUISIANA":
                    return "LA";

                case "MAINE":
                    return "ME";

                case "MARSHALL ISLANDS":
                    return "MH";

                case "MARYLAND":
                    return "MD";

                case "MASSACHUSETTS":
                    return "MA";

                case "MICHIGAN":
                    return "MI";

                case "MINNESOTA":
                    return "MN";

                case "MISSISSIPPI":
                    return "MS";

                case "MISSOURI":
                    return "MO";

                case "MONTANA":
                    return "MT";

                case "NEBRASKA":
                    return "NE";

                case "NEVADA":
                    return "NV";

                case "NEW HAMPSHIRE":
                    return "NH";

                case "NEW JERSEY":
                    return "NJ";

                case "NEW MEXICO":
                    return "NM";

                case "NEW YORK":
                    return "NY";

                case "NORTH CAROLINA":
                    return "NC";

                case "NORTH DAKOTA":
                    return "ND";

                case "NORTHERN MARIANA ISLANDS":
                    return "MP";

                case "OHIO":
                    return "OH";

                case "OKLAHOMA":
                    return "OK";

                case "OREGON":
                    return "OR";

                case "PALAU":
                    return "PW";

                case "PENNSYLVANIA":
                    return "PA";

                case "PUERTO RICO":
                    return "PR";

                case "RHODE ISLAND":
                    return "RI";

                case "SOUTH CAROLINA":
                    return "SC";

                case "SOUTH DAKOTA":
                    return "SD";

                case "TENNESSEE":
                    return "TN";

                case "TEXAS":
                    return "TX";

                case "UTAH":
                    return "UT";

                case "VERMONT":
                    return "VT";

                case "VIRGIN ISLANDS":
                    return "VI";

                case "VIRGINIA":
                    return "VA";

                case "WASHINGTON":
                    return "WA";

                case "WEST VIRGINIA":
                    return "WV";

                case "WISCONSIN":
                    return "WI";

                case "WYOMING":
                    return "WY";
            }

            throw new Exception("Not Available");
        }
    }
}
