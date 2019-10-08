namespace EC_to_VSP_EDI {
    using System;
    using System.Text;

    public class SubHeader {
        private const string SegmentIDGS = "GS";
        private const string FunctionalIDCode = "BE";
        private const string SenderID = "94-2239786";
        private const string ReceiverID = "94-1632821";
        private readonly string gSDate;
        private readonly string gSTime;
        private readonly uint groupControlNumber;
        private const char ResponsibleAgencyCode = 'X';
        private const string VersionReleaseCode = "005010X220A1";
        private const string SegmentIDST = "ST";
        private const string TransactionIDCode = "834";
        private readonly string transactionSetControlNumber;
        private const string ImplementationConventionReference = "005010X220A1";
        private const string SegmentIDBGN = "BGN";
        private readonly string transactionSetPurpose;

        // private const string ReferenceNumber = "";
        private readonly string bGNDate;
        private readonly string bGNTime;
        private const string BGN05 = "";
        private const string BGN06 = "";
        private const string BGN07 = "";

        // private string ReferenceIdentification;
        private const char ActionCode = '4';
        private const string SegmentIDRef = "REF";
        private const string RefReferenceNumberQualifier = "38";
        private const string RefReferenceNumber = "8005054";
        private const string N1SegmentID = "N1";
        private const string EntityIdentCodeSponser = "P5";

        // private const string PlanSponser = "Sponser Name";
        private const string N1IdentificationCodeQualifier = "FI";
        private const string N1BEntityIdentifierCode = "IN";
        private const string N1BName = "Vision Service Plan";

        // private const string N1BIdentificationCode = "94-1632821";
        private const string N1CEntityIdentifierCode = "TV";
        private const string N1CName = "TDS Group";

        // private const string N1BIdentificationCodeQualifier = "FI";
        // private const string N1CIdentificationCode = "30-0369656";
        private const string SegmentTerminator = "~";

        public SubHeader(string type) {
            this.gSDate = DateTime.Now.ToString("yyyyMMdd");
            this.gSTime = DateTime.Now.ToString("hhmm");
            this.groupControlNumber = InterchangeTracker.GetInterchangeNumber();
            this.transactionSetControlNumber = InterchangeTracker.GetInterchangeNumber().ToString().PadLeft(4, '0');
            this.transactionSetPurpose = type;

            this.bGNDate = this.gSDate;
            this.bGNTime = this.gSTime;
        }

        public new string ToString() {
            StringBuilder tempSB = new StringBuilder();
            tempSB.AppendLine(SegmentIDGS + '*' + FunctionalIDCode + '*' + SenderID + '*' + ReceiverID + '*' + this.gSDate + '*' + this.gSTime + '*' +
                this.groupControlNumber + '*' + ResponsibleAgencyCode + '*' + VersionReleaseCode + SegmentTerminator);

            tempSB.AppendLine(SegmentIDST + '*' + TransactionIDCode + '*' + this.transactionSetControlNumber + '*' +
                ImplementationConventionReference + SegmentTerminator);

            // tempSB.AppendLine(SegmentIDBGN + '*' + TransactionSetPurpose + '*' + ReferenceNumber + '*' + BGNDate + '*' + BGNTime + '*' +
            //    ((TransactionSetPurpose != TransactionSetPurposes.Original) ? "****" : ("*" + TransactionSetPurpose + "*")) +
            //    ActionCode + SegmentTerminator);
            tempSB.AppendLine(SegmentIDBGN + '*' + this.transactionSetPurpose + '*' + this.transactionSetControlNumber + '*' + this.bGNDate + '*' + this.bGNTime + '*' +
                BGN05 + '*' + BGN06 + '*' + BGN07 + '*' + ActionCode + SegmentTerminator);

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
