using ProReception.Messaging.Messages.Nested;

namespace ProReception.Messaging.Messages
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class VisitorArrivalMessage
    {
        public int ClientLevelId { get; set; }

        public string HostName { get; set; }

        public string HostSkypeId { get; set; }

        public string VisitorName { get; set; }

        public string VisitorFirstName => VisitorName.Split(' ')[0];

        public string VisitorLastName => string.Join(" ", VisitorName.Split(' ').Skip(1));

        public string VisitorCompany { get; set; }

        public string VisitorDivision { get; set; }

        public int? VisitorDivisionId { get; set; }

        public string VisitorTypeName { get; set; }

        public string CardNumber { get; set; }

        public DateTime CheckinTime { get; set; }

        public DateTime ExpectedCheckout { get; set; }

        public string ClientSiteLocale { get; set; }

        public string SkypeMessage { get; set; }

        public IList<VisitorArrivalAction> Actions { get; set; }

        public bool KeepImWindowsOpen { get; set; }

        public PrinterType PrinterType { get; set; }

        public bool EnablePrinterCutter { get; set; }

        public bool EnableMarkDetection { get; set; }

        public double CutLengthForPaper { get; set; }

        public string WifiSsid { get; set; }

        public string WifiUsername { get; set; }

        public string WifiPassword { get; set; }

        public string QrCodePayload { get; set; }

        public int LabelVersion { get; set; }

        public string MeetingName { get; set; }

        public string PhotoUrl { get; set; }

        // Key = Label field name, Value = Label field value
        public IDictionary<string, string> CustomMessages { get; set; }

        public string ClientSiteAreas { get; set; }

        public string ComplianceText { get; set; }

        public string Custom_1 { get; set; }

        public string Custom_2 { get; set; }

        public string Custom_3 { get; set; }

        public string VisitPeriod
        {
            get
            {
                var cultureInfo = !string.IsNullOrEmpty(ClientSiteLocale)
                    ? new CultureInfo(ClientSiteLocale)
                    : CultureInfo.CurrentCulture;

                if (CheckinTime.Year == ExpectedCheckout.Year)
                {
                    if (CheckinTime.Month == ExpectedCheckout.Month)
                    {
                        if (CheckinTime.Day == ExpectedCheckout.Day)
                        {
                            return $"{CheckinTime.ToString("d MMMM, yyyy", cultureInfo)}";
                        }

                        return $"{CheckinTime.ToString("%d", cultureInfo)} - {ExpectedCheckout.ToString("d MMMM, yyyy", cultureInfo)}";
                    }

                    return $"{CheckinTime.ToString("d MMMM", cultureInfo)} - {ExpectedCheckout.ToString("d MMMM, yyyy", cultureInfo)}";
                }

                return $"{CheckinTime.ToString("d MMMM, yyyy", cultureInfo)} - {ExpectedCheckout.ToString("d MMMM, yyyy", cultureInfo)}";
            }
        }
    }
}
