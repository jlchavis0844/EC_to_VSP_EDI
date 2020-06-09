using EC_to_BCBS_EDI;

public class Header {
    private const string SegmentID = "ISA";
    private const string AuthorizationInfoQualifier = "00";
    private readonly string authorizationInfo = string.Empty.PadLeft(10);
    private const string SecurityInfoQualifier = "00";
    private readonly string securityInfo = string.Empty.PadLeft(10);
    private const string SenderIDQualifier = "30";
    private readonly string senderID = "82-3606235".PadRight(15);// 15 fixed width
    private const string ReceiverIDQualifier = "30";
    private readonly string receiverID = "630103830".PadRight(15);
    private readonly string interchangeDate;
    private readonly string interchangeTime;
    private const char InterchangeControlID = '^';
    private const string InterchangeControlVersionNum = "00501";
    private readonly string interchangeControlNum;
    private const char AcknowledgementRequested = '0';
    private readonly char usageIndicator;
    private const char ComponentElementSeparator = ':';
    private const char SegmentTerminator = '~';

    public Header(char usage) {
        this.interchangeDate = InterchangeTracker.GetInterchangeDate();
        this.interchangeTime = InterchangeTracker.GetInterchangeTime();
        this.interchangeControlNum = InterchangeTracker.GetInterchangeNumber().ToString().PadLeft(9, '0');

        //if (Form1.cbType.SelectedIndex == 0) {
        //    this.usageIndicator = 'T';
        //} else {
        //    this.usageIndicator = 'P';
        //}
        this.usageIndicator = usage;
    }

    public new string ToString() {
        return SegmentID + '*' + AuthorizationInfoQualifier + '*' + this.authorizationInfo + '*' + SecurityInfoQualifier + '*' +
            this.securityInfo + '*' + SenderIDQualifier + '*' + this.senderID + '*' + ReceiverIDQualifier + '*' + this.receiverID + '*' + this.interchangeDate + '*' +
            this.interchangeTime + '*' + InterchangeControlID + '*' + InterchangeControlVersionNum + '*' + this.interchangeControlNum + '*' +
            AcknowledgementRequested + '*' + this.usageIndicator + '*' + ComponentElementSeparator + SegmentTerminator;
    }
}
