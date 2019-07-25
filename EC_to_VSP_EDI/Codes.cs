
namespace EC_to_VSP_EDI {
    public static class RelationshipCodes {
        public static string Spouse = "01";
        public static string Self = "18";
        public static string Child = "19";
        public static string LifePartner = "53";
    }

    public static class MaintenanceType {
        public static string Change = "001";
        public static string Add = "021";
        public static string Termination = "024";
        public static string FullReplaceFile = "030";
    }

    public static class MaintenanceReason {
        public static string Death = "03";
        public static string Retirement = "04";
        public static string Termination = "08";
        public static string NonPayment = "59";
    }

    public static class BenefitStatus {
        public static char Active = 'A';
        public static char Cobra = 'C';
        public static char SurvivingInsured = 'S';
    }

    public static class GenderCodes {
        public static char Male = 'M';
        public static char Female = 'F';
        public static char Unknown = 'U';
    }

    public static class MaritalStatusCodes {
        public static char RegisteredDomesticPartner = 'B';
        public static char Divorced = 'D';
        public static char Single = 'I';
        public static char Married = 'M';
        public static char Unreported = 'R';
        public static char Separated = 'S';
        public static char Unmarried = 'U';
        public static char Widowed = 'W';
        public static char LegallySeparated = 'X';
    }

    public static class RaceCodes {
        public static char NotProvided = '7';
        public static char NotApplicable = '8';
        public static char AsianorPacificIslander = 'A';
        public static char Black = 'B';
        public static char Caucasian = 'C';
        public static char SubcontinentAsianAmerican = 'D';
        public static char OtherRaceorEthnicity = 'E';
        public static char AsianPacificAmerican = 'F';
        public static char NativeAmerican = 'G';
        public static char Hispanic = 'H';
        public static char AmericanIndianorAlaskanNative = 'I';
        public static char NativeHawaiian = 'J';
        public static char BlackNonHispanic = 'N';
        public static char WhiteNonHispanic = 'O';
        public static char PacificIslander = 'P';
        public static char MutuallyDefined = 'Z';

    }

    public static class CitizenshipCodes {
        public static char USCitizen = '1';
        public static char NonResidentAlien = '2';
        public static char ResidentAlien = '3';
        public static char IllegalAlien = '4';
        public static char Alien = '5';
        public static char USCitizenNonResident = '6';
        public static char USCitizenResident = '7';
    }

    public static class CoverageLevels {
        public static string Individual = "IND";
        public static string Family = "FAM";
        public static string EmployeeSpouse = "ESP";
        public static string EmployeePartner = "E1D";
        public static string EmployeeCHD = "ECH";
    }

    public static class TransactionSetPurposes {
        public static string Original = "00";
        public static string ReSubmission = "15";
        public static string InformationCopy = "22";
    }
}
