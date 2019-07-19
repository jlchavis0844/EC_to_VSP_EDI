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
    public const string ReceiverID = "94-1632821     ";
    public static string InterchangeDate;
    public static string InterchangeTime;
    public const char InterchangeControlID = '=';
    public const string InterchangeControlVersionNum = "00501";
    public static string InterchangeControlNum;
    public const char AcknowledgementRequested = '0';
    public const char UsageIndicator = 'P';
    public const char ComponentElementSeparator = '>';
    public const char SegmentTerminator = '~';

    public Header(){

	}
}
