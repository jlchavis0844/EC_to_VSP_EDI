using System;
using System.Text;

namespace EC_to_VSP_EDI {
    public class SubHeader {
        private const string SegmentIDGS = "GS";
        private const string FunctionalIDCode = "BE";
        private const string SenderID = "94-2239786";
        private const string ReceiverID = "94-1632821";
        private string GSDate;
        private string GSTime;
        private uint GroupControlNumber;
        private const char ResponsibleAgencyCode = 'X';
        private const string VersionReleaseCode = "005010X220A1";
        private const string SegmentIDST = "ST";
        private const string TransactionIDCode = "834";
        private string TransactionSetControlNumber;
        private const string ImplementationConventionReference = "005010X220A1";
        private const string SegmentIDBGN = "BGN";
        private string TransactionSetPurpose;
        private const string ReferenceNumber = "";
        private string BGNDate;
        private string BGNTime;
        private string ReferenceIdentification;
        private const char ActionCode = '4';
        private const string SegmentIDRef = "REF";
        private const string RefReferenceNumberQualifier = "38";
        private const string RefReferenceNumber = "8005054";
        private const string N1SegmentID = "N1";
        private const string EntityIdentCodeSponser = "P5";
        private const string PlanSponser = "Sponser Name";
        private const string N1IdentificationCodeQualifier = "FI";
        private const string N1BEntityIdentifierCode = "IN";
        private const string N1BName = "Vision Service Plan";
        private const string N1BIdentificationCode = "94-1632821";
        private const string N1CEntityIdentifierCode = "TV";
        private const string N1CName = "TDS Group";
        private const string N1BIdentificationCodeQualifier = "FI";
        private const string N1CIdentificationCode = "30-0369656";
        private const string SegmentTerminator = "~";

        public SubHeader(string type) {
            GSDate = DateTime.Now.ToString("yyyyMMdd");
            GSTime = DateTime.Now.ToString("hhmm");
            GroupControlNumber = InterchangeTracker.GetInterchangeNumber();
            TransactionSetControlNumber = InterchangeTracker.GetInterchangeNumber().ToString().PadLeft(4,'0');
            TransactionSetPurpose = type;

            BGNDate = GSDate;
            BGNTime = GSTime;
        }

        public new string ToString() {
            StringBuilder tempSB = new StringBuilder();
            tempSB.AppendLine(SegmentIDGS + '*' + FunctionalIDCode + '*' + SenderID + '*' + ReceiverID + '*' + GSDate + '*' + GSTime + '*' +
                GroupControlNumber + '*' + ResponsibleAgencyCode + '*' + VersionReleaseCode + SegmentTerminator);

            tempSB.AppendLine(SegmentIDST + '*' + TransactionIDCode + '*' + TransactionSetControlNumber + '*' +
                ImplementationConventionReference + SegmentTerminator);

            tempSB.AppendLine(SegmentIDBGN + '*' + TransactionSetPurpose + '*' + ReferenceNumber + '*' + BGNDate + '*' + BGNTime + '*' +
                ((TransactionSetPurpose != TransactionSetPurposes.Original) ? "****" : ("*" + TransactionSetPurpose + "*")) +
                ActionCode + SegmentTerminator);

            tempSB.AppendLine(SegmentIDRef + '*' + RefReferenceNumberQualifier + '*' + RefReferenceNumber + SegmentTerminator);

            tempSB.AppendLine(N1SegmentID + '*' + EntityIdentCodeSponser + '*' + N1CName + '*' + 
                N1IdentificationCodeQualifier + '*' + SenderID + SegmentTerminator);

            tempSB.AppendLine(N1SegmentID + '*' + N1BEntityIdentifierCode + '*' + N1BName + '*' + 
                N1IdentificationCodeQualifier + '*' + ReceiverID + SegmentTerminator);

            tempSB.AppendLine(N1SegmentID + '*' + N1CEntityIdentifierCode + '*' + N1CName + '*' + N1IdentificationCodeQualifier + '*' + 
                SenderID + SegmentTerminator);
            return tempSB.ToString();
        }
    }
}
