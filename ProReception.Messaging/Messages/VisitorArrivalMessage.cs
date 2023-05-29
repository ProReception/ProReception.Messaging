namespace ProReception.Messaging.Messages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class VisitorArrivalMessage
    {
        public string HostName { get; set; }

        public string HostSkypeId { get; set; }

        public string HostLyncUri { get; set; }

        public string VisitorName { get; set; }

        public string VisitorFirstName => VisitorName.Split(' ')[0];

        public string VisitorLastName => string.Join(" ", VisitorName.Split(' ').Skip(1));

        public string VisitorCompany { get; set; }

        public string VisitorDivision { get; set; }

        public string VisitorTypeName { get; set; }

        public string CardNumber { get; set; }

        public DateTime CheckinTime { get; set; }

        public DateTime ExpectedCheckout { get; set; }

        public string ClientSiteLocale { get; set; }

        public string SkypeMessage { get; set; }

        public string LyncMessage { get; set; }

        public IList<VisitorArrivalAction> Actions { get; set; }

        public bool KeepImWindowsOpen { get; set; }

        public PrinterType PrinterType { get; set; }

        public bool EnablePrinterCutter { get; set; }

        public bool EnableMarkDetection { get; set; }

        public double CutLengthForPaper { get; set; }

        public string WifiSsid { get; set; }

        public string WifiUsername { get; set; }

        public string WifiPassword { get; set; }

        public string QrCodeUrl { get; set; }

        public int LabelVersion { get; set; }

        // Key = Label field name, Value = Label field value
        public IDictionary<string, string> CustomMessages { get; set; }

        public string VisitPeriod
        {
            get
            {
                if (CheckinTime.Year == ExpectedCheckout.Year)
                {
                    if (CheckinTime.Month == ExpectedCheckout.Month)
                    {
                        if (CheckinTime.Day == ExpectedCheckout.Day)
                        {
                            return $"{CheckinTime:d MMMM, yyyy}";
                        }
                        else
                        {
                            return $"{CheckinTime:%d} - {ExpectedCheckout:d MMMM, yyyy}";
                        }
                    }
                    else
                    {
                        return $"{CheckinTime:d MMMM} - {ExpectedCheckout:d MMMM, yyyy}";
                    }
                }
                else
                {
                    return $"{CheckinTime:d MMMM, yyyy} - {ExpectedCheckout:d MMMM, yyyy}";
                }
            }
        }
    }
}
