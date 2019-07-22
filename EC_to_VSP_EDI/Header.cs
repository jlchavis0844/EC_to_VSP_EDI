using System;

public class Header
{
    public const string SegementID = "ISA";
    public const string AuthorizationInfoQualifier = "00";
    public const string AuthorizationInfo = "          ";
    public const string SecurityInfoQualifier = "00";
    public const string SecurityInfo = "          ";
    public const string SenderIDQualifier = "30";
    public const string SenderID = "94-2239786     ";
    public const string ReceiverIDQualifier = "30";
    public const string ReceiverID = "94-1632821    ";
    public string InterchangeDate;
    public string InterchangeTime;
    public const char InterchangeControlID = '=';
    public const string InterchangeControlVersionNum = "00501";
    public string InterchangeControlNum;
    public const char AcknowledgementRequested = '0';
    public const char UsageIndicator = 'P';
    public const char ComponentElementSeparator = '>';
    public const char SegmentTerminator = '~';

    public Header(){
        InterchangeDate = InterchangeTracker.GetInterchangeDate();
        InterchangeTime = InterchangeTracker.GetInterchangeTime();
        InterchangeControlNum = InterchangeTracker.GetInterchangeNumber().ToString().PadLeft(9,'0');
	}

    public new string ToString() {
        return SegementID + '*' + AuthorizationInfoQualifier + '*' + AuthorizationInfo + '*' + SecurityInfoQualifier + '*' +
            SecurityInfo + '*' + SenderIDQualifier + '*' + SenderID + '*' + ReceiverIDQualifier + '*' + ReceiverID + '*' + InterchangeDate + '*' +
            InterchangeTime + '*' + InterchangeControlID + '*' + InterchangeControlVersionNum + '*' + InterchangeControlNum + '*' +
            AcknowledgementRequested + '*' + UsageIndicator + '*' + ComponentElementSeparator + SegmentTerminator;
    }
}
